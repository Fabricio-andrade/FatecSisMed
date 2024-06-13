using FatecSisMed.MedicoAPI.DTO.Entities;

namespace FatecSisMed.MedicoAPI.Services.Interfaces
{
    public interface IRemedioService
    {
        Task<IEnumerable<RemedioDTO>> GetAll();
        Task<RemedioDTO> GetById(int id);
        Task Create(RemedioDTO RemedioDTO);
        Task Update(RemedioDTO RemedioDTO);
        Task Remove(int id);
    }
}
