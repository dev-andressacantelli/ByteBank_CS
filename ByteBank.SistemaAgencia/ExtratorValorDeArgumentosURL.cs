using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {
        private readonly string _argumentos;
        public string URL { get; }

        public ExtratorValorDeArgumentosURL(string url)
        {
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url não pode ser nulo ou vazio.", nameof(url));
            }

            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao + 1);

            URL = url;
        }

        /* O método GetValor consegue executar ambas as digitações:
        moedaOrigem=real&moedaDestino=dolar
        MOEDAORIGEM=REAL&MOEDADESTINO=DOLAR */
        public string GetValor(string nomeParametro)
        {
            
            //Adicionando métodos para converter p/ caixa alta caso usuário escreva em caixa baixa etc;
            nomeParametro = nomeParametro.ToUpper(); // valor passará à ser VALOR
            string argumentoCaixaAlta = _argumentos.ToUpper(); // passará à ser: MOEDAORIGEM=REAL&MOEDADESTINO=DOLAR

            string termo = nomeParametro + "="; //moedaDestino=
            int indiceTermo = argumentoCaixaAlta.IndexOf(termo); //x

            //coloca-se _argumentos neste caso pois independente de caixa alta ou baixa, o TAMANHO(length) continua o mesmo!
            string resultado = _argumentos.Substring(indiceTermo + termo.Length); //dolar
            int indiceEcomercial = resultado.IndexOf('&');

            if(indiceEcomercial == -1)
            {
                return resultado;
            }

            return resultado.Remove(indiceEcomercial);
        }
    }
}

       
