/*
 * --------------------------------------------------------------------------------
 * <copyright file = "Person"   Developer: Diogo Rocha @IPCA</copyright>
 * <author>Diogo Miguel Correia Rocha</author>
 * <email>a18855@alunos.ipca.pt</email>
 * <date>22/05/2020</date>
 * <description>Esta classe define um obito.</description>
 * --------------------------------------------------------------------------------
 */
using System;

namespace Classes
{
    /// <summary>
    /// Classe Obitos.Define um obito
    /// </summary>
    public class Obitos : Pessoa
    {
        #region Atributos
        Causas causas;
        #endregion

        #region Construtor
        public Obitos()
        {

        }

        /// <summary>
        /// Construtor com dados do exterior
        /// </summary>
        /// <param name="rRegiao"></param>
        /// <param name="iIdade"></param>
        /// <param name="gGenero"></param>
        /// <param name="cMorte"></param>
        public Obitos(string rRegiao, int iIdade, string gGenero, Causas cCausa) : base (rRegiao, iIdade, gGenero)
        {
            causas = cCausa;
        }
        #endregion

        public Causas Causa
        {
            get { return causas; }
            set { causas = value; }
        }

        #region Propriedades   
        public enum Causas
        {
            Covid,
            Gripe
        }
 

        #endregion

    }
}
