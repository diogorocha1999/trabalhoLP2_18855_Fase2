using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace Regras_Validações
{
    class Regras
    {
        /// <summary>
        /// Insere uma nova pessoa caso não exista
        /// </summary>
        /// <param name="casos"></param>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public static bool InserePessoa(List<Caso> casos, Caso pessoa)
        {
            bool auxVerificaExistePessoa = VerificaExistePessoa(casos, pessoa);
            if (auxVerificaExistePessoa == false)
            {
                casos.Add(pessoa);
            }
            return true;
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
    }
}
