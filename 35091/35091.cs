#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static bool[] V1, V2;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static void BFS(bool[] V)
	{
		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue(l);
				V[l] = true;
			}
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		V1 = new bool[N];
		V2 = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			(L[left] ??= new List<int>()).Add(int.Parse(S[1]) - 1);
		}
		S = Console.ReadLine().Split();
		int a = int.Parse(S[0]) - 1;
		Q.Enqueue(a);
		V1[a] = true;

		BFS(V1);

		int b = int.Parse(S[1]) - 1;
		Q.Enqueue(b);
		V2[b] = true;

		BFS(V2);

		int r = -1;
		for (int i = 0; i < N; i++)
		{
			if (V1[i] && V2[i])
			{
				r = i + 1;
				break;
			}
		}

		Console.WriteLine(r == -1 ? "no" : "yes\n" + r);
	}
}