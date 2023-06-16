using System;
using Banco;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using ProjetoBlockchain.Banco;
using Model;

namespace ProjetoBlockchain
{
    public class Program
    {
        public static bool AcessoAutoridadeModeradora = false;
        static void Main(string[] args)
        {
            //"Server=localhost;Port=5433;User Id=postgres;Password=0000;database=Blockchain";
            //Parte de carregamento da Blockchain na memória da máquina
            Console.WriteLine("Seja bem-vindo a Blockchain da Smart Home Security System!");
            //Console.WriteLine("Digite abaixo a connection string do banco de dados:");
            //string connection = Console.ReadLine();
            string connectionString = "Server=localhost;Port=5433;User Id=postgres;Password=0000;database=Blockchain";
            Console.WriteLine("Blockchain carregada!");
            Blockchain blockchain = new Blockchain(connectionString);

            //Autenticação de usuário para definir as ações
            Console.WriteLine("Por favor digite suas credenciais de acesso para autenticar seu nível de acesso! ");
            Console.Write("Email: ");
            String Email = Console.ReadLine();
            Console.Write("Senha: ");
            String Senha = Console.ReadLine();
            Autenticacao autenticacao= new Autenticacao();
            autenticacao.Autenticar(Email, Senha);
            //Verifica o nível do acesso
            if(AcessoAutoridadeModeradora == true)
            {
                Console.WriteLine("Você como Autoridade Moderadora autenticada consegue realizar as seguintes ações:");
                Console.WriteLine("1 - Adicionar sensores");
                Console.WriteLine("2 - Alterar sensores");
                Console.WriteLine("3 - Localizar o bloco mais recente de um determinado ID");
                Console.WriteLine("4 - Verificar a autenticidade dos blocos da blockchain");
                int AcaoModerador = Convert.ToInt32(Console.ReadLine());
                //Ações
                switch(AcaoModerador)
                {
                    case 1:
                        Console.Write("Digite o ID do sensor: ");
                        String Sensor = Console.ReadLine();
                        Console.Write("Digite o endereço do local onde fica o sensor: ");
                        String Address = Console.ReadLine();
                        blockchain.AddBlock(Sensor, Address, false);
                        break;
                    case 2:
                        Console.Write("Digite o ID do sensor: ");
                        Sensor = Console.ReadLine();
                        Console.Write("Digite o novo status do sensor: ");
                        bool NewStatus = bool.Parse(Console.ReadLine());
                        blockchain.ChangeSensorStatus(Sensor, NewStatus);
                        break;
                    case 3:
                        Console.Write("Digite o ID do sensor para localizar: ");
                        String SensorLocalize = Console.ReadLine();
                        Block latestBlock = blockchain.GetLatestBlockForSensor(SensorLocalize);
                        Console.WriteLine($"Último bloco com esse Id está com o seguinte status de alarme: {latestBlock?.MotionDetected}");
                        break;
                    case 4:
                        Console.WriteLine(blockchain.IsChainValid());
                        break;
                }
 
            }
            else//Ações usuário normal
            {
                Console.WriteLine("Você como usuário comum consegue realizar as seguintes ações:");
                Console.WriteLine("1 - Localizar sensores");
                Console.WriteLine("2 - Verificar a autenticidade dos blocos da blockchain");
                int AcaoComum = Convert.ToInt32(Console.ReadLine());

                switch (AcaoComum)
                {
                    case 1:
                        Console.Write("Digite o ID do sensor para localizar: ");
                        String SensorLocalize = Console.ReadLine();
                        Block latestBlock = blockchain.GetLatestBlockForSensor(SensorLocalize);
                        Console.WriteLine($"Último bloco com esse Id está com o seguinte status de alarme: {latestBlock?.MotionDetected}");
                        break;
                    case 2:
                        Console.WriteLine(blockchain.IsChainValid());
                        break;
                }
            }
        }
    }
}
