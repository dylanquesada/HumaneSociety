using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal dog = new Animal();
            dog.PetName = "dog";
            
                using (var db = new GameDbContext())
                {
                    var playerQuery = from p in db.Players orderby p.GameId select new { p.Name, p.GameId };
                    Console.WriteLine("List of Players in DB:");
                    foreach (var p in playerQuery) Console.WriteLine(p);
                
            }
        }
    }
}
