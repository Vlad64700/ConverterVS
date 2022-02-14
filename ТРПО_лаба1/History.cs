using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Converter
{
    public struct Record
    {
        int p1;
        int p2;
        string number1;
        string number2;

        public Record(int p1, int p2, string n1, string n2)
        {
            this.p1 = p1;
            this.p2 = p2;
            number1 = n1;
            number2 = n2;
        }

        public override string ToString()
        {
            return number1 + $"[{p1}] = " + number2 + $"[{p2}];";
        }
    }
    public class History
    {
        List<Record> historyList;

        public History()
        {
            historyList = new List<Record>();
        }

        // индексатор
        public Record this[int index]
        {
            get => historyList[index];
            set => historyList[index] = value;
        }

        public void AddRecord(int p1, int p2, string n1, string n2)
        {
            historyList.Add(new Record(p1, p2, n1, n2));
        }

        public void Clear()
        {
            //если список не пустой - очищаем
            if (historyList.Any())
                historyList.Clear();
        }

        public int Count() => historyList.Count;

    }

}