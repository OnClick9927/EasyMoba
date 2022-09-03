using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMO.ServerCore.Utils;

internal class Random
{
    static System.Random random = new System.Random();
    public static int Range(int min, int max)
    {
        return random.Next(min, max);
    }
}
