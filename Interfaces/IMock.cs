using Sithec.Models.Models;

namespace Sithec.Interfaces
{
    public interface IMock
    {
        Task<List<Humano>> GetMock();
    }
}