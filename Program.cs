using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeTrimestral
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila();
            char opcaomenu;

            do
            {
                Console.WriteLine("\nMENU");
                Console.WriteLine("1 - Cadastrar paciente");
                Console.WriteLine("2 - Listar fila");
                Console.WriteLine("3 - Atender paciente");
                Console.WriteLine("4 - Alterar dados do paciente");
                Console.WriteLine("q - Sair");
                Console.Write("\nEscolha uma opção: ");
                opcaomenu = Console.ReadLine().ToLower()[0];

                switch (opcaomenu)
                {
                    case '1':
                        fila.CadastrarPaciente();
                        break;
                    case '2':
                        fila.ListarFila();
                        break;
                    case '3':
                        fila.AtenderPaciente();
                        break;
                    case '4':
                        fila.AlterarPaciente();
                        break;
                    case 'q':
                        Console.WriteLine("Encerrando o sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcaomenu != 'q');
        }
    }
}
