using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Task7.Enitites;
using Task7.Interfaces;

[XmlInclude(typeof(PaperBook))]
[XmlInclude(typeof(EBook))]
public class SerializableBook
{
	public IBook Book { get; set; }

	public SerializableBook() { }

	public SerializableBook(IBook book)
	{
		Book = book;
	}
}