#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, K, R = 0;
	public static int[] T;

	public static void DFS(int depth, int cur)
	{
		if (depth == N)
		{
			if (cur == K) R++;
			return;
		}

		DFS(depth + 1, cur + T[depth]);
		DFS(depth + 1, cur);
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);
		if (K == 0) R--;
		T = new int[N];
		S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}

		DFS(0, 0);

		Console.WriteLine(R);
	}
}