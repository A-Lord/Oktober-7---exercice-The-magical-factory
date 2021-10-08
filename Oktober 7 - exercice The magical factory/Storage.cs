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


        public Storage()
        {

            List<Material> listOfMaterials = new List<Material>();
            List<Blueprints> ListOfCreatedItems = new List<Blueprints>();
            AddList();

        }
        public void AddList()
        {
            listOfMaterials.Add(Material.Wood);
            listOfMaterials.Add(Material.Wood);
            listOfMaterials.Add(Material.Wood);
            listOfMaterials.Add(Material.Wood);
            listOfMaterials.Add(Material.Wood);
            listOfMaterials.Add(Material.Steel);
            listOfMaterials.Add(Material.Steel);
            listOfMaterials.Add(Material.Steel);
            listOfMaterials.Add(Material.Steel);
            listOfMaterials.Add(Material.Steel);
            listOfMaterials.Add(Material.RedPaint);
            listOfMaterials.Add(Material.RedPaint);
            listOfMaterials.Add(Material.RedPaint);
            listOfMaterials.Add(Material.RedPaint);
            listOfMaterials.Add(Material.Screw);
            listOfMaterials.Add(Material.Screw);
            listOfMaterials.Add(Material.Screw);
            listOfMaterials.Add(Material.Screw);
            listOfMaterials.Add(Material.Plastic);
            listOfMaterials.Add(Material.Plastic);
            listOfMaterials.Add(Material.Plastic);
            listOfMaterials.Add(Material.Plastic);
            listOfMaterials.Add(Material.Plastic);
            listOfMaterials.Add(Material.Plastic);

        }



        public void ShowLager()
        {
            Console.Clear();
            Console.WriteLine("The storage contains the folowing materials:  ");
            for (int i = 0; i < listOfMaterials.Count; i++)
            {
                Console.WriteLine($" - {listOfMaterials[i]}");
            }
            Console.WriteLine("You own the folowing products:  ");
            for (int i = 0; i < ListOfCreatedItems.Count; i++)
            {
                Console.WriteLine($" - {ListOfCreatedItems[i]}");
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

        public void ConvertUnusedIntsBackToMaterials()
        {
            //while(NumOfPlastic > 0 || NumOfRedPaint > 0 || NumOfScrew >0 || NumOfSteel >0 ||NumOfWood >0)
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



        public void MaterialsFromStorageToFactory()
        {
            Console.WriteLine("");
            bool isDone = false;
            string pickMaterial;
            MaterialsToSendToFabric = new List<Material>();
            while (isDone == false)
            {
                ShowLager();
                Console.Write("\nMaterials you want do send in is:");
                for (int q = 0; q < MaterialsToSendToFabric.Count; q++)
                {
                    Console.Write($"{MaterialsToSendToFabric[q]}, ");
                }
                Console.WriteLine("\nWhat material to you want to send in to the fabric? , \"Done\" when done");
                BlueprintHorse();
                BlueprintBicycle();
                BlueprintTelephone();


                pickMaterial = (Console.ReadLine());

                switch (pickMaterial)
                {
                    case "Wood":
                        if (listOfMaterials.Contains(Material.Wood))
                        {
                            MaterialsToSendToFabric.Add(Material.Wood);
                            RemoveWoodFromStorage();
                        }
                        break;
                    case "Steel":
                        if (listOfMaterials.Contains(Material.Steel))
                        {
                            MaterialsToSendToFabric.Add(Material.Steel);
                            RemoveSteelFromStorage();
                        }
                        break;
                    case "Screw":
                        if (listOfMaterials.Contains(Material.Screw))
                        {
                            MaterialsToSendToFabric.Add(Material.Screw);
                            RemoveScrewFromStorage();
                        }
                        break;
                    case "RedPaint":
                        if (listOfMaterials.Contains(Material.RedPaint))
                        {
                            MaterialsToSendToFabric.Add(Material.RedPaint);
                            RemoveRedPaintFromStorage();
                        }
                        break;
                    case "Plastic":
                        if (listOfMaterials.Contains(Material.Plastic))
                        {
                            MaterialsToSendToFabric.Add(Material.Plastic);
                            RemovePlasticFromStorage();
                        }
                        break;
                    case "Done":
                        ConvertMaterialsToInt();
                        isDone = true;
                        break;
                    default:
                        Console.WriteLine("You didn't enter a valid material!");
                        break;
                }

                static void BlueprintHorse()
                {
                    Console.WriteLine("A wooden horse needs: 1 Red Paint, 2 Wood, 1 Screw - This will be prio 1");
                }
                static void BlueprintTelephone()
                {
                    Console.WriteLine("A Telephone needs: 1 Steel, 1 Wood, 3 Screw - This will be prio 2");
                }
                static void BlueprintBicycle()
                {
                    Console.WriteLine("A Bicycle needs: 3 Plastic, 1 Wood, 1 Screw - This will be prio 3");
                }
            }

        }

    }
}

