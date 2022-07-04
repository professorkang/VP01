// See https://aka.ms/new-console-template for more information

using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    static void Main(string[] args)
    {
      int sum = 0;
      int eSum = 0;
      int oSum = 0;
      double rSum = 0;

      for (int i = 1; i <= 100; i++)
      {
        sum += i;
      }

      Console.WriteLine("1~100까지의 합 = {0}", sum);

      for (int i = 1; i <= 100; i++)
      {
        if (i % 2 == 0)
          eSum += i;
        else
          oSum += i;
        rSum += 1.0 / i;
      }

      Console.WriteLine("1~100까지 홀수의 합 : {0}", oSum);
      Console.WriteLine("1~100까지 짝수의 합 : {0}", eSum);
      Console.WriteLine("1~100까지 역수의 합 : {0:0.0000}", rSum);
    }
  }
}