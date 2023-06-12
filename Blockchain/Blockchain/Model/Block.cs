using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Block
    {
        public int Nonce { get; set; }
        public DateTime Timestamp { get; set; }
        public string SensorId { get; set; }
        public bool MotionDetected { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
    }
}
