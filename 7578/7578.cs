#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static int N;
	public static int[] A;
	public static int[] tmp;
	public static long R = 0;
	public static Dictionary<int, int> D = new Dictionary<int, int>();

	public static void merge_sort(int left, int right)
	{
		if (left >= right) return;

		int mid = (left + right) / 2;

		merge_sort(left, mid);
		merge_sort(mid + 1, right);

		merge(left, mid, right);
	}

	public static void merge(int left, int mid, int right)
	{
		int l = left;
		int r = mid + 1;
		int k = left;

		while (l <= mid && r <= right)
		{
			if (A[l] <= A[r])
			{
				tmp[k++] = A[l++];
			}
			else
			{
				R += (mid - l + 1);
				tmp[k++] = A[r++];
			}
		}

		while (l <= mid)
		{
			tmp[k++] = A[l++];
		}

		while (r <= right)
		{
			tmp[k++] = A[r++];
		}

		Array.Copy(tmp, left, A, left, right - left + 1);
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());
		A = new int[N];
		tmp = new int[N];
		int[] lineA = new int[N];

		string[] inputA = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			lineA[i] = int.Parse(inputA[i]);
		}

		string[] inputB = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			D[int.Parse(inputB[i])] = i;
		}

		for (int i = 0; i < N; i++)
		{
			A[i] = D[lineA[i]];
		}

		merge_sort(0, N - 1);

		Console.WriteLine(R);
	}
}