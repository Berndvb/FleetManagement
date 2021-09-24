using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class ShowChauffeurVoertuigDto // Create a ShowChauffeurDetail-class
    {
        public string Id { get; set; }

        public ShowVoertuigDto Voertuig { get; set; }

        public bool Actief { get; set; }

        public DateTime AanmaakDatum { get; set; }

        public DateTime? AfsluitDatum { get; set; }

        public ShowChauffeurVoertuigDto(
            string id,
            bool actief,
            DateTime aanmaakDatum,
            DateTime? afsluitDatum)
        {
            Id = id;
            Actief = actief;
            AanmaakDatum = aanmaakDatum;
            AfsluitDatum = afsluitDatum;
        }

        public class ShowVoertuigDto
        {
            public string Id { get; set; }

            public ShowIdentiteitVoertuigDto Identiteit { get; set; }

            public List<int> Kilometerstanden { get; set; }

            public Dictionary<string, DateTime> Onderhoudsbeurten { get; set; } // change to ShowOnderhoudsbeurtDto

            public Dictionary<string, DateTime> Herstellingen { get; set; } // 

            public Dictionary<string, DateTime> Aanvragen { get; set; } //

            public ShowVoertuigDto(
                string id, 
                ShowIdentiteitVoertuigDto identiteit, 
                List<int> kilometerstanden, 
                Dictionary<string, DateTime> onderhoudsbeurten,
                Dictionary<string, DateTime> herstellingen, 
                Dictionary<string, DateTime> aanvragen)
            {
                Id = id;
                Identiteit = identiteit;
                Kilometerstanden = kilometerstanden;
                Onderhoudsbeurten = onderhoudsbeurten;
                Herstellingen = herstellingen;
                Aanvragen = aanvragen;
            }

            public class ShowIdentiteitVoertuigDto
            {
                public string Id { get; set; }
                    
                public EBrandstofType BrandstofType { get; set; }

                public EWagenType WagenType { get; set; }

                public string Merk { get; set; }

                public string HuidigeNummerplaat { get; set; }

                public ShowIdentiteitVoertuigDto(
                    string id,
                    EBrandstofType brandstofType,
                    EWagenType wagenType,
                    string merk,
                    string huidigeNummerplaat)
                {
                    Id = id;
                    BrandstofType = brandstofType;
                    WagenType = wagenType;
                    Merk = merk;
                    HuidigeNummerplaat = huidigeNummerplaat;
                }
            }
        }
    }
}
