Pyramid(5);
Pyramid(7);
Pyramid(10);

static void Pyramid(int n)
{
  for (int i = 1; i <= n; i++)
  {
    for (int j = 0; j < n - i; j++)
    {
      Console.Write(" ");
    }
    for (int j = 0; j < 2 * i - 1; j++)
    {
      Console.Write("*");
    }
    Console.WriteLine();
  }
}
