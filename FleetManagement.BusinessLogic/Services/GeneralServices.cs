using FleetManagement.Domain.Models;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace FleetManagement.BLL.Services
{
    public class GeneralServices // opsplitsen aparte classes en vervolgens injecteren
    {
        public IdentiteitPersoonDto ConvertIdentiteitPersoon(IdentiteitPersoon identiteit)
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

        public IdentiteitPersoon ConvertToIdentiteitPersoon(IdentiteitPersoonDto identiteitDto)
        {
            if (identiteitDto != null)
            {
                var identiteit = new IdentiteitPersoon() {
                    Id = identiteitDto.Id,
                    Naam = identiteitDto.Naam,
                    Voornaam = identiteitDto.Voornaam,
                    Rijksregisternummer = identiteitDto.Rijksregisternummer,
                    Geboortedatum = identiteitDto.Geboortedatum};

                return identiteit;
            }
            return null;
        }

        public IdentiteitVoertuigDto ConvertIdentiteitVoertuig(IdentiteitVoertuig identiteit)
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

        public IdentiteitVoertuig ConvertToIdentiteitVoertuig(IdentiteitVoertuigDto identiteitDto)
        {
            if (identiteitDto != null)
            {
                var identiteit = new IdentiteitVoertuig()
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

        public ContactgegevensDto ConvertContactgegevens(Contactgegevens contactgegevens)
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

        public ContactgegevensDto ConvertToContactgegevens(ContactgegevensDto contactgegevensDto) 
        {
            if (contactgegevensDto != null)
            {
                var contactgegevens = new Contactgegevens()
                {
                    Id = contactgegevensDto.Id,
                    EmailAdres = contactgegevensDto.EmailAdres,
                    GsmNummer = contactgegevensDto.GsmNummer,
                    Telefoonnummer = contactgegevensDto.Telefoonnummer,
                    Adres = ConvertToAdres(contactgegevensDto.Adres)
                };

                return contactgegevensDto;
            }
            return null;
        }

        public AdresDto ConvertAdres(Adres adres)
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

        public Adres ConvertToAdres(AdresDto adresDto)
        {
            if (adresDto != null)
            {
                var adres = new Adres() {
                    Id = adresDto.Id,
                    Straat = adresDto.Straat,
                    Stad = adresDto.Stad,
                    Postcode = adresDto.Postcode};

                return adres;
            }
            return null;
        }

        public VoertuigDto ConvertReadVoertuig(ReadVoertuig voertuig)  // laatste stuk-----------------------------------!!!
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

        public List<AanvraagDto> ConvertReadAanvragen(List<ReadAanvraag> aanvragen)
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

        public List<TankkaartChauffeurDto> ConvertTankkaartChauffeurs(List<TankkaartChauffeur> tankkaartchauffeurs)
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

        public List<ChauffeurVoertuigDto> ConvertChauffeurVoertuigen(List<ChauffeurVoertuig> chauffeurVoertuigen)
        {
            if ((chauffeurVoertuigen != null) && (!chauffeurVoertuigen.Any()))
            {
                var chauffeurVoertuigDtos = new List<ChauffeurVoertuigDto>();
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


        public List<HerstellingDto> ConvertReadHerstellingen(List<ReadHerstelling> herstellingen)
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


        public List<OnderhoudsbeurtDto> ConvertReadOnderhoudsbeurten(List<ReadOnderhoudsbeurt> onderhoudsbeurten)
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

        public TankkaartDto ConvertReadTankkaart(ReadTankkaart tankkaart)
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

        public ChauffeurDto ConvertReadChauffeur(ReadChauffeur chauffeur)
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

        public List<ChauffeurDto> ConvertReadChauffeurs(ICollection<ReadChauffeur> chauffeurs)
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

        public List<ReadChauffeur> ConvertToReadChauffeur(ICollection<ChauffeurDto> chauffeurs)
        {
            if ((chauffeurs != null) && (!chauffeurs.Any()))
            {
                var readChauffeurs = new List<ReadChauffeur>();
                foreach (var chauffeur in chauffeurs)
                {
                    var readChauffeur = new ReadChauffeur(
                            chauffeur.Id,
                            ConvertToIdentiteitPersoon(chauffeur.Identiteit),
                            ConvertContactgegevens(chauffeur.Contactgegevens),
                            chauffeur.RijbewijsType,
                            chauffeur.InDienst,
                            ConvertTankkaartChauffeurs(chauffeur.Tankkaarten),
                            ConvertChauffeurVoertuigen(chauffeur.Voertuigen),
                            ConvertAanvragen(chauffeur.Aanvragen));

                    readChauffeurs.Add(readChauffeur);
                }
                return readChauffeurs;
            }
            return null;
        }

        public TankkaartOptiesDto ConvertTankkaartOpties(TankkaartOpties tankkaartOpties)
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

        public GarageDto ConvertGarage(Garage garage)
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

        public List<FileDto> ConvertFiles(List<File> files)
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
