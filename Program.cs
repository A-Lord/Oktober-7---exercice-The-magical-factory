using System;
using System.Collections.Generic;

namespace Oktober_7___exercice_The_magical_factory
{
    partial class Program
    {
        static void Main(string[] args)
        {



            Fabric myFabric = new();
            Storage myStorage = new();
            while (true)
            {


                Console.WriteLine("Welcome to the Macical Factory!\n");

                myStorage.ShowLager();
                myFabric.ShowBlueprints();
                myStorage.MaterialsFromStorageToFactory();

                myFabric.ShowBlueprints();

                
                myStorage.ConvertMaterialsToInt();
                myFabric.TryWoodenHorse(myStorage);
                myFabric.TryTelephone(myStorage);
                myFabric.TryBicycle(myStorage);
                myStorage.ConvertUnusedIntsBackToMaterials();

                myStorage.ShowLager();



            }
        }

    }
}
