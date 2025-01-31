 
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

            // public Music(string title, string artist, string album, double length, Genre genre)
            // {
            //     _Title = title;
            //     _Artist = artist;
            //     _Album = album;
            //     _Length = length;
            //     _Genre = genre;
            // }
            public string Display()
            {
                return "Title: " + _Title + "\nArtist: " + _Artist +
                    "\nAlbum: " + _Album + "\nLength: " + _Length + "\nGenre: " + _Genre;
            }
            public void setTitle(string title)
            {
                _Title = title;
            }
            public void setArtist (string artist)
            {
                _Artist = artist;
            }
            public void setAlbum (string album)
            {
                _Album = album;
            }
            public void setLength (double length)
            {
                _Length = length;
            }
            public void setGenre (Genre? genre)
            {
                _Genre = genre;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("How many songs would you like to enter?");
            int size = int.Parse(Console.ReadLine());
            Music[] collection = new Music[size];
            try
            {
                for (int i=0; i < size; i++)
                {
                    Console.WriteLine("What is the title of your favorite song?");
                    collection[i].setTitle(Console.ReadLine());
                    Console.WriteLine("Who is the artist?");
                    collection[i].setArtist(Console.ReadLine());
                    Console.WriteLine("What is the album?");
                    collection[i].setAlbum(Console.ReadLine());
                    Console.WriteLine("What is the length?");
                    collection[i].setLength(double.Parse(Console.ReadLine()));
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
                    collection[i].setGenre(tempGenre);
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine($"{collection[i].Display()}");
                }
            }
        }
    }
}