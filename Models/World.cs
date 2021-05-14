using System;
using System.Collections.Generic; // used to store multi objects and have it store any type of object i want
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>(); // made an empty list and will be loaded through worldFacotry

        internal void Addlocation(int xCoord, int yCoord, string name, string description, string imageName) // voided because we do not need to return anything since this is just for storing info. Will pull stuff from WorldFactory.cs
        {
            
            Location loc = new Location();
            loc.XCoord = xCoord;
            loc.YCoord = yCoord;
            loc.Name = name;
            loc.Description = description;
            loc.ImageName = imageName;

            _locations.Add(loc);

        }
        public Location LocationAt(int xCoord, int yCoord)
        {
            foreach(Location loc in _locations)
            {
                if(loc.XCoord == xCoord && loc.YCoord == yCoord)
                {
                    return loc;
                }
            }
            // null is used here if coords are invalid
            return null;
        }
    }
}
