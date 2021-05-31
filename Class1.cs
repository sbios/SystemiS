using System;
using System.Collections.Generic;
using System.Text;

namespace Notation
{
    public static class Notation
    {
        public static Exception EmptyStringException = new Exception("Empty string exception!");
        public static Exception WrongSymbolException = new Exception("Wrong symbol exception!");
        public static Exception OutOfBoundsException = new Exception("Out of bounds exception");

        private static int CharToInt(char a)
        {
            if ((a >= '0') && (a <= '9')) return a - '0';   //Цифры
            if ((a >= 'A') && (a <= 'Z')) return a - 'A' + 10;  //Англ ^
            if ((a >= 'a') && (a <= 'z')) return a - 'a' + 10;  //Англ
            if (a == '.' || a == ',') return 0;
            return 33;
        }

        private static char IntToChar(int a)
        {
            if ((a >= 0) && (a < 10)) return (char)(a + '0');
            return (char)(a + 'A' - 10);
        }

        public static string Сonversion(string str, int source, int end)
        {
            int tempi = 0;
            string temps = "", ex = "", r;
            double tempd = 0.0;

            if (str.Length == 0) throw EmptyStringException;
            else if (source < 2 || source > 32 || end < 2 || end > 32) throw OutOfBoundsException;
            else
            {
                for (int i = 0; i < str.Length && str[i] != '.' && str[i] != ','; ++i) //Выбиряем часть до точки или всё строку
                {
                    if (CharToInt(str[i]) >= source) throw WrongSymbolException;//Проверка на символы
                    temps = temps + str[i]; //копируем часть до точки или всё строку
                    tempi = tempi * source + CharToInt(temps[i]); // To dec
                }
                if (tempi == 0) r = "0"; // Ставим ноль если до точки ничего не написанно
                else //во втором случае просто переводим
                {
                    while (tempi != 0)
                    {
                        ex = IntToChar(tempi % end) + ex; //записываем реверсивным методом
                        tempi = tempi / end;
                    }
                    r = ex; // записываем часть до строчки
                }
                ex = temps;
                temps = "";

                for (int i = ex.Length + 1; i < str.Length; ++i)
                {
                    temps = temps + str[i];  //После
                    if (CharToInt(str[i]) >= source) throw WrongSymbolException;
                }
                if (temps.Length > 0)
                {
                    ex = "";
                    for (int i = temps.Length - 1; i >= 0; --i)
                        tempd = (CharToInt(temps[i]) + tempd) / source;
                    while (Math.Truncate(tempd) > 0)
                        tempd = tempd * 0.1;
                    while (tempd > 0)
                    {
                        tempd = tempd * end;
                        ex = ex + IntToChar((int)Math.Truncate(tempd));
                        tempd = tempd - Math.Truncate(tempd);
                    }
                    r = r + "." + ex;
                }
            }
            return r;
        }
    }
}