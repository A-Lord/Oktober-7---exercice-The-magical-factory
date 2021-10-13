using System;
using System.Collections.Generic;
namespace Oktober_7___exercice_The_magical_factory
{
    public class Fabric
    {
       
        public List<Blueprints> blueprints;
        public List<Material> MaterialsToSendToFabric;

        public Fabric()
        {
            //Adds enum blueprints to list of blueprints
            blueprints = new List<Blueprints>();
            foreach (var item in blueprints)
            {
                blueprints.Add(item);
            }

        }
        
        //Lists all the blueprints avalible through the enum "BluePrints"
        public void ShowBlueprints()
        {
            Console.WriteLine("\nIt's posible to create: \n");
            for (int i = 0; i < blueprints.Count; i++)
            {
                Console.WriteLine($" - {blueprints[i]}");
            }
           
        }

        //Tries to create Wooden Horse and send it back to storage
        public Storage TryWoodenHorse(Storage myStorage)
        {

            if (myStorage.NumOfRedPaint > 0 && myStorage.NumOfWood > 1 && myStorage.NumOfScrew > 0)
            {
                myStorage.ListOfCreatedItems.Add(Blueprints.WoodenHorse);
                
            }
            return myStorage;
        }
        //Tries to create a telephone and send it back to storage
        public Storage TryTelephone(Storage myStorage)
        {

            if (myStorage.NumOfSteel > 1 && myStorage.NumOfWood > 0 && myStorage.NumOfScrew > 1)
            {
                myStorage.ListOfCreatedItems.Add(Blueprints.Telephone);
            }
            return myStorage;
        }
        //Tries to create bicycle and send it back to storage
        public Storage TryBicycle(Storage myStorage)
        {

            if (myStorage.NumOfPlastic > 2 && myStorage.NumOfScrew > 1)
            {
                myStorage.ListOfCreatedItems.Add(Blueprints.Bicycle);
            }
            return myStorage;
        }

 
    }
}

