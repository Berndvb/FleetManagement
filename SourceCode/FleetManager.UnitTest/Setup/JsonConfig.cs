using FleetManagement.Framework.Constants;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.UnitTest.Integration.Setup
{
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
