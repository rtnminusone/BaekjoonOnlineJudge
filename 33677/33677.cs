#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N;
	public static (int day, long water)[] dist;
	public static PriorityQueue<(long, int, long), (int, long)> PQ = new PriorityQueue<(long, int, long), (int, long)>();

	public static string BFS()
	{
		while (PQ.Count > 0)
		{
			var (q, day, water) = PQ.Dequeue();

			if (q == N) return day + " " + water;

			if (q + 1 <= N && (dist[q + 1].day > day + 1 || (dist[q + 1].day == day + 1 && dist[q + 1].water > water + 1)))
			{
				PQ.Enqueue((q + 1, day + 1, water + 1), (day + 1, water + 1));
				dist[q + 1] = (day + 1, water + 1);
			}
			if (q * 3 <= N && (dist[q * 3].day > day + 1 || (dist[q * 3].day == day + 1 && dist[q * 3].water > water + 3)))
			{
				PQ.Enqueue((q * 3, day + 1, water + 3), (day + 1, water + 3));
				dist[q * 3] = (day + 1, water + 3);
			}
			if (q * q <= N && (dist[q * q].day > day + 1 || (dist[q * q].day == day + 1 && dist[q * q].water > water + 5)))
			{
				PQ.Enqueue((q * q, day + 1, water + 5), (day + 1, water + 5));
				dist[q * q] = (day + 1, water + 5);
			}
		}

		return "";
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		dist = new (int, long)[N + 1];
		for (int i = 1; i <= N; i++)
		{
			dist[i] = (int.MaxValue, long.MaxValue);
		}
		PQ.Enqueue((0, 0, 0), (0, 0));
		dist[0] = (0, 0);

		Console.WriteLine(BFS());
	}
}