#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static int BFS(int start)
	{
		int r = 0;

		Q.Enqueue(start);
		Array.Fill(V, false);
		V[start] = true;

		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			r++;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue(l);
				V[l] = true;
			}
		}

		return r;
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
			int left = int.Parse(S[1]) - 1;
			int right = int.Parse(S[0]) - 1;
			(L[left] ??= new List<int>()).Add(right);
		}

		int r = int.MinValue;
		List<int> R = new List<int>();
		for (int i = 0; i < N; i++)
		{
			int b = BFS(i);
			if (r < b)
			{
				R.Clear();
				r = b;
			}
			if (r == b) R.Add(i + 1);
		}

		Console.WriteLine(string.Join(" ", R));
	}
}