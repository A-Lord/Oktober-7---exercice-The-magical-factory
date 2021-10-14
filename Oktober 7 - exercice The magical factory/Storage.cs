using System.Collections.Generic;
using System;
namespace Oktober_7___exercice_The_magical_factory
{

    public class Storage
    {

        public List<Material> listOfMaterials = new List<Material>();
        public static List<int> _listOfMaterialsAmount = new List<int>(); //förändra static
        public List<int> _materialsToSendNumbers = new List<int>();
        public static List<Recipes> _playerItems = new();   //in this list we will save all items that is made.

        //Constructor that creats necessary lists and items to storage
        public Storage()
        {
            listOfMaterials = new List<Material>();
            _listOfMaterialsAmount = new List<int>();
            _materialsToSendNumbers = new List<int>();
           AddList();
        }

        //Intital materials
        public void AddList()
        {
            for (int i = 0; i < Enum.GetNames(typeof(Material)).Length; i++)
            {
                int randomNumber = new Random().Next(2, 10);  //we randomize the items 2-9 in each atm
                _listOfMaterialsAmount.Add(randomNumber);
                listOfMaterials.Add((Material)i);
                _materialsToSendNumbers.Add(0);  // here we reset what materials we want to send.
            }
        }


        // Lists all the materials and finished products you have
        public void ShowLager()
        {
            Console.Clear();
            Console.WriteLine("The storage contains the folowing materials:  "); 
            for (int i = 0; i < listOfMaterials.Count; i++)
            {
                Console.WriteLine($" {i+1} - {listOfMaterials[i],10} -Amount: {_listOfMaterialsAmount[i]}");
            }
            if (_playerItems.Count > 0) //added check so we dont write it if u dont actualy own any items
            {
                Console.WriteLine("You own the folowing products:  ");
                for (int i = 0; i < _playerItems.Count; i++)
                {
                    Console.WriteLine($" - {_playerItems[i].Name}");
                }
            }

            Console.WriteLine("");

        }

        //Converts the list of sent materials to ints for easier production
       

        //Unused materials will be converted back from ints to list-item and back to storage
       
        // Method that lets you sent materials from storage to inventory, looping until "Done"
        public List<int> MaterialsFromStorageToFactory()
        {
            Console.WriteLine("");
            bool isDone = false;
            string sentMaterialsText = "";
            //MaterialsToSendToFabric = new List<Material>();
            while (isDone == false)
            {
                ShowLager();
                Console.Write(sentMaterialsText);
                for (int q = 0; q < _materialsToSendNumbers.Count; q++)   //writes out all materials that are picked.
                {
                    if (_materialsToSendNumbers[q] > 0)
                    {
                        Console.WriteLine($"  - {listOfMaterials[q],10} -Amount: {_materialsToSendNumbers[q]}");
                    }
                }

                Console.WriteLine("\nWhat material to you want to send in to the fabric? \n\nUse numbers to pick materials.\n\nPress any other key to send the materials to the fabric \n ");

                var UserInput = Console.ReadKey();
                if (char.IsDigit(UserInput.KeyChar))
                { 
                    int inputKey = int.Parse(UserInput.KeyChar.ToString());
                    inputKey--;
                    if (inputKey < _listOfMaterialsAmount.Count)
                    {

                        if (_listOfMaterialsAmount[inputKey] > 0)
                        {
                        _listOfMaterialsAmount[inputKey] = _listOfMaterialsAmount[inputKey] - 1;
                        _materialsToSendNumbers[inputKey]++; //a int list that we update the number of items to send to factory. 
                                                             //MaterialsToSendToFabric.Add((Material)inputKey);

                        sentMaterialsText = "\nMaterials you want do send in is:\n"; //string that starts empty but will get value once u pick material.
                        }
                        else
                    
                        {
                        Console.WriteLine($"{(Material)inputKey} is out of stock. Press enter to continue.");
                        Console.ReadKey();
                    
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    
                    isDone = true;
                    //break;
                    
                }


            }
            List<int> list2 = new List<int>(_materialsToSendNumbers.Count); //change list2 to a better name
            foreach (int item in _materialsToSendNumbers)
                list2.Add(item);
            for (int i = 0; i < _materialsToSendNumbers.Count; i++)
            {
                _materialsToSendNumbers[i] = 0;
            }
           
            return list2;

        }

    }
}

