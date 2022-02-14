using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    public class Control
    {
        //основание системы сч. исходного числа по умолчанию
        const int pin = 10;
        //основание сч.результата по умолчанию
        const int pout = 16;
        //число резрядов в дробной части результата
        const int accuracy = 10;
        //История
        public History his = new History();
        public enum State
        {
            editing,
            converted
        }
        // свойства для чтения и записи состояние Конвертера.
        public State St { get; set; }
        public Control()
        {
            St = State.editing;
            Pin = pin;
            Pout = pout;
        }
        //объект редактор 
        public Editor ed = new Editor();
        //свойства для чтения и запиши основания системы сч. p1.
        public int Pin { get; set; }
        //свойства для чтения и запиши основания системы сч. p2.
        public int Pout { get; set; }

        // выполнить команду конвертера
        public string DoCmnd()
        {
            double result;
            string s_result;
            result = Conver_p_10.dval(ed.Number, Pin);
            s_result = Conver_10_p.Do(result, (Byte)Pout);
            return s_result;

        }
        //Выполнить обработку нажатия
        public void ClickEvent(int Digit)
        {
            //Если нажали запятую
            if (Digit == 198 || Digit == 190 || Digit == 191 || Digit == 16)
                Digit = 46;

             if (Digit == 8)
             {
                ed.Bs();
                return;
             }
                
            char ch = Convert.ToChar(Digit);
            ed.AddDigit(ch);
           
        }

    }
}
