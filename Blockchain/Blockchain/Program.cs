using System;
using Banco;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ProjetoBlockchain.Banco;

namespace ProjetoBlockchain
{
    public class Program
    {
        public static bool AcessoAutoridadeModeradora = false;
        static void Main(string[] args)
        {
            //"Server=localhost;Port=5433;User Id=postgres;Password=0000;database=Blockchain";
            Console.WriteLine("Seja bem-vindo a Blockchain da Smart Home Security System!");
            Console.WriteLine("Digite abaixo a connection string do banco de dados:");
            string connection = Console.ReadLine();
            string connectionString = connection;
            Console.WriteLine("Blockchain carregada!");
            Blockchain blockchain = new Blockchain(connectionString);

            Console.WriteLine("Por favor digite suas credenciais de acesso para autenticar seu nível de acesso! ");
            Console.Write("Email: ");
            String Email = Console.ReadLine();
            Console.Write("Senha: ");
            String Senha = Console.ReadLine();
            Autenticacao autenticacao= new Autenticacao();
            autenticacao.Autenticar(Email, Senha);

            if(AcessoAutoridadeModeradora == true)
            {
                Console.WriteLine("Você como Autoridade Moderadora autenticada consegue realizar as seguintes ações:");
                Console.WriteLine("1 - Adicionar sensores");
                Console.WriteLine("2 - Alterar sensores");
                int AcaoModerador = Console.Read();
                
                switch(AcaoModerador)
                {
                    case 1:
                        Console.Write("Digite o ID do sensor: ");
                        String sensor = Console.ReadLine();
                        blockchain.AddBlock("Sensor1", false);
                        break;
                    case 2:
                        break;

                }
            }

            

            // Simula a adição de blocos à blockchain
            blockchain.AddBlock("Sensor1", true);
            blockchain.AddBlock("Sensor2", false);

            // Simula a alteração de status do sensor
            blockchain.ChangeSensorStatus("Sensor1", false);

            //bool isChainValid = blockchain.IsChainValid();

            Console.WriteLine("Blockchain is valid: " + blockchain.IsChainValid());
            Console.ReadLine();
        }
    }
}
