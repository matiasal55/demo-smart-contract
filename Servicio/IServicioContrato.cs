using System.Threading.Tasks;

namespace Servicio
{
    public interface IServicioContrato
    {
        Task<object> CrearContrato();
        Task<object> SetNumero(ContratoPostReq request);
        Task<object> GetNumero(ContratoGetReq request);
    }
}