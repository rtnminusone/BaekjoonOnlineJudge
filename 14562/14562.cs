#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public static int N, M;
	public static Dictionary<(int, int), bool> V = new Dictionary<(int, int), bool>();
	public static Queue<(int, int, int)> Q = new Queue<(int, int, int)>();

	public static int BFS()
	{
		while (Q.Count > 0)
		{
			var (n, m, w) = Q.Dequeue();

			if (n > m) continue;
			if (n == m) return w;

			if (!V.ContainsKey((n + 1, m)))
			{
				Q.Enqueue((n + 1, m, w + 1));
				V[(n + 1, m)] = true;
			}
			if (!V.ContainsKey((n * 2, m + 3)))
			{
				Q.Enqueue((n * 2, m + 3, w + 1));
				V[(n * 2, m + 3)] = true;
			}
		}

		return -1;
	}
	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());

		while (t-- > 0)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[0]);
			M = int.Parse(S[1]);
			V.Clear();
			Q.Clear();
			Q.Enqueue((N, M, 0));
			V[(N, M)] = true;

			sb.AppendLine(BFS().ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}