using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flashcardApp.DAO;
using flashcardApp.Models;

namespace flashcardApp
{
    public class flashcardsCLI
    {
        private readonly ICardDAO cardDao;
        private readonly IModuleDAO moduleDao;
        private readonly IUnitDAO unitDao;
        private readonly CLIHelper console = new CLIHelper();

        public flashcardsCLI(ICardDAO cardDAO, IModuleDAO moduleDAO, IUnitDAO unitDAO)
        {
            this.cardDao = cardDAO;
            this.moduleDao = moduleDAO;
            this.unitDao = unitDAO;
        }

        public void RunCLI()
        {
            while (true)
            {
                console.PrintMainMenu();
                int menuSelection = console.PromptForInteger("Enter a selection", 0, 5);
                Console.Clear();

                if (menuSelection == 0)
                {
                    break;
                }
                
                if (menuSelection == 1)
                {
                    ShowModules();

                    int moduleToOpen = console.PromptForInteger("Pick a Module", 1, 3);
                    Console.Clear();

                    ShowUnitsInModule(moduleToOpen);

                    int unitToOpen = console.PromptForInteger("Pick a unit", 1, 62);
                    Console.Clear();

                    ShowCardsInUnit(unitToOpen);

                    int cardToOpen = console.PromptForInteger("Pick a card", 1, 62);
                    Console.Clear();

                    PickCard(cardToOpen);
                }

                if (menuSelection == 2)
                {
                    ShowUnits();
                    int unitToOpen = console.PromptForInteger("Pick a unit", 1, 62);
                    Console.Clear();

                    ShowCardsInUnit(unitToOpen);

                    int cardToOpen = console.PromptForInteger("Pick a card", 1, 62);
                    Console.Clear();

                    PickCard(cardToOpen);
                }

                if (menuSelection == 3)
                {
                    Random rnd = new Random();
                    PickCard(rnd.Next(1, 28));
                }

            }
        }

        private void ShowModules()
        {
            try
            {
                IList<Module> modules = moduleDao.GetModules();
                if (modules != null)
                {
                    console.PrintModules(modules);
                    Console.WriteLine();
                }
            }
            catch 
            {
                Console.WriteLine($"There is an error");
            }
        }

        private void ShowUnits()
        {
            try
            {
                IList<Unit> units = unitDao.GetUnits();
                if(units != null)
                {
                    console.PrintAllUnits(units);
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine($"There is an error");
            }
        }

        private void ShowUnitsInModule(int moduleId)
        {
            try
            {
                IList<Unit> units = unitDao.GetUnitsPerModule(moduleId);
                if (units != null)
                {
                    console.PrintModuleUnits(units);
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine($"There is an error");
            }
        }

        private void ShowCardsInUnit(int unitId)
        {
            try
            {
                IList<Card> cards = cardDao.GetCardsByUnit(unitId);
                if (cards != null)
                {
                    console.PrintCardsByUnit(cards);
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine($"There is an error");
            }
        }

        private void PickCard (int cardId)
        {
            try
            {
                Card selectedCard = cardDao.GetCard(cardId);
                if (selectedCard != null)
                {
                    console.PrintCard(selectedCard);
                }
            }
            catch
            {
                Console.WriteLine($"There is an error");
            }
            console.Pause();
        }

    }
}
