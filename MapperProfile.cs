
using AutoMapper;
using Sithec.Data.Models;
using Sithec.Models.Models;
using Sithec.Models.Request;

namespace Sithec
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CreaHumanoRequest,Humano>();
            CreateMap<ActualizaHumanoRequest,Humano>();
            CreateMap<Humano,HumanoModel>();
        }
    }
}