using System;
using System.Collections.Generic;
using System.Text;
using engine.Models;

namespace engine.Factories
{
    static class WorldFactory
    { 
         public static World CreateWorld()
            // add locations
        {
            World newWorld = new World();
            // Forestmonster, mainTown, Mudhut, mudhutgarden, mainTown, TownGate, Trader,

            newWorld.Addlocation(-2, -1, "Ivan's Field", "This is ivan's field he likes sunflowers!", "pack://application:,,,/Engine;component/Images/Locations/Field.png");
            newWorld.LocationAt(-2, -1).AddMonster(2, 100);
            newWorld.Addlocation(-1, -1, "Ivan's Home", "This is your friend's house.", "pack://application:,,,/Engine;component/Images/Locations/Framhouse.png" );
            newWorld.Addlocation(0, -1, "home", "This is your home", "pack://application:,,,/Engine;component/Images/Locations/home.png");
            newWorld.Addlocation(-1, 0, "Trader", "This is a freindly trader, say hi!", "pack://application:,,,/Engine;component/Images/Locations/Trader.png");
            newWorld.Addlocation(0, 0, "Main town", "Welcome to LONDON!", "pack://application:,,,/Engine;component/Images/Locations/mainTown.png");
            newWorld.Addlocation(1, 0 , "Town Gate", "used to proect from unwated guests, im nervous", "pack://application:,,,/Engine;component/Images/Locations/TownGate.png");
            newWorld.Addlocation(2, 0, "Forest", "This place seems odd...", "pack://application:,,,/Engine;component/Images/Locations/Forestmonster.png");

            newWorld.LocationAt(2, 0).AddMonster(3, 100);

            newWorld.Addlocation(0, 1, "Hut", "you can rest here... however something is waiting for you in the back...", "pack://application:,,,/Engine;component/Images/Locations/Mudhut.png");
            newWorld.LocationAt(0, 1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));

            newWorld.Addlocation(0, 2, "Hut garden", "this place looks AMAZING, however something approaches you", "pack://application:,,,/Engine;component/Images/Locations/mudhutgarden.png");

            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            return newWorld;
        }
    }
}
