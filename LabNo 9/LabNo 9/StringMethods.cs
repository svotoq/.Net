using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNo_9
{
    class StringMethods
    {
        public string CurrentString { get; set; }
        public int lenght { get => CurrentString.Length; }
        public void DeleteCommas() // удаляем запятые
        {
            for (int i = 0; i < lenght; i++)
            {
                if (CurrentString[i] == ',')
                {
                    CurrentString = CurrentString.Replace(',', ' ');
                }
            }
        }
        public void AddCharacters(int pos1, int pos2) // добавим буквы H
        {
            CurrentString = CurrentString.Insert(pos1, "H");
            CurrentString = CurrentString.Insert(pos2, "H");
        }
        public void ToUpperCase()
        {
            CurrentString = CurrentString.ToUpper();
        }
        public void RemoveSpaces()
        {
            for (int i = 0; i < lenght; i++)
            {
                if (CurrentString[i] == ' ' && CurrentString[i + 1] == ' ')
                {
                    CurrentString = CurrentString.Remove(i+1,1);
                    i--;
                }
            }
        }
        public string ReplaceAtoB(char A, char B) // Замена всех А на Б
        {
            CurrentString = CurrentString.Replace(A, B);
            return CurrentString;
        }
    }
}
