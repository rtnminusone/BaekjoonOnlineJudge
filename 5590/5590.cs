#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, M;
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
				if (dist[nextq] > w + nextw)
				{
					PQ.Enqueue((nextq, w + nextw), w + nextw);
					dist[nextq] = w + nextw;
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
		dist = new int[N];
		L = new List<(int, int)>[N];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			if (S.Length == 4)
			{
				int left = int.Parse(S[1]) - 1;
				int right = int.Parse(S[2]) - 1;
				int w = int.Parse(S[3]);
				(L[left] ??= new List<(int, int)>()).Add((right, w));
				(L[right] ??= new List<(int, int)>()).Add((left, w));
			}
			else
			{
				int a = int.Parse(S[1]) - 1;
				PQ.Clear();
				PQ.Enqueue((a, 0), 0);
				Array.Fill(dist, int.MaxValue);
				dist[a] = 0;

				sb.AppendLine(Dijkstra(int.Parse(S[2]) - 1));
			}
		}

		Console.WriteLine(sb.ToString());
	}
}