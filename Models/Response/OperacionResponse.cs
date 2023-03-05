using Sithec.Models.Models;

namespace Sithec.Models.Respose
{
    public class OperacionResponse
    {
        public int CodigoEstatus {get;set;}
        public string Descripcion { get; set; }
        public Operacion Datos { get; set; }
    }
}