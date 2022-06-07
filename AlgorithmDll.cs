using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TobaccoExe
{
    class AlgorithmDll
    {
        [DllImport("fuzyyDll.dll", EntryPoint = "cacFuzzy", CallingConvention = CallingConvention.Cdecl)]
        private static extern double cacFuzzy(double d1, double d2);
        public double fuzzyDllCac(double d1, double d2)
        {
            double a = cacFuzzy(d1, d2);
            return a;
        }
    }
}
