using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleMenu.Books.Entities;
using ConsoleMenu.Books.Helpers;
using ConsoleMenu.Core;
using ConsoleMenu.Core.Logic;

namespace ConsoleMenu.Books.Commands;

public class ShowBooksCommand : ICommand<ValueWrapper<IList<Book>>>
{
	public string Description { get; }
	public bool IsBackAfterExecute { get; }

	public ShowBooksCommand(string description, bool isBackAfterExecute = false)
	{
		Description = description;
		IsBackAfterExecute = isBackAfterExecute;
	}

	public Task ExecuteAsync(ValueWrapper<IList<Book>> wrapper)
	{
		PrintHelper.PrintWithPause(wrapper.Value.Select((book, i) => $"{Environment.NewLine}Книга #{i + 1}{Environment.NewLine}Название: {book.Title}, Автор: {book.Author}, Количество страниц: {book.Pages.Count}"), 10);

		PrintHelper.ReadKeyForContinue();

		return Task.CompletedTask;
	}
}