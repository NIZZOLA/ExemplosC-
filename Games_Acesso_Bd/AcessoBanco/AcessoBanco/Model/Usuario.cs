using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoBanco.Model
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }


        public bool IsValid()
        {
            var retorno = true;
            if (this.Nome == null || this.Nome == "")
                retorno = false;
            else if (this.Nome.Length > 50)
                retorno = false;

            if (this.Email == null || this.Email == "")
                retorno = false;
            else if (this.Email.Length > 80)
                retorno = false;

            if (this.Senha == null || this.Senha == "")
                retorno = false;
            else  if (this.Senha.Length > 10)
                retorno = false;

            
            return retorno;
        }
    }
}
