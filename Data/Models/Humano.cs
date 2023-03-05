using System;
using System.Collections.Generic;

namespace Sithec.Data.Models
{
    public partial class Humano
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public int Edad { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
    }
}
