using System.Collections.Generic;
using Classes;

namespace IValidações
{
    class Validacões
    {


        /// <summary>
        /// Verifica se existe determinada pessoa
        /// </summary>
        /// <param name="casos"></param>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public static bool VerificaExistePessoa(List<Caso> casos, Caso pessoa)
        {

            foreach (Caso caso in casos)
            {
                if (caso == pessoa)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
