using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    public class bigint
    {
        public string n1;
        public string n2;
        public int[] n1arr;
        public int[] n2arr;
        public int[] sum;
        public string sumstr;
        public string substr;
        public int[] sub;
        public int x;
        public int y;
        public class divclass
        {
           public string q;
           public string r;
        }
        public bigint()
        {

        }

        public bigint(string num1, string num2)
        {
            n1 = num1;
            n2 = num2;
        }
        
        public int fillstrings(ref string num1, ref string num2)
        {
            n1 = num1;
            n2 = num2;

            
            if (n1.Length >= n2.Length)
            {
                int d = n1.Length;

                n2 = n2.PadLeft(d, '0');

                num1 = n1;
                num2 = n2;
                return n1.Length;

            }
            else
            {
                int d = n2.Length;
                n1 = n1.PadLeft(d, '0');
                num1 = n1;
                num2 = n2;
                return n2.Length;
            }
        }
        public string add2bigint(ref string num1, ref string num2)
        {

            int max_length = fillstrings(ref num1, ref num2);
            sum = new int[max_length + 1];

            n1arr = new int[max_length];
            n2arr = new int[max_length];
            char[] arr1 = new char[max_length];
            char[] arr2 = new char[max_length];
            arr1 = n1.ToCharArray();
            arr2 = n2.ToCharArray();
            for (int i = 0; i < max_length; i++)
            {

                n1arr[i] = arr1[i] - 48;
                n2arr[i] = arr2[i] - 48;
            }
            Array.Reverse(n1arr);
            Array.Reverse(n2arr);


            int carry = 0;
            for (int i = 0; i < max_length; i++)
            {
                sum[i] = (n1arr[i] + n2arr[i] + carry) % 10;
                if (n1arr[i] + n2arr[i] + carry >= 10)
                {
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
            }


            sum[max_length] = carry;

            if (carry == 0)
            {
                char[] sumres = new char[max_length];
                for (int i = max_length - 1; i >= 0; i--)
                {

                    sumres[i] += (char)(sum[i] + '0');

                }
                Array.Reverse(sumres);
                sumstr = new string(sumres);
            }
            else
            {
                char[] sumres1 = new char[max_length + 1];
                for (int i = max_length; i >= 0; i--)
                {

                    sumres1[i] += (char)(sum[i] + '0');

                }
                Array.Reverse(sumres1);
                sumstr = new string(sumres1);
            }


            return sumstr;

        }

        public string subtract2bigint(ref string str1, ref string str2)
        {

            int max_length = fillstrings(ref str1, ref str2);
            char[] ch1 = n1.ToCharArray();
            Array.Reverse(ch1);
            n1 = new string(ch1);
            char[] ch2 = n2.ToCharArray();
            Array.Reverse(ch2);
            n2 = new string(ch2);

            int carry = 0;


            sub = new int[max_length];
            for (int i = 0; i < max_length; i++)
            {


                sub[i] = (((int)n1[i] - '0') -
                        ((int)n2[i] - '0') - carry);


                if (sub[i] < 0)
                {
                    sub[i] = sub[i] + 10;
                    carry = 1;
                }
                else
                    carry = 0;

            }
            bool bb = false;
            int counter = 0;

            for (int i = max_length - 1; i >= 0; i--)
            {
                if (sub[i] == 0 && bb == false)
                {
                    counter++;
                    continue;
                }
                else
                {
                    bb = true;
                    break;
                }
            }
            if (bb == false)
            {
                counter = max_length - 1;
            }
            char[] sub1 = new char[max_length - counter];
            for (int i = 0; i < max_length - counter; i++)
            {
                sub1[i] = (char)(sub[i] + '0');
            }
            Array.Reverse(sub1);


            string str4 = new string(sub1);

            return str4;
        }
        


        public string mul(string n1, string n2)
        {



            int len = fillstrings(ref n1, ref n2);


            if (n1.Length == 1 && n2.Length == 1)
            {

                return (int.Parse(n1) * int.Parse(n2)).ToString();
            }


            x = len / 2;
            y = len - x;


            string firstpartS1 = n1.Substring(0, x);
            string secondpartS1 = n1.Substring(x, y);

            string firstpartS2 = n2.Substring(0, x);
            string secondpartS2 = n2.Substring(x, y);


            string ac = mul(firstpartS1, firstpartS2);
            string bd = mul(secondpartS1, secondpartS2);
            string apb_cpd = mul(add2bigint(ref firstpartS1, ref secondpartS1), add2bigint(ref firstpartS2, ref secondpartS2));

            int pad = secondpartS1.Length + secondpartS2.Length;
            return calculateTheMul(ac, bd, apb_cpd, pad);
        }

        public string calculateTheMul(string ac, string bd, string apd_cpd, int pad)
        {
            
            string minus1 = subtract2bigint(ref apd_cpd, ref ac);

            string sub1 = subtract2bigint(ref minus1, ref bd);
            string sub2 = sub1.PadRight(sub1.Length + pad / 2, '0');

            string sub3 = ac.PadRight(ac.Length + pad, '0');
            string add1 = add2bigint(ref sub2, ref sub3);
            string result = add2bigint(ref add1, ref bd);


            result = result.TrimStart(new char[] { '0' });
            if (result == "")
                return "0";
            else
                return result;

        }

        public bool smaller(string a,string b)
        {
            if (a.Length>b.Length)
            {
                return false;
            }
            else if (a.Length<b.Length)
            {
                return true;
            }
            else
            {
                for (int i=0;i<a.Length;i++)
                {
                    if (a[i]>b[i])
                    {
                        return false;
                    }
                    else if (a[i]<b[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public divclass div(string a, string b)
        {
            divclass d = new divclass();
            if (smaller(a, b))
            {
                d.q = "0";
                d.r = a;
                return d;
            }
            else
            {
                string bb = add2bigint(ref b, ref b);
                d = div(a, bb);

            }
            d.q = add2bigint(ref d.q, ref d.q);
            if (smaller(d.r, b))
            {
                return d;
            }
            else
            {
                string add1 = "1";
                d.q = add2bigint(ref d.q, ref add1);
                d.r = subtract2bigint(ref d.r, ref b);
                return d;

            }


        }
        public string modofpower(string b, string p, string n)
        {

            string ans = "0";
            if (b == "0")
            {
                return "0";
            }


            else if (p == "0")
                return "1";

            divclass temp = div(p, "2");


            if (temp.r == "0")
            {
                string evenE = modofpower(b, temp.q, n);
                ans = mul(evenE, evenE);

            }
            else
            {
                string oddE = modofpower(b, temp.q, n);
                ans = mul(oddE, oddE);
                ans = mul(ans, b);

            }

            divclass r2 = div(ans, n);
            return r2.r;

        }
        public string encryption(string m, string e, string n)
        {
            return modofpower(m, e, n);
        }
        public string decryption(string em, string d, string n)
        {
            return modofpower(em, d, n);
        }
    }

}



