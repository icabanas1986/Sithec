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

        public DataServices(ILogger<DataServices> _logger,DataBaseContext _dbContext)
        {
            logger = _logger;
            dbContext = _dbContext;
        }

        public async Task<Humano> CreaHumano(CreaHumanoRequest request)
        {
            Humano humano = new Humano()
            {
                Altura = request.Altura,
                Edad = request.Edad,
                Nombre = request.Nombre,
                Peso = request.Peso,
                Sexo  = request.Sexo
            };
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
            var humano = await dbContext.Humanos.Where(h=>h.Id.Equals(request.Id)).FirstOrDefaultAsync();
            if(humano!=null)
            {
                Humano humanoUpd = new Humano()
                {
                    Altura = request.Altura,
                    Edad = request.Edad,
                    Nombre = request.Nombre,
                    Peso = request.Peso,
                    Sexo = request.Sexo,
                    Id = request.Id
                };

                dbContext.Humanos.Update(humanoUpd);
                var updated = await dbContext.SaveChangesAsync();
                if(Convert.ToBoolean(updated))
                {
                    return humanoUpd;
                }
                else{
                    return null;
                }
            }
            return null;
        }
    }
}