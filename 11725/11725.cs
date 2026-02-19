#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N;
	public static int[] T;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			var (q, root) = Q.Dequeue();

			if (root != -1) T[q - 1] = root + 1;

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue((l, q));
				V[l] = true;
			}
		}

		return string.Join("\n", T);
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		T = new int[N - 1];
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < N - 1; i++)
		{
			string[] S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			(L[left] ??= new List<int>()).Add(right);
			(L[right] ??= new List<int>()).Add(left);
		}

		Q.Enqueue((0, -1));
		V[0] = true;

		Console.WriteLine(BFS());
	}
}