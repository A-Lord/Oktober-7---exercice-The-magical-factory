using System.Collections.Generic;
using System;
namespace Oktober_7___exercice_The_magical_factory
{

    public class Storage
    {
        public int NumOfWood { get; private set; }
        public int NumOfScrew { get; private set; }
        public int NumOfRedPaint { get; private set; }
        public int NumOfSteel { get; private set; }
        public int NumOfPlastic { get; private set; }

        public List<Material> MaterialsToSendToFabric;

        public List<Material> listOfMaterials = new List<Material>();
        public List<Blueprints> ListOfCreatedItems = new List<Blueprints>();
        public static List<int> _listOfMaterialsAmount = new List<int>();
        public List<int> _materialsToSendNumbers = new List<int>();
        public List<Material> _materialsToFactory = new List<Material>();
        public static List<Recipes> _playerItems = new();

        //Constructor that creats necessary lists and items to storage
        public Storage()
        {

            listOfMaterials = new List<Material>();
            ListOfCreatedItems = new List<Blueprints>();
            _listOfMaterialsAmount = new List<int>();
            _materialsToSendNumbers = new List<int>();
           AddList();

        }

        //Intital materials
        public void AddList()
        {
            for (int i = 0; i < Enum.GetNames(typeof(Material)).Length; i++)
            {
                int randomNumber = new Random().Next(2, 10);
                _listOfMaterialsAmount.Add(randomNumber);
                listOfMaterials.Add((Material)i);
                _materialsToSendNumbers.Add(0);
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


        public void RemoveWoodFromStorage()
        {
            listOfMaterials.Remove(Material.Wood);
        }
        public void RemoveSteelFromStorage()
        {
            listOfMaterials.Remove(Material.Steel);
        }
        public void RemoveRedPaintFromStorage()
        {
            listOfMaterials.Remove(Material.RedPaint);
        }
        public void RemoveScrewFromStorage()
        {
            listOfMaterials.Remove(Material.Screw);
        }
        public void RemovePlasticFromStorage()
        {
            listOfMaterials.Remove(Material.Plastic);
        }

        //Converts the list of sent materials to ints for easier production
        public void ConvertMaterialsToInt()
        {
            NumOfPlastic = 0;
            NumOfRedPaint = 0;
            NumOfScrew = 0;
            NumOfSteel = 0;
            NumOfWood = 0;

            foreach (var item in MaterialsToSendToFabric)
            {
                if (item == Material.Wood)
                {
                    NumOfWood = NumOfWood + 1;
                }
                if (item == Material.Plastic)
                {
                    NumOfPlastic = NumOfPlastic + 1;
                }
                if (item == Material.Steel)
                {
                    NumOfSteel++;
                }
                if (item == Material.RedPaint)
                {
                    NumOfRedPaint++;
                }
                if (item == Material.Screw)
                {
                    NumOfScrew++;
                }
            }
        }

        //Unused materials will be converted back from ints to list-item and back to storage
        public void ConvertUnusedIntsBackToMaterials()
        {
            
            if (NumOfPlastic > 0)
            {
                listOfMaterials.Add(Material.Plastic);
                NumOfPlastic--;
            }
            if (NumOfRedPaint > 0)
            {
                listOfMaterials.Add(Material.RedPaint);
                NumOfRedPaint--;
            }
            if (NumOfScrew > 0)
            {
                listOfMaterials.Add(Material.Screw);
                NumOfScrew--;
            }
            if (NumOfSteel > 0)
            {
                listOfMaterials.Add(Material.Steel);
                NumOfSteel--;
            }
            if (NumOfWood > 0)
            {
                listOfMaterials.Add(Material.Wood);
                NumOfWood--;
            }
        }


        // Method that lets you sent materials from storage to inventory, looping until "Done"
        public List<int> MaterialsFromStorageToFactory()
        {
            Console.WriteLine("");
            bool isDone = false;
            string sentMaterialsText = "";
            // string pickMaterial;
            MaterialsToSendToFabric = new List<Material>();
            
            while (isDone == false)
            {
                ShowLager();

                Console.Write(sentMaterialsText);
                for (int q = 0; q < _materialsToSendNumbers.Count; q++)
                {
                    if (_materialsToSendNumbers[q] > 0)
                    {
                        Console.WriteLine($"  - {listOfMaterials[q],10} -Amount: {_materialsToSendNumbers[q]}");
                    }
                }



                //for (int q = 0; q < MaterialsToSendToFabric.Count; q++)
                //{
                //    Console.Write($"{MaterialsToSendToFabric[q]}, ");
                //}
                Console.WriteLine("\nWhat material to you want to send in to the fabric? \n\nUse numbers to pick materials.\n\nPress anyother key to send the materials to the fabric \n ");
                //BlueprintHorse();
                //BlueprintBicycle();
                //BlueprintTelephone();

                //int inputKey = ((int.Parse(Convert.ToString(Console.ReadKey(true).KeyChar)))-1);
                var UserInput = Console.ReadKey();
                if (char.IsDigit(UserInput.KeyChar))
                {
                    int inputKey = int.Parse(UserInput.KeyChar.ToString());
                    inputKey--;
                    if (inputKey < _listOfMaterialsAmount.Count)
                    {

                        

                    //pickMaterial = (Console.ReadLine());
                        if (_listOfMaterialsAmount[inputKey] > 0)
                    {
                        _listOfMaterialsAmount[inputKey] = _listOfMaterialsAmount[inputKey] - 1;
                        _materialsToSendNumbers[inputKey]++; //a int list that we update the number of items to send to factory. 
                                                             //MaterialsToSendToFabric.Add((Material)inputKey);
                        sentMaterialsText = "\nMaterials you want do send in is:\n";
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
                    break;
                    
                }

            }
            List<int> list2 = new List<int>(_materialsToSendNumbers.Count);
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

