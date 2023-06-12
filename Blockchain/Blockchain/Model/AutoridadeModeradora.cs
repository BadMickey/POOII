using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBlockchain.Model
{
    class AutoridadeModeradora
    {
        private string Email { get; set; }
        private string Senha { get; set; }
        private NivelAcesso nivelAcesso { get; set; }

        public AutoridadeModeradora(string Email, string Senha, NivelAcesso nivelAcesso)
        {
            this.Email = Email;
            this.Senha = Senha;
            this.nivelAcesso = nivelAcesso;
        }

        public String getEmail()
        {
            return Email;
        }
        
        public void setEmail(String Email)
        {
            this.Email = Email;
        }
        public String getSenha()
        {
            return Senha;
        }
        
        public NivelAcesso GetNivelAcesso()
        {
            return nivelAcesso;
        }
        public void setNivelAcesso(NivelAcesso nivelAcesso)
        {
            this.nivelAcesso = nivelAcesso;
        }
    }
}
