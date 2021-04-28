using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api_DIO.Data.Collections
{
    public class Infectado : InfectadoId
    {
         public Infectado(long id, DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            this.id = id;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
        public long id { get; set; }
    }
}