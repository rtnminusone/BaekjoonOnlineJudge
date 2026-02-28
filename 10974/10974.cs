#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N;
	public static int[] R;
	public static bool[] V;
	public static StringBuilder sb = new StringBuilder();

	public static void DFS(int depth)
	{
		if (depth == N)
		{
			sb.AppendLine(string.Join(" ", R));
			return;
		}

		for (int i = 0; i < N; i++)
		{
			if (V[i]) continue;
			V[i] = true;
			R[depth] = i + 1;
			DFS(depth + 1);
			V[i] = false;
		}
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		R = new int[N];
		V = new bool[N];

		DFS(0);

		Console.WriteLine(sb.ToString());
	}
}