#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, S, D, F, B, K;
	public static int[] T;
	public static bool[] V;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (q == D) return w.ToString();

			if (q + F < N && T[q + F] != 1 && !V[q + F])
			{
				Q.Enqueue((q + F, w + 1));
				V[q + F] = true;
			}
			if (q - B >= 0 && T[q - B] != 1 && !V[q - B])
			{
				Q.Enqueue((q - B, w + 1));
				V[q - B] = true;
			}
		}

		return "BUG FOUND";
	}

	public static void Main()
	{
		string[] P = Console.ReadLine().Split();
		N = int.Parse(P[0]);
		S = int.Parse(P[1]) - 1;
		D = int.Parse(P[2]) - 1;
		F = int.Parse(P[3]);
		B = int.Parse(P[4]);
		K = int.Parse(P[5]);
		T = new int[N];
		V = new bool[N];
		if (K > 0) P = Console.ReadLine().Split();
		for (int i = 0; i < K; i++)
		{
			T[int.Parse(P[i]) - 1] = 1;
		}

		Q.Enqueue((S, 0));
		V[S] = true;

		Console.WriteLine(BFS());
	}
}