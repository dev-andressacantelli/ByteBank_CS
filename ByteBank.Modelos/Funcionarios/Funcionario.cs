using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public abstract class Funcionario
    {
        public static int TotalDeFuncionarios { get; private set; }

        public string Nome { get; set; }

        public string CPF { get; private set; }
        
        public double Salario { get; protected set; }

        public Funcionario(double salario, string cpf)
        {
            Console.WriteLine("Criando FUNCIONARIO");

            CPF = cpf;
            Salario = salario;

            TotalDeFuncionarios++;
        }

        public abstract void AumentarSalario();

        /* internal protected é considerável um único modificador de acesso,
        não existe outro modificador de acesso com dois nomes mesclados além desse;

        GetBonificacao = visível dentro do projeto modelos e qualquer classe que deriva, 
        inclusive classes fora desse projeto;   */
        internal protected abstract double GetBonificacao(); 
    }
}
