 
using System;
namespace music
{
    class Program
    {
        enum Genre
        {
            Rock,
            Pop,
            Hiphop,
            Electronic,
            Jazz
        }
        struct Music
        {
            private string _Title;
            private string _Artist;
            private string _Album;
            private double? _Length;
            private Genre? _Genre;

            public Music(string title, string artist, string album, double length, Genre genre)
            {
                _Title = title;
                _Artist = artist;
                _Album = album;
                _Length = length;
                _Genre = genre;
            }
            public string Display()
            {
                return "Title: " + _Title + "\nArtist: " + _Artist +
                    "\nAlbum: " + _Album + "\nLength: " + _Length + "\nGenre: " + _Genre;
            }
            public void setTitle(string title)
            {
                _Title = title;
            }
            public void setLength (int length)
            {
                _Length = length;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("What is the title of your favorite song?");
            string tempTitle=Console.ReadLine();
            Console.WriteLine("Who is the artist?");
            string tempArtist=Console.ReadLine();
            Console.WriteLine("What is the album?");
            string tempAlbum=Console.ReadLine();
            Console.WriteLine("What is the length?");
            double tempLength = double.Parse(Console.ReadLine());
            Console.WriteLine("R - Rock\nP - Pop\nH - Hiphop\nE - Electronic\nJ - Jazz");
            Genre tempGenre=Genre.Rock;
            char g = char.Parse(Console.ReadLine());
            switch(g)
            {
                case 'R':
                    tempGenre = Genre.Rock; 
                    break;
                case 'P':
                    tempGenre = Genre.Pop;
                    break;
                case 'H':
                    tempGenre = Genre.Hiphop;
                    break;
                case 'E':
                    tempGenre = Genre.Electronic;
                    break;
                case 'J':
                    tempGenre = Genre.Jazz;
                    break;
            }
            Music music = new Music(tempTitle,tempArtist,tempAlbum,tempLength,tempGenre);
            Console.WriteLine($"{music.Display()}");
            Music moreMusic = music;
            moreMusic.setTitle("Summer");
            moreMusic.setLength(3);
            Console.WriteLine("Here's song #2");
            Console.WriteLine($"{moreMusic.Display()}");
            Console.WriteLine();
        }
    }
}