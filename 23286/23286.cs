#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, M, T;
	public static int[] dist;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static string Dijkstra(int goal)
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (q == goal) return w.ToString();

			if (L[q] == null) continue;
			foreach (var (nextq, nextw) in L[q])
			{
				if (dist[nextq] > Math.Max(w, nextw))
				{
					PQ.Enqueue((nextq, Math.Max(w, nextw)), Math.Max(w, nextw));
					dist[nextq] = Math.Max(w, nextw);
				}
			}
		}

		return "-1";
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);
		T = int.Parse(S[2]);
		dist = new int[N];
		L = new List<(int, int)>[N];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			(L[left] ??= new List<(int, int)>()).Add((right, int.Parse(S[2])));
		}
		for (int i = 0; i < T; i++)
		{
			PQ.Clear();
			Array.Fill(dist, int.MaxValue);
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			int right = int.Parse(S[1]) - 1;
			PQ.Enqueue((left, 0), 0);
			dist[left] = 0;

			sb.AppendLine(Dijkstra(right));
		}

		Console.WriteLine(sb.ToString());
	}
}