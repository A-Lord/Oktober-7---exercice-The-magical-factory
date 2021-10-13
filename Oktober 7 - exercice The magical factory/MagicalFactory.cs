using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oktober_7___exercice_The_magical_factory
{
    public class MagicalFactory
    {
        private Fabric myFabric = new();
        private Storage myStorage = new();
        public MagicalFactory()
        {

        }
        public void Run()  //starts the game
        {
            Recipes.CreateRecipes(); //creats the items that u can craft
            while (true)
            {
                Console.WriteLine("Welcome to the Macical Factory!\n");
                myStorage.ShowLager();
                myFabric.MaterialFromUser(myStorage.MaterialsFromStorageToFactory());  //Starting materialsfromStorage that will return a int list with the materials 
                                                                                       //the user wants to try and make items from,. we send it to materials from user funktion.
                                                                                       //myFabric.ShowBlueprints();

            }
        }   
    }
}
