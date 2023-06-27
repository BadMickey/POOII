using System;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Npgsql;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Data;

class Program
{
    static MqttClient mqttClient;

    static async Task Main(string[] args)
    {
        string connectionString = "Server=localhost;Port=5433;User Id=postgres;Password=0000;database=Blockchain";
        List<int> sensores = new List<int>();
        Random random = new Random();
        
        mqttClient = new MqttClient("localhost");

        string clientId = Guid.NewGuid().ToString();
        mqttClient.Connect(clientId);

        // Loop para enviar requisições MQTT a cada 30 segundos
        while (true)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT sensorid FROM blocks";
                using (var command = new NpgsqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int sensor = reader.GetInt32(0);
                            sensores.Add(sensor);
                        }
                    }
                }
                connection.Close();
            }

            int posicao = random.Next(1, sensores.Count);
            bool status = random.Next(2) == 0;
            // Construir os dados da requisição MQTT
            string dados = SerializeMessage(sensores[posicao], status);

            // Enviar a requisição MQTT para o Projeto A com o tópico "data"
            mqttClient.Publish("sensorid", System.Text.Encoding.UTF8.GetBytes(dados), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);

            // Aguardar 30 segundos
            Thread.Sleep(TimeSpan.FromSeconds(10));
        
        }
    }
    static string SerializeMessage(int sensorid, bool status)
    {
        var messageObj = new
        {
            Sensorid = sensorid,
            Status = status
        };

        return JsonConvert.SerializeObject(messageObj);
    }
}