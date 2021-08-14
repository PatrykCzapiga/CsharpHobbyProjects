using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class CoffeeVendingMachine
    {
        String command = "";
        int amountOfCups;
        int possibleCups;
        readonly int[] neededWater = { 250, 350, 200 };
        readonly int[] neededMilk = { 0, 75, 100 };
        readonly int[] neededCoffeBeans = { 16, 20, 12 };
        readonly int[] price = { 4, 7, 6 };
        int water = 400;
        int milk = 540;
        int coffeBeans = 120;
        int cups = 9;
        int money = 550;
        int drink;
        String option;
        bool runStatus;

        public void take()
        {
            Console.WriteLine("I gave you $" + money);
            money = 0;
            Console.WriteLine();
        }
        public void remaining()
        {
            Console.WriteLine();
            Console.WriteLine("The coffee machine has:");
            Console.WriteLine(water + " ml of water");
            Console.WriteLine(milk + " ml of milk");
            Console.WriteLine(coffeBeans + " g of coffee beans");
            Console.WriteLine(cups + " disposable cups");
            Console.WriteLine("$" + money + " of money");
            Console.WriteLine();
        }
        public void fill()
        {
            Console.WriteLine("Write how many ml of water you want to add:");
            water += Int32.Parse(Console.ReadLine());
            Console.WriteLine("Write how many ml of milk you want to add:");
            milk += Int32.Parse(Console.ReadLine());
            Console.WriteLine("Write how many grams of coffee beans you want to add:");
            coffeBeans += Int32.Parse(Console.ReadLine());
            Console.WriteLine("Write how many disposable cups of coffee you want to add:");
            cups += Int32.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        public void buy()
        {
            Console.WriteLine("What do you want to buy? 1 - espresso, 2 - latte, 3 - cappuccino, back - to main menu");
            option = Console.ReadLine();
            if (option.Equals("1") || option.Equals("2") || option.Equals("3"))
            {
                drink = Int32.Parse(option) - 1;
                if (water >= neededWater[drink] && milk >= neededMilk[drink] && coffeBeans >= neededCoffeBeans[drink] && cups >= 1)
                {
                    water -= neededWater[drink];
                    milk -= neededMilk[drink];
                    coffeBeans -= neededCoffeBeans[drink];
                    cups--;
                    money += price[drink];
                    Console.WriteLine("I have enough resources, making you a coffee!");
                }
                else if (water <= neededWater[drink])
                {
                    Console.WriteLine("Sorry, not enough water!");
                }
                else if (milk <= neededMilk[drink])
                {
                    Console.WriteLine("Sorry, not enough milk!");
                }
                else if (coffeBeans <= neededCoffeBeans[drink])
                {
                    Console.WriteLine("Sorry, not enough coffee beans!");
                }
                else if (cups <= 1)
                {
                    Console.WriteLine("Sorry, not enough disposable cups!");
                }
            }
            Console.WriteLine();
        }
        public void run()
        {
            runStatus = true;
            while (runStatus)
            {
                Console.WriteLine("Write action (buy, fill, take, remaining, exit):");
                command = Console.ReadLine();
                Console.WriteLine();

                switch (command)
                {
                    case "buy":
                        {
                            this.buy();
                            break;
                        }
                    case "fill":
                        {
                            this.fill();
                            break;
                        }
                    case "remaining":
                        {
                            this.remaining();
                            break;
                        }
                    case "take":
                        {
                            this.take();
                            break;
                        }
                    case "exit":
                        {
                            runStatus = false;
                            break;
                        }
                }

            }
        }

    }
}
