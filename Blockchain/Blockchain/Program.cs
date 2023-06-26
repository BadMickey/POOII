using System;
using System.Diagnostics;
using MQTTnet;
using MQTTnet.Client;
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

            int opcaoPrimaria = 0;
            while(true)
            {
                Console.WriteLine("Você pode escolher entre:");
                Console.WriteLine("1 - Visualizar os sensores apitando");
                Console.WriteLine("2 - Autenticar algum usuário");
                opcaoPrimaria = Convert.ToInt32(Console.ReadLine());
                switch (opcaoPrimaria)
                {
                    case 1:
                        Console.WriteLine("Abrindo logs");
                        var processInfo = new ProcessStartInfo
                        {
                            FileName = "dotnet",
                            Arguments = "run --project projetoMqtt.csproj",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        var process = Process.Start(processInfo);
                        break;
                    case 2:
                        Console.WriteLine("Por favor digite suas credenciais de acesso para autenticar seu nível de acesso! ");
                        Console.Write("Email: ");
                        String Email = Console.ReadLine();
                        Console.Write("Senha: ");
                        String Senha = Console.ReadLine();
                        Autenticacao autenticacao = new Autenticacao();
                        autenticacao.Autenticar(Email, Senha);
                        bool AcoesLogin = true;
                        while (AcoesLogin)
                        {
                            if (AcessoAutoridadeModeradora == true)
                            {
                                Console.Clear();
                                Console.WriteLine("Você como Autoridade Moderadora autenticada consegue realizar as seguintes ações:");
                                Console.WriteLine("1 - Adicionar sensores");
                                Console.WriteLine("2 - Alterar sensores");
                                Console.WriteLine("3 - Localizar o bloco mais recente de um determinado ID");
                                Console.WriteLine("4 - Verificar a autenticidade dos blocos da blockchain");
                                Console.WriteLine("5 - Sair/Voltar");
                                int AcaoModerador = Convert.ToInt32(Console.ReadLine());
                                //Ações
                                switch (AcaoModerador)
                                {
                                    case 1:
                                        Console.Write("Digite o ID do sensor: ");
                                        String Sensor = Console.ReadLine();
                                        Console.Write("Digite o endereço do local onde fica o sensor: ");
                                        String Address = Console.ReadLine();
                                        blockchain.AddBlock(Sensor, Address, false);
                                        Console.WriteLine("Bloco adicionado. Deseja voltar para executar outros comandos?");
                                        Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.Write("Digite o ID do sensor: ");
                                        Sensor = Console.ReadLine();
                                        Console.Write("Digite o novo status do sensor: ");
                                        bool NewStatus = bool.Parse(Console.ReadLine());
                                        blockchain.ChangeSensorStatus(Sensor, NewStatus);
                                        Console.ReadLine();
                                        break;
                                    case 3:
                                        Console.Write("Digite o ID do sensor para localizar: ");
                                        String SensorLocalize = Console.ReadLine();
                                        Block latestBlock = blockchain.GetLatestBlockForSensor(SensorLocalize);
                                        Console.WriteLine($"Último bloco com esse Id está com o seguinte status de alarme: {latestBlock?.MotionDetected}");
                                        Console.ReadLine();
                                        break;
                                    case 4:
                                        Console.WriteLine(blockchain.IsChainValid());
                                        Console.ReadLine();
                                        break;
                                    case 5:
                                        AcoesLogin = false;
                                        break;
                                }
                            }
                            else//Ações usuário normal
                            {
                                Console.Clear();
                                Console.WriteLine("Você como usuário comum consegue realizar as seguintes ações:");
                                Console.WriteLine("1 - Localizar sensores");
                                Console.WriteLine("2 - Verificar a autenticidade dos blocos da blockchain");
                                Console.WriteLine("3 - Sair/Voltar");
                                int AcaoComum = Convert.ToInt32(Console.ReadLine());

                                switch (AcaoComum)
                                {
                                    case 1:
                                        Console.Write("Digite o ID do sensor para localizar: ");
                                        String SensorLocalize = Console.ReadLine();
                                        Block latestBlock = blockchain.GetLatestBlockForSensor(SensorLocalize);
                                        Console.WriteLine($"Último bloco com esse Id está com o seguinte status de alarme: {latestBlock?.MotionDetected}");
                                        Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.WriteLine(blockchain.IsChainValid());
                                        Console.ReadLine();
                                        break;
                                    case 3:
                                        AcoesLogin = false;
                                        break;
                                }
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
