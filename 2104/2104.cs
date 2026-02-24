#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

class Program
{
	public static int N;
	public static long[] A, P;

	public static long Sum(int l, int r) => P[r + 1] - P[l];

	public static long Solve(int l, int r)
	{
		if (l == r) return A[l] * A[l];

		int mid = (l + r) / 2;
		long ret = Math.Max(Solve(l, mid), Solve(mid + 1, r));
		int left = mid, right = mid + 1;
		long minVal = Math.Min(A[left], A[right]);
		long sumVal = A[left] + A[right];

		ret = Math.Max(ret, minVal * sumVal);

		while (l < left || right < r)
		{
			if (right < r && (left == l || A[left - 1] < A[right + 1]))
			{
				right++; sumVal += A[right];
				minVal = Math.Min(minVal, A[right]);
			}
			else
			{
				left--;
				sumVal += A[left];
				minVal = Math.Min(minVal, A[left]);
			}
			ret = Math.Max(ret, minVal * sumVal);
		}

		return ret;
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		A = new long[N];
		P = new long[N + 1];
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			A[i] = long.Parse(S[i]);
			P[i + 1] = P[i] + A[i];
		}

		Console.WriteLine(Solve(0, N - 1));
	}
}