using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork
{ // класс для римских чисел
    public class Rumnumber
    {
        public static int Parse(string str)
        {
            char[] digits = { 'N','I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] digitValues = { 0, 1, 5, 10, 50, 100, 500, 1000 };
            int res = 0;
            //Если следующая цифра числа больше текущей, то
            // она вычитается из результата, иначе добавляется
            //IX: -1 + 10; XC: -10+100; XX: +10+10; CX : +100+10
            for (int i = str.Length - 1; i > -1; i--)
            {

                char digit = str[i];
                char digit2 = str[i];

                if (i - 1 > -1)
                {
                    digit2 = str[i - 1];
                }







                int ind = Array.IndexOf(digits, digit);
                int ind2 = Array.IndexOf(digits, digit2);


                if (ind == -1)
                {
                    throw new ArgumentException($"Invalid character {digit}");
                }
                int val = digitValues[ind];

                int val2 = digitValues[ind2];
                
                if (i <= 0) { val2 = 0; }

                if (val <= val2)
                {


                    res += val + val2;


                }
                else
                {


                    res += val - val2;




                }
                if (i != 0)
                {
                    i--;
                }


                //  pos -= 1;// предпоследняя цифра
            }
            return res;
        }
    }
}
