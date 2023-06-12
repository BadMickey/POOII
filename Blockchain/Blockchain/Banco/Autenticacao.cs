using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBlockchain.Banco
{
    public class Autenticacao
    {
        private string EmailAutoridade = "Autoridade13";
        private string SenhaAutoridade = "1234";
        //
        //

        public void Autenticar(string email, string senha)
        {
            string Email = email;
            string Senha = senha;

            if (Email.Equals(EmailAutoridade) && Senha.Equals(SenhaAutoridade))
            {
                Program.AcessoAutoridadeModeradora = true;
            }
        }
    }
}
