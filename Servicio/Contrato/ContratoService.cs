using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Servicio.Contracts.Contrato.ContractDefinition;

namespace Servicio.Contracts.Contrato
{
    public partial class ContratoService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ContratoDeployment contratoDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ContratoDeployment>().SendRequestAndWaitForReceiptAsync(contratoDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ContratoDeployment contratoDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ContratoDeployment>().SendRequestAsync(contratoDeployment);
        }

        public static async Task<ContratoService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ContratoDeployment contratoDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, contratoDeployment, cancellationTokenSource);
            return new ContratoService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ContratoService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> GetNumeroQueryAsync(GetNumeroFunction getNumeroFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNumeroFunction, BigInteger>(getNumeroFunction, blockParameter);
        }

        
        public Task<BigInteger> GetNumeroQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNumeroFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> SetNumeroRequestAsync(SetNumeroFunction setNumeroFunction)
        {
             return ContractHandler.SendRequestAsync(setNumeroFunction);
        }

        public Task<TransactionReceipt> SetNumeroRequestAndWaitForReceiptAsync(SetNumeroFunction setNumeroFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNumeroFunction, cancellationToken);
        }

        public Task<string> SetNumeroRequestAsync(BigInteger numero)
        {
            var setNumeroFunction = new SetNumeroFunction();
                setNumeroFunction.Numero = numero;
            
             return ContractHandler.SendRequestAsync(setNumeroFunction);
        }

        public Task<TransactionReceipt> SetNumeroRequestAndWaitForReceiptAsync(BigInteger numero, CancellationTokenSource cancellationToken = null)
        {
            var setNumeroFunction = new SetNumeroFunction();
                setNumeroFunction.Numero = numero;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNumeroFunction, cancellationToken);
        }
    }
}
