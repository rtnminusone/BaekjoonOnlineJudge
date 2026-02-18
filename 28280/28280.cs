#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N;
	public static bool[] V;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (q == N) return w.ToString();

			if (q * 2 < N + 2 && !V[q * 2])
			{
				Q.Enqueue((q * 2, w + 1));
				V[q * 2] = true;
			}
			if (q - 1 > 0 && !V[q - 1])
			{
				Q.Enqueue((q - 1, w + 1));
				V[q - 1] = true;
			}
		}

		return "Wrong proof!";
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());

		while (t-- > 0)
		{
			N = int.Parse(Console.ReadLine());

			Q.Clear();
			V = new bool[N + 2];
			Q.Enqueue((1, 0));
			V[1] = true;

			sb.AppendLine(BFS());
		}

		Console.WriteLine(sb.ToString());
	}
}