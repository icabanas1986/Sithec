using Sithec.Interfaces;
using Sithec.Models.Models;

namespace Sithec.Services
{
    public class Mock:IMock
    {
        ILogger<Mock> logger;
        
        public Mock(ILogger<Mock> _logger)
        {
            logger = _logger;
        }

        public async Task<List<Humano>> GetMock()
        {
            List<Humano> arrayHumano = new List<Humano>();
            Humano humano = new Humano();
            humano.Id = 1;
            humano.Nombre = "Ivan";
            humano.Peso = "90kg";
            humano.Sexo = "Masculino";
            humano.Edad = "36";
            humano.Altura = "170cm";
            arrayHumano.Add(humano);
            humano = new Humano();
            humano.Id = 2;
            humano.Nombre = "Jorge";
            humano.Peso = "70kg";
            humano.Sexo = "Masculino";
            humano.Edad = "30";
            humano.Altura = "180cm";
            arrayHumano.Add(humano);
            humano = new Humano();
            humano.Id = 3;
            humano.Nombre = "Ana";
            humano.Peso = "50kg";
            humano.Sexo = "Femenino";
            humano.Edad = "27";
            humano.Altura = "160cm";
            arrayHumano.Add(humano);
            humano = new Humano();

            return arrayHumano;
        }
    }
}