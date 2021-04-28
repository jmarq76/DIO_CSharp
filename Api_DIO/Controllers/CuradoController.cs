using Api_DIO.Data.Collections;
using Api_DIO.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api_DIO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuradoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Curado> _curadosCollection;

        public CuradoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _curadosCollection = _mongoDB.DB.GetCollection<Curado>(typeof(Curado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarCurado([FromBody] CuradoDto dto)
        {
            var idCurado = _curadosCollection.CountDocuments(Builders<Curado>.Filter.Empty) + 1;

            var curado = new Curado(idCurado, dto.Sexo, dto.DataNascimento, dto.Latitude, dto.Longitude);

            _curadosCollection.InsertOne(curado);

            return StatusCode(201, "Curado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterCurados()
        {
            var curados = _curadosCollection.Find(Builders<Curado>.Filter.Empty).ToList();

            return Ok(curados);
        }

        [HttpPut]
        public ActionResult AtualizarCurados([FromBody] CuradoDto dto)
        {
            _curadosCollection.UpdateOne(Builders<Curado>.Filter.Where(_ => _.Id == dto.Id), Builders<Curado>.Update.Set("sexo", dto.Sexo));

            return Ok("Curado Atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public ActionResult ApagaCuradoId(long id)
        {
            _curadosCollection.DeleteOne(Builders<Curado>.Filter.Where(_ => _.Id == id));

            return Ok("Apagado com sucesso");
        }

        [HttpGet("{id}")]
        public ActionResult ObterCuradoPorId(long id)
        {
            var curado = _curadosCollection.Find(Builders<Curado>.Filter.Where(_ => _.Id == id)).ToList();

            return Ok(curado);
        }
        
    }
}