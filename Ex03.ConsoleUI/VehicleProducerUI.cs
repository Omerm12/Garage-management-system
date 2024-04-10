using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class VehicleProducerUI
    {
        internal static void CreateNewVehicle(Garage i_Garage)
        {
            bool tryCreating = true, trySetting = true;
            Factory.eVehicleTypes vehicleType;
            Vehicle vehicle = null;
            string[] vehicleProperties;

            Console.Write("Please enter the license number: ");
            string licenseNumber = Console.ReadLine();

            while (VehicleProducer.IsVehicleExist(licenseNumber))
            {
                Console.WriteLine("There is already a vehicle with this license number.");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1 - Enter another license number");
                Console.WriteLine("2 - Back to the previous menu");

                if (!int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    continue;
                }

                switch (userChoice)
                {
                    case 1:
                        Console.Write("Please enter another license number: ");
                        licenseNumber = Console.ReadLine();
                        break;
                    case 2:
                        return; //back to the previous menu
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        break;
                }
            }
            Console.WriteLine("Please choose your required vehicle by its number:");
            
            foreach (Factory.eVehicleTypes type in Enum.GetValues(typeof(Factory.eVehicleTypes)))
            {
                Console.WriteLine(string.Format("{0}: {1}", (int)type, type.ToString()));
            }

            while (tryCreating)
            {
                while (!Enum.TryParse<Factory.eVehicleTypes>(Console.ReadLine(), out vehicleType))
                {
                    Console.Write("Please enter a valid number to choose the vehicle's type: ");
                }

                try
                {
                    vehicle = Factory.CreateVehicle(vehicleType);
                    tryCreating = false;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Please enter a valid number to choose the vehicle's type: ");
                }
            }
           
            Console.WriteLine(string.Format(
@"Please provide your requested properties for the new vehicle separated by ','.
you should give {0}", VehicleProducer.GetPropertiesOfVehicle(vehicle)));
            while (trySetting)
            {
                vehicleProperties = $"{licenseNumber},{Console.ReadLine()}".Split(',');
                try
                {
                    VehicleProducer.SetPropertiesOfVehicle(vehicle, vehicleProperties);
                    trySetting = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Try again: ");
                }
            }

            Console.WriteLine();
            initAirPressuresInVehicle(vehicle);
            Console.WriteLine();
            initEnergyInVehicle(vehicle);
            DetailsOfTheVehicleOwner(i_Garage, licenseNumber);
            Console.WriteLine($"Vehicle was added successfully to the garage.{Environment.NewLine}");
            Console.WriteLine(string.Format("{0}{1}", VehicleProducer.VehicleInfo(vehicle), Environment.NewLine));
        }

        private static void DetailsOfTheVehicleOwner(Garage i_Garage, string licenseNumber)
        {
            string[] inputs;

            Console.Write("Please enter the owner name and owner phone (separated by ','): ");
            try
            {
                GarageUI.checkNumOfParameters(out inputs, 2);
                VehicleProducer.AddToGarage(i_Garage, licenseNumber, inputs[0], inputs[1]);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(string.Format("{0}{1}", ex.Message, Environment.NewLine));
            }
        }


        private static void initAirPressuresInVehicle(Vehicle i_Vehicle)
        {
            int airPressure;

            Console.Write("Inflate the vehicle's tires. Provide a single air pressure value for all tires: ");

            while (!int.TryParse(Console.ReadLine(), out airPressure) || airPressure < 0)
            {
                Console.Write("Please enter a valid non-negative number for the air pressure: ");
            }

            LinkedList<int> airPressures = new LinkedList<int>();

            for (int i = 0; i < i_Vehicle.GetNumOfTires(); i++)
            {
                airPressures.AddLast(airPressure);
            }

            try
            {
                VehicleProducer.InitTiresAirPressure(i_Vehicle, airPressures);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                initAirPressuresInVehicle(i_Vehicle);
            }
        }
        private static void initEnergyInVehicle(Vehicle i_Vehicle)
        {
            float energyToAdd;

            Console.Write("Put energy in the vehicle. Provide float number: ");
            while (!float.TryParse(Console.ReadLine(), out energyToAdd))
            {
                Console.Write("Please provide a float number: ");
            }

            try
            {
                VehicleProducer.InitEnergy(i_Vehicle, energyToAdd);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                initEnergyInVehicle(i_Vehicle);
            }
        }
        
    }
}
