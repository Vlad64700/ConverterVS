using System;


namespace Converter
{
    public class Editor
    {
        //знак
        private string sign;

        //Поле для хранения редактируемого числа.
        private string number = "";

        //Разделитель целой и дробной частей.
        const string delim = ".";

        //Ноль.
        const string zero = "0";

        //
        const string minus = "-";

        //Свойствое для чтения редактируемого числа.
        public string Number
        {
            get => this.number;
            set 
            {
                if (value.IndexOf(",") != -1)
                    value = value.Replace(',', '.');
                this.number = value; 
            } // штука временная, для тестирования кое-чего
        }

        //Добавить символ.
        public string AddDigit(char ch)
        {
            //если добавляем минус
            if (ch==45)
            {
                AddMinus();
                return number;
            }

            //если добавляем разделитель
            if (ch == 46 || ch == 44 || ch==198 || ch==190 || ch==191 || ch==188)
            {
                AddDelim();
                return number;
            }

            //если добавляем ноль
            if (ch == 48)
            {
                AddZero();
                return number;
            }

            //если добавляем 0-9 A-F
            if ((ch >= 48 && ch <= 57) || (ch >= 65 && ch <= 70))
            {
                if (number == "0") number = ch.ToString();
                else number += ch;
                return number;
            }
            else
                throw new Exception("Недопустимый символ для добавления");

        }

        
        //Добавить ноль.
        public string AddZero()
        {
            if (number.Length==1 && number=="0")
            {
                return number;
            }
            else
            {
                this.number += zero;
                return number;
            }
            
            
        }

        //Добавить минус КАК ЗНАК.
        public string AddMinus()
        {
            //проверка не пытаемся ли мы добавить минус не первым символом
            if (this.number.Length > 0)
                throw new Exception("Минус можно добавлять только первым символом");
            else
            {
                this.number += minus;
                return number;
            }

        }

        //Добавить разделитель.
        public string AddDelim()
        {
            //проверка не пытаемся ли мы добавить разделитель первым символом
            if (this.number.Length == 0)
                throw new Exception("Разделитель не может быть первым символом");

            //проверка не пытаемся ли мы добавить разделитель второй раз
            if (this.number.IndexOf(".") != -1 || this.number.IndexOf(",") != -1)
                throw new Exception("В числе уже существует один разделитель, второй быть не может");
            else
            {
                this.number += delim;
                return number;
            }
        }
        //Удалить символ справа.
        public string Bs()
        {
            if (this.number.Length == 0)
                throw new Exception("Нельзя удалить символ у пустого числа");
            this.number = this.number.Substring(0, this.number.Length - 1);
            return this.number;
        }
        //Очистить редактируемое число.
        public string Clear()
        {
            this.number = "";
            return this.number;
        }
        

        public Editor()
        {


        }
    }
}
