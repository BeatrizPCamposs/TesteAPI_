using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooAPI.Model;

namespace ZooAPI.Data.Repositories
{
    public interface IZooRepository
    {
        // Tipos de Animais
        Task<IEnumerable<TipoAnimal>> GetAllTiposAnimais();
        Task<TipoAnimal> GetTipoAnimalById(int id);
        Task<bool> InsertTipoAnimal(TipoAnimal tipoAnimal);

        // Animais
        Task<IEnumerable<Animal>> GetAllAnimais();
        Task<IEnumerable<Animal>> GetAnimaisByTipo(int tipoId);
        Task<Animal> GetAnimalById(int id);
        Task<bool> InsertAnimal(Animal animal);
        Task<bool> UpdateAnimal(Animal animal);
    }
}
