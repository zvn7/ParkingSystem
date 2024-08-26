using System;

class Program
{
    static void Main(string[] args)
    {
        ParkingLot parkingLot = null;

        while (true)
        {
            string command = Console.ReadLine();
            if (command == null) continue;
            var inputs = command.Split(' ');

            switch (inputs[0])
            {
                case "create_parking_lot":
                    int slots = int.Parse(inputs[1]);
                    parkingLot = new ParkingLot(slots);
                    parkingLot.CreateParkingLot();
                    break;
                case "park":
                    string regNo = inputs[1];
                    string colour = inputs[2];
                    string type = inputs[3];
                    parkingLot.Park(new Vehicle(regNo, colour, type));
                    break;
                case "leave":
                    int slotNumber = int.Parse(inputs[1]);
                    parkingLot.Leave(slotNumber);
                    break;
                case "status":
                    parkingLot.Status();
                    break;
                case "type_of_vehicles":
                    string vehicleType = inputs[1];
                    parkingLot.TypeOfVehicles(vehicleType);
                    break;
                case "registration_numbers_for_vehicles_with_ood_plate":
                    parkingLot.RegistrationNumbersForVehiclesWithOddPlate();
                    break;
                case "registration_numbers_for_vehicles_with_event_plate":
                    parkingLot.RegistrationNumbersForVehiclesWithEvenPlate();
                    break;
                case "registration_numbers_for_vehicles_with_colour":
                    string vehiclecolour = inputs[1];
                    parkingLot.RegistrationNumbersForVehiclesWithColour(vehiclecolour);
                    break;
                case "slot_numbers_for_vehicles_with_colour":
                    string slotcolour = inputs[1];
                    parkingLot.SlotNumbersForVehiclesWithColour(slotcolour);
                    break;
                case "slot_number_for_registration_number":
                    string regNoToFind = inputs[1];
                    parkingLot.SlotNumberForRegistrationNumber(regNoToFind);
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}
