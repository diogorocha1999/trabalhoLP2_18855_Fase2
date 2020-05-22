/*
 * --------------------------------------------------------------------------------
 * <copyright file = "Person"   Developer: Diogo Rocha @IPCA</copyright>
 * <author>Diogo Miguel Correia Rocha</author>
 * <email>a18855@alunos.ipca.pt</email>
 * <date>22/05/2020</date>
 * <description>Esta classe define um recuperado.</description>
 * --------------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Classes
{
    /// <summary>
    /// Classe Recuperados.Define um recuperado
    /// </summary>
    [Serializable]
    public class Recuperados : Pessoa
    {
        #region Atributos
        protected string recuperado;
        
        #endregion

        #region Construtor
        public Recuperados()
        {

        }

        /// <summary>
        /// Construtor com dados do exterior
        /// </summary>
        /// <param name="rRegiao"></param>
        /// <param name="iIdade"></param>
        /// <param name="gGenero"></param>
        /// <param name="rRecuperado"></param>
        public Recuperados(string rRegiao, int iIdade, string gGenero, string rRecuperado) : base(rRegiao, iIdade, gGenero)
        {
            recuperado = rRecuperado;
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Manipula atributo recuperado
        /// </summary>
        public string Recuperado
        {
            get { return recuperado; }
            set { value = recuperado; }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Imprime a lista de recuperados e nao recuperados
        /// </summary>
        /// <param name="casolista"></param>
        public void ListaRecuperados(List<Recuperados> casolista)
        {
            foreach (Recuperados x in casolista)
            {
                Console.WriteLine("Região: " + x.Regiao + " Idade " + x.Idades + " Genero: " + x.Genero + "Recuperado: " + x.Recuperado);
            }
        }


        //public string ConsultaRegiao(List<Recuperados> recuperados, string pRecuperados)
        //{
        //    try
        //    {
        //        foreach ( Recuperados c in recuperados)
        //        {
        //            if (c.Regiao == pRecuperados)
        //            {
        //               Console.WriteLine("Região: " + c.Regiao + " Idade " + c.Idades + " Genero: " + c.Genero + "Recuperado: " + c.recuperado);
                        
        //            }
        //        }
        //        return Console.ReadLine();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

            /// <summary>
            /// Conta o numero de pessoas nao recuperadas.
            /// </summary>
            /// <param name="recuperados"></param>
            /// <param name="mau"></param>
            /// <returns></returns>
        public int ContaNaoRecuperados(List<Recuperados> recuperados, string mau)
        {
            try
            {
                int qtmau = 0;
                foreach (Recuperados c in recuperados)
                {
                    if (c.recuperado == mau)
                    {
                        qtmau++;
                    }
                }
                return qtmau;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Conta o numero de pessoas recuperadas
        /// </summary>
        /// <param name="recuperados"></param>
        /// <param name="bom"></param>
        /// <returns></returns>
        public int ContaRecuperados(List<Recuperados> recuperados, string bom)
        {
            try
            {
                int qtbom = 0;
                foreach (Recuperados c in recuperados)
                {
                    if (c.recuperado == bom)
                    {
                        qtbom++;
                    }

                }
                return qtbom;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// Insere um novo recuperado caso nao exista
        /// </summary>
        /// <param name="recuperados"></param>
        /// <param name="recuperado"></param>
        /// <returns></returns>
        public static bool InserePessoa(List<Recuperados> recuperados, Recuperados recuperado)
        {
            bool auxVerificaExistePessoa = VerificaExistePessoa(recuperados, recuperado);
            if (auxVerificaExistePessoa == false)
            {
                recuperados.Add(recuperado);
            }
            return true;
        }

        /// <summary>
        /// Verifica se já existe determinado recuperado
        /// </summary>
        /// <param name="casos"></param>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public static bool VerificaExistePessoa(List<Recuperados> recuperados, Recuperados recuperado)
        {

            foreach (Recuperados recuperados1 in recuperados)
            {
                if (recuperados1 == recuperado)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Grava os dados inseridos em ficheiro.
        /// </summary>
        /// <param name="casos"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool SaveCaso(List<Recuperados> casos, string filename)
        {
            if (File.Exists(filename))
            {
                try
                {
                    Stream stream = File.Open(filename, FileMode.Create);
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, casos);
                    stream.Close();
                    return true;
                }
                catch (IOException e)
                {
                    Console.Write("Erro de gravação: " + e.Message);
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Limpa a lista.
        /// </summary>
        /// <param name="casos"></param>
        public static void LimpaRecuperados(List<Recuperados> casos)
        {
            casos.Clear();
        }

        /// <summary>
        /// Carrega o ficheiro com os dados foram gravados.
        /// NÃO CONSEGUI IMPLEMENTAR!!!
        /// </summary>
        /// <param name="casos"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool LoadRecuperados(List<Recuperados> casos, string fileName)
        {

            if (File.Exists(fileName))
            {
                try
                {
                    Stream stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    casos = (List<Recuperados>)bin.Deserialize(stream);
                    stream.Close();
                    return true;
                }
                catch (IOException e)
                {
                    Console.Write("ERRO!!:" + e.Message);
                    throw e;
                }
            }
            return false;
        }

        /// <summary>
        /// Le os dados guardados do ficheiro.
        /// </summary>
        /// <param name="casos"></param>
        /// <returns></returns>
        public static string LeFicheiro(List<Recuperados> casos)
        {
            string lista = "";


            foreach (Recuperados x in casos)
            {
                lista += String.Format("Região: " + x.Regiao + " Idade " + x.Idades + " Genero: " + x.Genero + " Sintomas : " + x.Recuperado + "\n");
            }

            return lista;

        }
        #endregion
    }
}
