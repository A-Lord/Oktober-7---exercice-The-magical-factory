using System;
using System.Collections.Generic;
using System.Threading;
namespace Oktober_7___exercice_The_magical_factory
{
    public class Fabric
    {
        private int _woodInFactory;
        private int _ironInFactory;
        private int _rubberInFactory;
        private int _redPaintInFactory;
        private int _screwsInFactory;
        public List<Material> MaterialsToSendToFabric;

        public Fabric()
        {
            //Adds enum blueprints to list of blueprints


        }
        public void MaterialFromUser(int[] inputMaterials)
        {
            _woodInFactory = inputMaterials[0];
            _ironInFactory = inputMaterials[0];
            _rubberInFactory = inputMaterials[0];
            _redPaintInFactory = inputMaterials[0];
            _screwsInFactory = inputMaterials[0];
        }

        //Lists all the blueprints avalible through the enum "BluePrints!"
        //public void ShowBlueprints()
        //{
        //    Console.WriteLine("\nIt's posible to create: \n");
        //    for (int i = 0; i < blueprints.Count; i++)
        //    {
        //        Console.WriteLine($" - {blueprints[i]}");
        //    }

        //}

        //Tries to create Wooden Horse and send it back to storage
        //removed to change them to something else then functions.
        private void CheckMaterialAgainstRecepies()
        {
            int topTotalMaterial = 0;
            int indexOfTopRecipe = 0;
            foreach (var item in Recipes._listOfAllRecipes)
            {
                if (item.WoodNeeded <= _woodInFactory && item.SteelNeeded <= _ironInFactory && item.PlasticNeeded <= _rubberInFactory && item.RedPaintNeeded <= _redPaintInFactory && item.ScrewNeeded <= _screwsInFactory)
                {
                    if (item.SumAllMaterialNeeded > topTotalMaterial)
                    {
                        topTotalMaterial = item.SumAllMaterialNeeded;
                        indexOfTopRecipe = Recipes._listOfAllRecipes.IndexOf(item);
                    }
                }
            }


            if (Recipes._listOfAllRecipes[indexOfTopRecipe].WoodNeeded <= _woodInFactory &&
                Recipes._listOfAllRecipes[indexOfTopRecipe].SteelNeeded <= _ironInFactory &&
                Recipes._listOfAllRecipes[indexOfTopRecipe].PlasticNeeded <= _rubberInFactory &&
                Recipes._listOfAllRecipes[indexOfTopRecipe].RedPaintNeeded <= _redPaintInFactory &&
                Recipes._listOfAllRecipes[indexOfTopRecipe].ScrewNeeded <= _screwsInFactory)
            {
                Console.WriteLine("item to create: {0}", Recipes._listOfAllRecipes[indexOfTopRecipe].Name);
                CreateItemFromRecipe(Recipes._listOfAllRecipes[indexOfTopRecipe]);
            }
            else
            {
                Console.WriteLine("Found noting to create ");
            }
        }
        private void CreateItemFromRecipe(Recipes recipe)
        {
            Random timeRando = new();
            Console.Write("Gathering rescourses ");
            string dotdotdot = ".";
            for (int i = 0; i < 10; i++)
            {
                Console.Write(dotdotdot);
                if (i % 4 == 0) { Console.Write("\b\b\b   \b\b\b"); }
                Thread.Sleep(timeRando.Next(50, 400));
            }
            Console.WriteLine();

            Console.WriteLine("Construction of {0} is starting ...", recipe.Name);
            Thread.Sleep(timeRando.Next(50, 400));
            //Inventory.PlayerItems.Add(recipe);
            //Console.WriteLine("itemlist count: {0}", Inventory.PlayerItems.Count);
            Console.WriteLine("Success!");
            Console.WriteLine("The {0} was added to your inventory.", recipe.Name);
            Thread.Sleep(700);
            Console.WriteLine("Checking if there anything else to make ..");

            _woodInFactory -= recipe.WoodNeeded; // ta bort material från inv i fabrik
            _ironInFactory -= recipe.SteelNeeded;
            _rubberInFactory -= recipe.PlasticNeeded;
            _redPaintInFactory -= recipe.RedPaintNeeded;
            _screwsInFactory -= recipe.ScrewNeeded;
            CheckMaterialAgainstRecepies(); // kör 

            //Inventory.UpdateAndCleanUpInventory(_woodInFactory, _ironInFactory, _rubberInFactory);
            Console.WriteLine("Your remaining material has been returned.");
            _woodInFactory = 0;
            _ironInFactory = 0;
            _rubberInFactory = 0;

            //Console.WriteLine("trä: {0} järn: {1} gummi: {2}", _woodInFactory, _ironInFactory, _rubberInFactory);

        }


    }
}

