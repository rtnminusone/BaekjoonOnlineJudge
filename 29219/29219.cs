#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8625

class Program
{
	sealed class FastScanner
	{
		private readonly Stream _s = Console.OpenStandardInput();
		private readonly byte[] _buf = new byte[1 << 16];
		private int _len, _ptr;

		private int ReadByte()
		{
			if (_ptr >= _len)
			{
				_len = _s.Read(_buf, 0, _buf.Length);
				_ptr = 0;

				if (_len <= 0) return -1;
			}

			return _buf[_ptr++];
		}

		public int NextInt()
		{
			int c;

			do
			{
				c = ReadByte();
			}
			while (c <= 32 && c != -1);

			if (c == -1) throw new EndOfStreamException();

			int sign = 1;

			if (c == '-')
			{
				sign = -1;
				c = ReadByte();
			}

			int val = 0;

			while (c > 32 && c != -1)
			{
				val = val * 10 + (c - '0');
				c = ReadByte();
			}

			return val * sign;
		}
	}

	public static int N, M, K, X, Y;
	public static int[] T;
	public static bool[] V;
	public static List<int>[] L;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();
	public static Dictionary<int, int> D = new Dictionary<int, int>();

	public static void BFS()
	{
		while (Q.Count > 0)
		{
			var (q, w) = Q.Dequeue();

			if (D.ContainsKey(w)) D[w] += T[q];
			else D[w] = T[q];

			if (L[q] == null) continue;
			foreach (int l in L[q])
			{
				if (V[l]) continue;
				Q.Enqueue((l, w + 1));
				V[l] = true;
			}
		}
	}

	public static string Simulation()
	{
		int vam = 0;
		int wolf = Y;
		int time = 0;

		while (true)
		{
			if (D.ContainsKey(time)) vam += D[time];

			int min = Math.Min(vam, wolf);
			min = Math.Min(min, K);

			vam -= min;
			wolf -= min;

			if (wolf > 0 && vam == 0) return "Werewolves win";
			if (wolf == 0) break;

			time++;
		}

		return "Vampires win";
	}

	public static void Main()
	{
		FastScanner fs = new FastScanner();
		N = fs.NextInt();
		M = fs.NextInt();
		K = fs.NextInt();
		T = new int[N];
		V = new bool[N];
		L = new List<int>[N];
		for (int i = 0; i < N; i++)
		{
			T[i] = fs.NextInt();
		}
		for (int i = 0; i < M; i++)
		{
			int left = fs.NextInt() - 1;
			int right = fs.NextInt() - 1;
			if (L[left] == null) L[left] = new List<int>();
			if (L[right] == null) L[right] = new List<int>();
			L[left].Add(right);
			L[right].Add(left);
		}
		X = fs.NextInt() - 1;
		Y = fs.NextInt();

		Q.Enqueue((X, 0));
		V[X] = true;

		BFS();

		Console.WriteLine(Simulation());
	}
}