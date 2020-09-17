using Common.ComponentsCreators;
using Common.DataModel;
using Common.Repository;
using Common.SHESControl;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    class Program
    {
        static SmartHomeEnergySystem shes;
        static void Main(string[] args)
        {
            bool running = true;
            IWriteMeasurementToDb writer = new WriteMeasurementToDb();
            shes = new SmartHomeEnergySystem(writer);
            shes.StartBatteryUpdateThread();
            
            while(running)
            {
                int option = Menu();

                switch(option)
                {
                    case 0: running = false; break;
                    case 1: AddSolarPanel(); break;
                    case 2: AddBattery(); break;
                    case 3: AddConsumer(); break;
                    case 4: ChangeSunlight(); break;
                    case 5: TurnConsumerOnOff(); break;
                    case 6: ReadMeasurements(); break;
                    default: Console.Clear(); break;
                }
            }

            Console.Clear();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void ReadMeasurements()
        {
            Console.WriteLine("Enter component id: ");
            string id = Console.ReadLine();

            Console.WriteLine("Enter date: ");
            DateTime date;
            if(!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.Clear();
                Console.WriteLine("Date not formated properly. Enter date in format mm/dd/yyyy");
                return;
            }
            //DateTime date = DateTime.ParseExact(string.Format(Console.ReadLine(), "dd:mm:yyyy")); //15:09:2020
            using (ShesDbContext context = new ShesDbContext())
            {
                var list = context.Measurements.ToList();
                var measList = list.Where(x => x.Component == id && x.TimeStamp.Date == date.Date).ToList();
                Console.Clear();
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Measurements for the selected date: ");
                measList.ForEach(x => Console.WriteLine($"{x.TimeStamp} - {x.Value}"));
                Console.WriteLine("------------------------------------------------------------");
            }
        }

        static int Menu()
        {
            while (true)
            {
                Console.WriteLine("Choose option: ");
                Console.WriteLine("0. EXIT.");
                Console.WriteLine("1. Add solar panel.");
                Console.WriteLine("2. Add battery.");
                Console.WriteLine("3. Add consumer.");
                Console.WriteLine("4. Change sunlight.");
                Console.WriteLine("5. Turn off/on consumer.");
                Console.WriteLine("6. Filter database.");

                int i;
                if (!int.TryParse(Console.ReadLine(), out i))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                if (i < 0 || i > 6)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid number. Please enter a number between 0 and 6.");
                    continue;
                }

                return i;
            }
        }

        private static void AddConsumer()
        {
            Console.Clear();
            Console.WriteLine("Please enter information about consumer in format id:consumption");
            string input = Console.ReadLine();
            string[] parts = input.Split(':');
            if(parts.Length != 2)
            {
                Console.Clear();
                Console.WriteLine("Error while parsing information. Try again");
                return;
            }

            double consumption = 0;
            if(!double.TryParse(parts[1], out consumption))
            {
                Console.Clear();
                Console.WriteLine("Error while parsing information. Try again");
                return;
            }

            ConsumerCreator creator = new ConsumerCreator();
            Consumer b = creator.Create(parts[0], consumption);
            Console.WriteLine("Success!!!");
            //add to db ?
        
        }

        private static void AddBattery()
        {
            Console.Clear();
            Console.WriteLine("Please enter information about battery in format id:maxPower:capacity");
            string input = Console.ReadLine();
            string[] parts = input.Split(':');
            if (parts.Length != 3)
            {
                Console.Clear();
                Console.WriteLine("Error while parsing information. Try again");
                return;
            }

            double maxPower = 0;
            if (!double.TryParse(parts[1], out maxPower))
            {
                Console.Clear();
                Console.WriteLine("Error while parsing information. Try again");
                return;
            }

            double capacity = 0;
            if (!double.TryParse(parts[2], out capacity))
            {
                Console.Clear();
                Console.WriteLine("Error while parsing information. Try again");
                return;
            }

            BatteryCreator creator = new BatteryCreator();
            Battery b = creator.Create(parts[0], maxPower, capacity);
            Console.WriteLine("Success!!!");
            //add to db ?
        }

        private static void AddSolarPanel()
        {
            Console.Clear();
            Console.WriteLine("Please enter information about solar panel in format id:mawPower");
            string input = Console.ReadLine();
            string[] parts = input.Split(':');
            if (parts.Length != 2)
            {
                Console.Clear();
                Console.WriteLine("Error while parsing information. Try again");
                return;
            }

            double maxPower = 0;
            if (!double.TryParse(parts[1], out maxPower))
            {
                Console.Clear();
                Console.WriteLine("Error while parsing information. Try again");
                return;
            }

            SolarPanelCreator creator = new SolarPanelCreator();
            SolarPanel sp = creator.Create(parts[0], maxPower);
            Console.WriteLine("Success!!!");
            //add to db ?
        }

        private static void ChangeSunlight()
        {
            Console.Clear();
            Console.WriteLine("Enter new value of sunlight [0 - 100].");
            double newSungliht;
            if(double.TryParse(Console.ReadLine(), out newSungliht))
            {
                shes.UpdateSunlight(newSungliht);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid value. Please try again.");
            }
        }

        private static void TurnConsumerOnOff()
        {
            Console.Clear();
            Console.WriteLine("Enter consumer id: ");
            string id = Console.ReadLine();

            Console.WriteLine("Enter 1/0 for on/off.");
            double mode;
            if(double.TryParse(Console.ReadLine(), out mode))
            {
                if(mode == 1 || mode == 0)
                {
                    shes.TurnConsumerOnOff(mode, id);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid value. Please try again.");
                }
            }
        }
    }
}
