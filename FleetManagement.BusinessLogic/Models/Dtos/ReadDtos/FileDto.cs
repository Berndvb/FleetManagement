using System;
using FleetManagement.Framework.Models.Enums;

namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class FileDto
    {
        public int Id { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public Byte[] Content { get; set; }
    }
}
