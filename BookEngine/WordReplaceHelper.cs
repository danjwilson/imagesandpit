using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEngine
{
    public static class WordReplaceHelper
    {
        public static string Replace(Character character, string text)
        {
            List<string> words = text.Split(' ').ToList<string>();
            List<string> alreadyReplaced = new List<string>();

            foreach(string word in words)
            {
                if (word.StartsWith("{") && word.EndsWith("}") && !alreadyReplaced.Contains(word))
                { 
                    text = text.Replace(word, LookupWord(character, word));
                    alreadyReplaced.Add(word);
                }
            }

            return text;
        }

        private static string LookupWord(Character character, string word)
        {
            string replacement = "[REPLACEMENT ERROR]";
            bool isMale = (character.Gender.ToUpper() == "BOY" || character.Gender.ToLower() == "MAN" || character.Gender.ToLower() == "M");

            switch (word)
            {
                case "{NAME}":
                    replacement = character.Name.ToUpper();
                    break;
                case "{Name}":
                    replacement = character.Name;
                    break;
                case "{HIS}":
                case "{HER}":
                    replacement = isMale ? "HIS" : "HER";
                    break;
                case "{his}":
                case "{her}":
                    replacement = isMale ? "his" : "her";
                    break;
                case "{His}":
                case "{Her}":
                    replacement = isMale ? "His" : "Her";
                    break;
                case "{HIM}":
                    replacement = isMale ? "HIM" : "HER";
                    break;
                case "{him}":
                    replacement = isMale ? "him" : "her";
                    break;
                case "{Him}":
                    replacement = isMale ? "Him" : "Her";
                    break;
                case "{HE}":
                case "{SHE}":
                    replacement = isMale ? "HE" : "SHE";
                    break;
                case "{he}":
                case "{she}":
                    replacement = isMale ? "he" : "she";
                    break;
                case "{He}":
                case "{She}":
                    replacement = isMale ? "He" : "She";
                    break;
                case "{BOY}":
                case "{GIRL}":
                    replacement = isMale ? "BOY" : "GIRL";
                    break;
                case "{boy}":
                case "{girl}":
                    replacement = isMale ? "boy" : "girl";
                    break;
                case "{Boy}":
                case "{Girl}":
                    replacement = isMale ? "Boy" : "Girl";
                    break;
            }

            return replacement;
        }
    }
}
