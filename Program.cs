using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_de_Clientes
{
    internal class Program
    {
        enum Menu {Lista = 1, Adicionar, Remover, Pesquisar, Sair };
        enum Pesquisa { quantidade = 1, maisLetras, menosLetras };
        static void Main(string[] args)
        {
            //Cria o sistema de listas!
            List<string> Clientes = new List<string>();

            bool escolheuSair = false;
            while (!escolheuSair) //Enquanto não escolheu sair continua o código! :D
            {
                Console.WriteLine("Escolha umas das opções!");
                Console.WriteLine("1 - Lista de Clientes\n2 - Adicionar Cliente\n3 - Remover Cliente\n4 - Pesquisar nos Clientes\n5 - Sair");

                //A escolha é atribuida à variável opcao, posteriormente usada pra selecionar dentro do enum a opção escolhida!
                Menu opcaoMenu = (Menu)int.Parse(Console.ReadLine());

                switch (opcaoMenu)
                {
                    case Menu.Lista:

                        if (Clientes.Count > 0)
                        {
                            Console.WriteLine("Aqui está o nome dos clientes atualmente cadastrados: ");

                            //Cada cliente precisa ter seu número de identificação!
                            int Contador = 0;

                            foreach (string Cliente in Clientes)
                            {
                                Contador++;
                                Console.Write($"[{Contador}] - ");
                                Console.WriteLine(Cliente);
                            }
                        } else
                        {
                            Console.WriteLine("Sua lista atualmente está vazia! Experimente adicionar alguém!");
                        }
                        Console.ReadLine();

                        break;

                    case Menu.Adicionar:

                        Console.Write("Digite a seguir: ");
                        Clientes.Add(Console.ReadLine());

                        break;

                    case Menu.Remover:

                        Console.Write("Digite a seguir o número do cliente: ");

                        Clientes.RemoveAt(int.Parse(Console.ReadLine()) - 1);
                        break;

                    case Menu.Pesquisar:

                        //menu de opções para pesquisa, como se fosse o menu principal!
                        Console.WriteLine("1 - Quantidade de pessoas\n2 - Pessoas com mais caracteres\n3 - Pessoas com menos caracteres");

                        Pesquisa opcaoPesquisa = (Pesquisa)int.Parse(Console.ReadLine());

                        switch (opcaoPesquisa)
                        {
                            case Pesquisa.quantidade:
                                if(Clientes.Count > 0)
                                {
                                    Console.WriteLine($"O sistema tem atualmente {Clientes.Count} clientes cadastrados!");
                                }
                                else { Console.WriteLine("O sistema está vazio, não há nada para se pesquisar!");}
                                break;

                            case Pesquisa.maisLetras:

                                Console.Write("Digite a quantidade de letras: ");

                                int quantMax = int.Parse(Console.ReadLine());
                                List<string> Filtro1 = Clientes.FindAll(Cliente => Cliente.Length > quantMax);

                                Console.WriteLine("Aqui está o resultado da busca: ");
                                if (Clientes.Count > 0)
                                {
                                    foreach (string filtro in Filtro1)
                                    {
                                        Console.WriteLine(filtro);
                                    }
                                } else { Console.WriteLine("Nada correspondente foi achado!"); }
                                break;

                            case Pesquisa.menosLetras:

                                Console.Write("Digite a quantidade de letras: ");

                                int quantMin = int.Parse(Console.ReadLine());
                                List<string> Filtro2 = Clientes.FindAll(Cliente => Cliente.Length < quantMin);

                                Console.WriteLine("Aqui está o resultado da busca: ");
                                if (Clientes.Count > 0)
                                {
                                    foreach (string filtro in Filtro2)
                                    {
                                        Console.WriteLine(filtro);
                                    }
                                } else { Console.WriteLine("Nada correspondente foi achado!"); }
                                break;
                        }

                        Console.ReadLine();

                        break;

                    case Menu.Sair:
                        escolheuSair = true;
                        break;
                }

                Console.Clear();
            }
        }

        //organizar
    }
}
