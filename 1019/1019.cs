#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static long N;
	public static long[] T = new long[10];

	public static void Count()
	{
		long digit = 1;

		while (digit <= N)
		{
			long high = N / (digit * 10);
			long cur = (N / digit) % 10;
			long low = N % digit;

			for (int i = 0; i < 10; i++)
			{
				T[i] += high * digit;
			}

			for (int i = 0; i < cur; i++)
			{
				T[i] += digit;
			}

			T[cur] += low + 1;
			T[0] -= digit;
			digit *= 10;
		}
	}

	public static void Main()
	{
		N = long.Parse(Console.ReadLine());

		Count();

		Console.WriteLine(string.Join(" ", T));
	}
}