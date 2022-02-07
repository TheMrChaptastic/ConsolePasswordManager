using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager
{
    public class Parser
    {
        public TrackData Parse(string line)
        {
            var cells = line.Split(',');
            if (cells.Length < 6) //Makes sure lines are correctly formatted
            {
                return null;
            }
            for(int i = 0; i < cells.Length; i++)
            {
                cells[i] = cells[i].Trim();
            }

            var service = cells[0]; 
            var email = cells[1];
            var password = cells[2];
            var sChar = bool.Parse(cells[3]);
            var uCase = bool.Parse(cells[4]);
            var length = int.Parse(cells[5]);

            var data = new TrackData() { Service = service, Email = email, Password = password, SChar = sChar, UCase = uCase, PassLength = length };

            return data;
        }
    }
}
