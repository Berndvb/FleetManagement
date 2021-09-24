using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class ChauffeurBeheerService 
    {
        public IUnitOfWork _unitOfWork { get; set; } //telkens saven en disposen?

        public ChauffeurBeheerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ChauffeurDto> GetChauffeursSynopsis() // returns id, naam, rijbewijsType, InDienst (~ the synopsis)
        {
            var readChauffeurs = _unitOfWork.Chauffeurs.Include(x => x.Identiteit.Naam).ToList();
            var chauffeurDtos = readChauffeurs.ConvertReadChauffeurs();
            return chauffeurDtos;
        }

        public async Task<ChauffeurDto> GetChauffeurDetails(string id) // returns id, identiteit, contactgegevens, rijbewijsttype and indienst (~ the details)
        {
            var readChauffeur = await _unitOfWork.Chauffeurs.GetByIdWithIncludesAsync(int.Parse(id), x => new { x.Identiteit, x.Contactgegevens });
            var chauffeurDto = readChauffeur.ConvertReadChauffeur();
            return chauffeurDto;
        }

        public async Task GetChauffeurVoertuigen(string chauffeurId) // need a list of chauffeurVoertuig for that specific chauffeur, with the correct voertuig AND identiteitvoertuig
        {
            var chauffeurVoertuigen = _unitOfWork.ChauffeurVoertuigen.Find(x => x.Chauffeur.Id == chauffeurId).ToList();
            var voertuigenIds = chauffeurVoertuigen.Select(x => x.Voertuig.Id).ToList();
            var voertuigen = (await _unitOfWork.Voertuigen.FindWithIncludesAsync(x => voertuigenIds.Contains(x.Id), x => x.Identiteit)).ToList();

            //herstellingen - select date's, status and Ids
            var herstellingenInfo = _unitOfWork.Herstellingen.FindAndSelect(x => voertuigenIds.Contains(x.Id), x => new { x.UitvoeringsDatum, x.Id, x.HerstellingStatus, x.DatumVoorval });
            //chauffeurs
            //aanvragen
        }


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

        public List<ChauffeurDto> Find(Expression<Func<ReadChauffeur, bool>> expression)
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
            var chauffeurs = new List<ReadChauffeur>();
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
