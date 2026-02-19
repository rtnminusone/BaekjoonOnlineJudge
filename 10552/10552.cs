#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K;
	public static int[,] T;
	public static bool[] V;
	public static int[] HATE;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static bool Check(int q)
	{
		for (int i = 0; i < N; i++)
		{
			if (T[i, 1] == q) return false;
		}

		return true;
	}

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (HATE[q] == int.MaxValue) return w;

			if (V[T[HATE[q], 0]]) break;

			Q.Enqueue((T[HATE[q], 0], w + 1));
			V[T[HATE[q], 0]] = true;
		}

		return -1;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		K = int.Parse(S[2]) - 1;
		T = new int[N, 2];
		V = new bool[M];
		HATE = new int[M];
		Array.Fill(HATE, int.MaxValue);
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			int love = int.Parse(S[0]) - 1;
			int hate = int.Parse(S[1]) - 1;
			HATE[hate] = HATE[hate] > i ? i : HATE[hate];
			T[i, 0] = love;
			T[i, 1] = hate;
		}

		Q.Enqueue((K, 0));
		V[K] = true;

		Console.WriteLine(BFS());
	}
}