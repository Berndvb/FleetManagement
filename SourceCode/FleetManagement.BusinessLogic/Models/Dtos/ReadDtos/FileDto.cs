using System;
using System.Text.Json.Serialization;
using FleetManagement.Framework.Models.Enums;
using Newtonsoft.Json.Converters;


namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class FileDto
    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public Byte[] Content { get; set; }
    }
}
