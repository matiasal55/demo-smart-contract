using System.Threading.Tasks;
using Nethereum.ABI.Util;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Servicio.Contracts.Contrato;
using Servicio.Contracts.Contrato.ContractDefinition;

namespace Servicio
{
    public class ServicioContrato : IServicioContrato
    {
        public async Task<object> CrearContrato()
        {
            var url = "http://localhost:7545";
            var privateKey = "d0598d641326d9b33e861dffab43ce1211986ac7107f0a21740523b76c9037a3";
            var account = new Account(privateKey);
            var web3 = new Web3(account, url);
            web3.TransactionManager.UseLegacyAsDefault = true;
            
            var deployment = new ContratoDeployment();
            var receipt = await ContratoService.DeployContractAndWaitForReceiptAsync(web3, deployment);
            return receipt;
        }

        public async Task<object> SetNumero(ContratoPostReq request)
        {
            var url = "http://localhost:7545";
            var privateKey = "d0598d641326d9b33e861dffab43ce1211986ac7107f0a21740523b76c9037a3";
            var account = new Account(privateKey);
            var web3 = new Web3(account, url);
            web3.TransactionManager.UseLegacyAsDefault = true;
            
            var contractAddress = request.ContractAddress;
            var service = new ContratoService(web3, contractAddress);
            var receiptForSetFunctionCall = await service.SetNumeroRequestAndWaitForReceiptAsync(new SetNumeroFunction()
                {
                    Numero = request.Numero,
                    //Gas = 400000
                });
            return receiptForSetFunctionCall;
        }

        public async Task<object> GetNumero(ContratoGetReq request)
        {
            var url = "http://localhost:7545";
            var web3 = new Web3(url);

            var contractAddress = request.ContractAddress;
            var service = new ContratoService(web3, contractAddress);
            var currentStoredValue = await service.GetNumeroQueryAsync();
            return new
            {
                numero = currentStoredValue.ToString()
            };
        }
    }
}