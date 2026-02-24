#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N, M;
	public static char[,] map;
	public static int[] parent;

	public static int[] dx = { 1, -1, 0, 0 };
	public static int[] dy = { 0, 0, 1, -1 };

	public static Queue<(int, int)> waterQ = new Queue<(int, int)>();
	public static Queue<(int, int)> nextWaterQ = new Queue<(int, int)>();

	public static int Find(int x)
	{
		if (parent[x] == x) return x;
		return parent[x] = Find(parent[x]);
	}

	public static void Union(int a, int b)
	{
		a = Find(a);
		b = Find(b);
		if (a != b) parent[b] = a;
	}

	public static int Id(int x, int y) => x * M + y;

	public static void Main()
	{
		string[] S = Console.ReadLine().Split();
		N = int.Parse(S[0]);
		M = int.Parse(S[1]);

		map = new char[N, M];
		parent = new int[N * M];

		List<(int, int)> swans = new();

		for (int i = 0; i < N; i++)
		{
			S[0] = Console.ReadLine();
			for (int j = 0; j < M; j++)
			{
				map[i, j] = S[0][j];
				parent[Id(i, j)] = Id(i, j);

				if (map[i, j] != 'X') waterQ.Enqueue((i, j));
				if (map[i, j] == 'L') swans.Add((i, j));
			}
		}

		int day = 0;

		while (true)
		{
			int cnt = waterQ.Count;
			for (int i = 0; i < cnt; i++)
			{
				var (x, y) = waterQ.Dequeue();
				for (int j = 0; j < 4; j++)
				{
					int nx = x + dx[j];
					int ny = y + dy[j];
					if (nx < 0 || ny < 0 || nx >= N || ny >= M) continue;
					if (map[nx, ny] != 'X') Union(Id(x, y), Id(nx, ny));
				}
				waterQ.Enqueue((x, y));
			}

			if (Find(Id(swans[0].Item1, swans[0].Item2)) == Find(Id(swans[1].Item1, swans[1].Item2)))
			{
				Console.WriteLine(day);
				return;
			}

			while (waterQ.Count > 0)
			{
				var (x, y) = waterQ.Dequeue();
				for (int i = 0; i < 4; i++)
				{
					int nx = x + dx[i];
					int ny = y + dy[i];
					if (nx < 0 || ny < 0 || nx >= N || ny >= M) continue;
					if (map[nx, ny] == 'X')
					{
						map[nx, ny] = '.';
						nextWaterQ.Enqueue((nx, ny));
					}
				}
			}

			(waterQ, nextWaterQ) = (nextWaterQ, waterQ);
			day++;
		}
	}
}