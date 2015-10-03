using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEngine
{
    public enum CharacterWordPlaceholder
    {
        Name, HisHerLower, HisHerTitle, HeSheLower, HeSheTitle, HimHerLower, HimHerTitle, BoyGirlLower, BoyGirlTitle
        // With enums, Json serialization doesn't use the name, but the int value. Look at this: http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Converters_StringEnumConverter.htm
    };

    public static class WordReplaceHelper
    {
        public static string Replace(Character character, string text, List<CharacterWordPlaceholder> placeholders)
        {
            Dictionary<int, string> replacementWords = new Dictionary<int,string>();

            // Determine what are the replacement words
            int i = 0;

            foreach (CharacterWordPlaceholder placeholder in placeholders)
            {
                text = text.Replace("{" + i.ToString() + "}", LookupWord(character, placeholder));
                i++;
            }

            return text;
        }

        private static string LookupWord(Character character, CharacterWordPlaceholder placeholder)
        {
            string word = "[UNKNOWN]";
            bool isMale = (character.Gender.ToLower() == "boy" || character.Gender.ToLower() == "man" || character.Gender.ToLower() == "m");

            switch (placeholder)
            {
                case CharacterWordPlaceholder.Name:
                    word = character.Name;
                    break;
                case CharacterWordPlaceholder.HisHerLower:
                    word = isMale ? "his" : "her";
                    break;
                case CharacterWordPlaceholder.HisHerTitle:
                    word = isMale ? "His" : "Her";
                    break;
                case CharacterWordPlaceholder.HeSheLower:
                    word = isMale ? "he" : "she";
                    break;
                case CharacterWordPlaceholder.HeSheTitle:
                    word = isMale ? "He" : "She";
                    break;
                case CharacterWordPlaceholder.BoyGirlLower:
                    word = isMale ? "boy" : "girl";
                    break;
                case CharacterWordPlaceholder.BoyGirlTitle:
                    word = isMale ? "Boy" : "Girl";
                    break;
            }

            return word;
        }
    }
}
