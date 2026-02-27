#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static int BFS()
	{
		int r = 0;

		while (Q.Count > 0)
		{
			int q = Q.Dequeue();
			int w = 0;

			if (L[q] == null)
			{
				r++;
				continue;
			}
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue(l);
				V[l] = true;
				w++;
			}
			if (w == 0) r++;
		}

		return r;
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		V = new bool[N];
		L = new List<int>[N];
		int start = -1;
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			int left = int.Parse(S[i]);
			if (left == -1)
			{
				start = i;
				continue;
			}
			(L[left] ??= new List<int>()).Add(i);
		}
		V[int.Parse(Console.ReadLine())] = true;

		if (V[start]) Console.WriteLine(0);
		else
		{
			Q.Enqueue(start);
			V[start] = true;

			Console.WriteLine(BFS());
		}
	}
}