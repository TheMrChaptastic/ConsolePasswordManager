using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager
{
    public static class PasswordGenerator
    {
        static Random random = new Random();
        public static string MakePassword(int maxLength, bool cap, bool sChar)
        {
            var rStr = "";
            var alph = "abcdefghijklmnopqrstuvwxyz";
            var nums = "0123456789";
            var sChars = "!$#";
            var sCharAdded = false;
            var numOrLet = 0;

            for (int i = 0; i < maxLength; i++)
            {
                if (i == 0 && cap == true)
                {
                    rStr += alph[random.Next(alph.Length)].ToString().ToUpper();
                }
                if (i == maxLength / 3 && sChar == true && sCharAdded == false)
                {
                    rStr += sChars[random.Next(sChars.Length)];
                    sCharAdded = true;
                }
                else
                {
                    numOrLet = random.Next(2);
                    if (numOrLet == 1)
                    {
                        rStr += alph[random.Next(alph.Length)].ToString();
                    }
                    else
                    {
                        rStr += nums[random.Next(nums.Length)];
                    }
                }
            }

            return rStr;
        }
    }
}
