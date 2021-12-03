using System;
using System.Threading;

namespace moment3_Guestbook
{
    //Moment 3 DT071G av Alice Fagerberg
    class Program
    {
        static void Main(string[] args)
        {
            //Instans av Guestbook
            GuestBook guestbook = new GuestBook();

            int i = 0;

            while (true)
            {
                //Konsollmenyn
                Console.Clear(); Console.CursorVisible = false;

                Console.WriteLine("--Alices gästbok--\n\n");

                Console.WriteLine("1. Skriv i gästboken");
                Console.WriteLine("2. Ta bort ett inlägg\n");
                Console.WriteLine("X. Avsluta\n");

                i = 0;
                foreach (Guest guest in guestbook.getGuests())
                {
                    //Skriver ut gästbokslistan
                    Console.WriteLine("[" + i++ + "] " + guest.Author + " - " + guest.Post);
                }

                int input = (int)Console.ReadKey(true).Key;
                switch (input)
                {
                    case '1':
                        //ange namn-author och sitt inlägg-post
                        Console.CursorVisible = true;

                        Console.Write("Ange ditt namn: ");
                        string myAuthor = Console.ReadLine();
                        //Instans av Guest
                        Guest obj = new Guest();
                        obj.Author = myAuthor;

                        Console.Write("Skriv ett inlägg: ");
                        string myPost = Console.ReadLine();
                        obj.Post = myPost;

                        //Kontroll input
                        if (String.IsNullOrEmpty(myAuthor) || String.IsNullOrEmpty(myPost))
                        {   
                            //skriv felmeddelande vid felaktig input och sedan ladda om till konsollmenyn
                            Console.WriteLine("Både namn och inlägg måste fyllas i korrekt!"); 
                            Thread.Sleep(3000);
                        }      
                        else guestbook.addGuest(obj); //Lägg till gästinlägget i listan vid korrekt input
                        break;

                    case '2':
                        Console.CursorVisible = true;

                        Console.Write("Ange index att radera: ");
                        string index = Console.ReadLine();
                        //Raderar gästinlägg utifrån index
                        guestbook.deleteGuest(Convert.ToInt32(index));
                        break;

                    case 88:
                        //Avslutar konsollappen
                        Environment.Exit(0);
                        break;
                }

            }

        }
    }
}
