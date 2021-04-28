using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api_DIO.Data.Collections
{
    public class Infectado : Identificacao
    {
         public Infectado(long id, DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            this.Id = id;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
        public long Id { get; set; }
    }
}