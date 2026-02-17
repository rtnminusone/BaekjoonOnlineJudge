#pragma warning disable CS8600, CS8602, CS8604

using System.Collections;

ArrayList A = new ArrayList();
ArrayList B = new ArrayList();
ArrayList G = new ArrayList();
int a = 0, b = 0;

string[] N = Console.ReadLine().Split();

string[] bufA = Console.ReadLine().Split();
for (int i = 0; i < int.Parse(N[0]); i++)
{
    A.Add(bufA[i]);
}

string[] bufB = Console.ReadLine().Split();
for (int i = 0; i < int.Parse(N[1]); i++)
{
    B.Add(bufB[i]);
}

string[] bufG = Console.ReadLine().Split();
for (int i = 0; i < int.Parse(N[2]); i++)
{
    G.Add(bufG[i]);
}

foreach (string s in G)
{
    if (A.Contains(s)) a++;
    else b++;
}

if (a > b) Console.WriteLine("A");
else if (a < b) Console.WriteLine("B");
else Console.WriteLine("TIE");