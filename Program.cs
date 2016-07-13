using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/*
Practice: Develop custom classes Plant, Herbivore and Carnivore.
Plant slowly grows to be eaten by Herbivore, which in its turn is eaten by Carnivore. 
Implement this interaction using event delegates.
*/

namespace FifthTask
{
    delegate void FinishStepEventHandler();

    class Plant
    {
        public event FinishStepEventHandler PlantGrew;
        
        public void PlantGrowing()
        {
            Console.WriteLine("Plant grows...");
            Thread.Sleep(2000);
            
            OnPlantGrew();
        } 

        protected virtual void OnPlantGrew()
        {
            Console.WriteLine("Plant grew!");
            if (PlantGrew != null)
                PlantGrew();
        }
    }

    class Herbivore
    {
        public void OnPlantGrew()
        {
            Console.WriteLine("Herbivore is in business!");
            Thread.Sleep(2000);

            OnHerbivoreAtePlant();
        }

        public event FinishStepEventHandler HerbivoreAtePlant;

        public void OnHerbivoreAtePlant()
        {
            Console.WriteLine("Herbivore ate plant.");
            if (HerbivoreAtePlant != null)
                HerbivoreAtePlant();
        }
    }

    class Carnivore
    {
        public void OnHerbivoreAtePlant()
        {
            Console.WriteLine("Carnivore is in business!");
            Thread.Sleep(2000);

            OnCarnivoreAteHerbivore();
        }

        public void OnCarnivoreAteHerbivore()
        {
            Console.WriteLine("Carnivore ate herbivore.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Plant p1 = new Plant();
            Herbivore h1 = new Herbivore();
            Carnivore c1 = new Carnivore();

            p1.PlantGrew += h1.OnPlantGrew;
            h1.HerbivoreAtePlant += c1.OnHerbivoreAtePlant;

            p1.PlantGrowing();

            Console.ReadKey();
        }
    }
}
