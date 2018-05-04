using AcessoBanco.Model;
using AcessoBanco.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario usu = new Usuario();
            usu.Nome = "Marcio";
            usu.Email = "marcio@nizzola.com.br";
            usu.Senha = "102030";

            UsuarioRepository usuRep = new UsuarioRepository();

            var ret = usuRep.Incluir(usu);


        }
    }
}
