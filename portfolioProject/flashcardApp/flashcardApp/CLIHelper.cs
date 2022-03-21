using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flashcardApp.Models;

namespace flashcardApp
{
    public class CLIHelper
    {
        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("FlashCard Menu");
            Console.WriteLine("--------------");
            Console.WriteLine("1: Modules");
            Console.WriteLine("2: Units");
            Console.WriteLine("3: Pick a random card");
            Console.WriteLine("0: Exit");
            Console.WriteLine("--------------");
        }

        public int PromptForInteger(string message, int minimum, int maximum)
        {
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{message}: ");
                Console.ResetColor();
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selection) && selection >= minimum && selection <= maximum)
                {
                    return selection;
                }
                else
                {
                    Console.WriteLine("Invalid selection, please try again");
                }
            }
        }

        public void PrintModules(IList<Module> modules)
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Modules");
            Console.WriteLine("--------------");
            foreach (Module module in modules)
            {
                Console.WriteLine($"{module.ModuleId}: {module.ModuleName}");
            }
        }

        public void PrintAllUnits(IList<Unit> units)
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Units");
            Console.WriteLine("--------------");
            foreach (Unit unit in units)
            {
                Console.WriteLine($"Module {unit.ModuleId} | Unit {unit.UnitId}: {unit.UnitName}");
            }
        }

        public void PrintModuleUnits(IList<Unit> units)
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Units");
            Console.WriteLine("--------------");
            foreach (Unit unit in units)
            {
                Console.WriteLine($"Unit {unit.UnitId}: {unit.UnitName}");
            }
        }

        public void PrintCardsByUnit(IList<Card> cards)
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Cards");
            Console.WriteLine("--------------");
            foreach (Card card in cards)
            {
                Console.WriteLine($"{card.CardId}: {card.Term}");
            }
        }

        public void PrintCard(Card selectedCard)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Term: ");
            Console.ResetColor();
            Console.WriteLine(selectedCard.Term);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Definition: ");
            Console.ResetColor();
            Console.WriteLine(selectedCard.Definition);
            Console.WriteLine();

            if(selectedCard.CodeExample.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Code Example: ");
                Console.ResetColor();
                Console.WriteLine(selectedCard.CodeExample);
                Console.WriteLine();
            }

            if (selectedCard.InterviewQs.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Related interview question: ");
                Console.ResetColor();
                Console.WriteLine(selectedCard.InterviewQs);
                Console.WriteLine();
            }
        }

        public void Pause()
        {
            Console.Write("Press any key to continue:");
            Console.ReadKey();
        }

    }
}
