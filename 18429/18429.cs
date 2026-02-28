#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, K, R = 0;
	public static int[] T;
	public static bool[] V;

	public static void DFS(int depth, int cur)
	{
		if (cur < 0) return;
		if (depth == N)
		{
			R++;
			return;
		}

		for (int i = 0; i < N; i++)
		{
			if (V[i]) continue;
			V[i] = true;
			DFS(depth + 1, cur - K + T[i]);
			V[i] = false;
		}
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		T = new int[N];
		V = new bool[N];
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}

		DFS(0, 0);

		Console.WriteLine(R);
	}
}