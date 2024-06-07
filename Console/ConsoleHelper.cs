using System;

namespace LibraryTestTask
{
	internal static class ConsoleHelper
	{
		public static void Menu(params (string DisplayName, Action Action)[] options) =>
			Menu(null, null, null, options);

		public static void Menu(
			string title = null,
			string prompt = null,
			string invalidMessage = null,
			params (string DisplayName, Action Action)[] options)
		{
			// handling parameters
			if (options is null)
			{
				throw new ArgumentNullException(nameof(options));
			}
			if (options.Length <= 0)
			{
				throw new ArgumentException($"{options} is empty", nameof(options));
			}
			if (title == null)
			{
				title = "Menu...";
			}
			if (prompt == null)
			{
				prompt = $"Choose an option (1-{options.Length}): ";
			}
			if (invalidMessage == null)
			{
				invalidMessage = "Invalid Input. Try Again...";
			}

			// render menu
			Console.Clear();
			Console.WriteLine(title);
			for (int i = 0; i < options.Length; i++)
			{
				Console.WriteLine($"{i + 1}. {options[i].DisplayName}");
			}

			// get user input
			int inputValue;
			Console.Write(prompt);
			while (!int.TryParse(Console.ReadLine(), out inputValue) || inputValue < 1 || options.Length < inputValue)
			{
				Console.WriteLine(invalidMessage);
				Console.Write(prompt);
			}

			// invoke the action relative to the user input
			options[inputValue - 1].Action?.Invoke();

			Console.WriteLine("Press [enter] to continue...");
			Console.ReadLine();
			Menu(title, prompt, invalidMessage, options);
		}
	}
}
