#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M, K;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<int> Q = new Queue<int>();

	public static string BFS()
	{
		if (V[0]) return "Yes";

		Q.Enqueue(0);
		V[0] = true;

		while (Q.Count > 0)
		{
			int q = Q.Dequeue();

			if (L[q] == null) return "yes";
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue(l);
				V[l] = true;
			}
		}

		return "Yes";
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
			(L[int.Parse(S[0]) - 1] ??= new List<int>()).Add(int.Parse(S[1]) - 1);
		}
		K = int.Parse(Console.ReadLine());
		S = Console.ReadLine().Split();
		for (int i = 0; i < K; i++)
		{
			V[int.Parse(S[i]) - 1] = true;
		}

		Console.WriteLine(BFS());
	}
}