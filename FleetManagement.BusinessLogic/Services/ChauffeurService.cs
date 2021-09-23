using FleetManagement.Domain.Interfaces;
using FleetManagement.Framework.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class ChauffeurService : GeneralServices, IFleetManagementService<ChauffeurDto>
    {
        public IUnitOfWork _unitOfWork { get; set; } //telkens saven en disposen?
        public ChauffeurService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ChauffeurDto> GetById(string id)
        {
            var readChauffeur = await _unitOfWork.Chauffeurs.GetById(int.Parse(id)); // validate the parse? + Does it include the classes in included entities?

            var chauffeurDto = new ChauffeurDto(
                readChauffeur.Id,
                ConvertIdentiteitPersoon(readChauffeur.Identiteit),
                ConvertContactgegevens(readChauffeur.Contactgegevens),
                readChauffeur.RijbewijsType,
                readChauffeur.InDienst,
                ConvertTankkaartChauffeurs(readChauffeur.Tankkaarten),
                ConvertChauffeurVoertuigen(readChauffeur.Voertuigen),
                ConvertAanvragen(readChauffeur.Aanvragen));

            return chauffeurDto;
        }

        public async Task<List<ChauffeurDto>> GetAll()
        {
            var chauffeurs = await _unitOfWork.Chauffeurs.GetAll();
            var chauffeurDtos = ConvertChauffeurs(chauffeurs);

            return chauffeurDtos;
        }

        public List<ChauffeurDto> Find(Expression<Func<ChauffeurDto, bool>> expression) // fill in parameters
        {
            var chauffeurDtos = new List<ChauffeurDto>();
            return chauffeurDtos;
        }

        public ICollection<TType> Select<TType>(Expression<Func<ChauffeurDto, TType>> select) // fill in parameters
        {
            return null;
        }

        public ICollection<TType> FindAndSelect<TType>(Expression<Func<ChauffeurDto, bool>> where, Expression<Func<ChauffeurDto, TType>> select) where TType : class // fill in parameters
        {
            return null;
        }
        public void Add(ChauffeurDto chauffeur) // reverse convert!
        {

        }

        public void AddRange(List<ChauffeurDto> entities)
        {

        }

        public void Remove(ChauffeurDto chauffeur) // convert
        {
            var readChauffeur = ConvertToReadChauffeur(chauffeur);
            _unitOfWork.Chauffeurs.Remove(chauffeur);
            _unitOfWork.Complete();
        }

        public void RemoveById(int id)
        {

        }

        public void RemoveRange(List<ChauffeurDto> entities)
        {
        }

        public List<ChauffeurDto> Include(params Expression<Func<ChauffeurDto, object>>[] includes)
        {
            return null;
        }
    }
}
