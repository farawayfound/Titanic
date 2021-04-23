using System.Collections.Generic;
using System.IO;

namespace Titanic
{
   public static class Titanic
   {
      //   F i e l d s   &   P r o p e r t i e s


      //   C o n s t r u c t o r s


      //   M e t h o d s

      public static List<Passenger> GetPassengers(string fileName)
      {
         List<Passenger> passengers = new List<Passenger>();

         using (var reader = new StreamReader(fileName))
         {
            reader.ReadLine(); // Heading Line
            while (reader.EndOfStream == false)
            {
               passengers.Add(new Passenger(reader.ReadLine()));
            }
         }

         return passengers;
      } // end GetPassengers( )
   }
}
