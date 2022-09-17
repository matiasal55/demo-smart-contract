// SPDX-License-Identifier: MIT
pragma solidity >=0.6.0 <0.9.0;

contract Contrato{
    int _numero;

    function setNumero(int numero) public {
        _numero = numero;
    }

    function getNumero() public view returns (int) {
        return _numero;
    }
}