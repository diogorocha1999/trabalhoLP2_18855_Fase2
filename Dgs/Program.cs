/*
 * --------------------------------------------------------------------------------
 * <copyright file = "Person"   Developer: Diogo Rocha @IPCA</copyright>
 * <author>Diogo Miguel Correia Rocha</author>
 * <email>a18855@alunos.ipca.pt</email>
 * <date>22/05/2020</date>
 * <description>Este programa permite gerir pessoas infecionadas no caso de uma possivel pandemia.Ou seja fazer uma possivel análise estatistica ao numero de infecionados</description>
 * --------------------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using Classes;
using Regras;
/// <summary>
/// Mainspace do programa. Neste espaço, a classe principal(Program), é que irá chamar e executar todos os métodos.
/// </summary>
namespace Classes
{
    class Program

    {
        /// <summary>
        ///Main. Vai executar sempre.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<Caso> casos = new List<Caso>();
            Caso c = new Caso();
            
            Validar.InserePessoa(casos, new Caso("Norte", 25, "Masculino", "Sim"));
            Validar.InserePessoa(casos, new Caso("Sul", 25, "Feminino", "Nâo"));
            Validar.InserePessoa(casos, new Caso("Sul", 25, "Feminino", "Sim"));
            Validar.InserePessoa(casos, new Caso("Centro", 32, "Masculino", "Sim"));
            Validar.InserePessoa(casos, new Caso("Centro", 8, "Masculino", "Não"));
            Validar.InserePessoa(casos, new Caso("Sul", 16, "Feminino", "Sim"));
            Validar.InserePessoa(casos, new Caso("Sul", 40, "Feminino", "Sim"));
            Validar.InserePessoa(casos, new Caso("Norte", 55, "Feminino", "Sim"));
            Validar.InserePessoa(casos, new Caso("Norte", 65, "Feminino", "Não"));
            Validar.InserePessoa(casos, new Caso("Centro", 80, "Feminino", "Não"));

            #region Lista de Casos
            Console.WriteLine("Lista de casos");
            c.ListaCasos(casos);
            #endregion

            #region Consulta Região
            int contaRegiao = 0;
            while (contaRegiao == 0)
            {
                Console.WriteLine("Insira a região a consultar: ");
                string pRegiao = Console.ReadLine();
                contaRegiao = c.ConsultaRegiao(casos, pRegiao);

                if (contaRegiao > 0)
                {
                    Console.WriteLine("Nº de casos na região " + pRegiao + " : " + contaRegiao);
                }
                else
                {
                    Console.WriteLine("Não existe registo para essa região");
                }
            }
            #endregion

            #region Consulta Idades
            int nIdades = 0;
            while (nIdades == 0)
            {
                try
                {
                    Console.WriteLine("Insira a idade a consultar: ");
                    int pIdade = Convert.ToInt32(Console.ReadLine());
                    nIdades = c.ConsultaIdade(casos, pIdade);

                    if (nIdades > 0)
                    {
                        Console.WriteLine("Nº de casos com a idade de " + pIdade + " : " + nIdades);
                    }
                    else
                    {
                        Console.WriteLine("Não existe registos para essa idade!");

                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Erro formato:" + e.Message);
                }

            }
            #endregion

            #region Consulta Genero
            int nGenero = 0;
            while (nGenero == 0)
            {
                try
                {
                    Console.WriteLine("Insira o genero a consultar: ");
                    string pGenero = Console.ReadLine();
                    nGenero = c.ConsultaGenero(casos, pGenero);

                    if (nGenero > 0)
                    {
                        Console.WriteLine("Nº de casos com o género  " + pGenero + "é de : " + nGenero);
                    }
                    else
                    {
                        Console.WriteLine("Não existe registos para esse género!");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Erro formato:" + e.Message);
                }
            }
            #endregion

            #region Doentes de Risco
            string risco = "Sim";
            int nRisco = c.ContaRisco(casos, risco);
            
            Console.WriteLine("Nº de casos de risco é de: " + nRisco);
            
            #endregion

            #region Doentes sem risco
            string semRisco = "Não";
            int nsemRisco = c.ContaSemRisco(casos, semRisco);

            Console.WriteLine("Nº de casos sem risco é de: " + nsemRisco);

            #endregion

            #region Maior Idade
            int mIdade = c.MaiorIdade(casos);
            Console.WriteLine("O(s) infetado(s) com maior idade é: " + mIdade);
            #endregion

            #region Média de Idades
            int averageAge = c.MediaIdades(casos);
            Console.WriteLine("A idade média de casos é de : " + averageAge);
            #endregion

            #region Percentagem Genero Masculino
            float percentGeneroM = c.PercentagemGeneroM(casos);
            Console.WriteLine("Percentagem de obitos por genero : ");
            Console.WriteLine("Masculino :" + +percentGeneroM + "%");
            #endregion

            #region Percentagem Genero Feminino
            float percentGeneroF = c.PercentagemGeneroF(casos);
            Console.WriteLine("Percentagem de obitos por genero : ");
            Console.WriteLine("Masculino :" + +percentGeneroF + "%");
            #endregion

            #region Ficheiro
            Console.WriteLine("Salva Ficheiro!");
            Caso.SaveCaso(casos, @"C:\Users\diogo\Desktop\DGS\Dgs\bin\caso.bin");
            
            Caso.LimpaCaso(casos);
            Console.WriteLine("Limpa lista!");


            Console.WriteLine("Carrega ficheiro!");
            Console.WriteLine(Caso.LeFicheiro(casos));
            Caso.LoadCasos(casos, @"C:\Users\diogo\Desktop\DGS\Dgs\bin\caso.bin");
            Console.WriteLine(Caso.LeFicheiro(casos));
            #endregion

            List<Recuperados> recuperados = new List<Recuperados>();
            Recuperados r = new Recuperados();

            Validar.InserePessoa(recuperados, new Recuperados("Norte", 25, "Masculino", "Não"));
            Validar.InserePessoa(recuperados, new Recuperados("Sul", 25, "Feminino", "Nâo"));
            Validar.InserePessoa(recuperados, new Recuperados("Sul", 25, "Feminino", "Sim"));
            Validar.InserePessoa(recuperados, new Recuperados("Centro", 32, "Masculino", "Sim"));
            Validar.InserePessoa(recuperados, new Recuperados("Centro", 8, "Masculino", "Não"));
            Validar.InserePessoa(recuperados, new Recuperados("Sul", 16, "Feminino", "Sim"));
            Validar.InserePessoa(recuperados, new Recuperados("Sul", 40, "Feminino", "Não"));
            Validar.InserePessoa(recuperados, new Recuperados("Norte", 55, "Feminino", "Sim"));
            Validar.InserePessoa(recuperados, new Recuperados("Norte", 65, "Feminino", "Não"));
            Validar.InserePessoa(recuperados, new Recuperados("Centro", 80, "Feminino", "Não"));

            #region Lista de Recuperados
            Console.WriteLine("Lista de Recuperados.");
            r.ListaRecuperados(recuperados);
            #endregion

            #region Doentes de recuperados
            string bom = "Sim";
            int nBom = r.ContaRecuperados(recuperados, bom);

            Console.WriteLine("Nº de doentes de recuperados é de: " + nBom);

            #endregion

            #region Doentes não recuperados
            string mau = "Não";
            int nMau = r.ContaNaoRecuperados(recuperados, mau);

            Console.WriteLine("Nº de casos sem risco é de: " + nMau);

            #endregion

            #region Ficheiro
            Console.WriteLine("Salva Ficheiro!");
            Recuperados.SaveCaso(recuperados, @"C:\Users\diogo\Desktop\DGS\Dgs\bin\recuperado.bin");

            Recuperados.LimpaRecuperados(recuperados);
            Console.WriteLine("Limpa lista!");


            Console.WriteLine("Carrega ficheiro!");
            Console.WriteLine(Recuperados.LeFicheiro(recuperados));
            Recuperados.LoadRecuperados(recuperados, @"C:\Users\diogo\Desktop\DGS\Dgs\bin\recuperado.bin");
            Console.WriteLine(Recuperados.LeFicheiro(recuperados));
            #endregion


            Console.ReadKey();

        }
    }
}