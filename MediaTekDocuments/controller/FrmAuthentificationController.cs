using MediaTekDocuments.dal;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.controller
{
    internal class FrmAuthentificationController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmAuthentificationController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Renvoie l'objet utilisateur si l'authentification est validée par l'api
        /// </summary>
        /// <param name="login">login de l'utilisateur</param>
        /// <param name="mdp">mdp de l'utilisateur</param>
        /// <returns></returns>
        public string GetAuthentification(string login, string mdp)
        {
            return access.GetVerifierAuthentification(login, mdp);
        }
    }
}
