using Forward_test_task.Class.Class_engine;
using System;

namespace Forward_test_task.Class
{
    class Menu_Show
    {

        public void Menu_Select()
        {
            Show_Menu();
            Console.Write("Enter the required menu item: ");
            string option;
            do
            {
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Write("Please enter ambient temperature: ");
                        double ambbient_temperature = double.Parse(Console.ReadLine());
                        Stand stand = new Stand(ambbient_temperature);
                        stand.Show_Test_Number_One(stand.Test_Number_One());
                        break;

                    case "2":
                            Stand stand1 = new Stand();  
                            stand1.Test_Number_Two();
                        break;

                    case "3":
                        break;
                    default:
                        if (option != "1" || option != "2" || option != "3" || option != "") 
                            Console.WriteLine("Invalid value entered");
                        break;
                }
            }
            while (option != "3");
        }

        public void Show_Menu()
        {
            Console.WriteLine("1. Time test from start to overheat");
            Console.WriteLine("2. Crankshaft rotation test");
            Console.WriteLine("3. Exit program");
        }
    }
}
