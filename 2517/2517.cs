#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618

using System.Text;

class Program
{
	public static int N;
	public static int[] tmp;
	public static int[] skill;
	public static int[] result;

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
		int l = left;
		int r = mid + 1;
		int k = 0;

		while (l <= mid && r <= right)
		{
			if (skill[T[l]] >= skill[T[r]])
			{
				tmp[k++] = T[l++];
			}
			else
			{
				result[T[r]] += (mid - l + 1);
				tmp[k++] = T[r++];
			}
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
		StringBuilder sb = new StringBuilder();
		N = int.Parse(Console.ReadLine());
		int[] T = new int[N];
		tmp = new int[N];
		skill = new int[N];
		result = new int[N];

		for (int i = 0; i < N; i++)
		{
			skill[i] = int.Parse(Console.ReadLine());
			T[i] = i;
		}

		merge_sort(T, 0, N - 1);

		for (int i = 0; i < N; i++)
		{
			sb.AppendLine((i + 1 - result[i]).ToString());
		}

		Console.WriteLine(sb.ToString());
	}
}