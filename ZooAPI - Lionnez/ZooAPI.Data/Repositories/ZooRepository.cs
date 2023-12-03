using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZooAPI.Data;
using ZooAPI.Model;

namespace ZooAPI.Data.Repositories
{
    public class ZooRepository : IZooRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public ZooRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection DbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Animal>> GetAllAnimais()
        {
            var db = DbConnection();
            var sql = "SELECT * FROM tbAnimal";
            return await db.QueryAsync<Animal>(sql);
        }

        public async Task<IEnumerable<Animal>> GetAnimaisByTipo(int tipoId)
        {
            var db = DbConnection();
            var sql = "SELECT * FROM tbAnimal WHERE tipo_id = @TipoId";
            return await db.QueryAsync<Animal>(sql, new { TipoId = tipoId });
        }

        public async Task<Animal> GetAnimalByNome(string nome)
        {
            var db = DbConnection();
            var sql = "SELECT * FROM tbAnimal WHERE nome = @Nome";
            return await db.QueryFirstOrDefaultAsync<Animal>(sql, new { Nome = nome });
        }

        public async Task<Animal> GetAnimalById(int id)
        {
            var db = DbConnection();
            var sql = "SELECT * FROM tbAnimal WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<Animal>(sql, new { Id = id });
        }

        public async Task<bool> InsertAnimal(Animal animal)
        {
            var db = DbConnection();
            var sql = "INSERT INTO tbAnimal (nome, tipo_id, descricao, habitat, pais, alimentacao, peso, altura, curiosidades, imagem, tipoanim, habitatResum) " +
                      "VALUES (@Nome, @TipoId, @Descricao, @Habitat, @Pais, @Alimentacao, @Peso, @Altura, @Curiosidades, @Imagem, @TipoAnim, @HabitatResum)";
            var result = await db.ExecuteAsync(sql, animal);
            return result > 0;
        }

        public async Task<bool> UpdateAnimal(Animal animal)
        {
            var db = DbConnection();
            var sql = "UPDATE tbAnimal SET nome = @Nome, tipo_id = @TipoId, descricao = @Descricao, habitat = @Habitat, " +
                      "pais = @Pais, alimentacao = @Alimentacao, peso = @Peso, altura = @Altura, " +
                      "curiosidades = @Curiosidades, imagem = @Imagem, tipoanim = @TipoAnim, habitatResum = @HabitatResum WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, animal);
            return result > 0;
        }

        public async Task<bool> DeleteAnimal(int id)
        {
            var db = DbConnection();
            var sql = "DELETE FROM tbAnimal WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<IEnumerable<TipoAnimal>> GetAllTiposAnimais()
        {
            var db = DbConnection();
            var sql = "SELECT * FROM tbTipoAnimal";
            return await db.QueryAsync<TipoAnimal>(sql);
        }

        public async Task<TipoAnimal> GetTipoAnimalById(int id)
        {
            var db = DbConnection();
            var sql = "SELECT * FROM tbTipoAnimal WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<TipoAnimal>(sql, new { Id = id });
        }

        public async Task<bool> InsertTipoAnimal(TipoAnimal tipoAnimal)
        {
            var db = DbConnection();
            var sql = "INSERT INTO tbTipoAnimal (nome) VALUES (@Nome)";
            var result = await db.ExecuteAsync(sql, tipoAnimal);
            return result > 0;
        }
        public async Task<bool> DeleteTipoAnimal(int id)
        {
            var db = DbConnection();
            var sql = "DELETE FROM tbTipoAnimal WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}
