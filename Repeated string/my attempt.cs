using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'repeatedString' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. LONG_INTEGER n
     */
	 
    /* MY CODE */
    private static long GetNumberOfAs(string s, long lastIndex)
    {
        long result = 0;
        for(int i = 0; i < lastIndex; i++)
        {
            result = s[i] == 'a' ? result + 1 : result + 0;
        }
        return result;
    }
    
    private static long GetAsForLongStrings(string s, long n)
    {
        long numberOfAsInS = GetNumberOfAs(s, s.Count());
        long result = (n / s.Count()) * numberOfAsInS;
        long numberOfCharactersLeft = n % s.Count();
        string restOfTheString;
        if(numberOfCharactersLeft != 0)
        {
            restOfTheString = s.Substring(0, (int)numberOfCharactersLeft);
            numberOfAsInS = GetNumberOfAs(s, restOfTheString.Count());
            result = result + numberOfAsInS;
        }
        return result;
    }

    public static long repeatedString(string s, long n)
    {
        long numberOfAs = 0;
        if(s.Count() == 0)
            return numberOfAs;
        
        if(s.Count() == 1 && s.Equals("a"))
            return n;
        
        if(s.Count() >= n)
        {
            numberOfAs = GetNumberOfAs(s, n);
            return numberOfAs;
        }
        
        if(s.Count() < n)
        {
            numberOfAs = GetAsForLongStrings(s, n);
        }
        return numberOfAs;
        
    }
	/* MY CODE */

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
