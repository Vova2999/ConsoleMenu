using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Books.Helpers;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Helpers;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands;

public class DeleteBookCommand : ICommand<ValueWrapper<IList<Book>>>
{
	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public DeleteBookCommand(string description, bool isBackAfterExecute = false)
	{
		Description = description;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public void Execute(ValueWrapper<IList<Book>> wrapper)
	{
		Console.WriteLine("Введите номер удаляемой книги");

		Console.WriteLine("Вывести книги?");
		Console.WriteLine("1: Да");
		Console.WriteLine("0: Нет");

		var printSelector = ConsoleReadHelper.ReadInt(" => ", 0, 1);
		if (printSelector == 1)
			PrintHelper.PrintWithPause(wrapper.Value.Select((book, i) => $"{Environment.NewLine}Книга #{i + 1}{Environment.NewLine}Название: {book.Title}, Автор: {book.Author}, Количество страниц: {book.Pages.Count}"));

		Console.WriteLine("Введите 0 для отмены");
		var bookSelector = ConsoleReadHelper.ReadInt(" => ", 0, wrapper.Value.Count);
		if (bookSelector == 0)
			return;

		wrapper.Value.RemoveAt(bookSelector - 1);
	}
}