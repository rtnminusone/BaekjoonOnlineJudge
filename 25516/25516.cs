#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N, K;
	public static bool[] T;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static int BFS()
	{
		int R = 0;

		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (T[q]) R++;

			if (w == K || L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue((l, w + 1));
				V[l] = true;
			}
		}

		return R;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		T = new bool[N];
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < N - 1; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]);
			(L[left] ??= new List<int>()).Add(int.Parse(S[1]));
		}
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			if (S[i].Equals("1")) T[i] = true;
			else T[i] = false;
		}
		Q.Enqueue((0, 0));
		V[0] = true;

		Console.WriteLine(BFS());
	}
}