#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, A, B;
	public static List<(int, int)> L = new List<(int, int)>();
	public static Queue<(int, int)> Q = new Queue<(int, int)>();
	public static Dictionary<int, bool> V = new Dictionary<int, bool>();

	public static bool Check(int v)
	{
		foreach (var (left, right) in L)
		{
			if (left <= v && v <= right) return false;
		}

		return true;
	}

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (q > N) continue;
			if (q == N) return w;

			if (!V.ContainsKey(q + A) && Check(q + A))
			{
				Q.Enqueue((q + A, w + 1));
				V[q + A] = true;
			}
			if (!V.ContainsKey(q + B) && Check(q + B))
			{
				Q.Enqueue((q + B, w + 1));
				V[q + B] = true;
			}
		}

		return -1;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		A = int.Parse(S[2]);
		B = int.Parse(S[3]);
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			L.Add((int.Parse(S[0]), int.Parse(S[1])));
		}

		Q.Enqueue((0, 0));
		V[0] = true;

		Console.WriteLine(BFS());
	}
}