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
     * Complete the 'cavityMap' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    public static List<string> cavityMap(List<string> grid)
    {
         int n = grid.Count;
        char[,] map = new char[n, n];

        
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                map[i, j] = grid[i][j];

        for (int i = 1; i < n - 1; i++)
        {
            for (int j = 1; j < n - 1; j++)
            {
                char current = map[i, j];
                if (current > map[i - 1, j] &&
                    current > map[i + 1, j] &&
                    current > map[i, j - 1] &&
                    current > map[i, j + 1])
                {
                    map[i, j] = 'X';
                }
            }
        }

        
        List<string> result = new List<string>();
        for (int i = 0; i < n; i++)
        {
            char[] row = new char[n];
            for (int j = 0; j < n; j++)
                row[j] = map[i, j];
            result.Add(new string(row));
        }

        return result;
    }
}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.cavityMap(grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
