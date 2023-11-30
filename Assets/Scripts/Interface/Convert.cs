using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convert
{
    public static string IntegerToSprite(int x)
    {
        char[] charArray = x.ToString().ToCharArray();
        string returnable = "";

        foreach (char c in charArray)
        {
            returnable += "<sprite name=\"" + c + "\">";
        }

        return returnable;
    }

    public static string StringToSprite(string s)
    {
        char[] charArray = s.ToUpper().ToCharArray();
        string returnable = "";

        foreach (char c in charArray)
        {
            if (c == ' ')
            {
                returnable += c;
            }
            else
            {
                returnable += "<sprite name=\"" + c + "\">";
            }
        }

        return returnable;
    }
}
