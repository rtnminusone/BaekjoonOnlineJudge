#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public struct Pos
	{
		public int x;
		public int y;

		public Pos(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public static int N, M;
	public static char[,] T;
	public static int[,] dist0, dist1, dist2;
	public static PriorityQueue<Pos, int> PQ = new PriorityQueue<Pos, int>();

	public static int[] dx = { 1, -1, 0, 0 };
	public static int[] dy = { 0, 0, 1, -1 };

	public static bool Create(int x, int y, out Pos pos)
	{
		pos = default;
	
		if (x < 0 || x >= N || y < 0 || y >= M) return false;
		if (T[x, y] == '*') return false;

		pos = new Pos(x, y);

		return true;
	}

	static void Dijkstra(Pos search, int[,] dist)
	{
		PQ.Clear();
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < M; j++)
			{
				dist[i, j] = int.MaxValue;
			}
		}

		dist[search.x, search.y] = 0;
		PQ.Enqueue(search, 0);

		while (PQ.Count > 0)
		{
			Pos p = PQ.Dequeue();

			for (int i = 0; i < 4; i++)
			{
				if (Create(p.x + dx[i], p.y + dy[i], out Pos pos))
				{
					int nextw = dist[p.x, p.y] + (T[pos.x, pos.y] == '#' ? 1 : 0);
					if (dist[p.x + dx[i], p.y + dy[i]] > nextw)
					{
						PQ.Enqueue(pos, nextw);
						dist[pos.x, pos.y] = nextw;
					}
				}
			}
		}
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		int t = int.Parse(Console.ReadLine());
		while (t-- > 0)
		{
			string[] S = Console.ReadLine().Split();
			int n = int.Parse(S[0]);
			int m = int.Parse(S[1]);

			N = n + 2;
			M = m + 2;
			T = new char[N, M];
			List<Pos> prisoners = new List<Pos>();
			for (int i = 1; i <= n; i++)
			{
				S[0] = Console.ReadLine();
				for (int j = 1; j <= m; j++)
				{
					T[i, j] = S[0][j - 1];
					if (T[i, j] == '$')
					{
						prisoners.Add(new Pos(i, j));
						T[i, j] = '.';
					}
				}
			}

			dist0 = new int[N, M];
			dist1 = new int[N, M];
			dist2 = new int[N, M];

			Dijkstra(new Pos(0, 0), dist0);
			Dijkstra(prisoners[0], dist1);
			Dijkstra(prisoners[1], dist2);

			int ans = int.MaxValue;

			for (int i = 0; i < N; i++)
			{
				for (int j = 0; j < M; j++)
				{
					if (T[i, j] == '*') continue;

					int sum = dist0[i, j] + dist1[i, j] + dist2[i, j];
					if (T[i, j] == '#') sum -= 2;

					ans = Math.Min(ans, sum);
				}
			}

			sb.AppendLine(ans.ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}