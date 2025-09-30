using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeTrimestral
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
                Console.WriteLine("Fila cheia! Não foi possível cadastrar mais pacientes.");
                return;
            }

            Paciente p = new Paciente();

            Console.Write("Nome do paciente: ");
            p.Nome = Console.ReadLine();

            Console.Write("Idade do paciente: ");
            p.Idade = int.Parse(Console.ReadLine());

            Console.Write("CPF do paciente: ");
            p.Cpf = Console.ReadLine();

            Console.Write("É preferencial? (s/n): ");
            char pref = Console.ReadLine().ToLower()[0];
            p.Preferencial = (pref == 's');

            InserirPacienteNaFila(p);
            Console.WriteLine("Paciente cadastrado com sucesso.");
        }

        public void ListarFila()
        {
            if (TotalPacientes == 0)
            {
                Console.WriteLine("Fila vazia.");
                return;
            }

            Console.WriteLine("\nFila de Pacientes");
            for (int i = 0; i < TotalPacientes; i++)
            {
                var p = fila[i];
                Console.WriteLine($"{i + 1}. {p.Nome} - Idade: {p.Idade} - CPF: {p.Cpf} - {(p.Preferencial ? "Preferencial" : "Comum")}");
            }
        }

        public void AtenderPaciente()
        {
            if (TotalPacientes == 0)
            {
                Console.WriteLine("Nenhum paciente na fila.");
                return;
            }

            Console.WriteLine($"Paciente {fila[0].Nome} foi atendido.");

            for (int i = 0; i < TotalPacientes - 1; i++)
                fila[i] = fila[i + 1];

            fila[TotalPacientes - 1] = null;
            TotalPacientes--;
        }

        public void AlterarPaciente()
        {
            if (TotalPacientes == 0)
            {
                Console.WriteLine("Fila vazia.");
                return;
            }

            Console.Write("Digite o nome do paciente a alterar: ");
            string nomeBusca = Console.ReadLine();

            for (int i = 0; i < TotalPacientes; i++)
            {
                if (fila[i].Nome.ToLower() == nomeBusca.ToLower())
                {
                    Paciente p = fila[i];

                    Console.Write("Novo nome: ");
                    p.Nome = Console.ReadLine();

                    Console.Write("Nova idade: ");
                    p.Idade = int.Parse(Console.ReadLine());

                    Console.Write("Novo CPF: ");
                    p.Cpf = Console.ReadLine();

                    Console.Write("É preferencial? (s/n): ");
                    char pref = Console.ReadLine().ToLower()[0];
                    p.Preferencial = (pref == 's');

                    for (int j = i; j < TotalPacientes - 1; j++)
                        fila[j] = fila[j + 1];

                    fila[TotalPacientes - 1] = null;
                    TotalPacientes--;

                    InserirPacienteNaFila(p);
                    Console.WriteLine("Dados atualizados com sucesso.");
                    return;
                }
            }

            Console.WriteLine("Paciente não encontrado.");
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

