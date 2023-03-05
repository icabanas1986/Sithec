using Sithec.Models.Models;

namespace Sithec.Models.Respose
{
    public class CreaHumanoResponse
    {
        public int CodigoEstatus {get;set;}
        public string Descripcion { get; set; }
        public HumanoModel Datos { get; set; }
    }
}