using System;
using System.Collections.Generic;
using DIO.Bank.Classes;

namespace DIO.Bank
{
    class Program
    {

        static List<Conta> listaContas = new List<Conta>();
        static List<LogHistory> listaLog = new List<LogHistory>();
        static List<Usuario> listaUsuarios = new List<Usuario>();

        static void Main(string[] args)
        {

            string login = ObterLogin();

            while (login.ToUpper() != "X")
            {
                switch (login)
                {
                    
                    case "1":
                        CadastrarUsuario();
                        break;
                    case "2":
                        if(AcessarSistema())
                        {
                            string opcaoUsuario = ObterOpcaoUsuario();

                            while (opcaoUsuario.ToUpper() != "V")
                            {
                            
                                switch (opcaoUsuario)
                                {
                                    case "1":
                                        ListarContas();
                                        break;
                                    case "2":
                                        InserirConta();
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
                                    case "6":
                                        ConsultaLog();
                                        break;
                                    case "C":
                                        Console.Clear();
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();

                                }

                                opcaoUsuario = ObterOpcaoUsuario();
                            }
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                login = ObterLogin();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
    }

        private static bool AcessarSistema()
        {
            Console.Write("Digite o nome do usuário: ");
            string userAcesso =  Console.ReadLine();

            Console.Write("Digite a senha: ");
            ConsoleKeyInfo infoChave;
            string senhaAcesso = "";

            do
            {
                infoChave = Console.ReadKey(true);
                if (infoChave.Key != ConsoleKey.Backspace && infoChave.Key != ConsoleKey.Enter)
                {
                    senhaAcesso += infoChave.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (infoChave.Key == ConsoleKey.Backspace && senhaAcesso.Length > 0)
                    {
                        senhaAcesso = senhaAcesso.Substring(0, (senhaAcesso.Length - 1));
                        Console.Write("b b");
                    }
                }
            } while (infoChave.Key != ConsoleKey.Enter);

            Usuario confereUser = new Usuario(userAcesso, senhaAcesso);

            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                if (listaUsuarios[i].Equals(confereUser))
                {
                    return true;
                }
            }

            Console.WriteLine("Usuário e/ou senha incorretos.");
            return false; 
        }

        private static void CadastrarUsuario()
        {
            Console.WriteLine("Introduza o nome do novo usário e nova senha");
            Console.WriteLine("Regras:");
            Console.WriteLine("Usuário tem de ter no mínimo 8 caracteres");
            Console.WriteLine("Senhas tem que ter no mínimo 8 caractares, composto por no mínimo: 1 número, 1 letra minúscula, 1 letra maiúscula e 1 caracter especial");

            Console.Write("Digite o nome do novo usuário: ");
            string username =  Console.ReadLine();

            Console.Write("Digite a nova senha: ");
            ConsoleKeyInfo infoChave;
            string senha = "";

            do
            {
                infoChave = Console.ReadKey(true);
                if (infoChave.Key != ConsoleKey.Backspace && infoChave.Key != ConsoleKey.Enter)
                {
                    senha += infoChave.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (infoChave.Key == ConsoleKey.Backspace && senha.Length > 0)
                    {
                        senha = senha.Substring(0, (senha.Length - 1));
                        Console.Write("b b");
                    }
                }
            } while (infoChave.Key != ConsoleKey.Enter);

            Usuario novoUsuario = new Usuario(username, senha);

            if (novoUsuario.CadastarUsuario())
            {
                listaUsuarios.Add(novoUsuario);
            }
            
        }

        private static void ConsultaLog()
        {
            if (listaLog.Count == 0)
            {
                Console.WriteLine("Não existe histórico para as contas");
                return;
            }

            for (int i = 0; i < listaLog.Count; i++)
            {
                LogHistory logHistory = listaLog[i];
                Console.WriteLine(logHistory);                  
            }
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);

            LogHistory logTransf = new LogHistory(listaLog.Count, 
                                                  TipoLog.Transferencia, 
                                                  listaContas[indiceContaOrigem].GetName(), 
                                                  valorTransferencia, 
                                                  $"Transferência de R${valorTransferencia} realizada da conta número {indiceContaOrigem} de {listaContas[indiceContaOrigem].GetName()} " +
                                                  $"para a conta número {indiceContaDestino} de {listaContas[indiceContaDestino].GetName()}");

            listaLog.Add(logTransf);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);

            LogHistory logDeposito = new LogHistory(listaLog.Count, 
                                                    TipoLog.Deposito, 
                                                    listaContas[indiceConta].GetName(), 
                                                    valorDeposito, 
                                                    $"Depósito de R${valorDeposito} realizado na conta número {indiceConta} de {listaContas[indiceConta].GetName()}");

            listaLog.Add(logDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);

            LogHistory logSaque = new LogHistory(listaLog.Count, 
                                                 TipoLog.Saque, 
                                                 listaContas[indiceConta].GetName(), 
                                                 valorSaque, 
                                                 $"Saque de R${valorSaque} realizado na conta número {indiceConta} de {listaContas[indiceConta].GetName()}");

            listaLog.Add(logSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            /* LogHistory logConsultas = new LogHistory(listaLog.Count, 
                                                     TipoLog.Consulta, 
                                                     usuario, 
                                                     null, 
                                                     $"{usuario} fez consulta às contas em {System.DateTime()}");

            listaLog.Add(logConsultas); */

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listaContas.Add(novaConta);

            LogHistory contaCriada = new LogHistory(listaLog.Count, 
                                                     TipoLog.ContaCriada, 
                                                     novaConta.GetName(), 
                                                     entradaSaldo, 
                                                     $"Criada conta para {novaConta.GetName()}, com saldo inicial {entradaSaldo}");

            listaLog.Add(contaCriada);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- Consulta Logs");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("V- Voltar");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static string ObterLogin()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Criar novo usuário");
            Console.WriteLine("2- Acessar Sistema");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string login = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return login;
        }
    }
}
