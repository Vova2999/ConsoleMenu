using System.Collections.Generic;

namespace ConsoleMenu.Books.Entities;

public class Book
{
	public string Title { get; set; }
	public string Author { get; set; }
	public List<string> Pages { get; set; }
}