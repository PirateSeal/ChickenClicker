using System;

namespace ChickenFarmer.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            Farm farm = new Farm();
            farm.info();
            Henhouse house = farm.Houses.AddHouse();
            farm.Market.BuyChicken(farm, house, 3,1);


            Console.WriteLine(@"start Game ");


            Console.ReadLine();

            bool game = true ;

            while (game)
            {                        
                Console.Clear();
                farm.info();
                Console.WriteLine("enter a command  :");
                string input = Console.ReadLine();
                switch (input)
                {   
                    
                    case "buychicken":
                        {
                            
                            Console.WriteLine("breed (1,2,3,4) ?");
                            var breed = int.Parse(Console.ReadLine());

                            Console.WriteLine("how many ?");
                            var count = int.Parse(Console.ReadLine());

                            if (farm.Market.BuyChicken(farm, house, count,breed)) Console.WriteLine("chiken buyed");
                            else Console.WriteLine("failed ");
                            Console.ReadLine();
                            break;
                        }

                    case "buyhenhouse":
                        {
                            farm.Market.BuyHenhouse(farm);
                            break;
                        }
                    case "sellegg":
                        {
                            farm.Market.Sellegg(farm);
                            break;
                        }
                    case "info":
                        {
                            farm.info();
                            break;
                        }
                    case "stop":
                        {
                            game = false;
                            break;
                        }
            



                    default:
                        Console.WriteLine("updated");
                        farm.update();
                        farm.info();
                        break;
                }
                
            }
        }
    }
}
