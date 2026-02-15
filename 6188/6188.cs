#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

class Program
{
	public static int N, M;
	public static int[] K;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			K[q] = w;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue((l, w + 1));
				V[l] = true;
			}
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		K = new int[N];
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int root = int.Parse(S[0]) - 1;
			int brc1 = int.Parse(S[1]) - 1;
			int brc2 = int.Parse(S[2]) - 1;
			if (L[root] == null) L[root] = new List<int>();
			L[root].Add(brc1);
			L[root].Add(brc2);
		}
		Q.Enqueue((0, 1));
		V[0] = true;
		BFS();

		Console.WriteLine(string.Join("\n", K));
	}
}