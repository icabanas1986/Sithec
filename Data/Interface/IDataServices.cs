using Sithec.Models.Request;
using Sithec.Data.Models;


namespace Sithec.Data.Interface
{
    public interface IDataServices
    {
        Task<Humano> CreaHumano(CreaHumanoRequest request);

        Task<List<Humano>> ObtieneHumanos();

        Task<Humano> ObtieneHumano(int id);

        Task<Humano> ActualizaHumano(ActualizaHumanoRequest request);


    }
}