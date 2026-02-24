#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, M;
	public static int[] dist;
	public static List<(int, int)>[] L;
	public static Dictionary<int, int> D = new Dictionary<int, int>();
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static string Dijkstra()
	{
		List<int> R = new List<int>();
		int p = -1;

		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (q == N - 1)
			{
				p = q;
				R.Add(p);
				break;
			}

			if (L[q] == null) continue;
			foreach (var (nextq, nextw) in L[q])
			{
				if (dist[nextq] > w + nextw)
				{
					PQ.Enqueue((nextq, w + nextw), w + nextw);
					dist[nextq] = w + nextw;
					D[nextq] = q;
				}
			}
		}

		if (p == -1) return "-1";
		while (D.ContainsKey(p))
		{
			p = D[p];
			R.Add(p);
		}
		R.Reverse();

		return string.Join(" ", R);
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());
		for (int c = 1; c <= t; c++)
		{
			string[] S = Console.ReadLine().Split();
			N = int.Parse(S[1]);
			M = int.Parse(S[0]);
			dist = new int[N];
			Array.Fill(dist, int.MaxValue);
			L = new List<(int, int)>[N];
			for (int i = 0; i < M; i++)
			{
				S = Console.ReadLine().Split();
				int left = int.Parse(S[0]);
				int right = int.Parse(S[1]);
				int w = int.Parse(S[2]);
				(L[left] ??= new List<(int, int)>()).Add((right, w));
				(L[right] ??= new List<(int, int)>()).Add((left, w));
			}
			PQ.Clear();
			PQ.Enqueue((0, 0), 0);
			dist[0] = 0;

			sb.AppendLine("Case #" + c + ": " + Dijkstra());
		}

		Console.WriteLine(sb.ToString());
	}
}