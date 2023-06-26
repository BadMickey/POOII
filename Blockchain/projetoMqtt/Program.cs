using System;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Teste");
        /*
        // Configurar cliente MQTT para enviar comandos ao Projeto A
        var mqttClient = new MqttFactory().CreateMqttClient();
        var mqttOptions = new MqttClientOptionsBuilder()
            .WithTcpServer("localhost", 1883)
            .Build();

        await mqttClient.ConnectAsync(mqttOptions);

        // Loop para enviar requisições MQTT a cada 30 segundos
        while (true)
        {
            // Envie a requisição MQTT para o Projeto A com um parâmetro
            var parametro = "exemplo";
            var message = new MqttApplicationMessageBuilder()
                .WithTopic("chamar_funcao")
                .WithPayload(parametro)
                .Build();

            await mqttClient.PublishAsync(message);

            Console.WriteLine($"Requisição enviada para chamar a função com o parâmetro: {parametro}");

            // Aguardar 30 segundos antes de enviar a próxima requisição
            await Task.Delay(TimeSpan.FromSeconds(30));
        */
        }
    }
}