using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Banco
{
    public class Blockchain
    {
        private List<Block> chain;
        private string connectionString;

        public Blockchain(string connectionString)
        {
            chain = new List<Block>();
            this.connectionString = connectionString;
            InitializeBlockchain();
        }

        private void InitializeBlockchain()
        {
            Boolean genesis = false;
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Blocks ORDER BY Nonce DESC";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Block genesisBlock = new Block
                            {
                                Nonce = reader.GetInt32(0),
                                Timestamp = reader.GetDateTime(1),
                                SensorId = reader.GetString(2),
                                MotionDetected = reader.GetBoolean(3),
                                PreviousHash = reader.GetString(4),
                                Hash = reader.GetString(5)
                            };

                            chain.Add(genesisBlock);
                        }
                        else
                        {
                            Block genesisBlock = new Block
                            {
                                Nonce = 0,
                                Timestamp = DateTime.Now,
                                SensorId = "Bloco gênese",
                                MotionDetected = false,
                                PreviousHash = string.Empty,
                                Hash = CalculateHash(0, DateTime.Now, "Bloco gênese", false, string.Empty)
                            };
                            chain.Add(genesisBlock);
                            genesis = true;
                        }
                    }
                }
                if (genesis == true)
                {
                    string query1 = "INSERT INTO Blocks (Nonce, Timestamp, SensorId, MotionDetected, PreviousHash, Hash) VALUES (@Nonce, @Timestamp, @SensorId, @MotionDetected, @PreviousHash, @Hash)";
                    using (NpgsqlCommand command1 = new NpgsqlCommand(query1, connection))
                    {
                        command1.Parameters.AddWithValue("@Nonce", chain[0].Nonce);
                        command1.Parameters.AddWithValue("@Timestamp", chain[0].Timestamp);
                        command1.Parameters.AddWithValue("@SensorId", chain[0].SensorId);
                        command1.Parameters.AddWithValue("@MotionDetected", chain[0].MotionDetected);
                        command1.Parameters.AddWithValue("@PreviousHash", chain[0].PreviousHash);
                        command1.Parameters.AddWithValue("@Hash", chain[0].Hash);

                        command1.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AddBlock(string sensorId, bool motionDetected)
        {
            Block previousBlock = chain[chain.Count - 1];
            int newNonce = previousBlock.Nonce + 1;
            DateTime newTimestamp = DateTime.Now;
            string newHash = CalculateHash(newNonce, newTimestamp, sensorId, motionDetected, previousBlock.Hash);

            Block newBlock = new Block
            {
                Nonce = newNonce,
                Timestamp = newTimestamp,
                SensorId = sensorId,
                MotionDetected = motionDetected,
                PreviousHash = previousBlock.Hash,
                Hash = newHash
            };

            chain.Add(newBlock);

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Blocks (Nonce, Timestamp, SensorId, MotionDetected, PreviousHash, Hash) VALUES (@Nonce, @Timestamp, @SensorId, @MotionDetected, @PreviousHash, @Hash)";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nonce", newNonce);
                    command.Parameters.AddWithValue("@Timestamp", newTimestamp);
                    command.Parameters.AddWithValue("@SensorId", sensorId);
                    command.Parameters.AddWithValue("@MotionDetected", motionDetected);
                    command.Parameters.AddWithValue("@PreviousHash", previousBlock.Hash);
                    command.Parameters.AddWithValue("@Hash", newHash);

                    command.ExecuteNonQuery();
                }
            }
        }

        private string CalculateHash(int nonce, DateTime timestamp, string sensorId, bool motionDetected, string previousHash)
        {
            string input = $"{nonce}-{timestamp}-{sensorId}-{motionDetected}-{previousHash}";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public string IsChainValid()
        {
            for (int i = 1; i < chain.Count; i++)
            {
                Block currentBlock = chain[i];
                Block previousBlock = chain[i - 1];

                if (currentBlock.Hash != CalculateHash(currentBlock.Nonce, currentBlock.Timestamp, currentBlock.SensorId, currentBlock.MotionDetected, previousBlock.Hash))
                {
                    return "A blockchain está com algum bloco inválido!";
                }
            }

            return "A blockchain está válida!";
        }

        public void ChangeSensorStatus(string sensorId, bool newStatus)
        {
            Block previousBlock = chain[chain.Count - 1];
            int newIndex = previousBlock.Nonce + 1;
            DateTime newTimestamp = DateTime.Now;
            string newHash = CalculateHash(newIndex, newTimestamp, sensorId, newStatus, previousBlock.Hash);

            Block newBlock = new Block
            {
                Nonce = newIndex,
                Timestamp = newTimestamp,
                SensorId = sensorId,
                MotionDetected = newStatus,
                PreviousHash = previousBlock.Hash,
                Hash = newHash
            };

            chain.Add(newBlock);

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Blocks (Nonce, Timestamp, SensorId, MotionDetected, PreviousHash, Hash) VALUES (@Nonce, @Timestamp, @SensorId, @MotionDetected, @PreviousHash, @Hash)";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nonce", newIndex);
                    command.Parameters.AddWithValue("@Timestamp", newTimestamp);
                    command.Parameters.AddWithValue("@SensorId", sensorId);
                    command.Parameters.AddWithValue("@MotionDetected", newStatus);
                    command.Parameters.AddWithValue("@PreviousHash", previousBlock.Hash);
                    command.Parameters.AddWithValue("@Hash", newHash);

                    command.ExecuteNonQuery();
                }
            }
        }
        public Block GetLatestBlockForSensor(string sensorId)
        {
            //foreach (var block in chain)
            //{
            //    if (block.SensorId == sensorId)
            //    {
            //        return block.MotionDetected;
            //    }
            //}

            //return false;
            return chain.LastOrDefault(b => b.SensorId == sensorId);
        }
    }

}
