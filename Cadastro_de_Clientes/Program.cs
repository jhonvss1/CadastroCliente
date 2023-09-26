using System;
using System.Collections.Generic;

namespace Cadastro_de_Clientes
{
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
    
        static void Main(string[] args) { 

        bool executando = true;

        while (executando)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Adicionar Cliente");
                Console.WriteLine("2 - Visualizar Cliente");
                Console.WriteLine("3 - Editar Cliente");
                Console.WriteLine("4 - Excluir Cliente");
                Console.WriteLine("5 - Sair");

                int opção = Convert.ToInt32(Console.ReadLine());

                switch (opção)
                {
                    case 1:
                        AdicionarCliente();
                        break;
                    case 2:
                        VisualizarClientes();
                        break;
                    case 3:
                        EditarCliente();
                        break;
                    case 4:
                        ExcluirCliente();
                        break;
                    case 5:
                        executando = false;
                        break;
                    default: Console.WriteLine("Opção inválida!");
                        break;                    
                }
            }
    
        }
        static void AdicionarCliente()
        {
            Console.WriteLine("Digite o nome do Cliente:");
            string? nome = Console.ReadLine();
            
            Console.WriteLine("Digite o e-mail do Cliente:");
            string? email = Console.ReadLine();

            Console.WriteLine("Informe a idade do Cliente");
            int age = Convert.ToInt32(Console.ReadLine());

            Random random = new Random();
            int id = random.Next(1000,10000);
            Console.WriteLine($"Seu número de identificação é: {id}");

            // Instanciando a classe Cliente
            Cliente cliente = new Cliente(nome, email, age, id);
            clientes.Add(cliente);
            Console.WriteLine("Cliente adicionado com Sucesso");
        }

        static void VisualizarClientes()
        {
            foreach(Cliente cliente in clientes)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine($"Nome: {cliente.Name}");
                Console.WriteLine($"Email: {cliente.Email}");
                Console.WriteLine($"Idade: {cliente.Age}");
                Console.WriteLine($"Identificador: {cliente.Id}");
                Console.WriteLine("--------------------------");
            }
        }

        static void EditarCliente()
        {
            Console.WriteLine("Digite o nome do cliente que deseja editar: ");
            string? nome = Console.ReadLine();

            Cliente cliente = clientes.Find(c => c.Name == nome);

            if (cliente != null)
            {
                Console.WriteLine("Digite o novo nome do cliente: ");
                string? newName = Console.ReadLine();

                Console.WriteLine("Digite o novo Email do Cliente: ");
                string? newEmail = Console.ReadLine();

                cliente.Name = newName;
                cliente.Email = newEmail;

                Console.WriteLine("Informações do cliente editadas com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }
            static void ExcluirCliente()
            {
                Console.WriteLine("Digite o nome do cliente que deseja excluir: ");
                string? name = Console.ReadLine();
                Cliente cliente = clientes.Find(c => c.Name == name);

                if (cliente != null)
                {
                    clientes.Remove(cliente);
                    Console.WriteLine("Cliente excluído com sucesso");
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado.");
                }
            }
        

        class Cliente
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Id { get; set; }
            public string Email { get; set; }

            //Definindo um contrutor para a classe Cliente
            public Cliente (string name, string email, int age, int id)

            {
                Name = name;
                Email = email;
                Age = age;
                Id = id;
            }

        }
    }
}