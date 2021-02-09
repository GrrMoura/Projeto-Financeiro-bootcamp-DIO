using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste.Enums;

namespace teste.Classes
{
    class Contas
    {
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoPessoa TipoPessoa { get; set; }

        public Contas(TipoPessoa tipoPessoa,double saldo, double credito,string nome)
        {
            this.TipoPessoa = tipoPessoa;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;

        }
        public bool Sacar(double valorSaque) 
        {
            if (this.Saldo - valorSaque < (this.Credito * -1)) 
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} e {1}",this.Nome,this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito) 
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} e {1}", this.Nome, this.Saldo);
        }

        public void Tranferir(double valorTransferencia, Contas contaDestino)
        { 
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoPessoa+" | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito + " | ";

            return retorno;
        }
    }
}
