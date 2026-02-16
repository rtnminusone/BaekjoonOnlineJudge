#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N, M;
	public static int[] T;
	public static bool[] V;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (q == 0) return "Roberta wins in " + w + " strokes.";

			foreach (int t in T)
			{
				int n = q - t;
				if (n < 0 || V[n]) continue;
				Q.Enqueue((n, w + 1));
				V[n] = true;
			}
		}

		return "Roberta acknowledges defeat.";
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		V = new bool[N + 1];
		M = int.Parse(Console.ReadLine());
		T = new int[M];
		for (int i = 0; i < M; i++)
		{
			T[i] = int.Parse(Console.ReadLine());
		}
		Q.Enqueue((N, 0));
		V[N] = true;

		Console.WriteLine(BFS());
	}
}