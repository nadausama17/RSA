using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int t;
            int n;
            n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                StreamWriter writer = new StreamWriter("add.txt");
                StreamReader reader = new StreamReader("AddTestCases.txt");
                t = int.Parse(reader.ReadLine());
                reader.ReadLine();
                for (int i = 0; i < t; i++)
                {
                    string num1 = reader.ReadLine() ;
                    string num2=reader.ReadLine();
                    reader.ReadLine();
                    bigint b = new bigint();
                   // b.fillstrings(ref num1, ref num2);
                    string sumstr = b.add2bigint(ref num1,ref num2);
                    Console.WriteLine(sumstr);
                    writer.Write(sumstr);
                    
                    
                    
                    writer.WriteLine();
                    writer.WriteLine();
               }
                reader.Close();
                writer.Close();
            }
            else if (n == 2)
            {
                StreamWriter writer = new StreamWriter("sub.txt");
                StreamReader reader = new StreamReader("SubtractTestCases.txt");
                t = int.Parse(reader.ReadLine());
                reader.ReadLine();

                for (int i = 0; i < t; i++)
                {
                    string num1 = reader.ReadLine();
                    string num2 = reader.ReadLine();
                    reader.ReadLine();
                    bigint b = new bigint();
                    string substr=b.subtract2bigint(ref num1,ref num2);
                    Console.WriteLine(substr);
                    writer.Write(substr);
                    writer.WriteLine();
                    writer.WriteLine();
                }
                reader.Close();
                writer.Close();
            }
            else if (n==3)
            {
              /*  string num1 = Console.ReadLine();
                string num2 = Console.ReadLine();
                bigint b = new bigint(num1, num2);

              
                Console.WriteLine(b.mul(num1, num2));*/
                StreamWriter writer = new StreamWriter("mul.txt");
                StreamReader reader = new StreamReader("MultiplyTestCases.txt");
                t = int.Parse(reader.ReadLine());
                reader.ReadLine();

                for (int i = 0; i < t; i++)
                {
                   string num1 = reader.ReadLine();
                    string num2 = reader.ReadLine();
                    reader.ReadLine();
                    bigint b = new bigint();
                    string mulstr = b.mul(num1, num2);
                    Console.WriteLine(mulstr);
                    writer.Write(mulstr);
                    writer.WriteLine();
                    writer.WriteLine();
                }
                reader.Close();
                writer.Close();
            }
            else if (n == 4)
            {
                StreamWriter writer = new StreamWriter("div.txt");
                StreamReader reader = new StreamReader("divtestcases.txt");
                t = int.Parse(reader.ReadLine());
                reader.ReadLine();

                for (int i = 0; i < t; i++)
                {
                    string num1 = reader.ReadLine();
                    string num2 = reader.ReadLine();
                    reader.ReadLine();
                    bigint b = new bigint();
                    string divstr = b.div(num1, num2).q;
                    Console.WriteLine(divstr);
                    writer.Write(divstr);
                    writer.WriteLine();
                    writer.WriteLine();
                }
                reader.Close();
                writer.Close();
            }
            else if(n==5)
            {
                StreamWriter writer = new StreamWriter("sample.txt");
                StreamReader reader = new StreamReader("SampleRSA.txt");
                t = int.Parse(reader.ReadLine());
                string enc="";
                string dec="";
                for (int i = 0; i < t; i++)
                {
                    long before;
                    long after;
                    string N = reader.ReadLine();
                    string e = reader.ReadLine();
                    string M = reader.ReadLine();
                    string num = reader.ReadLine();
                    bigint b = new bigint();
                    if (num=="0")
                    {
                        before = System.Environment.TickCount;
                        enc = b.encryption(M,e,N);
                        after = System.Environment.TickCount;
                        
                        Console.WriteLine(enc);
                     //   Console.WriteLine("Execution time: " + (after - before) + "ms");
                        writer.WriteLine(enc);
                    }
                    else if (num=="1")
                    {
                        before = System.Environment.TickCount;
                        dec = b.decryption(M, e, N);
                        after = System.Environment.TickCount;
                        Console.WriteLine(dec);
                       // Console.WriteLine("Execution time: " + (after - before) + "ms");
                        writer.WriteLine(dec);
                    }
                    
                    
                }
                reader.Close();
                writer.Close();
            }
            else if (n == 6)
            {
                StreamWriter writer = new StreamWriter("complete.txt");
                StreamReader reader = new StreamReader("TestRSA.txt");
                t = int.Parse(reader.ReadLine());
                string enc = "";
                string dec = "";
                for (int i = 0; i < t; i++)
                {
                    
                    string N = reader.ReadLine();
                    string e = reader.ReadLine();
                    string M = reader.ReadLine();
                    string num = reader.ReadLine();
                    bigint b = new bigint();
                    if (num == "0")
                    {
                        long before = System.Environment.TickCount;
                        enc = b.encryption(M, e, N);
                        long after = System.Environment.TickCount;
                        Console.WriteLine(enc);
                        Console.WriteLine("Execution time: " + (after - before) + "ms");
                        Console.WriteLine("Execution time: " + (after - before)/1000 + "s");
                        writer.WriteLine(enc);
                    }
                    else if (num == "1")
                    {
                        long before = System.Environment.TickCount;
                        dec = b.decryption(M, e, N);
                        long after = System.Environment.TickCount;
                        Console.WriteLine(dec);
                        Console.WriteLine("Execution time: "+(after - before)+"ms");
                        Console.WriteLine("Execution time: " + (after - before) / 1000 + "s");
                        writer.WriteLine(dec);
                    }
                   
                    

                }
                reader.Close();
                writer.Close();
            }
        }
    }
}
