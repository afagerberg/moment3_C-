using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace moment3_Guestbook
{
    //Moment 3 DT071G av Alice Fagerberg
    public class GuestBook
    {
        private string filename = @"guestbook.json"; //gilen guestbook
        private List<Guest> guests = new List<Guest>();//lista

        public GuestBook()
        {
            if (File.Exists(@"guestbook.json") == true)
            { // Kontroll om filen existrerar då läsa in
                string jsonString = File.ReadAllText(filename);
                guests = JsonSerializer.Deserialize<List<Guest>>(jsonString);
            }
        }

        //metod- lägga till gästinlägg
        public Guest addGuest(Guest guest)
        {
            guests.Add(guest);
            marshal();
            return guest;
        }

        //metod - radera gästinlägg
        public int deleteGuest(int index)
        {
            guests.RemoveAt(index);
            marshal();
            return index;
        }

        //Hämta alla gästinlägg
        public List<Guest> getGuests()
        {
            return guests;
        }

        private void marshal()
        {
            // Serialisera alla objects och spara till filen
            var jsonString = JsonSerializer.Serialize(guests);
            File.WriteAllText(filename, jsonString);


        }
    }
}
