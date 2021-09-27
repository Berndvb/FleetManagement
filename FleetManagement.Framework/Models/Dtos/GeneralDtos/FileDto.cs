using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Framework.Models.Dtos
{
    public class FileDto
    {
        public string Id { get; set; }

        public EFileType FileType { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public Byte[] Content { get; set; }

        public FileDto(
            string id,
            EFileType fileType,
            string fileName,
            string contentType,
            Byte[] content)
        {
            Id = id;
            FileType = fileType;
            FileName = fileName;
            ContentType = contentType;
            Content = content;
        }
    }
}
