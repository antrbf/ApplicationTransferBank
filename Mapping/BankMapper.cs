using BankModelTransfer.Enums;
using System;

namespace BankModelTransfer.Mapping
{
    public class Conta
	{
		// Atributos
		public TipoConta TipoConta { get; set; }
		public double Saldo { get; set; }
		public double Credito { get; set; }
		public string Nome { get; set; }

		// Métodos
		public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
		}

		public bool Sacar(double valorSaque)
		{
			// Validação de saldo suficiente
			if (this.Saldo - valorSaque < (this.Credito * -1))
			{
				Console.WriteLine("Saldo insuficiente! Verifique seu saldo disponível!");
				return false;
			}
			this.Saldo -= valorSaque;

			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
			// https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

			return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

			Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}
		public void ConsultarSaldo()
		{
			Console.WriteLine("Saldo atual da conta de {0} é R${1} e de credito é R${2}", this.Nome, this.Saldo, this.Credito);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia))
		
				contaDestino.Depositar(valorTransferencia);			
		}

		public override string ToString()
		{
			string retorno = "";
			retorno += "TipoConta: " + this.TipoConta + " | ";
			retorno += "Nome: " + this.Nome + " | ";
			retorno += "Saldo: R$ " + this.Saldo + " | ";
			retorno += "Crédito: R$ " + this.Credito;
			return retorno;
		}
	}
}