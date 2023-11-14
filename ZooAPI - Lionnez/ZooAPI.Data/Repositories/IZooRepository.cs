// IZooRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using ZooAPI.Model;

namespace ZooAPI.Data.Repositories
{
    public interface IZooRepository
    {
        Task<IEnumerable<Animal>> GetAllAnimais();
        Task<IEnumerable<Animal>> GetAnimaisByTipo(int tipoId);
        Task<Animal> GetAnimalById(int id);
        Task<bool> InsertAnimal(Animal animal);
        Task<bool> UpdateAnimal(Animal animal);
        Task<bool> DeleteAnimal(int id);

        Task<IEnumerable<TipoAnimal>> GetAllTiposAnimais();
        Task<TipoAnimal> GetTipoAnimalById(int id);
        Task<bool> InsertTipoAnimal(TipoAnimal tipoAnimal);
        Task<bool> DeleteTipoAnimal(int id);
    }
}
