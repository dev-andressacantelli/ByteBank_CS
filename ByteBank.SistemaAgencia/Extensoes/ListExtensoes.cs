using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    {
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
        {
            foreach (T item in itens)
            {
                lista.Add(item);
            }
        }

        public static void TesteGenerico<T2>(this string texto)
        {

        }

        static void Teste()
        {
            List<int> idades = new List<int>();

            idades.Add(14);
            idades.Add(26);
            idades.Add(60);

            
            idades.AdicionarVarios(54, 5465, 456);
            //Esse código não precisa determinar o tipo <>, é o mesmo que esse:
            //idades.AdicionarVarios<int>(54, 5465, 456);

            string andressa = "Abdressa";
            andressa.TesteGenerico<int>();

            //ListExtensoes<int>.AdicionarVarios(idades, 2, 3, 4);

            List<string> nomes = new List<string>();

            nomes.Add("Andressa");

            //ListExtensoes<string>.AdicionarVarios(nomes, "Andressa", "Fulano");

            nomes.AdicionarVarios("Andressa", "Fulano");
        }
    }
}

 