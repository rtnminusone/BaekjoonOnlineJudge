#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		int[] C = new int[N];
		int[] l = new int[N - 1];
		int[] r = new int[N - 1];
		long[] L = new long[N];
		long[] R = new long[N];
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			C[i] = int.Parse(S[i]);
		}
		S = Console.ReadLine().Split();
		for (int i = 0; i < N - 1; i++)
		{
			l[i] = int.Parse(S[i]);
		}
		S = Console.ReadLine().Split();
		for (int i = 0; i < N - 1; i++)
		{
			r[i] = int.Parse(S[i]);
		}

		for (int i = 1; i < N; i++)
		{
			L[i] = L[i - 1] + l[i - 1];
			R[i] = R[i - 1] + r[i - 1];
		}

		int R1 = -1;
		long R2 = long.MaxValue;
		for (int i = 0; i < N; i++)
		{
			long r2 = L[i] + C[i] + (R[N - 1] - R[i]);
			if (r2 < R2)
			{
				R1 = i + 1;
				R2 = r2;
			}
		}

		Console.WriteLine(R1 + " " + R2);
	}
}