// See https://aka.ms/new-console-template for more information

// n을 입력받아 1!에서 n!까지 출력해
Console.Write("Enter a number : ");
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
  Console.WriteLine(Factorial(i));
}

int Factorial(int n)
{
  if(n==1)
    return 1;
  else
    return Factorial(n-1)*n;
}