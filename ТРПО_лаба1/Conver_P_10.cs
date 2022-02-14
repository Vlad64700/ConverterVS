using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Converter
{
    public static class Conver_p_10
    {
        //Преобразовать символ в число
        private static double char_To_num(char ch)
        {
            // если символ лежит в отрезке ['0', '9']
            if (ch >= 48 && ch <= 57)
                return ch - 48;
            //иначе символ лежит в отрезке ['A', 'F']
            return ch - 55;

        }

        //Преобразовать строку в вещественное число, integerPartLength - длина целой части числа
        // для 123.FE -> integerPartLength=3
        private static double convert(string P_num, int P, int integerPartLength)
        {
            double result = 0;
            int currentDigitIndex = 0;
            int currentPower = integerPartLength - 1;
            //считаем целую часть числа
            while (currentDigitIndex != integerPartLength)
            {
                result += char_To_num(P_num[currentDigitIndex]) * Math.Pow(P, currentPower);
                currentDigitIndex++;
                currentPower--;
            }

            //пропускаем '.'
            currentDigitIndex++;

            // считаем дробную часть числа
            while (currentDigitIndex < P_num.Length)
            {
                result += char_To_num(P_num[currentDigitIndex]) * Math.Pow(P, currentPower);
                currentDigitIndex++;
                currentPower--;
            }
            return result;
        }

        //Преобразовать из с.сч. с основанием р 
        //в с.сч. с основанием 10.
        public static double dval(string P_num, int P)
        {
            //длина целой части числа
            int integerPartLength = P_num.IndexOf('.');
            //если число не содержит '.' => оно полностью целое
            if (integerPartLength == -1) integerPartLength = P_num.Length;
            return convert(P_num, P, integerPartLength);
        }

    }
}