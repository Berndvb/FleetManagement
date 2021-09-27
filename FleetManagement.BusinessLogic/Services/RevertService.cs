using FleetManagement.Domain.Models;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace FleetManagement.BLL.Services
{
    public static class RevertService
    {
        public static IdentityPerson RevertIdentiteitPersoonDto(this IdentiteitPersoonDto identiteitDto)
        {
            if (identiteitDto != null)
            {
                var identiteit = new IdentityPerson()
                {
                    Id = identiteitDto.Id,
                    Naam = identiteitDto.Naam,
                    Voornaam = identiteitDto.Voornaam,
                    Rijksregisternummer = identiteitDto.Rijksregisternummer,
                    Geboortedatum = identiteitDto.Geboortedatum
                };

                return identiteit;
            }
            return null;
        }

        public static IdentityVehicle RevertIdentiteitVoertuigDto(this IdentiteitVoertuigDto identiteitDto)
        {
            if (identiteitDto != null)
            {
                var identiteit = new IdentityVehicle()
                {
                    Id = identiteitDto.Id,
                    Chassisnummer = identiteitDto.Chassisnummer,
                    BrandstofType = identiteitDto.BrandstofType,
                    WagenType = identiteitDto.WagenType,
                    Merk = identiteitDto.Merk,
                    Nummerplaten = identiteitDto.Nummerplaten.Unify()
                };

                return identiteit;
            }
            return null;
        }

        public static ContactInfo RevertContactgegevensDto(this ContactgegevensDto contactgegevensDto)
        {
            if (contactgegevensDto != null)
            {
                var contactgegevens = new ContactInfo()
                {
                    Id = contactgegevensDto.Id,
                    EmailAdres = contactgegevensDto.EmailAdres,
                    GsmNummer = contactgegevensDto.GsmNummer,
                    Telefoonnummer = contactgegevensDto.Telefoonnummer,
                    Adres = RevertAdresDto(contactgegevensDto.Adres)
                };

                return contactgegevens;
            }
            return null;
        }

        public static Address RevertAdresDto(this AdresDto adresDto)
        {
            if (adresDto != null)
            {
                var adres = new Address()
                {
                    Id = adresDto.Id,
                    Straat = adresDto.Straat,
                    Stad = adresDto.Stad,
                    Postcode = adresDto.Postcode
                };

                return adres;
            }
            return null;
        }

        public static ReadVehicle RevertVoertuigDto(this VoertuigDto voertuigDto)
        {
            if (voertuigDto != null)
            {
                var readVoertuig = new ReadVehicle()
                {
                    Id = voertuigDto.Id,
                    Identiteit = RevertIdentiteitVoertuigDto(voertuigDto.Identiteit),
                    Kilometerstanden = voertuigDto.Kilometerstanden.Unify(),
                    Onderhoudsbeurten = RevertOnderhoudsbeurtenDto(voertuigDto.Onderhoudsbeurten),
                    Herstellingen = RevertHerstellingenDto(voertuigDto.Herstellingen),
                    Chauffeurs = RevertChauffeurVoertuigenDto(voertuigDto.Chauffeurs),
                    Aanvragen = RevertAanvragenDto(voertuigDto.Aanvragen)
                };

                return readVoertuig;
            }

            return null;
        }

        public static List<ReadAppeal> RevertAanvragenDto(this List<AanvraagDto> aanvraagDtos)
        {
            if ((aanvraagDtos != null) && (!aanvraagDtos.Any()))
            {
                var readAanvragen = new List<ReadAppeal>();
                foreach (var aanvraag in aanvraagDtos)
                {
                    var readAanvraag = new ReadAppeal()
                    {
                        Id = aanvraag.Id,
                        AanmaakDatum = aanvraag.AanmaakDatum,
                        AanvraagType = aanvraag.AanvraagType,
                        EersteDatumInplanning = aanvraag.EersteDatumInplanning,
                        TweedeDatumInplanning = aanvraag.TweedeDatumInplanning,
                        Status = aanvraag.Status,
                        Voertuig = RevertVoertuigDto(aanvraag.Voertuig),
                        Chauffeur = RevertChauffeurDto(aanvraag.Chauffeur),
                        Message = aanvraag.Message
                    };

                    readAanvragen.Add(readAanvraag);
                }
                return readAanvragen;
            }
            return null;
        }

        public static List<FuelCardDriver> RevertTankkaartChauffeursDto(this List<TankkaartChauffeurDto> tankkaartchauffeurDtos)
        {
            if ((tankkaartchauffeurDtos != null) && (!tankkaartchauffeurDtos.Any()))
            {
                var tankkaartChauffeurs = new List<FuelCardDriver>();
                foreach (var tankkaartchauffeurDto in tankkaartchauffeurDtos)
                {
                    var tankkaartChauffeur = new FuelCardDriver()
                    {
                        Id = tankkaartchauffeurDto.Id,
                        Tankkaart = RevertTankkaartDto(tankkaartchauffeurDto.Tankkaart),
                        Chauffeur = RevertChauffeurDto(tankkaartchauffeurDto.Chauffeur),
                        Actief = tankkaartchauffeurDto.Actief,
                        AanmaakDatum = tankkaartchauffeurDto.AanmaakDatum,
                        AfsluitDatum = tankkaartchauffeurDto.AfsluitDatum
                    };

                    tankkaartChauffeurs.Add(tankkaartChauffeur);
                }
                return tankkaartChauffeurs;
            }
            return null;
        }

        public static List<DriverVehicle> RevertChauffeurVoertuigenDto(this List<ShowVoertuigInfoDto> chauffeurVoertuigDtos)
        {
            if ((chauffeurVoertuigDtos != null) && (!chauffeurVoertuigDtos.Any()))
            {
                var chauffeurVoertuigen = new List<DriverVehicle>();
                foreach (var chauffeurVoertuigDto in chauffeurVoertuigDtos)
                {
                    var chauffeurVoertuig = new DriverVehicle()
                    {
                        Id = chauffeurVoertuigDto.Id,
                        Voertuig = RevertVoertuigDto(chauffeurVoertuigDto.Voertuig),
                        Chauffeur = RevertChauffeurDto(chauffeurVoertuigDto.Chauffeur),
                        Actief = chauffeurVoertuigDto.Actief,
                        AanmaakDatum = chauffeurVoertuigDto.AanmaakDatum,
                        AfsluitDatum = chauffeurVoertuigDto.AfsluitDatum
                    };

                    chauffeurVoertuigen.Add(chauffeurVoertuig);
                }
                return chauffeurVoertuigen;
            }
            return null;
        }

        public static List<ReadRepare> RevertHerstellingenDto(this List<HerstellingDto> herstellingDtos)
        {
            if ((herstellingDtos != null) && (!herstellingDtos.Any()))
            {
                var readHerstellingen = new List<ReadRepare>();
                foreach (var HerstellingDto in herstellingDtos)
                {
                    var readHerstelling = new ReadRepare()
                    {
                        Id = HerstellingDto.Id,
                        DatumVoorval = HerstellingDto.DatumVoorval,
                        SchadeOmschrijving = HerstellingDto.SchadeOmschrijving,
                        Verzekeringsmaatschappij = HerstellingDto.Verzekeringsmaatschappij,
                        ReferentieNummer = HerstellingDto.ReferentieNummer,
                        HerstellingStatus = HerstellingDto.HerstellingStatus
                    };

                    readHerstellingen.Add(readHerstelling);
                }
                return readHerstellingen;
            }
            return null;
        }

        public static List<ReadMaintenance> RevertOnderhoudsbeurtenDto(this List<OnderhoudsbeurtDto> pderhoudsbeurtDtos)
        {
            if ((pderhoudsbeurtDtos != null) && (!pderhoudsbeurtDtos.Any()))
            {
                var readOnderhoudsbeurten = new List<ReadMaintenance>();
                foreach (var onderhoudsbeurtDto in pderhoudsbeurtDtos)
                {
                    var readOnderhoudsbeurt = new ReadMaintenance()
                    {
                        Id = onderhoudsbeurtDto.Id,
                        Voertuig = RevertVoertuigDto(onderhoudsbeurtDto.Voertuig),
                        UitvoeringsDatum = onderhoudsbeurtDto.UitvoeringsDatum,
                        FacturatieDatum = onderhoudsbeurtDto.FacturatieDatum,
                        Prijs = onderhoudsbeurtDto.Prijs,
                        Garage = RevertGarageDto(onderhoudsbeurtDto.Garage),
                        Documenten = RevertFilesDto(onderhoudsbeurtDto.Documenten)
                    };

                    readOnderhoudsbeurten.Add(readOnderhoudsbeurt);
                }
                return readOnderhoudsbeurten;
            }
            return null;
        }

        public static ReadFuelCard RevertTankkaartDto(this TankkaartDto tankkaartDto)
        {
            if (tankkaartDto != null)
            {
                var readTankkaart = new ReadFuelCard()
                {
                    Id = tankkaartDto.Id,
                    Kaartnummer = tankkaartDto.Kaartnummer,
                    GeldigheidsDatum = tankkaartDto.GeldigheidsDatum,
                    Pincode = tankkaartDto.Pincode,
                    AuthenticatieType = tankkaartDto.AuthenticatieType,
                    TankkaartOpties = RevertTankkaartOptiesDto(tankkaartDto.TankkaartOpties),
                    Geblokkeerd = tankkaartDto.Geblokkeerd,
                    Chauffeurs = RevertTankkaartChauffeursDto(tankkaartDto.Chauffeurs)
                };

                return readTankkaart;
            }
            return null;
        }

        public static ReadDriver RevertChauffeurDto(this ChauffeurDto ChauffeurDto)
        {
            if (ChauffeurDto != null)
            {
                var readChauffeur = new ReadDriver()
                {
                    Id = ChauffeurDto.Id,
                    Identiteit = RevertIdentiteitPersoonDto(ChauffeurDto.Identiteit),
                    Contactgegevens = RevertContactgegevensDto(ChauffeurDto.Contactgegevens),
                    RijbewijsType = ChauffeurDto.RijbewijsType,
                    InDienst = ChauffeurDto.InDienst,
                    Tankkaarten = RevertTankkaartChauffeursDto(ChauffeurDto.Tankkaarten),
                    Voertuigen = RevertChauffeurVoertuigenDto(ChauffeurDto.Voertuigen),
                    Aanvragen = RevertAanvragenDto(ChauffeurDto.Aanvragen)
                };

                return readChauffeur;
            }
            return null;
        }

        public static List<ReadDriver> RevertChauffeursDto(this ICollection<ChauffeurDto> chauffeurDtos)
        {
            if ((chauffeurDtos != null) && (!chauffeurDtos.Any()))
            {
                var readChaffeurs = new List<ReadDriver>();
                foreach (var chauffeurDto in chauffeurDtos)
                {
                    var readChauffeur = new ReadDriver()
                    {
                        Id = chauffeurDto.Id,
                        Identiteit = RevertIdentiteitPersoonDto(chauffeurDto.Identiteit),
                        Contactgegevens = RevertContactgegevensDto(chauffeurDto.Contactgegevens),
                        RijbewijsType = chauffeurDto.RijbewijsType,
                        InDienst = chauffeurDto.InDienst,
                        Tankkaarten = RevertTankkaartChauffeursDto(chauffeurDto.Tankkaarten),
                        Voertuigen = RevertChauffeurVoertuigenDto(chauffeurDto.Voertuigen),
                        Aanvragen = RevertAanvragenDto(chauffeurDto.Aanvragen)
                    };

                    readChaffeurs.Add(readChauffeur);
                }
                return readChaffeurs;
            }
            return null;
        }

        public static FuelCardOptions RevertTankkaartOptiesDto(this TankkaartOptiesDto tankkaartOptiesDto)
        {
            if (tankkaartOptiesDto != null)
            {
                var tankkaartOpties = new FuelCardOptions()
                {
                    Id = tankkaartOptiesDto.Id,
                    BrandstofType = tankkaartOptiesDto.BrandstofType,
                    ExtraServices = tankkaartOptiesDto.ExtraServices.Unify()
                };
                return tankkaartOpties;
            }
            return null;
        }
    
        public static Garage RevertGarageDto(this GarageDto garageDto)
        {
            if (garageDto != null)
            {
                var garage = new Garage()
                {
                    Id = garageDto.Id,
                    Naam = garageDto.Naam,
                    Contactgegevens = RevertContactgegevensDto(garageDto.Contactgegevens),
                    Ondernemingsnummer = garageDto.Ondernemingsnummer,
                    Bankrekeningnummer = garageDto.Bankrekeningnummer
                };

                return garage;
            }
            return null;
        }

        public static List<File> RevertFilesDto(this List<FileDto> fileDtos)
        {
            if ((fileDtos != null) && (!fileDtos.Any()))
            {
                var files = new List<File>();
                foreach (var fileDto in fileDtos)
                {
                    var file = new File()
                    {
                        Id = fileDto.Id,
                        FileType = fileDto.FileType,
                        FileName = fileDto.FileName,
                        ContentType = fileDto.ContentType,
                        Content = fileDto.Content
                    };

                    files.Add(file);
                }
                return files;
            }
            return null;
        }
    }
}
