using System;
using Banco;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProjetoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = "Server=localhost;Port=5433;User Id=postgres;Password=0000;database=Blockchain";

            Console.WriteLine("Seja bem-vindo a Blockchain da Smart Home Security System!");
            Console.WriteLine("Por favor digite suas credenciais de acesso para autenticar seu nível de acesso! ");
            Console.Write("Email: ");
            String Email = Console.ReadLine();
            Console.Write("\nSenha: ");
            String Senha = Console.ReadLine();


            /*
            Blockchain blockchain = new Blockchain(connectionString);

            // Simula a adição de blocos à blockchain
            blockchain.AddBlock("Sensor1", true);
            blockchain.AddBlock("Sensor2", false);

            // Simula a alteração de status do sensor
            blockchain.ChangeSensorStatus("Sensor1", false);

            //bool isChainValid = blockchain.IsChainValid();

            Console.WriteLine("Blockchain is valid: " + blockchain.IsChainValid());
            Console.ReadLine();*/
        }
    }
}
