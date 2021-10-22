using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FleetManager.UnitTest.Integration.Setup
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseWrapper<TResponse, TResponse>> PostAsync<TResponse>(this System.Net.Http.HttpClient client,
            string requestUri, Dictionary<string, string> data, CancellationToken cancellationToken = default)
        {
            var body = new FormUrlEncodedContent(data);
            return client.ExecuteRequestAsync<TResponse, TResponse, TResponse>(requestUri, HttpMethod.Post, body, cancellationToken);
        }

        public static Task<HttpResponseWrapper<TResponse, TResponse>> PostAsync<TResponse>(this System.Net.Http.HttpClient client,
            string requestUri, HttpContent body, CancellationToken cancellationToken = default)
        {
            return client.ExecuteRequestAsync<TResponse, TResponse, TResponse>(requestUri, HttpMethod.Post, body,
                cancellationToken);
        }

        public static Task<HttpResponseMessage> PostAsync<TRequest>(this System.Net.Http.HttpClient client,
            string requestUri, TRequest item, CancellationToken cancellationToken = default)
        {
            var body = GetHttpContent(item);
            return client.ExecuteRequestAsync<TRequest>(requestUri, HttpMethod.Post, body, cancellationToken);
        }

        public static Task<HttpResponseWrapper<TResponse, TResponse>> PostAsync<TRequest, TResponse>(
            this System.Net.Http.HttpClient client,
            string requestUri, TRequest item,
            CancellationToken cancellationToken = default)
        {
            var body = GetHttpContent(item);
            return client.ExecuteRequestAsync<TRequest, TResponse, TResponse>(requestUri, HttpMethod.Post, body,
                cancellationToken);
        }

        public static Task<HttpResponseWrapper<TResponse, TError>> PostAsync<TRequest, TResponse, TError>(
            this System.Net.Http.HttpClient client,
            string requestUri, TRequest item,
            CancellationToken cancellationToken = default)
        {
            var body = GetHttpContent(item);
            return client.ExecuteRequestAsync<TRequest, TResponse, TError>(requestUri, HttpMethod.Post, body,
                cancellationToken);
        }

        public static Task<HttpResponseMessage> PutAsync<TRequest>(this System.Net.Http.HttpClient client,
            string requestUri, TRequest item, CancellationToken cancellationToken = default)
        {
            var body = GetHttpContent(item);
            return client.ExecuteRequestAsync<TRequest>(requestUri, HttpMethod.Put, body, cancellationToken);
        }

        public static Task<HttpResponseWrapper<TResponse, TError>> PutAsync<TResponse, TError>(
            this System.Net.Http.HttpClient client, string requestUri, CancellationToken cancellationToken = default)
        {
            return client.ExecuteRequestAsync<TResponse, TError>(requestUri, HttpMethod.Put, cancellationToken);
        }

        public static Task<HttpResponseWrapper<TResponse, TError>> PutAsync<TRequest, TResponse, TError>(
            this System.Net.Http.HttpClient client, string requestUri, TRequest item,
            CancellationToken cancellationToken = default)
        {
            var body = GetHttpContent(item);
            return client.ExecuteRequestAsync<TRequest, TResponse, TError>(requestUri, HttpMethod.Put, body, cancellationToken);
        }

        public static Task<HttpResponseWrapper<TResponse, TResponse>> GetWithBodyAsync<TBody, TResponse>(
          this System.Net.Http.HttpClient client,
          string requestUri,
          TBody body,
          CancellationToken cancellationToken = default)
        {
            var content = GetHttpContent(body);
            return client.ExecuteRequestAsync<TBody, TResponse, TResponse>(requestUri, HttpMethod.Post, content, cancellationToken);
        }

        public static Task<HttpResponseWrapper<TResponse, TError>> GetWithBodyAsync<TBody, TResponse, TError>(
            this System.Net.Http.HttpClient client,
            string requestUri,
            TBody body,
            CancellationToken cancellationToken = default)
        {
            var content = GetHttpContent(body);
            return client.ExecuteRequestAsync<TBody, TResponse, TError>(requestUri, HttpMethod.Post, content, cancellationToken);
        }

        public static Task<HttpResponseWrapper<TResponse, TResponse>> GetAsync<TResponse>(this System.Net.Http.HttpClient client,
            string requestUri, CancellationToken cancellationToken = default)
        {
            return client.ExecuteRequestAsync<TResponse, TResponse>(requestUri, HttpMethod.Get, cancellationToken);
        }

        public static Task<HttpResponseWrapper<TResponse, TError>> GetAsync<TResponse, TError>(this System.Net.Http.HttpClient client,
            string requestUri, CancellationToken cancellationToken = default)
        {
            return client.ExecuteRequestAsync<TResponse, TError>(requestUri, HttpMethod.Get, cancellationToken);
        }

        public static Task<HttpResponseWrapper<TResponse, TError>> DeleteAsync<TResponse, TError>(
            this System.Net.Http.HttpClient client, string requestUri, CancellationToken cancellationToken)
        {
            return client.ExecuteRequestAsync<TResponse, TError>(requestUri, HttpMethod.Delete, cancellationToken);
        }

        private static async Task<HttpResponseWrapper<TResponse, TError>> ExecuteRequestAsync<TRequest, TResponse, TError>(
            this System.Net.Http.HttpClient client,
            string uri,
            HttpMethod httpMethod,
            HttpContent content,
            CancellationToken cancellationToken)
        {
            using (var request = new HttpRequestMessage(httpMethod, uri) { Content = content })
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
}
