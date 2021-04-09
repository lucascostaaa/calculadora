﻿using System;

namespace Calculadora.ConsoleApp
{
    class Program
    {
        #region Requisito 01 [OK]
        //Nossa calculadora deve ter a possibilidade de somar dois números
        #endregion

        #region Requisito 02 [OK]
        //Nossa calculadora deve ter a possibilidade fazer várias operações de soma
        #endregion

        #region Requisito 03 [OK]
        //Nossa calculadora deve ter a possibilidade fazer várias operações de soma e de subtração
        #endregion

        #region Requisito 04 [OK]
        //Nossa calculadora deve ter a possibilidade fazer as quatro operações básicas da matemática
        #endregion

        #region Requisito 05 [OK]
        //Nossa calculadora deve validar a opções do menu [OK]
        #endregion

        #region BUG 01 [OK]
        //Nossa calculadora deve realizar as operações com "0"
        #endregion

        #region Requisito 06
        /** Nossa calculadora deve permitir visualizar as operações já realizadas
         *  Critérios:
         *      1 - A descrição da operação realizada deve aparecer assim, exemplo:
         *          2 + 2 = 4
         *          10 - 5 = 5
         */
        #endregion

        static void Main(string[] args)
        {
            string[] operacoesRealizadas = new string[100];
            string opcao = "";
            int contadorOperacoesRealizadas = 0;

            while (true)
            {
                MostrarMenu();

                opcao = Console.ReadLine();


                if (EhOpcaoInvalida(opcao)) //AND 
                {
                    string menssagemDeErro = "Opção inválida! Tente novamente";
                    MostrarMenssagem(menssagemDeErro); 

                    continue;
                }

                if (opcao == EhOpcaoVizualizacao())
                {
                    Console.WriteLine();

                    if (contadorOperacoesRealizadas == 0)

                    {
                        string nenhumaOpcao = "Nenhuma operação fui realizada!";
                        NenhumaOpcaoRealizada(nenhumaOpcao);
                    }
                    else
                   
                        OpcoesRealizadas(operacoesRealizadas);
                   


                    Console.ReadLine();
                    Console.Clear();

                    continue;

                }


                if (OpcaoSair(opcao))
                    break;
                

                double primeiroNumero, segundoNumero;

                primeiroNumero = ObterNumero("primeiro");

                do
                {
                    segundoNumero = ObterNumero("segundo");

                    if (SegundoNumeroInvalido(opcao, segundoNumero))
                    {
                        MostrarMenssagem("Segundo número inválido! Tente novamente");
                    }

                } while (SegundoNumeroInvalido(opcao, segundoNumero));

                double resultado = CalcularResultado(opcao, primeiroNumero, segundoNumero);

   

                

                      //SEM CONCATENAR 
                //string operacaoRealizada =
                    //primeiroNumero.ToString() + " " + simboloOperacao + " " +
                    //segundoNumero.ToString() + " = " + resultado.ToString();

                    // CONCATENANDO

                    // O OBTERSIMBOLO FOI CONCATENADA DENTRO DA OPERAÇAOREALIZADA
                string operacaoRealizada = $"{primeiroNumero} {ObterSimbolo(opcao)} {segundoNumero} = {resultado} ";


                operacoesRealizadas[contadorOperacoesRealizadas] = operacaoRealizada;

                contadorOperacoesRealizadas++;

                Console.WriteLine(resultado);

                Console.WriteLine();

                Console.ReadLine();

                Console.Clear();

            }
        }
        private static string ObterSimbolo(string opcao)
        {
            string simboloOperacao = "";

            switch (opcao)
            {
                case "1": simboloOperacao = "+"; break;

                case "2":simboloOperacao = "-"; break;

                case "3":simboloOperacao = "*"; break;

                case "4":simboloOperacao = "/"; break;
                    
                default:
                    break;
            }
            return simboloOperacao;
        }

        private static double CalcularResultado(string opcao, double primeiroNumero, double segundoNumero)
        {
            double resultado = 0;

            switch (opcao)
            {
                case "1":
                    resultado = primeiroNumero + segundoNumero;
               
                    break;

                case "2":
                    resultado = primeiroNumero - segundoNumero;
                    
                    break;

                case "3":
                    resultado = primeiroNumero * segundoNumero;
                    
                    break;

                case "4":
                    resultado = primeiroNumero / segundoNumero;
                    
                    break;



                default:
                    break;
            }
            return resultado;
        }

        private static bool SegundoNumeroInvalido(string opcao, double segundoNumero)
        {
            return opcao == "4" && segundoNumero == 0;
        }

        private static double ObterNumero(string ordem) 
        {
            //INTERPOLAÇÃO / CONCATENAÇÃO MAIS CHIQUE
            Console.Write($"Digite o {ordem} numero: ");

            double numero = Convert.ToDouble( Console.ReadLine());

            return numero;
        }


        private static bool OpcaoSair(string opcao)
        {
            return opcao.Equals("s", StringComparison.OrdinalIgnoreCase);
        }

        private static void OpcoesRealizadas(string[] operacoesRealizadas)
        {
            for (int i = 0; i < operacoesRealizadas.Length; i++)
            {
                if (operacoesRealizadas[i] != null)
                    Console.WriteLine(operacoesRealizadas[i]);
            }
        }

        private static void NenhumaOpcaoRealizada(string nenhumaOpcao)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(nenhumaOpcao);

            Console.ResetColor();
        }

        private static string EhOpcaoVizualizacao()
        {
            return "5";
        }

        private static void MostrarMenssagem(string mensagem)
        {


            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();

            Console.Clear();
        }

        private static bool EhOpcaoInvalida(string opcao)
        {
            return opcao != "1" && opcao != "2" && opcao != "3"
                                && opcao != "4" && opcao != "5"
                                && opcao != "S" && opcao != "s";
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("Calculadora Tabajara 1.7.1");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para somar");

            Console.WriteLine("Digite 2 para subtrair");

            Console.WriteLine("Digite 3 para multiplicação");

            Console.WriteLine("Digite 4 para divisão");

            Console.WriteLine("Digite 5 para visualizar as operações realizadas");

            Console.WriteLine("Digite S para sair");
        }
    }
}
