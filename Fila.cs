using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtvTrimestral
{
    internal class Fila
    {
        private const int MaxPacientes = 15;
        private Paciente[] fila = new Paciente[MaxPacientes];
        private int TotalPacientes = 0;

        public void CadastrarPaciente()
        {
            if (TotalPacientes >= MaxPacientes)
            {
                Console.WriteLine("\n\n\nFila cheia! Não foi possível cadastrar mais pacientes.\n\n\n");
                return;
            }

            Paciente p = new Paciente();

            Console.Write("Nome do(a) paciente: ");
            p.Nome = Console.ReadLine();

            Console.Write("Idade do(a) paciente: ");
            p.Idade = int.Parse(Console.ReadLine());

            Console.Write("CPF do(a) paciente: ");
            p.Cpf = Console.ReadLine();

            Console.Write("É preferencial? S/N: ");
            char pref = Console.ReadLine().ToLower()[0];
            p.Preferencial = (pref == 's');

            InserirPacienteNaFila(p);
            Console.WriteLine("\n\n\nPaciente cadastrado(a) com sucesso!\n\n\n");
        }

        public void ListarFila()
        {
            if (TotalPacientes == 0)
            {
                Console.WriteLine("\n\n\nA fila está vazia.\n\n\n");
                return;
            }

            Console.WriteLine("\nFila de Pacientes");
            for (int i = 0; i < TotalPacientes; i++)
            {
                Paciente p = fila[i];
                Console.WriteLine($"\n\n\n{i + 1}. {p.Nome} - Idade: {p.Idade} - CPF: {p.Cpf} - {(p.Preferencial ? "Preferencial" : "Comum")}\n\n\n");
            }
        }

        public void AtenderPaciente()
        {
            if (TotalPacientes == 0)
            {
                Console.WriteLine("\n\n\nNenhum(a) paciente na fila.\n\n\n");
                return;
            }

            Console.WriteLine($"\n\n\nPaciente {fila[0].Nome} foi atendido(a).\n\n\n");

            for (int i = 0; i < TotalPacientes - 1; i++)
                fila[i] = fila[i + 1];

            fila[TotalPacientes - 1] = null;
            TotalPacientes--;
        }

        public void AlterarPaciente()
        {
            if (TotalPacientes == 0)
            {
                Console.WriteLine("\n\n\nA fila está vazia.\n\n\n");
                return;
            }

            Console.Write("\nDigite o nome do(a) paciente que vai alterar: \n\n");
            string nomeBusca = Console.ReadLine();

            for (int i = 0; i < TotalPacientes; i++)
            {
                if (fila[i].Nome.ToLower() == nomeBusca.ToLower())
                {
                    Paciente p = fila[i];

                    Console.Write("\nNovo nome: ");
                    p.Nome = Console.ReadLine();

                    Console.Write("\nNova idade: ");
                    p.Idade = int.Parse(Console.ReadLine());

                    Console.Write("\nNovo CPF: ");
                    p.Cpf = Console.ReadLine();

                    Console.Write("\nÉ preferencial? S/N: ");
                    char pref = Console.ReadLine().ToLower()[0];
                    p.Preferencial = (pref == 's');

                    for (int j = i; j < TotalPacientes - 1; j++)
                        fila[j] = fila[j + 1];

                    fila[TotalPacientes - 1] = null;
                    TotalPacientes--;

                    InserirPacienteNaFila(p);
                    Console.WriteLine("\n\n\nDados atualizados com sucesso!\n\n\n");
                    return;
                }
            }

            Console.WriteLine("\n\n\nPaciente não encontrado(a)!\n\n\n");
        }

        private void InserirPacienteNaFila(Paciente p)
        {
            if (p.Preferencial)
            {
                for (int i = 0; i <= TotalPacientes; i++)
                {
                    if (i == TotalPacientes || !fila[i].Preferencial)
                    {
                        for (int j = TotalPacientes; j > i; j--)
                        {
                            fila[j] = fila[j - 1];
                        }
                        fila[i] = p;
                        break;
                    }
                }
            }
            else
            {
                fila[TotalPacientes] = p;
            }

            TotalPacientes++;
        }
    }
}
