#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, K;
	public static int[] T, R;
	public static bool[] V;
	public static Dictionary<string, bool> D = new Dictionary<string, bool>();

	public static void DFS(int depth)
	{
		if (depth == K)
		{
			D[string.Join("", R)] = true;
			return;
		}

		for (int i = 0; i < N; i++)
		{
			if (V[i]) continue;
			V[i] = true;
			R[depth] = T[i];
			DFS(depth + 1);
			V[i] = false;
		}
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		K = int.Parse(Console.ReadLine());
		T = new int[N];
		R = new int[K];
		V = new bool[N];
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(Console.ReadLine());
		}

		DFS(0);

		Console.WriteLine(D.Count);
	}
}