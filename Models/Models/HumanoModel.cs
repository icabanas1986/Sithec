using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sithec.Models.Models
{
    public class HumanoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
    }
}