#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N;
	public static int[] TX, TY;
	public static bool[] V;
	public static Queue<(int, int)> Q = new Queue<(int, int)>();

	public static string BFS()
	{
		while (Q.Count > 0)
		{
			var (x, y) = Q.Dequeue();

			if (x == TX[N - 1] && y == TY[N - 1]) return "happy";

			for (int i = 0; i < N; i++)
			{
				if (V[i]) continue;
				if (Math.Abs(x - TX[i]) + Math.Abs(y - TY[i]) <= 1000)
				{
					Q.Enqueue((TX[i], TY[i]));
					V[i] = true;
				}
			}
		}

		return "sad";
	}

	public static void Main()
	{
		StringBuilder sb = new StringBuilder();
		string[] S = null;
		int t = int.Parse(Console.ReadLine());
		while (t-- > 0)
		{
			N = int.Parse(Console.ReadLine()) + 2;
			TX = new int[N];
			TY = new int[N];
			V = new bool[N];
			Q.Clear();
			for (int i = 0; i < N; i++)
			{
				S = Console.ReadLine().Split();
				TX[i] = int.Parse(S[0]);
				TY[i] = int.Parse(S[1]);
			}

			Q.Enqueue((TX[0], TY[0]));
			V[0] = true;

			sb.AppendLine(BFS());
		}

		Console.WriteLine(sb.ToString());
	}
}