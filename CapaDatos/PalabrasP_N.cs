using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class PalabrasP_N
    {
        private readonly string[] WordsPositive;
        private readonly string[] WordsNegative;

        public PalabrasP_N()
        {
            WordsPositive = File.ReadAllLines("C:\\Users\\Dell\\Desktop\\palabras-positivas.txt");
            WordsNegative = File.ReadAllLines("C:\\Users\\Dell\\Desktop\\palabras-negativas.txt");
        }

        public string[] GetWordsPositive()
        {
            return WordsPositive;
        }

        public string[] GetWordsNegative()
        {
            return WordsNegative;
        }
    }
}
