#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static string BFS()
	{
		int R = 0;

		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			R++;

			if (R == N) return "yes";

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue(l);
				V[l] = true;
			}
		}

		return "no";
	}

	public static void Main()
	{
		string line;
		line = Console.ReadLine();
		while (string.IsNullOrWhiteSpace(line)) line = Console.ReadLine();
		string[] S = line.Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		K = int.Parse(S[2]);
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < M; i++)
		{
			line = Console.ReadLine();
			while (string.IsNullOrWhiteSpace(line)) line = Console.ReadLine();
			S = line.Split();
			int left = int.Parse(S[0]);
			int right = int.Parse(S[1]);
			(L[left] ??= new List<int>()).Add(right);
			(L[right] ??= new List<int>()).Add(left);
		}
		Q.Enqueue(K);
		V[K] = true;

		Console.WriteLine(BFS());
	}
}