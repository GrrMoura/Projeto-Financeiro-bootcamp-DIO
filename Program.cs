using System.Globalization;
using System;
using System.Collections.Generic;
using teste.Classes;
using teste.Enums;

namespace aumento_de_salario

{

    class Financeiro

    {
        static List<Contas> ListaContas = new List<Contas>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirContas();
                        break;

                    case "3":
                        Transferir();
                        break;

                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterUsuario();
            }
            Console.WriteLine("Obrigado por usar nossos serviços");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta origem");
            int indiceContaOrigem = int.Parse(Console.ReadLine());


            Console.WriteLine("Valor a ser tranferido");
            double valorTranferido = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta Destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());


            ListaContas[indiceContaOrigem].Tranferir(valorTranferido,ListaContas[indiceContaDestino]);
            
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Valor a ser depositado");
            double valorDeposito = double.Parse(Console.ReadLine());

            ListaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Valor a ser sacado");
            double valorSaque = double.Parse(Console.ReadLine());

            ListaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            if (ListaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < ListaContas.Count; i++)
            {
                Contas contas = ListaContas[i];
                Console.WriteLine("#{0} - ", i+1);
                Console.WriteLine(contas);
            }
        }

        private static void InserirContas()
        {
            Console.WriteLine("Inserir Nova Conta");

            Console.WriteLine("Digite 1 para Conta Física ou 2 Para Jurídica: ");
            int entradaTipoPessoa = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Digite seu saldo Inicial");
            double saldoInit = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito");
            double creditoInit = double.Parse(Console.ReadLine());

            Contas novaConta = new Contas((TipoPessoa)entradaTipoPessoa, saldoInit, creditoInit, nomeCliente);

            ListaContas.Add(novaConta);
        }

        private static string ObterUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Banco Rocha pronto para te atender");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir nova Conta");
            Console.WriteLine("3- Tranferir");
            Console.WriteLine("4- Scar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }

}