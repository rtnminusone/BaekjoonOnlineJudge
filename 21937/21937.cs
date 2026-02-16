#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N, M, K;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static int BFS()
	{
		int R = -1;

		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			R++;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue(l);
				V[l] = true;
			}
		}

		return R;
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
			int right = int.Parse(S[1]) - 1;
			(L[right] ??= new List<int>()).Add(int.Parse(S[0]) - 1);
		}
		K = int.Parse(Console.ReadLine()) - 1;
		Q.Enqueue(K);
		V[K] = true;

		Console.WriteLine(BFS());
	}
}