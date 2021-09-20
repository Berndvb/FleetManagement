using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Framework.Models.Dtos
{
    public class FileDto
    {
        public string Id { get; set; }

        public EFileType FileType { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public Byte[] Content { get; set; }
    }
}
