﻿using System;

namespace bookStore
{
    class book
    {
        int Id;
        string _Title;
        string _Author;
        private static int _transactions = 0;

        public book ()
        {
            Id = 0;
            _Title = "";
            _Author = "";
        }

        public book (int id, string title, string author)
        {
            Id = id;
            _Title = title;
            _Author = author;
        }

        public int GetId ()
        {
            return Id;
        }
        public string GetTitle ()
        {
            return _Title;
        }
        public string GetAuthor ()
        {
            return _Author;
        }
        public void SetId (int id)
        {
            Id = id;
        }
        public void SetTitle (string title)
        {
            _Title = title;
        }
        public void SetAuthor (string author)
        {
            _Author = author;
        }

        public void SetTrans ()
        {
            _transactions++;
        }

        public int GetTrans ()
        {
            return _transactions;
        }
    }
    class myStore
    {
        static void Main(string[] args)
        {
            book book1 = new book ();
            book1.SetTrans();
            book1.SetId (1);
            book1.SetTitle ("Onyx Storm");
            book1.SetAuthor ("Rebecca Yarros");

            book book2 = new book ();
            book2.SetTrans();
            Console.WriteLine("Please enter the member ID: ");
            book2.SetId(int.Parse(Console.ReadLine()));
            Console.WriteLine("Please enter the title: ");
            book2.SetTitle(Console.ReadLine());
            Console.WriteLine("Please enter the author: ");
            book2.SetAuthor(Console.ReadLine());

            book book3 = new book (1, "Fourth Wing", "Rebecca Yarros");
            book3.SetTrans();

            Console.WriteLine("Please enter the member ID: ");
            int tempID = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the title: ");
            string tempTitle = Console.ReadLine();   
            Console.WriteLine("Please enter the author: ");
            string tempAuthor = Console.ReadLine();
            book book4 = new book (tempID, tempTitle, tempAuthor);
            book4.SetTrans();

            Console.WriteLine($"There are {book1.GetTrans()} books.");

            displayBooks(book1);
            displayBooks(book2);
            displayBooks(book3);
            displayBooks(book4);
        }

        static void displayBooks(book book1)
        {
            Console.WriteLine("Here is your book information");
            Console.WriteLine($"Member ID: {book1.GetId()}");
            Console.WriteLine($"Title: {book1.GetTitle()}");
            Console.WriteLine($"Author: {book1.GetAuthor()}");
        }
    }
}