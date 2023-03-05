using Sithec.Models.Models;
using Sithec.Models.Respose;
using Sithec.Models.Request;

namespace Sithec.Interfaces
{

    public interface ISithec
    {
        Task<List<HumanoModel>> GetMock();
        Task<OperacionResponse> MakeOpe(OperacionRequest request);
        Task<CreaHumanoResponse> CreaHumano(CreaHumanoRequest request);
        Task<HumanoResponse> ObtieneHumanos();
        Task<HumanoResponse> ObtieneHumano(int id);

        Task<HumanoResponse> UpdateHumano(ActualizaHumanoRequest request);
    }
}