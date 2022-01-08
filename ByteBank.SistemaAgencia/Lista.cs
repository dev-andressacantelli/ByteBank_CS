using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.SistemaAgencia
{
    /* Classe que utiliza argumento de tipo genérico, PORTANTO utiliza-se o argumento dentro de <>,
    como por exemplo: <T>, que poderia ser qualquer nome, como por exemplo: <MeuTipoGenerico>. 
    Porém é convencional utilizar nomes pequenos p/ não serem confundidos com classes.           */
    public class Lista<T>
    {
        // T é tipo, ele indica os lugares genéricos onde precisarão ser alterado p/ classe indicada!
        private T[] _itens;
        private int _proximaPosicao; //O valor padrão é ZERO;


        //Número de itens que existem na nossa lista:
        public int Tamanho
        {
            get //Pessoas de fora, com código externo não devem alterar o tamanho da lista, portanto somente GET;
            {
                return _proximaPosicao; //A _proximaPosicao coincide com o número de elementos que já existem no array;
            }
        }


        /*O argumento (int capacidadeInicial) é opcional,
        portanto o compilador utilizará 5 como default,   
        podendo ser alterado quando for instanciado.   */
        public Lista(int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial]; //5 é o limite de espaços no meu array;
            _proximaPosicao = 0; //Declarando novamente que é ZERO para reforçar o que já sabemos;
        }

        //Testando método que contém argumento opcional:
        public void MeuMetodo(string textoOpcional = "Texto padrão", int numeroOpcional = 10)
        {

        }

        //Método que adiciona nova conta corrente dentro do array delimitado:
        public void Adicionar(T item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

            //DESCOMENTAR ESSE TRECHO!!
            //Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");

            _itens[_proximaPosicao] = item; //item é referencia;
            _proximaPosicao++; //incrementando a posição, indo p/ a próxima posição;
        }

        /* Método que adiciona diversas contas ao mesmo tempo:
        Um array de conta corrente com vários itens. 
        Para cada item desse array adicionará o "iésimo" item;
        Estrutura do FOREACH neste método: 
        para cada "T" adicionará "item" no array "itens";   */
        public void AdicionarVarios(params T[] itens)
        {
            //O foreach não se preocupa com índices!
            foreach (T item in itens)
            {
                Adicionar(item);
            }

            //Esse trecho de código seria o mesmo que escrever assim:
            //for (int i = 0; i < itens.Length; i++)
            //{
            //    Adicionar(itens[i]);
            //}
        }

        //Método que varre o array todo "caçando" o índice do objeto idêntico ao item:
        public void Remover(T item)
        {
            int indiceItem = -1; //var que guarda o índice;

            //Varre até a próxima posição livre:
            for (int i = 0; i < _proximaPosicao; i++) // i é índice do array
            {
                T itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indiceItem = i;
                    break; //Necessário p/ parar de varrer o array
                }
            }


            //Quero remover o 0x01:
            // [0x03] [0x04] [0x05] [null]
            //                       ^
            //                         `_proximaPosicao

            for (int i = indiceItem; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--; //Decrementa a proxima posição!


            /* Trecho de código desativado:
            _itens[_proximaPosicao] = null;
            No código original, esse trecho funciona pois usamos um tipo específico,
            porém nesta classe LISTA, a classe não sabe se o tipo de <T> é um tipo de referência ou tipo de valor, 
            portanto não compila e acusa erro! 
            Porém aqui nesta classe, 
            não há problema retirar esse trecho de código pois o valor de _proximaPosicao será = item 
            (como lá em cima no método adicionar);    */
        }


        //Verifica os valores do nosso índice, que não pode ser negativo:
        public T GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        //Método que verifica a capacidade do Array:
        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return; //Não retorna nada pois o array já comporta o tamanho necessário;
            }

            /* Caso seja necessário aumentar o tamanho do array,
            não é possível aumenta-lo, portanto,
            é necessário criar um novo array para cumprir essa função: */

            //Criar uma nova variavel:
            int novoTamanho = _itens.Length * 2;
            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            //DESCOMENTAR!
            //Console.WriteLine("Aumentando capacidade da lista!");

            T[] novoArray = new T[novoTamanho];

            /* Esse novo array ^ é criado com vários itens nulos, então,
            precisamos pegar o nosso array antigo e copiar todos os valores p/ esse novo array: */
            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
                //DESCOMENTAR!
                //Console.WriteLine(".");
            }

            //Referência atual apontando para o novoArray:
            _itens = novoArray;
        }

        //Criando INDEXADOR: (ele é meio método meio propriedade);
        public T this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }
    }
}

