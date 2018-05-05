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
            UsuarioRepository usuRep = new UsuarioRepository();

            var item = usuRep.ConsultarPorEmail("marcio@aaa.com");
            Console.WriteLine("\nCodigo:" + item.UsuarioId + "\nNome" + item.Nome + "\nE-mail:" + item.Email + "\n Senha:" + item.Senha + "\n");
            Console.ReadKey();


            /*
            var lista = usuRep.ConsultarTodos();
            foreach (var item in lista)
            {
                Console.WriteLine("\nCodigo:" + item.UsuarioId + "\nNome" + item.Nome + "\nE-mail:" + item.Email + "\n Senha:" + item.Senha + "\n");
            }

            Console.ReadKey();




            
            usu.Nome = "Marcio";
            usu.Email = "marcio@nizzola.com.br";
            usu.Senha = "102030";

            
            
            var ret = usuRep.Incluir(usu);

            Console.WriteLine("Usuário adicionado:" + usu.UsuarioId.ToString());

            Console.ReadKey();
            
            ret.Nome = "MARCIO ROGERIO";

            var ret2 = usuRep.Alterar(ret);


            var consulta = usuRep.Consultar(ret.UsuarioId);

            Console.WriteLine("Nome:" + consulta.Nome + "\n E-mail:" + consulta.Email + "\n Senha:" + consulta.Senha );
            Console.ReadKey();

            var resp = usuRep.Excluir(12);

            Console.WriteLine("Resposta da exclusão:" + resp.ToString());
            Console.ReadKey();
            */
        }
    }
}
