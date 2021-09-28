using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class TankkaartDto
    {
        public int Id { get; set; }

        public string Kaartnummer { get; set; }

        public DateTime GeldigheidsDatum { get; set; }

        public string Pincode { get; set; }

        public AuthenticatieType AuthenticatieType { get; set; }

        public TankkaartOptiesDto TankkaartOpties { get; set; }

        public bool Geblokkeerd { get; set; }

        public List<TankkaartChauffeurDto> Chauffeurs { get; set; }

        public TankkaartDto(
            int id,
            string kaartnummer,
            DateTime geldigheidsDatum,
            string pincode,
            AuthenticatieType authenticatieType,
            TankkaartOptiesDto tankkaartOpties,
            bool geblokkeerd,
            List<TankkaartChauffeurDto> chauffeurs)
        {
            Id = id;
            Kaartnummer = kaartnummer;
            GeldigheidsDatum = geldigheidsDatum;
            Pincode = pincode;
            AuthenticatieType = authenticatieType;
            TankkaartOpties = tankkaartOpties;
            Geblokkeerd = geblokkeerd;
            Chauffeurs = chauffeurs;
        }
    }
}
