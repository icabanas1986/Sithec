using Microsoft.AspNetCore.Mvc;
namespace Sithec.Models.Request
{
    public class OperacionHeaderRequest
    {
        [FromHeader]
        public double numerouno { get; set; }
        [FromHeader]
        public double numerodos { get; set; }
        [FromHeader]
        public char operador { get; set; }
    }
}