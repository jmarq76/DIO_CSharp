using System;
using Api_DIO.Data.Collections;
using Api_DIO.Data.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api_DIO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {

            var idInfectado = _infectadosCollection.CountDocuments(Builders<Infectado>.Filter.Empty) + 1;


            var infectado = new Infectado(idInfectado, dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }

        [HttpPut]
        public ActionResult AtualizarInfectado([FromBody] InfectadoDto dto)
        {

            _infectadosCollection.UpdateOne(Builders<Infectado>.Filter.Where(_ => _.Id == dto.Id), Builders<Infectado>.Update.Set("sexo", dto.Sexo));
            
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {

            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(_ => _.Id == id));
            
            return Ok("Apagado com sucesso");
        }

        [HttpGet("{id}")]
        public ActionResult ObterInfectadosPorId(long id)
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Where(_ => _.Id == id)).ToList();
            
            return Ok(infectados);
        }
    }
}