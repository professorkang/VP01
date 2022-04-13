using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.Write("숫자 입력 : ");
      int a = int.Parse(Console.ReadLine());
      Console.Write("숫자 입력 : ");
      int b = int.Parse(Console.ReadLine());
      Console.Write("숫자 입력 : ");
      int c = int.Parse(Console.ReadLine());

      Console.WriteLine(Larger(Larger(a, b),c));
    }

    private static int Larger(int a, int b)
    {
      if (a < b)
        return b;
      else
        return a;
    }
  }
}
