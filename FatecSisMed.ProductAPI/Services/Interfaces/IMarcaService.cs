using FatecSisMed.MedicoAPI.DTO.Entities;

namespace FatecSisMed.MedicoAPI.Services.Interfaces
{
    public interface IMarcaService
    {
        Task<IEnumerable<MarcaDTO>> GetAll();
        Task<MarcaDTO> GetById(int id);
        Task Create(MarcaDTO MarcaDTO);
        Task Update(MarcaDTO MarcaDTO);
        Task Remove(int id);
    }
}
