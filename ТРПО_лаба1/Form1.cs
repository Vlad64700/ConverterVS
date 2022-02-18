namespace Converter
{
    public partial class Main_form : Form
    {
        public Control control = new Control();
        public Main_form()
        {
            InitializeComponent();
        }

        //функция для проверки соответсия числен заданной системе счисления
        private void checkCorrectDigits()
        {
            string st = textBox1.Text;
            for (int i=0; i<st.Length; i++)
            {
                if (Conver_p_10.char_To_num(st[i]) > (int)numericUpDown1.Value-1)
                    throw new Exception("Использовались симовлы недоступные для данной системы счисления");

            }
        }
        private void change_textbox1(char ch)
        {
            try
            {
                textBox1.Text += ch;
                control.ClickEvent((int)ch);
            }
            catch (Exception ex) // при возникновении ошибки пока что всё сбрасывается
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                control.ed.Bs();
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                //textBox1.Text = "";
                //textBox2.Text = "";
                //numericUpDown1.Value = 10;
                //trackBar1.Value = 10;
                //numericUpDown2.Value = 10;
                //trackBar2.Value = 10;
                //control.Pin = trackBar1.Value;
                //control.Pout = trackBar2.Value;
                //control.ed.Clear();
            }
            
        }

        private bool check_symbol(char ch)
        {
            if ((ch >= 48 && ch <= 57) || (ch >= 65 && ch <= 70) || ch == 46 || ch == 44 || ch==8 || ch == 198 || ch == 190 || ch == 191 || ch == 16)
                return true;
            else
                return false;
        }

        //проверяет строку на наличие ошибок, если есть, возвращяет индекс где ошибка, иначе -1
        private int check_symbol (string str)
        {
           for (int i=0; i<str.Length; i++)
            {
                if (!check_symbol(str[i]))
                    return i;
            }
           return -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Конвертер_Load(object sender, EventArgs e)
        {

        }



        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            numericUpDown2.Value = trackBar2.Value;
            control.Pout = trackBar2.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
            control.Pin = trackBar1.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var number_temp = numericUpDown1.Value;
            int number = Convert.ToInt32(number_temp);
            if (number < 2 || number > 16)
            {
                MessageBox.Show("Используйте только диапазон 2-16");
                numericUpDown1.Value = 10;
                trackBar1.Value = 10;
                control.Pin = trackBar1.Value;
            }
            else
            {
                trackBar1.Value = number;
                control.Pin = trackBar1.Value;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            var number_temp = numericUpDown2.Value;
            int number = Convert.ToInt32(number_temp);
            if (number < 2 || number > 16)
            {
                MessageBox.Show("Используйте только диапазон 2-16");
                numericUpDown2.Value = 10;
                trackBar2.Value = 10;
                control.Pout = trackBar2.Value;

            }
            else
            {
                trackBar2.Value = number;
                control.Pout = trackBar2.Value;
            }
        }



        private void button0_Click(object sender, EventArgs e)
        {
            change_textbox1('0');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            change_textbox1('1');
        }

        private void button2_Click(object sender, EventArgs e)
        {
            change_textbox1('2');
        }

        private void button3_Click(object sender, EventArgs e)
        {
            change_textbox1('3');
        }

        private void button4_Click(object sender, EventArgs e)
        {
            change_textbox1('4');
        }

        private void button5_Click(object sender, EventArgs e)
        {
            change_textbox1('5');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            change_textbox1('6');
        }

        private void button7_Click(object sender, EventArgs e)
        {
            change_textbox1('7');
        }

        private void button8_Click(object sender, EventArgs e)
        {
            change_textbox1('8');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            change_textbox1('9');
        }

        private void buttonA_Click(object sender, EventArgs e)
        {
            change_textbox1('A');
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            change_textbox1('B');
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            change_textbox1('C');
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            change_textbox1('D');
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            change_textbox1('E');
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            change_textbox1('F');
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //если пуская строка - ничего не делаем
            if (textBox1.Text == "")
                return;
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            control.ed.Bs();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            numericUpDown1.Value = 10;
            trackBar1.Value = 10;
            numericUpDown2.Value = 10;
            trackBar2.Value = 10;
            control.Pin = trackBar1.Value;
            control.Pout = trackBar2.Value;
            control.ed.Clear();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            return; // код временно должен не работать 

            //Если нажии shift или enter
            if ((int)e.KeyCode == 16 || e.KeyCode==Keys.Enter || (int)e.KeyCode == 17 || (int)e.KeyCode == 91)
                return;
            

            //если пуская строка - ничего не делаем
            if (textBox1.Text == "")
            {
                control.ed.Clear();
                return;
            }

            //смотрим использовался ли верный символ
            var text = textBox1.Text;
            int correct_str = check_symbol(text); //поиск индекса если есть ошибки
            if (correct_str != -1)
            {
                MessageBox.Show("Используйте только диапазон 0-9 А-F");
                textBox1.Text = textBox1.Text.Remove(correct_str, 1);
            }
            else
            {
                try
                {
                    if (check_symbol(Convert.ToChar((int)e.KeyCode)))
                         control.ClickEvent((int)e.KeyCode);
                }
                catch (Exception ex) // при возникновении ошибки пока что всё сбрасывается
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    numericUpDown1.Value = 10;
                    trackBar1.Value = 10;
                    numericUpDown2.Value = 10;
                    trackBar2.Value = 10;
                    control.Pin = trackBar1.Value;
                    control.Pout = trackBar2.Value;
                    control.ed.Clear();
                }
   
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            change_textbox1('.');
        }

        private string onlyNumbers(string st)
        {
       
            st = st.Replace("A", "");
            st = st.Replace("B", "");
            st = st.Replace("C", "");
            st = st.Replace("D", "");
            st = st.Replace("E", "");
            st = st.Replace("F", "");
            return st;
        }
        private void button19_Click(object sender, EventArgs e)
        {  
            //временно закоментированный код по зайцеву
            //string out_str = control.DoCmnd();
            //textBox2.Text = out_str;

            
            try
            {
                double temp;

                if (textBox1.Text == "0")
                    return;

                checkCorrectDigits();
                string in_str = textBox1.Text;
                string temp_str;
                //конвертируем точку в запятую
                if (in_str.IndexOf(".") != -1)
                    in_str = in_str.Replace('.',',');

                //проверяем есть буквы для временной стороки, если есть - удаляем, необходимо для работы конвертера
                temp_str = in_str;
                temp_str =onlyNumbers(temp_str);

                if (temp_str != "")
                     temp= Convert.ToDouble(temp_str);
                
                control.ed.Number = in_str;

                string out_str = control.DoCmnd();
                textBox2.Text = out_str;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

       
    }
}