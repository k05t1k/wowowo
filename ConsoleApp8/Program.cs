namespace ConsoleApp8
{
	internal class Program
	{
		public static void Main()
		{
			Console.WriteLine("Нажмите Enter, чтобы начать тест");
			ConsoleKeyInfo keyInfo = Console.ReadKey();

			// output with some logistic
			Output output = new Output();

			output.IsEnd = false;

			// locked value of timer on 1:00
			Timer timer = new Timer(1, 0, output);

			if (keyInfo.Key == ConsoleKey.Enter)
			{
				Console.Clear();

				Thread thread = new Thread(new ThreadStart(timer.StartTimer));
				thread.Start();

				Thread thread2 = new Thread(new ThreadStart(output.RenderText));
				thread2.Start();
			}
		}
	}
}
