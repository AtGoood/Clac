using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcProject.App;

namespace Classwork
{ // класс для римских чисел
    public record Rumnumber
    {
        const char ZERO_DIGIT = 'N';
        public static Resources Resources { get; set; } = null!;
        public  int a { get; set; }
    

        public  Rumnumber(int A=0)
        {
            a = A;
        }





        public static int Parse(String str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            if (str == "N")  
            {
                return 0;
            }
            if (str.Length < 1)
            {
                throw new ArgumentException(
                    Resources.GetEmptyStringMessage());
            }
            bool isNegative = false;
            if (str.StartsWith('-'))
            {
                isNegative = true;
                str = str[1..];
            }

            if (str.Length < 1)
            {
                throw new ArgumentException("Empty string not allowed");
            }

            char[] digits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] digitValues = { 1, 5, 10, 50, 100, 500, 1000 };
      
            int pos = str.Length - 1;  
            char digit = str[pos];   
            int ind = Array.IndexOf(digits, digit);  
            if (ind == -1)
            {
                throw new ArgumentException($"Invalid char {digit}");
            }
            int val = digitValues[ind]; 
            int res = val;
            int nextDigitVal = val;
            while (pos > 0)
            {
                pos -= 1;  
                digit = str[pos];     
                ind = Array.IndexOf(digits, digit);  
                if (ind == -1)
                {
                    throw new ArgumentException(
                       digit == ZERO_DIGIT
                       ? Resources.GetMispalcedNMessage()
                       : Resources.GetInvalidCharMessage(digit));
                }


                val = digitValues[ind];  
                res += (val < nextDigitVal)
                        ? -val
                        : val;
                nextDigitVal = val;
            }
            return isNegative ? -res : res;
        }

        public Rumnumber Add(Rumnumber rn)
        {

            if(rn is null)
            {
                throw new ArgumentException(nameof(rn));
            }

            return new(this.a + rn.a);

        }
        public Rumnumber Add(int rn)
        {

          

            return new(this.a + rn);

        }
        public Rumnumber Add(string roman)
        {
            return this.Add(new Rumnumber(Parse(roman)));
        }
        public  Rumnumber Add(Rumnumber f ,int s)
        {
            return this.Add(new Rumnumber(s));
        }
        public static Rumnumber Add(Rumnumber f, string s)
        {
            return new Rumnumber(f.a + Parse(s));
        }
        public static Rumnumber Add(string f, string s)
        {
            return new Rumnumber(Parse(f) + Parse(s));
        }
        public static Rumnumber Add(Rumnumber f, Rumnumber s)
        {
            return new Rumnumber(f.a +s.a );
        }
        public static Rumnumber Add(int f, int s)
        {
            return new Rumnumber(f).Add(s);
        }

        public static Rumnumber Add(object obj1, object obj2)
        {
            var rns = new Rumnumber[] { null!, null! };
            var pars = new object[] { obj1, obj2 };

            for (int i = 0; i < 2; i++)
            {
                if (pars[i] is null) throw new ArgumentNullException($"obj{i + 1}");

                if (pars[i] is int val) rns[i] = new Rumnumber(val);
                else if (pars[i] is String str) rns[i] = new Rumnumber(Parse(str));
                else if (pars[i] is Rumnumber rn) rns[i] = rn;
                else throw new ArgumentException($"obj{i + 1}: type unsupported");
            }

            return rns[0].Add(rns[1]);   
        }

        public override string ToString()
        {
            if (this.a == 0)
            {
                return "N";
            }
            int n = this.a < 0 ? -this.a : this.a;
            String res = this.a < 0 ? "-" : "";

            String[] parts = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            for (int j = 0; j <= parts.Length - 1; j++)
            {
                while (n >= values[j])
                {
                    n -= values[j];
                    res += parts[j];
                }
            }

            return res;
        }

        private Rumnumber(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (obj is int val) a = val;
            else if (obj is String str) a = Parse(str);
            else if (obj is Rumnumber rn) a = rn.a;
            else throw new ArgumentException(
             Resources.GetInvalidTypeMessage(obj.GetType().Name));
        }
        public Rumnumber Sub(Rumnumber rn)
        {
            if (rn is null) throw new ArgumentNullException(nameof(rn));
            return new(this.a - rn.a);  
        }
    }
   
}
