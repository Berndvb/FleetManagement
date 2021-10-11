using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Framework.Models.Dtos.ReadDtos
{
    public class FileDto
    {
        public int Id { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public Byte[] Content { get; set; }

        public FileDto(
            int id,
            FileType fileType,
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
