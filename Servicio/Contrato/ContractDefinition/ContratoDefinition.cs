using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Servicio.Contracts.Contrato.ContractDefinition
{


    public partial class ContratoDeployment : ContratoDeploymentBase
    {
        public ContratoDeployment() : base(BYTECODE) { }
        public ContratoDeployment(string byteCode) : base(byteCode) { }
    }

    public class ContratoDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052348015600f57600080fd5b5060ac8061001e6000396000f3fe6080604052348015600f57600080fd5b506004361060325760003560e01c806302ff2fb314603757806323d2fd0014604c575b600080fd5b60005460405190815260200160405180910390f35b605c6057366004605e565b600055565b005b600060208284031215606f57600080fd5b503591905056fea2646970667358221220fb1c0abde42c31d29d5bef75c9a0d860c1a850dd442872ed0d91a1d85a32e3c564736f6c63430008110033";
        public ContratoDeploymentBase() : base(BYTECODE) { }
        public ContratoDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class GetNumeroFunction : GetNumeroFunctionBase { }

    [Function("getNumero", "int256")]
    public class GetNumeroFunctionBase : FunctionMessage
    {

    }

    public partial class SetNumeroFunction : SetNumeroFunctionBase { }

    [Function("setNumero")]
    public class SetNumeroFunctionBase : FunctionMessage
    {
        [Parameter("int256", "numero", 1)]
        public virtual BigInteger Numero { get; set; }
    }

    public partial class GetNumeroOutputDTO : GetNumeroOutputDTOBase { }

    [FunctionOutput]
    public class GetNumeroOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
