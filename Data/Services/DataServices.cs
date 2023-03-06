using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sithec.Data.Context;
using Sithec.Data.Interface;
using Sithec.Data.Models;
using Sithec.Models.Request;

namespace Sithec.Data.Services
{
    public class DataServices:IDataServices
    {
        ILogger<DataServices> logger;
        private DataBaseContext dbContext;
        private readonly IMapper mapper;

        public DataServices(ILogger<DataServices> _logger,DataBaseContext _dbContext,IMapper _mapper)
        {
            logger = _logger;
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public async Task<Humano> CreaHumano(CreaHumanoRequest request)
        {
            Humano humano = mapper.Map<Humano>(request);
            dbContext.Humanos.Add(humano);
            int insertado = await dbContext.SaveChangesAsync();
            if(Convert.ToBoolean(insertado))
            {
                return humano;
            }
            return null;
        }

        public async Task<List<Humano>> ObtieneHumanos()
        {
            var lista = dbContext.Humanos.ToList();
            return lista;
        }

        public async Task<Humano> ObtieneHumano(int id)
        {
            var humano = await dbContext.Humanos.Where(h=>h.Id.Equals(id)).FirstOrDefaultAsync();
            return humano;
        }

        public async Task<Humano> ActualizaHumano(ActualizaHumanoRequest request)
        {
            Humano humano = await dbContext.Humanos.Where(h=>h.Id.Equals(request.Id)).FirstOrDefaultAsync();
            if(humano!=null)
            {
                humano = mapper.Map<Humano>(request);
                dbContext.Humanos.Update(humano);
                var updated = await dbContext.SaveChangesAsync();
                if(Convert.ToBoolean(updated))
                {
                    return humano;
                }
                else{
                    return null;
                }
            }
            return null;
        }
    }
}