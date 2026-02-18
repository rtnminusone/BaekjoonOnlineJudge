#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N, M;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (q == N - 1) return w;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue((l, w + 1));
				V[l] = true;
			}
		}

		return -1;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			(L[left] ??= new List<int>()).Add(int.Parse(S[1]) - 1);
		}

		Q.Enqueue((0, 0));
		V[0] = true;

		Console.WriteLine(BFS());
	}
}