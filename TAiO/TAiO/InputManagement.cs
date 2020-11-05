using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAiO
{
    public class InputManagement
    {
        public static List<int> ParseNList(string text)
        {
            text = text.Trim();
            var parsed_list = new List<int>();
            var substrings = text.Split(' ');
            foreach(string s in substrings)
            {
                int num;
                if (int.TryParse(s, out num))
                    parsed_list.Add(num);
                else
                    return null;
            }
            return parsed_list;
        }
    }
}
