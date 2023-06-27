using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Diagnostics;
using Banco;
using System.Collections.Generic;
using System.Text;
using ProjetoBlockchain.Banco;
using Model;
using Newtonsoft.Json;

namespace ProjetoBlockchain
{
    public class Program
    {
        static MqttClient mqttClient;

        public static bool AcessoAutoridadeModeradora = false;
        static string connectionString = "Server=localhost;Port=5433;User Id=postgres;Password=0000;database=Blockchain";
        static Blockchain blockchain = new Blockchain(connectionString);

        static void Main(string[] args)
        {
            //"Server=localhost;Port=5433;User Id=postgres;Password=0000;database=Blockchain";
            //Parte de carregamento da Blockchain na memória da máquina
            Console.WriteLine("Seja bem-vindo a Blockchain da Smart Home Security System!");
            //Console.WriteLine("Digite abaixo a connection string do banco de dados:");
            //string connection = Console.ReadLine();
            Console.WriteLine("Blockchain carregada!");

            int opcaoPrimaria = 0;
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Você pode escolher entre:");
                Console.WriteLine("1 - Visualizar os sensores apitando");
                Console.WriteLine("2 - Autenticar algum usuário");
                opcaoPrimaria = Convert.ToInt32(Console.ReadLine());
                switch (opcaoPrimaria)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Abrindo logs");
                        var processInfo = new ProcessStartInfo
                        {
                            FileName = "C:\\Users\\Joãovirone\\Documents\\Projetos\\POOII\\Blockchain\\projetoMqtt\\bin\\Debug\\net6.0\\projetoMqtt.exe",
                            Arguments = $"/k dotnet run --project projetoMqtt.csproj",
                            UseShellExecute = true

                        };

                        var process = Process.Start(processInfo);

                        
                        mqttClient = new MqttClient("localhost");

                        string clientId = Guid.NewGuid().ToString();
                        mqttClient.Connect(clientId);

                        // Inscrever-se ao tópico do Projeto B para receber as mensagens enviadas por ele
                        mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
                        mqttClient.Subscribe(new string[] { "sensorid" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

                        Console.WriteLine("Pressione qualquer tecla para parar o recebimento de requisições e sair");
                        Console.ReadKey();

                        mqttClient.Publish("stop", new byte[0], MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                        mqttClient.Disconnect();

                        process.Kill();
                        break;
                    case 2:
                        Console.Clear();
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
                                        int Sensor = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Digite o endereço do local onde fica o sensor: ");
                                        String Address = Console.ReadLine();
                                        blockchain.AddBlock(Sensor, Address, false);
                                        Console.WriteLine("Bloco adicionado. Deseja voltar para executar outros comandos?");
                                        Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.Write("Digite o ID do sensor: ");
                                        Sensor = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Digite o novo status do sensor: ");
                                        bool NewStatus = bool.Parse(Console.ReadLine());
                                        blockchain.ChangeSensorStatus(Sensor, NewStatus);
                                        Console.ReadLine();
                                        break;
                                    case 3:
                                        Console.Write("Digite o ID do sensor para localizar: ");
                                        int SensorLocalize = Convert.ToInt32(Console.ReadLine());
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
                                        Console.Clear();
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
                                        int SensorLocalize = Convert.ToInt32(Console.ReadLine());
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
                                        Console.Clear();
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
        private static void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // Processar a mensagem recebida do Projeto B
            string mensagem = System.Text.Encoding.UTF8.GetString(e.Message);

            var messageObj = DeserializeMessage(mensagem);
            int sensorid = messageObj.Sensorid;
            bool status = messageObj.Status;

            blockchain.ChangeSensorStatus(sensorid, status);

            if (status)
            {
                Console.WriteLine($"O sensor {sensorid} foi ligado e está apitando!");
            }
            else
            {
                Console.WriteLine($"O sensor {sensorid} foi desligado");
            }
        }

        static dynamic DeserializeMessage(string mensagem)
        {
            return JsonConvert.DeserializeObject(mensagem);
        }
    }
}
