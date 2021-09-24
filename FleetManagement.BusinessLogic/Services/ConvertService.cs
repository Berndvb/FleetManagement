using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace FleetManagement.BLL.Services
{
    public static class ConvertService
    {
        //Standard Converting
        public static IdentiteitPersoonDto ConvertIdentiteitPersoon(this IdentiteitPersoon identiteit)
        {
            if (identiteit != null)
            {
                var identiteitDto = new IdentiteitPersoonDto(
                    identiteit.Id,
                    identiteit.Naam,
                    identiteit.Voornaam,
                    identiteit.Rijksregisternummer,
                    identiteit.Geboortedatum);

                return identiteitDto;
            }
            return null;
        }

        public static IdentiteitVoertuigDto ConvertIdentiteitVoertuig(this IdentiteitVoertuig identiteit)
        {
            if (identiteit != null)
            {
                var identiteitDto = new IdentiteitVoertuigDto(
                    identiteit.Id,
                    identiteit.Chassisnummer,
                    identiteit.BrandstofType,
                    identiteit.WagenType,
                    identiteit.Merk,
                    identiteit.Nummerplaten);

                return identiteitDto;
            }
            return null;
        }

        public static ContactgegevensDto ConvertContactgegevens(this Contactgegevens contactgegevens)
        {
            if (contactgegevens != null)
            {
                var contactgegevensDto = new ContactgegevensDto(
                    contactgegevens.Id,
                    contactgegevens.EmailAdres,
                    contactgegevens.GsmNummer,
                    contactgegevens.Telefoonnummer,
                    ConvertAdres(contactgegevens.Adres));

                return contactgegevensDto;
            }
            return null;
        }

        public static AdresDto ConvertAdres(Adres adres)
        {
            if (adres != null)
            {
                var adresDto = new AdresDto(
                    adres.Id,
                    adres.Straat,
                    adres.Stad,
                    adres.Postcode);

                return adresDto;
            }
            return null;
        }

        public static VoertuigDto ConvertReadVoertuig(this ReadVoertuig voertuig)
        {
            if (voertuig != null)
            {
                var voertuigDto = new VoertuigDto(
                    voertuig.Id,
                    ConvertIdentiteitVoertuig(voertuig.Identiteit),
                    voertuig.Kilometerstanden,
                    ConvertReadOnderhoudsbeurten(voertuig.Onderhoudsbeurten),
                    ConvertReadHerstellingen(voertuig.Herstellingen),
                    ConvertChauffeurVoertuigen(voertuig.Chauffeurs),
                    ConvertReadAanvragen(voertuig.Aanvragen));

                return voertuigDto;
            }
            return null;
        }

        public static List<AanvraagDto> ConvertReadAanvragen(this List<ReadAanvraag> aanvragen)
        {
            if ((aanvragen != null) && (!aanvragen.Any()))
            {
                var aanvraagDtos = new List<AanvraagDto>();
                foreach (var aanvraag in aanvragen)
                {
                    var aanvraagDto = new AanvraagDto(
                        aanvraag.Id,
                        aanvraag.AanmaakDatum,
                        aanvraag.AanvraagType,
                        aanvraag.EersteDatumInplanning,
                        aanvraag.TweedeDatumInplanning,
                        aanvraag.Status,
                        ConvertReadVoertuig(aanvraag.Voertuig),
                        ConvertReadChauffeur(aanvraag.Chauffeur),
                        aanvraag.Message);

                    aanvraagDtos.Add(aanvraagDto);
                }
                return aanvraagDtos;
            }
            return null;
        }

        public static List<TankkaartChauffeurDto> ConvertTankkaartChauffeurs(this List<TankkaartChauffeur> tankkaartchauffeurs)
        {
            if ((tankkaartchauffeurs != null) && (!tankkaartchauffeurs.Any()))
            {
                var tankkaartChauffeurDtos = new List<TankkaartChauffeurDto>();
                foreach (var tankkaartchauffeur in tankkaartchauffeurs)
                {
                    var tankkaartChauffeurDto = new TankkaartChauffeurDto(
                        tankkaartchauffeur.Id,
                        ConvertReadTankkaart(tankkaartchauffeur.Tankkaart),
                        ConvertReadChauffeur(tankkaartchauffeur.Chauffeur),
                        tankkaartchauffeur.Actief,
                        tankkaartchauffeur.AanmaakDatum,
                        tankkaartchauffeur.AfsluitDatum);

                    tankkaartChauffeurDtos.Add(tankkaartChauffeurDto);
                }
                return tankkaartChauffeurDtos;
            }
            return null;
        }

        public static List<ShowChauffeurVoertuigDto> ConvertChauffeurVoertuigen(this List<ChauffeurVoertuig> chauffeurVoertuigen)
        {
            if ((chauffeurVoertuigen != null) && (!chauffeurVoertuigen.Any()))
            {
                var chauffeurVoertuigDtos = new List<ShowChauffeurVoertuigDto>();
                foreach (var chauffeurVoertuig in chauffeurVoertuigen)
                {
                    var chauffeurVoertuigDto = new ChauffeurVoertuigDto(
                        chauffeurVoertuig.Id,
                        ConvertReadVoertuig(chauffeurVoertuig.Voertuig),
                        ConvertReadChauffeur(chauffeurVoertuig.Chauffeur),
                        chauffeurVoertuig.Actief,
                        chauffeurVoertuig.AanmaakDatum,
                        chauffeurVoertuig.AfsluitDatum);

                    chauffeurVoertuigDtos.Add(chauffeurVoertuigDto);
                }
                return chauffeurVoertuigDtos;
            }
            return null;
        }

        public static List<HerstellingDto> ConvertReadHerstellingen(this List<ReadHerstelling> herstellingen)
        {
            if ((herstellingen != null) && (!herstellingen.Any()))
            {
                var herstellingDtos = new List<HerstellingDto>();
                foreach (var herstelling in herstellingen)
                {
                    var herstellingDto = new HerstellingDto(
                        herstelling.Id,
                        herstelling.DatumVoorval,
                        herstelling.SchadeOmschrijving,
                        herstelling.Verzekeringsmaatschappij,
                        herstelling.ReferentieNummer,
                        herstelling.HerstellingStatus);

                    herstellingDtos.Add(herstellingDto);
                }
                return herstellingDtos;
            }
            return null;
        }

        public static List<OnderhoudsbeurtDto> ConvertReadOnderhoudsbeurten(this List<ReadOnderhoudsbeurt> onderhoudsbeurten)
        {
            if ((onderhoudsbeurten != null) && (!onderhoudsbeurten.Any()))
            {
                var onderhoudsbeurtDtos = new List<OnderhoudsbeurtDto>();
                foreach (var onderhoudsbeurt in onderhoudsbeurten)
                {
                    var onderhoudsbeurtDto = new OnderhoudsbeurtDto(
                        onderhoudsbeurt.Id,
                        ConvertReadVoertuig(onderhoudsbeurt.Voertuig),
                        onderhoudsbeurt.UitvoeringsDatum,
                        onderhoudsbeurt.FacturatieDatum,
                        onderhoudsbeurt.Prijs,
                        ConvertGarage(onderhoudsbeurt.Garage),
                        ConvertFiles(onderhoudsbeurt.Documenten));

                    onderhoudsbeurtDtos.Add(onderhoudsbeurtDto);
                }
                return onderhoudsbeurtDtos;
            }
            return null;
        }

        public static TankkaartDto ConvertReadTankkaart(this ReadTankkaart tankkaart)
        {
            if (tankkaart != null)
            {
                var tankkaartDto = new TankkaartDto(
                    tankkaart.Id,
                    tankkaart.Kaartnummer,
                    tankkaart.GeldigheidsDatum,
                    tankkaart.Pincode,
                    tankkaart.AuthenticatieType,
                    ConvertTankkaartOpties(tankkaart.TankkaartOpties),
                    tankkaart.Geblokkeerd,
                    ConvertTankkaartChauffeurs(tankkaart.Chauffeurs));

                return tankkaartDto;
            }
            return null;
        }

        public static ChauffeurDto ConvertReadChauffeur(this ReadChauffeur chauffeur)
        {
            if (chauffeur != null)
            {
                var chauffeurDto = new ChauffeurDto(
                            chauffeur.Id,
                            ConvertIdentiteitPersoon(chauffeur.Identiteit),
                            ConvertContactgegevens(chauffeur.Contactgegevens),
                            chauffeur.RijbewijsType,
                            chauffeur.InDienst,
                            ConvertTankkaartChauffeurs(chauffeur.Tankkaarten),
                            ConvertChauffeurVoertuigen(chauffeur.Voertuigen),
                            ConvertReadAanvragen(chauffeur.Aanvragen));

                return chauffeurDto;
            }
            return null;
        }

        public static List<ChauffeurDto> ConvertReadChauffeurs(this ICollection<ReadChauffeur> chauffeurs)
        {
            if ((chauffeurs != null) && (!chauffeurs.Any()))
            {
                var chauffeurDtos = new List<ChauffeurDto>();
                foreach (var chauffeur in chauffeurs)
                {
                    var onderhoudsbeurtDto = new ChauffeurDto(
                            chauffeur.Id,
                            ConvertIdentiteitPersoon(chauffeur.Identiteit),
                            ConvertContactgegevens(chauffeur.Contactgegevens),
                            chauffeur.RijbewijsType,
                            chauffeur.InDienst,
                            ConvertTankkaartChauffeurs(chauffeur.Tankkaarten),
                            ConvertChauffeurVoertuigen(chauffeur.Voertuigen),
                            ConvertReadAanvragen(chauffeur.Aanvragen));

                    chauffeurDtos.Add(onderhoudsbeurtDto);
                }
                return chauffeurDtos;
            }
            return null;
        }

        public static TankkaartOptiesDto ConvertTankkaartOpties(this TankkaartOpties tankkaartOpties)
        {
            if (tankkaartOpties != null)
            {
                var tankkaartOptiesDto = new TankkaartOptiesDto(
                    tankkaartOpties.Id,
                    tankkaartOpties.BrandstofType,
                    tankkaartOpties.ExtraServices);

                return tankkaartOptiesDto;
            }
            return null;
        }

        public static GarageDto ConvertGarage(Garage garage)
        {
            if (garage != null)
            {
                var garageDto = new GarageDto(
                    garage.Id,
                    garage.Naam,
                    ConvertContactgegevens(garage.Contactgegevens),
                    garage.Ondernemingsnummer,
                    garage.Bankrekeningnummer);

                return garageDto;
            }
            return null;
        }

        public static List<FileDto> ConvertFiles(List<File> files)
        {
            if ((files != null) && (!files.Any()))
            {
                var fileDtos = new List<FileDto>();
                foreach (var file in files)
                {
                    var fileDto = new FileDto(
                    file.Id,
                    file.FileType,
                    file.FileName,
                    file.ContentType,
                    file.Content);

                    fileDtos.Add(fileDto);
                }
                return fileDtos;
            }
            return null;
        }
    }
}

