using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using LibraryWebApp.Model;

namespace LibraryWebApp.Service
{
    public class BookJSONService: IBookService
    {
        private string bookFile = "books.json";
        private IList<Book> books;
        
        //Checking if the file containing books exists
        public BookJSONService() {   
            if (!File.Exists(bookFile)) 
            {
                Seed();
                string booksAsJson = JsonSerializer.Serialize(books);
                File.WriteAllText(bookFile, booksAsJson);
            }
            else {
                string content = File.ReadAllText(bookFile);
                books = JsonSerializer.Deserialize<List<Book>>(content);
            }
            
        }
        
        //populating with test data
        private void Seed()
        {
            Book[] b =
            {
                new Book
                {
                    ISBN = "123-123-123",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 1,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 5
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "123-123-234",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 1,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 4
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "505-123-912",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 3,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 4
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "888-465-903",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 7,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 3
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "236-739-487",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 6,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 2
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "123-657-654",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 2,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 3
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "123-234-278",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 7,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 3
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "789-123-123",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 1,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 5
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "789-654-123",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 1,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 4
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "789-654-912",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 3,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 4
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "789-465-903",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 7,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 3
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "789-739-487",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 6,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 2
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "789-657-654",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 2,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 3
                            }
                        }
                    }
                },
                new Book
                {
                    ISBN = "789-234-278",
                    Room = new Room
                    {
                        RoomNumber = 1,
                        Row = new Row
                        {
                            RowNumber = 7,
                            Bookshelf = new Bookshelf
                            {
                                BookshelfNumber = 3
                            }
                        }
                    }
                }
            };
            books = b.ToList();
        }
        
        //Returning a copy of books list
        public IList<Book> GetBooks()
        {
            List<Book> temp = new List<Book>(books);
            return temp;
        }

        //Adding book to book list and save everything to file
        public void AddBook(Book _book)
        {
            books.Add(_book);
            string booksAsJSON = JsonSerializer.Serialize(books);
            File.WriteAllText(bookFile, booksAsJSON);
        }
    }
}