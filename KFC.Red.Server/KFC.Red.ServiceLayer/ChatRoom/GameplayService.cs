using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KFC.Red.DataAccessLayer.Models;
namespace KFC.Red.ServiceLayer.ChatRoom
{
    public class GameplayService
    {
        public int AssignTeam(List<User> users)
        {
            int t1Count = 0, t2Count = 0;
            for (int i = 0; i < users.Count(); i++)
            {
                if (String.Equals(users[i].Role, "Team1"))
                {
                    t1Count++;
                }
                else if (String.Equals(users[i].Role, "Team2"))
                {
                    t2Count++;
                }
            }
            if(t1Count <= t2Count)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public int AssignOrder(List<User> currentTeam, List<UserGameStorage> ugs)
        {
            List<int> orders = new List<int>();

            for (int i = 0; i < ugs.Count; i++)
            {
                for (int j = 0; j < currentTeam.Count; j++)
                {
                    if (ugs[i].UId == currentTeam[j].ID)
                    {
                        orders.Add(ugs[i].Order);
                    }
                }
            }
            if (orders.Contains(1) == false)
            {
                return 1;
            }
            else if (orders.Contains(2)== false)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }

}
