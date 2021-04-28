﻿using System;
using System.Collections.Generic;
using System.Text;
using engine.Models;

namespace engine.Factories
{
    class WorldFactory
    {
         public World CreateWorld()
        {
            World newWorld = new World();
            // Forestmonster, mainTown, Mudhut, mudhutgarden, mainTown, TownGate, Trader,

            newWorld.Addlocation(-2, -1, "Ivan's Field", "This is ivan's field he likes sunflowers!", "pack://application:,,,/Engine;component/Images/Locations/Field.png");
            newWorld.Addlocation(-1, -1, "Ivan's Home", "This is your friend's house.", "pack://application:,,,/Engine;component/Images/Locations/Framhouse.png" );
            newWorld.Addlocation(0, -1, "home", "this is your casa homie", "pack://application:,,,/Engine;component/Images/Locations/home.png");
            newWorld.Addlocation(-1, 0, "Trader", "This is a freindly trader, say hi!", "pack://application:,,,/Engine;component/Images/Locations/Trader.png");
            newWorld.Addlocation(0, 0, "Main town", "Welcome to LONDON!", "pack://application:,,,/Engine;component/Images/Locations/mainTown.png");
            newWorld.Addlocation(1, 0, "Town Gate", "used to proect from unwated guests, im nervous", "pack://application:,,,/Engine;component/Images/Locations/TownGate.png");
            newWorld.Addlocation(2, 0, "Forest", "This place seems odd...", "pack://application:,,,/Engine;component/Images/Locations/Forestmonster.png");
            newWorld.Addlocation(0, 1, "Hut", "you can rest here... however something is waiting for you in the back...", "pack://application:,,,/Engine;component/Images/Locations/Mudhut.png");
            newWorld.Addlocation(0, 2, "Hut garden", "this place looks AMAZING, however something approaches you", "pack://application:,,,/Engine;component/Images/Locations/mudhutgarden.png");


            return newWorld;
        }
    }
}