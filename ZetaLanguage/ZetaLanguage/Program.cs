using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

class Program
{
    static void Main(string[] args)
    {
        // Evaluate a special function
        Console.WriteLine(SpecialFunctions.Erf(0.5));

        // Solve a random linear equation system with 500 unknowns
        var m = Matrix<double>.Build.Random(500, 500);
        var v = Vector<double>.Build.Random(500);
        var y = m.Solve(v);
        Console.WriteLine(y);
    }
}