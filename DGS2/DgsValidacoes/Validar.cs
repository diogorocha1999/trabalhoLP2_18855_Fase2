using System.Collections.Generic;

namespace Classes
{
    public class Validar
    {
        //    public static bool ValidaData(string data)
        //    {
        //        DateTime dt;
        //        return (DateTime.TryParse(data.ToString(), out dt));
        //    }



        public static bool InserePessoa(List<Caso> casos, Caso pessoa)
        {

            //getpessoa - verificar se a pessoa existe
            bool auxVerificaExistePessoa = VerificaExistePessoa(casos, pessoa);

            if (auxVerificaExistePessoa == true)
            {
                casos.Add(pessoa);
            }
            return true;
        }

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
}



