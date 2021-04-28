using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Api_DIO.Data.Collections
{
    public class Curado : Identificacao
    {
        public long Id { get; set; }

        public string Sexo { get; set; }

        public DateTime DataNascimento { get; set; }

        public GeoJson2DGeographicCoordinates Localizacao { get; set; }

        public Curado(long id, string sexo, DateTime dataNascimento, double latitude, double longitude)
        {
            this.Id = id;
            this.Sexo = sexo;
            this.DataNascimento = dataNascimento;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
    }
}