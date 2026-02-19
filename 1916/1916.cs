#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static int[] dist;
	public static List<(int, int)>[] L;
	public static PriorityQueue<(int, int), int> PQ = new PriorityQueue<(int, int), int>();

	public static int BFS(int goal)
	{
		while (PQ.Count > 0)
		{
			var (q, w) = PQ.Dequeue();

			if (w > dist[q]) continue;

			if (q == goal) return w;

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

		return -1;
	}

	public static void Main()
	{
		string[] S = null;
		N = int.Parse(Console.ReadLine());
		M = int.Parse(Console.ReadLine());
		dist = new int[N];
		Array.Fill(dist, int.MaxValue);
		L = new List<(int, int)>[N];
		for (int i = 0; i < M; i++)
		{
			S = Console.ReadLine().Split();
			int left = int.Parse(S[0]) - 1;
			(L[left] ??= new List<(int, int)>()).Add((int.Parse(S[1]) - 1, int.Parse(S[2])));
		}
		S = Console.ReadLine().Split();
		int q = int.Parse(S[0]) - 1;
		PQ.Enqueue((q, 0), 0);
		dist[q] = 0;

		Console.WriteLine(BFS(int.Parse(S[1]) - 1));
	}
}