using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC.RED.DataAccessLayer.DTOs
{
    public class GameSessionDTO
    {
        public string Token { get; set; }

        public string Question { get; set; }

        public bool IsSessionUsed { get; set; }

        public int PlayerCount { get; set; }
        public string GameRole { get; set; }
        public int Order { get; set; }
    }
}
