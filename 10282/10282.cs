#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N, M, K;
	public static int[] dist;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static string BFS()
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

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

		List<int> R = new List<int>();
		for (int i = 0; i < N; i++)
		{
			if (dist[i] == int.MaxValue) continue;
			R.Add(dist[i]);
		}
		R.Sort();

		return R.Count + " " + R[R.Count - 1];
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
			K = int.Parse(S[2]) - 1;
			dist = new int[N];
			Array.Fill(dist, int.MaxValue);
			L = new List<(int, int)>[N];
			for (int i = 0; i < M; i++)
			{
				S = Console.ReadLine().Split();
				int left = int.Parse(S[1]) - 1;
				int right = int.Parse(S[0]) - 1;
				(L[left] ??= new List<(int, int)>()).Add((right, int.Parse(S[2])));
			}

			PQ.Enqueue((K, 0), 0);
			dist[K] = 0;

			sb.AppendLine(BFS());
		}

		Console.WriteLine(sb.ToString());
	}
}