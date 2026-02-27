#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, M, K;
	public static (int, int)[] dist;
	public static List<(int, int, bool)>[] L;
	public static PriorityQueue<(int, int, int), (int, int)> PQ = new PriorityQueue<(int, int, int), (int, int)>();

	public static void Dijkstra()
	{
		while (PQ.Count > 0)
		{
			var (q, w1, w2) = PQ.Dequeue();
			var (distw1, distw2) = dist[q];

			if (w1 > distw1 || (w1 == distw1 && w2 > distw2)) continue;

			if (L[q] == null) continue;
			foreach (var (nextq, nextw2, opt) in L[q])
			{
				int nextw1 = 0;
				if (opt) nextw1 = nextw2;

				var (nextdw1, nextdw2) = dist[nextq];
				if (nextdw1 > w1 + nextw1 || (nextdw1 == w1 + nextw1 && nextdw2 > w2 + nextw2))
				{
					PQ.Enqueue((nextq, w1 + nextw1, w2 + nextw2), (w1 + nextw1, w2 + nextw2));
					dist[nextq] = (w1 + nextw1, w2 + nextw2);
				}
			}
		}
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		K = int.Parse(S[2]);
		dist = new (int, int)[N];
		L = new List<(int, int, bool)>[N];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]);
			int right = int.Parse(S[1]);
			int w = int.Parse(S[2]);
			bool opt = S[3].Equals("O");
			(L[left] ??= new List<(int, int, bool)>()).Add((right, w, opt));
			(L[right] ??= new List<(int, int, bool)>()).Add((left, w, opt));
		}
		while (K-- > 0)
		{
			S = Console.ReadLine().Split();
			int a = int.Parse(S[0]);
			int b = int.Parse(S[1]);
			Array.Fill(dist, (int.MaxValue, int.MaxValue));
			PQ.Enqueue((a, 0, 0), (0, 0));
			dist[a] = (0, 0);

			Dijkstra();

			var (distw1, distw2) = dist[b];
			if (distw1 == int.MaxValue || distw2 == int.MaxValue) sb.AppendLine("IMPOSSIBLE");
			else sb.AppendLine(distw1 + " " + distw2);
		}

		Console.WriteLine(sb.ToString());
	}
}