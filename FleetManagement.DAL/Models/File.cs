using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Domain.Models
{
    public class File : IBaseClass
    {
        public int Id { get; private set; }

        public FileType FileType { get; private set; }

        public string FileName { get; private set; }

        public string ContentType { get; private set; }

        public Byte[] Content { get; private set; }

        public Administration administration { get; private set; }
    }
}
