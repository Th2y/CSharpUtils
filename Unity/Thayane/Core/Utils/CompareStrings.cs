using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class CompareStrings
{
    //Compara 2 strings, ignorando acentos, caracteres especiais e diferenças entre letras minúsculas e maiúsculas
    public static bool AreEqualIgnoringCaseAndDiacritics(string str1, string str2)
    {
        string normalizedStr1 = RemoveDiacritics(str1);
        string normalizedStr2 = RemoveDiacritics(str2);

        return string.Compare(normalizedStr1, normalizedStr2, StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static bool AreEqualIgnoringCaseAndDiacritics(string str1, List<string> str2)
    {
        string normalizedStr1 = RemoveDiacritics(str1);

        foreach (string str in str2)
        {
            string normalizedStr2 = RemoveDiacritics(str);

            if (string.Compare(normalizedStr1, normalizedStr2, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }
        }

        return false;
    }

    public static string RemoveDiacritics(string text)
    {
        string normalizedString = text.Normalize(NormalizationForm.FormD);
        StringBuilder stringBuilder = new();

        foreach (char c in normalizedString)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString();
    }
}
