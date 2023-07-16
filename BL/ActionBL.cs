using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnotechExam.BL
{
    //this can be implemented with command design pattern
    public class ActionBL
    {
        public static string Calculate(string expression)
        {
            string fixedexpresion = FixExpression(expression);
            var result = new System.Data.DataTable().Compute(fixedexpresion, "");
            return result.ToString();
        }
        private static string FixExpression(string expression) 
        {
            string fixedExpression = expression;
            for (int i=0; i<10; i++)
            {
                fixedExpression = fixedExpression.Replace($"{i}(", $"{i}*(");
            }
            return fixedExpression;
        }

        public static string PerMute(char[] list)
        {
            int x = list.Length - 1;
            List<string> output = new List<string>();
            GetPer(list, 0, x,output);
            output.Sort();
            return string.Join(",", output.ToArray()); 
        }

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }



        private static void GetPer(char[] list, int k, int m, List<string> output)
        {
            if (k == m)
            {
                output.Add(new string(list));
                //Console.Write(list);
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m, output);
                    Swap(ref list[k], ref list[i]);
                }
            }
        }
    }
}
