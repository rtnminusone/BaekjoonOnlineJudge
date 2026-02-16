#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

class Program
{
	public static long C = 0;

	public static void merge_sort(int[] T, int left, int right)
	{
		if (left >= right) return;

		int mid = (left + right) / 2;

		merge_sort(T, left, mid);
		merge_sort(T, mid + 1, right);

		merge(T, left, mid, right);
	}

	public static void merge(int[] T, int left, int mid, int right)
	{
		int[] tmp = new int[right - left + 1];
		int l = left;
		int r = mid + 1;
		int k = 0;

		while (l <= mid && r <= right)
		{
			if (T[l] > T[r])
			{
				tmp[k++] = T[r++];
				C += (mid - l + 1);
			}
			else tmp[k++] = T[l++];
		}

		while (l <= mid)
		{
			tmp[k++] = T[l++];
		}

		while (r <= right)
		{
			tmp[k++] = T[r++];
		}

		Array.Copy(tmp, 0, T, left, right - left + 1);
	}

	public static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		int[] T = new int[N];
		string[] S = Console.ReadLine().Split();
		for (int i = 0; i < N; i++)
		{
			T[i] = int.Parse(S[i]);
		}

		merge_sort(T, 0, N - 1);

		Console.WriteLine(C);
	}
}