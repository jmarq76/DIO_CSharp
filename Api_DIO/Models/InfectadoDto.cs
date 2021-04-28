using System;

namespace Api_DIO.Data.Models
{
    public class InfectadoDto
    {
        public long Id { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}