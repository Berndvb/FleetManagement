using FleetManagement.Framework.Constants;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManager.UnitTest.Http
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsync<TRequest>(this System.Net.Http.HttpClient client,
            string requestUri, TRequest item, CancellationToken cancellationToken = default)
        {
            var body = GetHttpContent(item);
            return client.ExecuteRequestAsync<TRequest>(requestUri, HttpMethod.Post, body, cancellationToken);
        }

        public static Task<HttpResponseMessage> PutAsync<TRequest>(this System.Net.Http.HttpClient client,
            string requestUri, TRequest item, CancellationToken cancellationToken = default)
        {
            var body = GetHttpContent(item);
            return client.ExecuteRequestAsync<TRequest>(requestUri, HttpMethod.Put, body, cancellationToken);
        }

        public static Task<HttpResponseWrapper<TResponse, TResponse>> GetAsync<TResponse>(this HttpClient client,
            string requestUri, CancellationToken cancellationToken = default)
        {
            return client.ExecuteRequestAsync<TResponse, TResponse>(requestUri, HttpMethod.Get, cancellationToken);
        }

        private static async Task<HttpResponseMessage> ExecuteRequestAsync<TRequest>(
            this System.Net.Http.HttpClient client,
            string uri,
            HttpMethod httpMethod,
            HttpContent body,
            CancellationToken cancellationToken)
        {
            using (var request = new HttpRequestMessage(httpMethod, uri) { Content = body })
            {
                var response = await client.SendAsync(request, cancellationToken);
                return response;
            }
        }

        private static async Task<HttpResponseWrapper<TResponse, TError>> ExecuteRequestAsync<TResponse, TError>(
            this System.Net.Http.HttpClient client,
            string uri,
            HttpMethod httpMethod,
            CancellationToken cancellationToken)
        {
            using (var request = new HttpRequestMessage(httpMethod, uri))
            {
                using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead,
                    cancellationToken))
                {
                    var stream = await response.Content.ReadAsStreamAsync();

                    var parsedResult = default(TResponse);
                    var parsedError = default(TError);

                    if (response.IsSuccessStatusCode)
                    {
                        parsedResult = DeserializeJsonFromStream<TResponse>(stream);
                    }
                    else
                    {
                        parsedError = DeserializeJsonFromStream<TError>(stream, false);
                    }

                    return new HttpResponseWrapper<TResponse, TError>(response, parsedResult, parsedError);
                }
            }
        }


        private static T DeserializeJsonFromStream<T>(Stream stream, bool throwOnError = true)
        {
            if (stream == null || stream.CanRead == false)
                return default;

            try
            {
                using (var sr = new StreamReader(stream))
                {
                    using (var jtr = new JsonTextReader(sr))
                    {
                        var js = JsonSerializer.Create(JsonConfig.GetJsonSettings());
                        var searchResult = js.Deserialize<T>(jtr);
                        return searchResult;
                    }
                }
            }
            catch (Exception e)
            {
                if (!throwOnError)
                {
                    return default;
                }
                throw;
            }
        }

        private static HttpContent GetHttpContent<T>(T item)
        {
            HttpContent content = new StringContent(
                JsonConvert.SerializeObject(item, JsonConfig.GetJsonSettings()), Encoding.UTF8,
                MediaTypeNames.Application.Json);
            return content;
        }


    }

    public class HttpResponseWrapper<T, Y>
    {
        public HttpResponseMessage ResponseMessage { get; }
        public T ParsedResponse { get; }
        public Y ErrorResponse { get; }

        public HttpResponseWrapper(HttpResponseMessage responseMessage, T parsedResponse, Y errorResponse)
        {
            ResponseMessage = responseMessage;
            ParsedResponse = parsedResponse;
            ErrorResponse = errorResponse;
        }
    }

    public static class JsonConfig
    {
        public static void ConfigureJsonSerialization(MvcNewtonsoftJsonOptions e)
        {
            var jsonSettings = GetJsonSettings();

            e.SerializerSettings.ContractResolver = jsonSettings.ContractResolver;
            e.SerializerSettings.ReferenceLoopHandling = jsonSettings.ReferenceLoopHandling;
            e.SerializerSettings.NullValueHandling = jsonSettings.NullValueHandling;
            e.SerializerSettings.Culture = jsonSettings.Culture;
            e.SerializerSettings.Converters.Add(new StringEnumConverter());
            e.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
        }

        public static JsonSerializerSettings GetJsonSettings()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Culture = new CultureInfo(Constants.Json.DefaultCulture)
            };
            settings.Converters.Add(new StringEnumConverter());
            settings.Converters.Add(new IsoDateTimeConverter());
            return settings;
        }
    }
}
