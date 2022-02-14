using System;
namespace Converter
{
    public static class Conver_10_p
    {
        //Преобразование из
        //вещественного числа n в число с системой счисления p, c - точность.
        public static string Do(double n, byte p, int c=6)
        {
            if (p > 16 && p < 2)
                throw new Exception("Выход за допустимый диапазон систем счисления");

            string number_10 = Convert.ToString(n);
            string integet_part = int_to_P(number_10, p);
            string fraction_part = flt_to_P(number_10, p, c);

            return integet_part + "." + fraction_part;
        }

        //преобразование целой части числа в нужную СС, разделитель - точка.
        public static string int_to_P(string number, byte basis)
        {
            double f_number = Convert.ToDouble(number);
            int integer_part = (int)f_number;
            string output = String.Empty;
            do
            {
                output = int_to_Char((byte)(integer_part % basis)) + output; // prepend
                integer_part /= basis;
            }
            while (integer_part > 0);
            return output;
        }

        //преобразование дробной части числа в нужную СС, разделитель - точка. На выход: число в виде строки, основание сс и точность.
        public static string flt_to_P(string number, byte basis, int c)
        {
            //проверяем есть ли вообще дробная часть
            if (number.IndexOf(".") == -1)
                return "0";

            string result = "";
            number = "0" + number.Substring(number.IndexOf("."));
            double numberDouble = double.Parse(number);
            int k = 0;

            while (numberDouble != 0 && k < c)
            {
                double a = basis * numberDouble;
                int Z = Convert.ToInt32(a);
                if ((double)Z > a) //проверка на округление
                    Z--;
                numberDouble = a - (double)Z;
                result += int_to_Char(Z);
                k++;
            }
            return result;
        }

        // преобразовать число в СИМВОЛ (10->A) 
        public static char int_to_Char(int n)
        {
            if (n >= 10)
            {
                return (char)(55 + n);
            }
            else
                if (n == 0)
            {
                return '0';
            }
            else

                return Convert.ToChar(n + 48);

        }
        

    }
}
