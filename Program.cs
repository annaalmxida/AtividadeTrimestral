using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtvTrimestral
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fila fila = new Fila();
            char opcaomenu;

            do
            {
                Console.WriteLine("\n        MENU \n Hospital BomSaúde <3");
                Console.WriteLine("\n1 - Cadastrar paciente");
                Console.WriteLine("2 - Mostrar fila");
                Console.WriteLine("3 - Atender paciente");
                Console.WriteLine("4 - Alterar os dados do paciente");
                Console.WriteLine("Q - Sair");
                Console.Write("\nEscolha a opção que deseja: ");
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
                        Console.WriteLine("\n\n\nFechando o sistema...");
                        break;
                    default:
                        Console.WriteLine("\n\n\nVocê digitou uma opção inválida!");
                        break;
                }

            } while (opcaomenu != 'q');
        }
    }
}
        
