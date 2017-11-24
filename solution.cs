using System;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    public int solution(int[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        int len = A.Length;
        int answer = 0;
        
        // need to use long due to overflow possibility - see input range
        long[] starts = new long[len];
        long[] ends = new long[len];
        
        for (long x = 0; x < len; x++)
        {
        // x must be a long here using int x instead will perform the whole operation as int and be subject to int's max/min values and overflows
            starts[x] = x - A[x];
            ends[x] = x + A[x];
        }
        
        Array.Sort(starts);
        Array.Sort(ends);
        
        int x1 = 0;
        int x2 = 0;
        int count = 0;
        len = starts.Length;
        
        while (x1 < len || x2 < len)
        {
            //Console.WriteLine("" + starts[x1] + " " + ends[x2]);
            if (answer > 10000000)
                return -1;
                
            if (x1 < len && starts[x1] <= ends[x2])
            {
                x1++;
                count++;
            }
            else
            {
                count--;
                answer += count;
                x2 = (x2 < len) ? ++x2 : x2;
            }
        }
        
        return answer;
    }
}
