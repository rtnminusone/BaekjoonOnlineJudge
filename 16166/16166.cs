#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N;
	public static List<int>[] subway;
	public static Dictionary<int, int> dist = new Dictionary<int, int>();
	public static Dictionary<int, List<int>> line = new Dictionary<int, List<int>>();
	public static PriorityQueue<(int, int, int), int> PQ = new PriorityQueue<(int, int, int), int>();

	public static void BFS()
	{
		while (PQ.Count > 0)
		{
			var (q, w, cur) = PQ.Dequeue();

			if (!dist.ContainsKey(q) || w > dist[q]) continue;

			if (!line.ContainsKey(q) || line[q] == null) continue;
			foreach (int l in line[q])
			{
				if (subway[l] == null) continue;
				int nextw = w + 1;
				if (l == cur) nextw = w;
				foreach (int st in subway[l])
				{
					if (!dist.ContainsKey(st) || dist[st] > nextw)
					{
						PQ.Enqueue((st, nextw, l), nextw);
						dist[st] = nextw;
					}
				}
			}
		}
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		subway = new List<int>[N];
		List<int> start = new List<int>();
		for (int i = 0; i < N; i++)
		{
			string[] S = Console.ReadLine().Split();
			int m = int.Parse(S[0]);
			for (int j = 1; j <= m; j++)
			{
				int s = int.Parse(S[j]);
				(subway[i] ??= new List<int>()).Add(s);
				if (!line.ContainsKey(s)) line[s] = new List<int>();
				line[s].Add(i);
				if (s == 0) start.Add(i);
			}
		}
		int goal = int.Parse(Console.ReadLine());

		foreach (int s in start)
		{
			PQ.Enqueue((0, 0, s), 0);
		}
		dist[0] = 0;

		BFS();

		Console.WriteLine(dist.ContainsKey(goal) ? dist[goal] : -1);
	}
}