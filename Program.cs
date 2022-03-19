using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public interface IBanco
    {
        string Agencia { get; set; }
        string Conta { get; set; }

        void Conectar();
    }

    public interface IToken
    {
        string Token1024Bits { get; set; }
    }

    public class Bradesco : IBanco
    {
        public string Agencia { get; set; }
        public string Conta { get; set; }

        public Bradesco(string Age, string Con)
        {
            this.Agencia = Age;
            this.Conta = Con;
        }

        public void Conectar()
        {
            // 3 coisas
        }
    }

    public class Santander: IBanco, IToken
    {
        public string Agencia { get; set; }
        public string Conta { get; set; }

        public Santander(string Age, string Con)
        {
            this.Agencia = Age;
            this.Conta = Con;
        }

        public string Token1024Bits { get; set; }

        public void Conectar()
        {
            // Verifica Token

            // 5 coisas
        }
    }

    public class CEF : IBanco
    {
        public string Agencia { get; set; }
        public string Conta { get; set; }

        public CEF(string Age, string Con)
        {
            this.Agencia = Age;
            this.Conta = Con;
        }

        public void Conectar()
        {
            // 4 coisas
        }
    }

    public class ModuloPagamentos
    {
        private IBanco BancoTemp;

        public ModuloPagamentos(IBanco Info)
        {
            BancoTemp = Info;
        }

        public void EnviarPix(string Chave, double valor)
        {
            BancoTemp.Conectar();

            Console.WriteLine("PIX Enviado do " + BancoTemp.ToString() +
                              " para " + Chave + " no valor de " +
                              valor.ToString());
        }

        public void TransferenciaBancaria(IBanco BancoDestino, double valor)
        {
            BancoTemp.Conectar();

            Console.WriteLine("Transferido " + valor.ToString() + 
                              " do banco " + BancoTemp.ToString() +
                             " para o banco " + BancoDestino.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bradesco Bc01 = new Bradesco("123", "4567");
            
            Santander Bc02 = new Santander("3234", "3324");
            Bc02.Token1024Bits = "";

            ModuloPagamentos Pag = new ModuloPagamentos(Bc01);
            Pag.EnviarPix("a@dd", 100);

            ModuloPagamentos Pag2 = new ModuloPagamentos(Bc02);
            Pag2.EnviarPix("234434324", 200);

            Pag.TransferenciaBancaria(Bc02, 200);

            // CEF Bc03 = new CEF("2323", "3324");

            Console.ReadLine();
        }
    }
}
