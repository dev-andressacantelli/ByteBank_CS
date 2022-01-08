using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }

        public override bool Equals(object obj)
        {
            /* Conversão explícita do tipo OBJECT pro tipo CLIENTE;
            Quando a conversão não é feita com sucesso, a variável outroCliente será nula,
            portanto, aparecerá uma exceção de null; */
            Cliente outroCliente = obj as Cliente; 

            if (outroCliente == null)
            {
                return false;
            }

            //COMPARANDO CAMPO PK PARA DETERMINAR IGUALDADE ENTRE DUAS ENTIDADES
            return CPF == outroCliente.CPF;
        }
    }
}
