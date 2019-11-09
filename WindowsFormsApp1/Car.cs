using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Car
    {
        private string make;
        private string model;
        private Engine engine;

        public Car(string newMake, string newModel, double newDisplacement, double newAmountOfFuel, double newFuelTankCapacity) :
            this(newMake, newModel, new Engine(newDisplacement, newAmountOfFuel, newFuelTankCapacity))
        { } // constructor that modifies main constructor

        public Car(string newMake, string newModel, double newDisplacement, double newAmountOfFuel) :
            this(newMake, newModel, new Engine(newDisplacement, newAmountOfFuel))
        { } // constructor that modifies main constructor

        public Car(string newMake, string newModel, Engine newEngine) // main constructor
        {
            this.make = newMake;
            this.model = newModel;
            this.engine = newEngine;
        }

        public void Go(double howManyKm, PictureBox pb1)
        {
            int X = pb1.Location.X;
            int Y = pb1.Location.Y;
            while (true)
            {
                this.engine.Work();
                Thread.Sleep(100);
                howManyKm--;
                if (howManyKm == 0) break;
                int interval, intervalOffset, xCoo, yCoo, xCooNew;
                interval = 52 - 247;                              //Max min location picture
                intervalOffset = 247;                              //Starting Point of PictureBox
                xCoo = pb1.Location.X;           //get xCoordinate of PictureBox
                xCoo -= intervalOffset;                            //Substract Offset in order to calculate next Point
                yCoo = pb1.Location.Y;           //get yCoordinate of PictureBox
                xCooNew = ((xCoo + 1) % (interval));               //calculate new xCoordinate of PictureBox
                pb1.Location = new Point((xCooNew + intervalOffset), yCoo);
            }
            //Console.WriteLine("\nHere I am");
        }

        public void Refuel(double fuelAmount)
        {
            this.engine.Refuel(fuelAmount);
        }

    }
}
