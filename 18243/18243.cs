#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, K;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static bool BFS()
	{
		int R = 0;

		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (w > 6) return false;
			if (++R == N) return true;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue((l, w + 1));
				V[l] = true;
			}
		}

		return false;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < K; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			(L[left] ??= new List<int>()).Add(right);
			(L[right] ??= new List<int>()).Add(left);
		}
		string ans = "Small World!";
		for (int i = 0; i < N; i++)
		{
			Q.Clear();
			Array.Fill(V, false);
			Q.Enqueue((i, 0));
			V[i] = true;
			if (!BFS())
			{
				ans = "Big World!";
				break;
			}
		}

		Console.WriteLine(ans);
	}
}