using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooAPI.Data.Repositories;
using ZooAPI.Data;
using ZooAPI.Model;

public class ZooRepository : IZooRepository
{
    private MySQLConfiguration _connectionString;

    public ZooRepository(MySQLConfiguration connectionString)
    {
        _connectionString = connectionString;
    }

    protected MySqlConnection dbConnection()
    {
        return new MySqlConnection(_connectionString.ConnectionString);
    }

    public async Task<IEnumerable<Animal>> GetAllAnimais()
    {
        var db = dbConnection();
        var sql = "SELECT * FROM tbAnimal";
        return await db.QueryAsync<Animal>(sql, new { });
    }

    public async Task<IEnumerable<TipoAnimal>> GetAllTiposAnimais()
    {
        var db = dbConnection();
        var sql = "SELECT * FROM tbTipoAnimal";
        return await db.QueryAsync<TipoAnimal>(sql, new { });
    }

    public async Task<IEnumerable<Animal>> GetAnimaisByTipo(int tipoId)
    {
        var db = dbConnection();
        var sql = "SELECT * FROM tbAnimal WHERE tipo_id = @TipoId";
        return await db.QueryAsync<Animal>(sql, new { TipoId = tipoId });
    }

    public async Task<Animal> GetAnimalById(int id)
    {
        var db = dbConnection();
        var sql = "SELECT * FROM tbAnimal WHERE id = @Id";
        return await db.QueryFirstOrDefaultAsync<Animal>(sql, new { Id = id });
    }

    public async Task<TipoAnimal> GetTipoAnimalById(int id)
    {
        var db = dbConnection();
        var sql = "SELECT * FROM tbTipoAnimal WHERE id = @Id";
        return await db.QueryFirstOrDefaultAsync<TipoAnimal>(sql, new { Id = id });
    }

    public async Task<bool> InsertAnimal(Animal animal)
    {
        var db = dbConnection();
        var sql = "INSERT INTO tbAnimal (nome, tipo_id, descricao, habitat, pais, alimentacao, peso, altura, curiosidades, imagem) " +
                  "VALUES (@Nome, @TipoId, @Descricao, @Habitat, @Pais, @Alimentacao, @Peso, @Altura, @Curiosidades, @Imagem)";
        var result = await db.ExecuteAsync(sql, animal);
        return result > 0;
    }

    public async Task<bool> InsertTipoAnimal(TipoAnimal tipoAnimal)
    {
        var db = dbConnection();
        var sql = "INSERT INTO tbTipoAnimal (nome) VALUES (@Nome)";
        var result = await db.ExecuteAsync(sql, tipoAnimal);
        return result > 0;
    }

    public async Task<bool> UpdateAnimal(Animal animal)
    {
        var db = dbConnection();
        var sql = "UPDATE tbAnimal SET nome = @Nome, descricao = @Descricao, habitat = @Habitat, " +
                  "pais = @Pais, alimentacao = @Alimentacao, peso = @Peso, altura = @Altura, " +
                  "curiosidades = @Curiosidades, imagem = @Imagem WHERE id = @Id";
        var result = await db.ExecuteAsync(sql, animal);
        return result > 0;
    }
}
