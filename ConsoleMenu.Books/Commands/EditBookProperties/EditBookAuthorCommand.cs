using System;
using System.Threading.Tasks;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands.EditBookProperties;

public class EditBookAuthorCommand : ICommand<Book>
{
	public string Description { get; }

	public EditBookAuthorCommand(string description)
	{
		Description = description;
	}

	public Task ExecuteAsync(Book book)
	{
		Console.Write("Введите автора => ");
		book.Author = Console.ReadLine();

		return Task.CompletedTask;
	}
}