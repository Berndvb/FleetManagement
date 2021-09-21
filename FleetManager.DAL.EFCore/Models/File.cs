using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManager.EFCore.Models
{
    public class File
    {
        public string Id { get; set; }

        public EFileType FileType { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public Byte[] Content { get; set; }

        public Administratie Administratie { get; set; }
    }
}
