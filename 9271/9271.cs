#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N, K, R = 0;
	public static int[] T;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static int BFS()
	{
		int r1 = int.MinValue;
		int r2 = -1;

		foreach (int t in T)
		{
			Q.Enqueue(t);
			V = new bool[N];
			V[t] = true;
			int c = 0;

			while (Q.Count > 0)
			{
				int q = Q.Dequeue();

				c++;

				if (L[q] == null) continue;
				foreach (int l in L[q])
				{
					if (V[l]) continue;
					Q.Enqueue(l);
					V[l] = true;
				}
			}

			if (c > r1)
			{
				r1 = c;
				r2 = t + 1;
			}
		}

		return r2;
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		T = new int[K];
		L = new List<int>[N];
		S = Console.ReadLine().Split();
		for (int i = 0; i < K; i++)
		{
			T[i] = int.Parse(S[i]) - 1;
		}
		for (int i = 0; i < N; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			L[left] = new List<int>();
			for (int j = 1; j < S.Length; j++)
			{
				L[left].Add(int.Parse(S[j]) - 1);
			}
		}

		Console.WriteLine(BFS());
	}
}