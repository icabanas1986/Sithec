using Sithec.Data.Interface;
using Sithec.Interfaces;
using Sithec.Models.Models;
using Sithec.Models.Request;
using Sithec.Models.Respose;
using AutoMapper;

namespace Sithec.Services
{
    public class Sithec:ISithec
    {
        ILogger<Sithec> logger;
        IDataServices dataServices;
        
        private readonly IMapper mapper;
        public Sithec(ILogger<Sithec> _logger,IDataServices _dataServices,IMapper _mapper)
        {
            logger = _logger;
            dataServices = _dataServices;
            mapper = _mapper;
        }

        public async Task<List<HumanoModel>> GetMock()
        {
            List<HumanoModel> arrayHumano = new List<HumanoModel>();
            HumanoModel humano = new HumanoModel();
            humano.Id = 1;
            humano.Nombre = "Ivan";
            humano.Peso = 90;
            humano.Sexo = "Masculino";
            humano.Edad = 36;
            humano.Altura = 1.70;
            arrayHumano.Add(humano);
            humano = new HumanoModel();
            humano.Id = 2;
            humano.Nombre = "Jorge";
            humano.Peso = 70;
            humano.Sexo = "Masculino";
            humano.Edad = 30;
            humano.Altura = 1.80;
            arrayHumano.Add(humano);
            humano = new HumanoModel();
            humano.Id = 3;
            humano.Nombre = "Ana";
            humano.Peso = 50;
            humano.Sexo = "Femenino";
            humano.Edad = 27;
            humano.Altura = 1.60;
            arrayHumano.Add(humano);
            humano = new HumanoModel();

            return arrayHumano;
        }
    
        public async Task<OperacionResponse> MakeOpe(OperacionRequest request)
        {
            bool error = false;
            Operacion operacion = new Operacion();
            switch(request.Operador)
            {
                case '+':
                    operacion.Resultado = request.numerouno + request.numerodos;
                break;
                case '-':
                    operacion.Resultado = request.numerouno - request.numerodos;
                break;
                case '/':
                    operacion.Resultado = request.numerouno / request.numerodos;
                break;
                case 'x':
                    operacion.Resultado = request.numerouno * request.numerodos;
                break;
                default:
                    error = true;
                break;
            }
            return new OperacionResponse()
            {
                CodigoEstatus = error==true?400:200,
                Datos = operacion,
                Descripcion = error==true?"Error:Operador no permitido":"OK"
            };
        }
        public async Task<CreaHumanoResponse> CreaHumano(CreaHumanoRequest request)
        {
                CreaHumanoResponse response = new CreaHumanoResponse();
                HumanoModel model = new HumanoModel();
                var humano = await dataServices.CreaHumano(request);
                if(humano!=null)
                {
                    response.Datos = mapper.Map<HumanoModel>(humano);
                    response.CodigoEstatus = 200;
                    response.Descripcion = "OK:Humano creado con exito";
                }
                else
                {
                    response.Datos = model;
                    response.CodigoEstatus = 400;
                    response.Descripcion = "ERROR:No se pudo crear humano";
                }
                return response;
        }

        public async Task<HumanoResponse> ObtieneHumanos()
        {
            HumanoResponse response = new HumanoResponse();
            List<HumanoModel> humanoList = new List<HumanoModel>();
            var humanos = await dataServices.ObtieneHumanos();
            if(humanos.Count>0)
            {
                foreach(var humano in humanos)
                {
                    humanoList.Add(mapper.Map<HumanoModel>(humano));
                }
                response.Datos = humanoList;
                response.CodigoEstatus = 200;
                response.Descripcion = "Ok";
                return response;
            }
            else{
                response.Datos = new List<HumanoModel>();
                response.CodigoEstatus = 400;
                response.Descripcion = "No se encontraron datos.";
                return response;
            }
        }

        public async Task<HumanoResponse> ObtieneHumano(int id)
        {
            HumanoResponse response = new HumanoResponse();
            List<HumanoModel> humanoList = new List<HumanoModel>();
            var humano = await dataServices.ObtieneHumano(id);
            if(humano!=null)
            {
                humanoList.Add(mapper.Map<HumanoModel>(humano));
                response.Datos = humanoList;
                response.CodigoEstatus = 200;
                response.Descripcion = "Ok";
                return response;
            }
            else{
                response.Datos = new List<HumanoModel>();
                response.CodigoEstatus = 400;
                response.Descripcion = "No se encontraron datos.";
                return response;
            }
        }

        public async Task<HumanoResponse> UpdateHumano(ActualizaHumanoRequest request)
        {
            HumanoResponse response = new HumanoResponse();
            List<HumanoModel> humanoList = new List<HumanoModel>();
            var humano = await dataServices.ActualizaHumano(request);
            if(humano!=null)
            {
                humanoList.Add(mapper.Map<HumanoModel>(humano));
                response.CodigoEstatus = 200;
                response.Datos = humanoList;
                response.Descripcion = "Ok";
                return response;
            }
            else
            {
                response.Datos = new List<HumanoModel>();
                response.CodigoEstatus = 400;
                response.Descripcion = "No se encontraron datos.";
                return response;
            }
        }
    }
}