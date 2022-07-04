// See https://aka.ms/new-console-template for more information

int[] a = new int[10];
Random r = new Random();
for (int i = 0; i < a.Length; i++)
  a[i] = r.Next(100);

for (int i = 0; i < a.Length; i++)
{
  Console.WriteLine(a[i]);
}

int sum = 0;
int min = a[0];
int max = a[0];

for (int i = 1; i < a.Length; i++)
{
  if(a[i] > max)
    max = a[i];
  if(a[i] < min)
    min = a[i];
  sum += a[i];
}

Console.WriteLine("min = {0}", min);
Console.WriteLine("max = {0}", max);
Console.WriteLine("avg = {0}", (double)sum/a.Length);