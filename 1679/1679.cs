#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N, K;
	public static int[] T;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();
	public static Dictionary<int, bool> V = new Dictionary<int, bool>();

	public static bool BFS(int goal)
	{
		Q.Clear();
		Q.Enqueue((0, 0));
		V.Clear();
		V[0] = true;

		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (w > K) continue;
			if (q == goal) return true;

			foreach (int t in T)
			{
				if (V.ContainsKey(q + t)) continue;
				Q.Enqueue((q + t, w + 1));
				V[q + t] = true;
			}
		}

		return false;
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N];
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}
		K = int.Parse(Console.ReadLine());
		int R = 1;
		while (true)
		{
			if (!BFS(R))
			{
				if (R % 2 == 1) Console.WriteLine("jjaksoon win at " + R);
				else Console.WriteLine("holsoon win at " + R);
				break;
			}
			R++;
		}
	}
}