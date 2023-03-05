using Sithec.Models.Models;

namespace Sithec.Models.Respose
{
    public class HumanoResponse
    {
        public int CodigoEstatus {get;set;}
        public string Descripcion { get; set; }
        public List<HumanoModel> Datos { get; set; }
    }
}