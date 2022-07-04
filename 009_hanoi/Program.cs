// See https://aka.ms/new-console-template for more information
Hanoi(3, 'A', 'B', 'C');

void Hanoi(int n, char f, char v, char t)
{
  if(n==1)
    Console.WriteLine("{0}=>{1}", f, t);
  else
  {
    Hanoi(n - 1, f, t, v);
    Console.WriteLine("{0}=>{1}", f, t);
    Hanoi(n-1, v, t, f);
  }
}