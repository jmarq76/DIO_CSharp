using System;

namespace Api_DIO.Models
{
    public class CuradoDto
    {
        public long Id { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}