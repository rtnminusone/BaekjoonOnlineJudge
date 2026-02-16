#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N, R = int.MaxValue;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static string BFS()
	{
		int r = 0;

		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			r++;

			if (L[q] == null)
			{
				if (R > w) R = w;
				continue;
			}
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue((l, w + 1));
				V[l] = true;
			}
		}

		return r == N ? "Y" : "N";
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			int m = int.Parse(S[0]);
			if (m == 0) continue;
			L[i] = new List<int>();
			for (int j = 1; j <= m; j++)
			{
				L[i].Add(int.Parse(S[j]) - 1);
			}
		}

		Q.Enqueue((0, 1));
		V[0] = true;

		Console.WriteLine(BFS());
		Console.WriteLine(R);
	}
}