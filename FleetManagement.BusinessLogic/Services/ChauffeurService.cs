using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static FleetManagement.Framework.Models.Dtos.VehicleInfoDto;
using static FleetManagement.Framework.Models.Dtos.VehicleInfoDto.VehicleDto;

namespace FleetManagement.BLL.Services
{
    public class ChauffeurService 
    {
        public IUnitOfWork _unitOfWork { get; set; } //telkens saven en disposen?

        public ChauffeurService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ChauffeurDto>> GetChauffeurOverviews() 
        {
            var readChauffeurs = await _unitOfWork.Chauffeurs.Include(x => x.Identiteit.Naam);
            var chauffeurDtos = readChauffeurs.ConvertReadChauffeurs();

            return chauffeurDtos;
        }
        //work on conversions!!

        public async Task<ChauffeurDto> GetChauffeurDetails(string id) 
        {
            var readChauffeur = await _unitOfWork.Chauffeurs.GetByIdWithIncludes(int.Parse(id), x => new { x.Identiteit, x.Contactgegevens });
            var chauffeurDto = readChauffeur.ConvertReadChauffeur();

            return chauffeurDto;
        }

        public async Task GetAllVoertuigInfo(string chauffeurId) 
        {
            //chauffeurvoertuig
            var chauffeurVoertuigen = await _unitOfWork.ChauffeurVoertuigen.FindMultiple(x => x.Chauffeur.Id == chauffeurId);

            //voertuigen + identiteit
            var voertuigenIds = chauffeurVoertuigen.Select(x => x.Voertuig.Id).ToList();

     

 
        }

        public async Task<VehicleInfoDto> GetVoertuigInfo(string voertuigId, string chauffeurId)
        {
            //chauffeurvoertuig
            var chauffeurVoertuig = await _unitOfWork.ChauffeurVoertuigen.FindSingle(x => x.Chauffeur.Id == chauffeurId);
            var chauffeurVoertuigDto = new DriverVehicleDto(
                chauffeurVoertuig.Id,
                chauffeurVoertuig.Actief,
                chauffeurVoertuig.AanmaakDatum,
                chauffeurVoertuig.AfsluitDatum);

            //voertuig
            var voertuig = (await _unitOfWork.Voertuigen.FindWithIncludes(x => x.Id == voertuigId, x => x.Identiteit)).FirstOrDefault(); // should be single

            //identiteit
            var voertuigIdentiteit = await _unitOfWork.IdentiteitVoertuigen.FindSingle(x => x.Id == voertuig.Identiteit.Id);
            var voertuigIdentiteitDto = new VehicleIdentityDto(
                        voertuigIdentiteit.Id,
                        voertuigIdentiteit.BrandstofType,
                        voertuigIdentiteit.Merk,
                        voertuigIdentiteit.Model);

            //herstellingen 
            var herstellingInfo = await _unitOfWork.Herstellingen.FindAndSelect(x => x.Id == voertuigId, x => new { x.Id, x.HerstellingStatus, x.DatumVoorval, x.FacturatieDatum });
            var herstellingDtos = new List<VehicleReparationDto>();
            foreach (var herstelling in herstellingInfo)
            {
                var herstellingDto = new VehicleReparationDto(herstelling.Id, herstelling.HerstellingStatus, herstelling.DatumVoorval, herstelling.FacturatieDatum);
                herstellingDtos.Add(herstellingDto);
            }

            //onderhoudsbeurten 
            var onderhoudsbeurtInfo = await _unitOfWork.Onderhoudsbeurten.FindAndSelect(x => x.Id == voertuigId, x => new { x.Id, x.FacturatieDatum }); ; ;
            var onderhoudsbeurtDtos = new List<VehicleMaintenanceDto>();
            foreach (var onderhoudsbeurt in onderhoudsbeurtInfo)
            {
                var onderhoudsbeurtDto = new VehicleMaintenanceDto(onderhoudsbeurt.Id, onderhoudsbeurt.FacturatieDatum);
                onderhoudsbeurtDtos.Add(onderhoudsbeurtDto);
            }

            //aanvragen
            var AanvraagInfo = await _unitOfWork.Aanvragen.FindAndSelect(x => x.Id == voertuigId, x => new { x.Id, x.AanvraagType, x.Status, x.AanmaakDatum });
            var aanvraagDtos = new List<VehicleAppealDto>();
            foreach (var aanvraag in AanvraagInfo)
            {
                var aanvraagDto = new VehicleAppealDto(aanvraag.Id, aanvraag.AanvraagType, aanvraag.Status, aanvraag.AanmaakDatum);
                aanvraagDtos.Add(aanvraagDto);
            }

            var voertuigDto = new VehicleDto(
                   voertuig.Id,
                   voertuigIdentiteitDto,
                    voertuig.Kilometerstanden,
                    onderhoudsbeurtDtos,
                    herstellingDtos,
                    aanvraagDtos);

            var VoertuigInfoDto = new VehicleInfoDto(chauffeurVoertuigDto, voertuigDto);

            return VoertuigInfoDto;
        }


            //check for null!

            #region Basic CRUD
            public async Task<ChauffeurDto> GetById(string id)
        {
            var readChauffeur = await _unitOfWork.Chauffeurs.GetById(int.Parse(id)); //!! validate the parse? + Does it include the classes in included entities?

            if (readChauffeur != null)
            {
                var chauffeurDto = new ChauffeurDto(
                readChauffeur.Id,
                readChauffeur.Identiteit.ConvertIdentiteitPersoon(),
                readChauffeur.Contactgegevens.ConvertContactgegevens(),
                readChauffeur.RijbewijsType,
                readChauffeur.InDienst,
                readChauffeur.Tankkaarten.ConvertTankkaartChauffeurs(),
                readChauffeur.Voertuigen.ConvertChauffeurVoertuigen(),
                readChauffeur.Aanvragen.ConvertReadAanvragen());

                return chauffeurDto;
            }

            return null;
        }

        public async Task<List<ChauffeurDto>> GetAll()
        {
            var chauffeurs = await _unitOfWork.Chauffeurs.GetAll();
            var chauffeurDtos = chauffeurs.ConvertReadChauffeurs();

            return chauffeurDtos;
        }

        public List<ChauffeurDto> Find(Expression<Func<ReadDriver, bool>> expression)
        {
            var readChauffeurs = _unitOfWork.Chauffeurs.Find(expression);
            var chauffeurDtos = readChauffeurs.ConvertReadChauffeurs();

            return chauffeurDtos;
        }

        public ICollection<TType> Select<TType>(Expression<Func<ChauffeurDto, TType>> select) 
        {
            return null;
        }

        public ICollection<TType> FindAndSelect<TType>(Expression<Func<ChauffeurDto, bool>> where, Expression<Func<ChauffeurDto, TType>> select) where TType : class 
        {
            return null;
        }
        public void Add(ChauffeurDto chauffeur) 
        {

        }

        public void AddRange(List<ChauffeurDto> entities)
        {

        }

        public async Task Remove(ChauffeurDto chauffeur)
        {
            var readChauffeur = chauffeur.RevertChauffeurDto();
            _unitOfWork.Chauffeurs.Remove(readChauffeur);
            _unitOfWork.Complete();
        }

        public async Task RemoveById(int id)
        {
            await _unitOfWork.Chauffeurs.RemoveById(id);
            _unitOfWork.Complete();
        }

        public async Task RemoveRange(List<ChauffeurDto> chauffeurDtos)
        {
            var chauffeurs = new List<ReadDriver>();
            foreach (var chauffeurDto in chauffeurDtos)
            {
                chauffeurs.Add(chauffeurDto.RevertChauffeurDto());
            }

            _unitOfWork.Chauffeurs.RemoveRange(chauffeurs);
            _unitOfWork.Complete();
        }

        public List<ChauffeurDto> Include(params Expression<Func<ChauffeurDto, object>>[] includes)
        {
            return null;
        }
        #endregion
    }
}
