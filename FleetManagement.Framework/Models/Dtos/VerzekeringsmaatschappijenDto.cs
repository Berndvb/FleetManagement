using FleetManagement.Framework.Helpers;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class VerzekeringsmaatschappijenDto
    {
        public List<string> Verzekeringsmaatschappijen { get; set; }

        public VerzekeringsmaatschappijenDto(
            string verzekeringsmaatschappijen)
        {
            Verzekeringsmaatschappijen = verzekeringsmaatschappijen.SplitToText();
        }
    }
}
