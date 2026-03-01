#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, K, R = 0;
	public static string R2 = "";
	public static Stack<int> Q = new Stack<int>();

	public static void DFS(int depth, int cur)
	{
		if (R == K) return;
		if (cur > N) return;
		if (cur == N)
		{
			R++;
			if (R == K) R2 = string.Join("+", Q.Reverse());
			return;
		}

		Q.Push(1);
		DFS(depth + 1, cur + 1);
		Q.Pop();

		Q.Push(2);
		DFS(depth + 1, cur + 2);
		Q.Pop();

		Q.Push(3);
		DFS(depth + 1, cur + 3);
		Q.Pop();
	}

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		K = int.Parse(S[1]);

		DFS(0, 0);

		Console.WriteLine(R2.Equals("") ? -1 : R2);
	}
}