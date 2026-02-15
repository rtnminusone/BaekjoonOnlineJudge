#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

class Program
{
	public static int N, M, K;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();
	public static Dictionary<int, int> D = new Dictionary<int, int>();

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
				if (V[l] || D.ContainsKey(l)) continue;
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
		K = int.Parse(S[2]);
		V = new bool[N + 1];
		L = new List<int>[N + 1];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			if (L[left] == null) L[left] = new List<int>();
			if (L[right] == null) L[right] = new List<int>();
			L[left].Add(right);
			L[right].Add(left);
		}
		S = Console.ReadLine().Split();
		for (int i = 0; i < K; i++)
		{
			D[int.Parse(S[i]) - 1] = 1;
		}
		V[0] = true;
		Q.Enqueue(0);

		Console.WriteLine(BFS());
	}
}