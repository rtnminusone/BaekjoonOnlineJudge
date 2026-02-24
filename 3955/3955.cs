#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static long EGCD(long a, long b, out long x, out long y)
	{
		if (b == 0)
		{
			x = 1;
			y = 0;
			return a;
		}

		long g = EGCD(b, a % b, out long x1, out long y1);
		x = y1;
		y = x1 - (a / b) * y1;

		return g;
	}

	public static void Main()
	{
		int T = int.Parse(Console.ReadLine());

		while (T-- > 0)
		{
			string[] S = Console.ReadLine().Split();
			long K = long.Parse(S[0]);
			long C = long.Parse(S[1]);
			long x0, y0;
			long g = EGCD(K, C, out x0, out y0);

			if (g != 1)
			{
				Console.WriteLine("IMPOSSIBLE");
				continue;
			}

			long t = Math.Min((y0 - 1) / K, (-x0 - 1) / C);
			long y = y0 - K * t;
			if (y <= 0)
			{
				t--;
				y = y0 - K * t;
			}

			if (y > 1_000_000_000)
			{
				Console.WriteLine("IMPOSSIBLE");
				continue;
			}

			Console.WriteLine(y);
		}
	}
}