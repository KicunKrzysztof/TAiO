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
        public static List<Job> ParseFile(string file)
        {
            var job_list = new List<Job>();
            var splited_file = file.Split('\n');
            for(int i = 0; i < splited_file.Length; i = i + 3)
            {
                splited_file[i] = splited_file[i].Trim();
                int piece_size;
                if (!int.TryParse(splited_file[i], out piece_size))
                    continue;
                splited_file[i + 1] = splited_file[i + 1].Trim();
                AlgorithmType algorithm = AlgorithmType.Heuristic;
                bool bad_algorithm_parse = false;
                switch (splited_file[i + 1])
                {
                    case "ok":
                        algorithm = AlgorithmType.Optimal;
                        break;
                    case "hk":
                        algorithm = AlgorithmType.Heuristic;
                        break;
                    default:
                        bad_algorithm_parse = true;
                        break;
                }
                if (bad_algorithm_parse)
                    continue;
                List<int> n_list = ParseNList(splited_file[i + 2]);
                if (n_list == null)
                    continue;
                job_list.Add(new Job(piece_size, n_list, algorithm));
            }
            return job_list;
        }
    }
    public class Job
    {
        public int PieceSize { private set; get; }
        public List<int> NList { private set; get; }
        public AlgorithmType AlgorithmType { private set; get; }
        
        public Job(int piece_size, List<int> n_list, AlgorithmType alg_type)
        {
            PieceSize = piece_size;
            NList = n_list;
            AlgorithmType = alg_type;
        }
    }
}
