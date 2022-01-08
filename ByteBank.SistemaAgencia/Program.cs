using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;


namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
           /**************************************************************************************
           *             Trabalhando com ordenação de lista: OrderBy e Expressão Lambda          *
           **************************************************************************************/

            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 1),
                new ContaCorrente(342, 999),
                null,
                new ContaCorrente(340, 4),
                new ContaCorrente(340, 456),
                new ContaCorrente(340, 10),
                null,
                null,
                new ContaCorrente(290, 123)
            };

            // contas.Sort(); -> Chamar a implementação dada em Icomparable
            // contas.Sort(new ComparadorContaCorrentePorAgencia());

            var contasOrdenadas = contas 
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);
            
            foreach (var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }


            Console.ReadLine();
       
            /**************************************************************************************
            *                     Trabalhando com ordenação de lista: SORT                        *
            **************************************************************************************/
            static void TestaSort()
            {
                //INICIALIZADOR DE LISTAS COM TIPO STRING:
                var nomes = new List<string>()
                {
                    "Michel",
                    "Lucius",
                    "Andressa",
                    "Celio",
                    "Zendaya",
                    "Tom Holland",
                    "Tobey Maguire",
                    "Andrew Garfield",
                    "Mayday Parker",
                    "Mary Jane"
                };

                nomes.Sort();

                foreach (var nome in nomes)
                {
                    Console.WriteLine(nome);
                }

                //INICIALIZADOR DE LISTAS COM TIPO NUMBER:
                var idades = new List<int>();

                idades.Add(1);
                idades.Add(5);
                idades.Add(14);
                idades.Add(25);
                idades.Add(38);
                idades.Add(61);

                idades.AdicionarVarios(45, 89, 12);

                idades.AdicionarVarios(99, -1);

                idades.Sort();//Método de ordenação

                for (int i = 0; i < idades.Count; i++)
                {
                    Console.WriteLine(idades[i]);
                }

                Console.ReadLine();
            }

            /**************************************************************************************
            *                 Trabalhando com o VAR - Inferência de tipo de variável              *
            **************************************************************************************/
            static void TestaVariavelGenerica()
            {
                /* var é uma variável do tipo object (deriva de object),
                quando utiliza-se var, estamos dizendo ao compilador:
                coloque dentro do var o nome do tipo que eu tenho na expressão da minha atribuição,
                no 1° caso: ContaCorrente / 2° caso: GerenciadorBonificacao etc.
                Utiliza-se o var p/ ter um código mais legível e não repetir 
                "ContaCorrente" / "GerenciadorBonificacao" etc, o tempo tdo,
                e tbm não utilizar nomes genéricos demais como "T". */

                //Forma correta de atribuir uma var:
                var conta = new ContaCorrente(344, 56456456);
                var gerenciador = new GerenciadorBonificacao();
                var gerenciadores = new List<GerenciadorBonificacao>();

                /* Ao ler tudo isso, o compilador transforma nisso:

                ContaCorrente conta = new ContaCorrente(344, 56456456);
                GerenciadorBonificacao gerenciador = new GerenciadorBonificacao();
                List<GerenciadorBonificacao> gerenciadores = new List<GerenciadorBonificacao>(); 

                Não é possível criar var solta, como exemplo:
                var idade;
                O compilador não sabe qual o tipo foi atribuído pois não possui expressaõ de atribuição! 
                Portanto, é necessário inicializar uma var assim:
                var idade = 14;
                Após atribuir valor à var, ela fica tipada e não é possível alterar seu tipo, exemplo:
                idade = "algum texto aqui";
                Não compila! idade foi definida como INT implicitamente, logo, não recebe string!
                Outro exemplo, definindo a var como string implicitamente:
                var nome = "Fulano";
                nome = 123;
                Não compila! var nome só aceita string! */
            }

            /**************************************************************************************
            *                Trabalhando com os métodos da classe LIST e Extensões                *
            **************************************************************************************/
            static void TestaList()
            {
                //Testando os métodos da classe LIST:
                List<int> idades = new List<int>();

                idades.Add(1);
                idades.Add(5);
                idades.Add(14);
                idades.Add(25);
                idades.Add(38);
                idades.Add(61);
                //idades.Remove(5);


                /* O tipo LIST do .net não possui um método chamado "AdicionarVarios", 
                esse método "AdicionarVarios" é um método de extensão que criamos dentro da classe "ListExtensoes",
                e somente é permitido extende-lo (dentro do LIST) à partir da palavra reservada "this",
                dessa forma é possível criar uma lista de arrays da seguinte maneira: */
                idades.AdicionarVarios(45, 89, 12);
                /* Por debaixo dos panos, o compilador está executando o seguinte código:
                ListExtensoes.AdicionarVarios(idades, 45, 89, 12);             */

                /* Como diferenciar um método definido na classe e um método de extensão? 
                Quando o método é da classe mãe, aparece um cubo roxo ao digita-lo,
                quando o método é EXTENSÃO, aparece um cubo roxo + seta para baixo \/,
                além de termos a definição de extenção na descrição. */

                for (int i = 0; i < idades.Count; i++)
                {
                    //Console.WriteLine(idades[i]); DESCOMENTAR AQUI QUANDO TESTAR ESSE MÉTODO
                }
                Console.ReadLine();
            }

            //Só chamando pra parar de dar warning!
            TestaVariavelGenerica();
            TestaList();
            TestaSort();
        }
    }
}
