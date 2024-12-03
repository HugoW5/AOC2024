using System.Net.Sockets;
using System.Numerics;

namespace Aoc2024D3P2
{
    internal class Program
    {
        static List<string> nums = new();
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            //Console.WriteLine(input);

            string[] blocks = input.Split("mul");
            bool doDont = true;
            for (int i = 0; i < blocks.Length; i++)
            {
                if (doDont)
                {
                    multiply(blocks[i]);
                }
                if (blocks[i].Contains("do()"))
                {
                    doDont = true;
                    Console.WriteLine("Do");
                }
                if (blocks[i].Contains("don't()"))
                {
                    Console.WriteLine("Dont");
                    doDont = false;
                }
            }
            Console.WriteLine("--------------------");

            //80748208 is too high
            int total = 0;
            foreach (string i in nums)
            {
                if (i.Contains(',') && i.Contains('(') && i.Contains(')'))
                {
                    string[] parts = i.Split(",");
                    string firstNum = new string(parts[0].Where(char.IsDigit).ToArray());
                    string secondNum = new string(parts[1].Where(char.IsDigit).ToArray());
                    if (int.TryParse(firstNum, out int first) && int.TryParse(secondNum, out int second))
                    {
                        total += (first * second);
                        Console.WriteLine(first + " * " + second);
                    }
                }
            }
            Console.WriteLine(nums.Count);
            Console.WriteLine(total);
        }
        static void multiply(string block)
        {
            string s = "";
            bool firstP = false;
            bool secondP = false;
            foreach (char c in block)
            {
                if (c == '(')
                {
                    if (firstP)
                    {
                        break;
                    }
                    firstP = true;
                }
                if (c == ')')
                {
                    secondP = true;
                    s = s + c;
                    break;
                }
                s = s + c;
            }
            if (firstP && secondP)
            {
                int distance = Math.Abs((block.IndexOf('(') - block.IndexOf(')')));
                if(distance > 2)
                {
                nums.Add(s);
                }

            }
            s = "";

        }
    }


}

