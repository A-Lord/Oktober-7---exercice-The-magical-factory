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
        
        //Lists all the blueprints avalible through the enum "BluePrints!"
        public void ShowBlueprints()
        {
            Console.WriteLine("\nIt's posible to create: \n");
            for (int i = 0; i < blueprints.Count; i++)
            {
                Console.WriteLine($" - {blueprints[i]}");
            }
           
        }

        //Tries to create Wooden Horse and send it back to storage
        //removed to change them to something else then functions.

 
    }
}

