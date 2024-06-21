using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ServiceCore.Utilities
{
    public class StringUtility
    {
        public static List<string> VietnamesesAlphabet = new List<string>
            {
                " ",
                "a", "á", "à", "ả", "ã", "ạ",
                "ă", "ằ", "ẳ", "ẵ", "ắ", "ặ",
                "â", "ầ", "ẩ", "ẫ", "ấ", "ậ",
                "b", "c", "d", "đ",
                "e", "è", "ẻ", "ẽ", "é", "ẹ",
                "ê", "ề", "ể", "ễ", "ế","ệ",
                "f", "g", "h",
                "i", "ì", "ỉ", "ĩ", "í", "ị",
                "j", "k", "l", "m", "n",
                "o", "ò", "ỏ", "õ", "ó", "ọ",
                "ô", "ồ", "ổ", "ỗ", "ố", "ộ",
                "ơ", "ờ", "ở", "ỡ", "ớ", "ợ",
                "p", "q", "r", "s", "t",
                "u", "ù", "ủ", "ũ", "ú", "ụ",
                "ư", "ừ", "ử", "ữ", "ứ", "ự",
                "v", "w", "x",
                "y", "ỳ", "ỷ", "ỹ", "ý", "ỵ",
                "z", "'"
            };
        public static List<string> VietnamesesAlphabetWithout = new List<string>
            {
                " ",
                "a", "a", "a", "a", "a", "a",
                "ă", "ă", "ă", "ă", "ă", "ă",
                "â", "â", "â", "â", "â", "â",
                "b", "c", "d", "đ",
                "e", "e", "e", "e", "e", "e",
                "ê", "ê", "ê", "ê", "ê", "ê",
                "f", "g", "h",
                "i", "i", "i", "i", "i", "i",
                "j", "k", "l", "m", "n",
                "o", "o", "o", "o", "o", "o",
                "ô", "ô", "ô", "ô", "ô", "ô",
                "ơ", "ơ", "ơ", "ơ", "ơ", "ơ",
                "p", "q", "r", "s", "t",
                "u", "u", "u", "u", "u", "u",
                "ư", "ư", "ư", "ư", "ư", "ư",
                "v", "w", "x",
                "y", "y", "y", "y", "y", "y",
                "z", "'"
            };
        public static int CompareVietnamesWordsIgnoreCase(string Word1, string Word2)
        {
            var Result = CompareVietnamesWords(Word1, Word2, true);
            if (Result == 0)
            {
                Result = CompareVietnamesWords(Word1, Word2, false);
            }
            return Result;
        }
        private static int CompareVietnamesWords(string Word1, string Word2, bool Without)
        {
            var VNAlphabet = Without ? VietnamesesAlphabetWithout : VietnamesesAlphabet;
            var WordChar1 = Word1.ToLower().ToCharArray();
            var WordChar2 = Word2.ToLower().ToCharArray();
            if (Without)
            {
                WordChar1 = RemoveVietnames(Word1.ToLower()).ToCharArray();
                WordChar2 = RemoveVietnames(Word2.ToLower()).ToCharArray();
            }
            if (Word1 == "" && Word2 != "")
            {
                return -1;
            }
            if (Word1 != "" && Word2 == "")
            {
                return 1;
            }
            var count = 0;
            while (count < WordChar1.Length && count < WordChar2.Length)
            {
                var Word1Index = VNAlphabet.IndexOf(WordChar1[count].ToString());
                var Word2Index = VNAlphabet.IndexOf(WordChar2[count].ToString());
                if (Word1Index < Word2Index)
                {
                    return -1;
                }
                else if (Word1Index > Word2Index)
                {
                    return 1;
                }
                count++;
            }
            if (WordChar1.Length < WordChar2.Length)
            {
                return -1;
            }
            if (WordChar1.Length > WordChar2.Length)
            {
                return 1;
            }
            return 0;
        }
        private static string RemoveVietnames(string Word)
        {
            var Index = 0;
            foreach (var char1 in VietnamesesAlphabet)
            {
                Word = Word.Replace(char1, VietnamesesAlphabetWithout[Index++]);
            }
            return Word;
        }
        public static string ToTitleCase(string StringToConvert)
        {
            if (StringToConvert != "" && StringToConvert != null)
            {
                string[] Splitted = StringToConvert.Trim().ToLower().Split(" ");
                var Result = new List<string>();
                foreach (var subString in Splitted)
                {
                    Result.Add(ToSentenceCase(subString));
                }
                return System.String.Join(" ", Result);
            }
            return "";
        }
        public static string ToSentenceCase(string StringToConvert)
        {
            if (StringToConvert != "" && StringToConvert != null)
            {
                return StringToConvert.Substring(0, 1).ToUpper() + StringToConvert.Substring(1).ToLower();
            }
            return "";
        }
        public static string RemoveAllSpecialCharacters(string StringToRemove)
        {
            return Regex.Replace(StringToRemove, @"[^\p{L}0-9 -]", "");
        }
        public static string RemoveAllUnUsualSpaces(string StringToRemove)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            return regex.Replace(StringToRemove, " ");
        }
    }
}