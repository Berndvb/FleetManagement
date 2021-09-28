using FleetManagement.Domain.Interfaces;
using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Domain.Models
{
    public class File : IBaseClass
    {
        public int Id { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public Byte[] Content { get; set; }

        public Administration administration { get; set; }
    }
}
