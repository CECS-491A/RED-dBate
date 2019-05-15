using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.Models;

namespace KFC.Red.ServiceLayer.Authorization
{
    public class ConstantClaims
    {
        //talk in chat, talk in team chat1, talk in team chat 2, start game, close game, leave game, decide winner
        public readonly Claim GLOBAL_CHAT;
        public readonly Claim TEAM_CHAT1;
        public readonly Claim TEAM_CHAT2;
        public readonly Claim START_GAME;
        public readonly Claim CLOSE_GAME;
        public readonly Claim LEAVE_GAME;
        public readonly Claim DECIDE_WINNER;

        public ConstantClaims()
        {
            GLOBAL_CHAT = new Claim(1, "GlobalChat");
            TEAM_CHAT1 = new Claim(2, "TeamChat1");
            TEAM_CHAT2 = new Claim(3, "TeamChat2");
            START_GAME = new Claim(4, "StartGame");
            CLOSE_GAME = new Claim(5, "CloseGame");
            LEAVE_GAME = new Claim(6, "LeaveGame");
            DECIDE_WINNER = new Claim(7, "DecideWinner");

        }
    }
}
