#pragma warning disable CS8600, CS8601, CS8602, CS8603, CS8604, CS8618, CS8620

using System.Text;

class Program
{
	public static int N;
	public static StringBuilder sb = new StringBuilder();
	public static StringBuilder sb2 = new StringBuilder();

	public static void Recursion(int n)
	{
		if (n != 0)
		{
			sb2.Append("____");
		}

		if (n == N)
		{
			sb.AppendLine(sb2.ToString() + "\"재귀함수가 뭔가요?\"");
			sb.AppendLine(sb2.ToString() + "\"재귀함수는 자기 자신을 호출하는 함수라네\"");
			sb.AppendLine(sb2.ToString() + "라고 답변하였지.");
			return;
		}

		sb.AppendLine(sb2.ToString() + "\"재귀함수가 뭔가요?\"");
		sb.AppendLine(sb2.ToString() + "\"잘 들어보게. 옛날옛날 한 산 꼭대기에 이세상 모든 지식을 통달한 선인이 있었어.");
		sb.AppendLine(sb2.ToString() + "마을 사람들은 모두 그 선인에게 수많은 질문을 했고, 모두 지혜롭게 대답해 주었지.");
		sb.AppendLine(sb2.ToString() + "그의 답은 대부분 옳았다고 하네. 그런데 어느 날, 그 선인에게 한 선비가 찾아와서 물었어.\"");

		Recursion(n + 1);

		sb2.Length -= 4;
		sb.AppendLine(sb2.ToString() + "라고 답변하였지.");
	}

	public static void Main()
	{
		N = int.Parse(Console.ReadLine());

		sb.AppendLine("어느 한 컴퓨터공학과 학생이 유명한 교수님을 찾아가 물었다.");

		Recursion(0);

		Console.WriteLine(sb.ToString());
	}
}