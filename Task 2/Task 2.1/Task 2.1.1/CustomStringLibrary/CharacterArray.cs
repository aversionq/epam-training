using System;
using System.Text;

namespace CustomStringLibrary
{
    public class CharacterArray
    {
        // Массив символов.
<<<<<<< HEAD
        public char[] CharArray { get; set; }
=======
        private char[] CharArray { get; set; }
>>>>>>> 9c75441ad503fb45c14c03d912c60fff928b89a5

        // Свойство, возвращающее длину массива символов.
        public int Length
        {
            get => this.CharArray.Length;
        }

        // Конструктор со строкой.
        public CharacterArray(string str)
        {
            this.CharArray = str.ToCharArray();
        }

        // Конструктор с массивом char.
        public CharacterArray(char[] chArr)
        {
            this.CharArray = chArr;
        }

        // Перегрузка оператора "+" - конкатенация.
        public static CharacterArray operator +(CharacterArray chArr1, CharacterArray chArr2)
        {
            char[] concatStr = new char[chArr1.Length + chArr2.Length];
            chArr1.CharArray.CopyTo(concatStr, 0);
            chArr2.CharArray.CopyTo(concatStr, chArr1.Length);
            return new CharacterArray(concatStr);
        }

        // Перегрузка операторов сравнения.
        public static bool operator ==(CharacterArray chArr1, CharacterArray chArr2) // => chArr1.CharArray.Equals(chArr2.CharArray);
        {
            if (chArr1.Length != chArr2.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < chArr1.Length; i++)
                {
                    if (chArr1.CharArray[i] != chArr2.CharArray[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static bool operator !=(CharacterArray chArr1, CharacterArray chArr2) // => !chArr1.CharArray.Equals(chArr2.CharArray);
        {
            if (chArr1.Length != chArr2.Length)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < chArr1.Length; i++)
                {
                    if (chArr1.CharArray[i] != chArr2.CharArray[i])
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        // Поиск первого вхождения символа.
        public int IndexOf(char ch) => new String(this.CharArray).IndexOf(ch);

        // Поиск последнего вхождения символа.
        public int LastIndexOf(char ch) => new String(this.CharArray).LastIndexOf(ch);

        // Переопределение метода ToString().
        public override string ToString()
        {
            StringBuilder resultStr = new StringBuilder("[");
            for (int i = 0; i < this.Length; ++i)
            {
                if (i != this.Length - 1)
                {
                    resultStr.Append(this.CharArray[i] + ", ");
                }
                else
                {
                    resultStr.Append(this.CharArray[i]);
                }
            }
            resultStr.Append(']');
            return resultStr.ToString();
        }

        // Определение явного преобразования CharacterArray в string.
        public static explicit operator string(CharacterArray chArr) => new string(chArr.CharArray);

        // Определение явного преобразования string в CharacterArray.
        public static explicit operator CharacterArray(string str) => new CharacterArray(str);

        // Определение явного преобразования char[] в CharacterArray.
        public static explicit operator CharacterArray(char[] charArr) => new CharacterArray(charArr);

        // Определение явного преобразования CharacterArray в char[].
        public static explicit operator char[](CharacterArray chArr) => chArr.CharArray;

        // Метод, определяющий среднее арифметическое символов по таблице Unicode.
        public double Mean()
        {
            double sum = 0;
            foreach (var item in this.CharArray)
            {
                sum += item;
            }
            return sum / this.Length;
        }

        // Реализация индексатора.
        public char this[int i]
        {
            get     // Возвращает символ с соответствующим индексом из массива символов.
            {
                if (i >= 0 && i < this.Length)
                {
                    return this.CharArray[i];
                }
                else
                {
                    // Если индекс за пределами массива, то выдаётся соответсвующая ошибка.
                    throw new IndexOutOfRangeException("Недопустимый индекс");
                }
            }
            set     // Присваивает элементу массива с соответсвующим индексом некоторый символ.
            {
                if (i >= 0 && i < this.Length)
                {
                    this.CharArray[i] = value;
                }
                else
                {
                    // Если индекс за пределами массива, то выдаётся соответсвующая ошибка.
                    throw new IndexOutOfRangeException("Недопустимый индекс");
                }
            }
        }
    }
}
