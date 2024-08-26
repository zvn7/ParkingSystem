using System;
using System.Collections.Generic;

class ParkingLot
{
    private readonly int totalSlots;
    private readonly Dictionary<int, Vehicle> slots;

    public ParkingLot(int totalSlots)
    {
        this.totalSlots = totalSlots;
        slots = new Dictionary<int, Vehicle>(totalSlots);
    }

    public void CreateParkingLot()
    {
        Console.WriteLine($"Created a parking lot with {totalSlots} slots");
    }

    public void Park(Vehicle vehicle)
    {
        for (int i = 1; i <= totalSlots; i++)
        {
            if (!slots.ContainsKey(i))
            {
                slots[i] = vehicle;
                Console.WriteLine($"Allocated slot number: {i}");
                return;
            }
        }
        Console.WriteLine("Sorry, parking lot is full");
    }

    public void Leave(int slotNumber)
    {
        if (slots.ContainsKey(slotNumber))
        {
            slots.Remove(slotNumber);
            Console.WriteLine($"Slot number {slotNumber} is free");
        }
        else
        {
            Console.WriteLine("Slot is already free");
        }
    }

    public void Status()
    {
        Console.WriteLine("Slot\tNo.\t\tType\tRegistration No\tColour");
        foreach (var slot in slots)
        {
            Console.WriteLine($"{slot.Key}\t{slot.Value.RegistrationNumber}\t{slot.Value.Type}\t{slot.Value.Colour}");
        }
    }

    public void TypeOfVehicles(string type)
    {
        int count = 0;
        foreach (var vehicle in slots.Values)
        {
            if (vehicle.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }

    public void RegistrationNumbersForVehiclesWithOddPlate()
    {
        List<string> registrationNumbers = new List<string>();
        foreach (var vehicle in slots.Values)
        {
            if (IsOddPlate(vehicle.RegistrationNumber))
            {
                registrationNumbers.Add(vehicle.RegistrationNumber);
            }
        }
        Console.WriteLine(string.Join(", ", registrationNumbers));
    }

    public void RegistrationNumbersForVehiclesWithEvenPlate()
    {
        List<string> registrationNumbers = new List<string>();
        foreach (var vehicle in slots.Values)
        {
            if (!IsOddPlate(vehicle.RegistrationNumber))
            {
                registrationNumbers.Add(vehicle.RegistrationNumber);
            }
        }
        Console.WriteLine(string.Join(", ", registrationNumbers));
    }

    public void RegistrationNumbersForVehiclesWithColour(string colour)
    {
        List<string> registrationNumbers = new List<string>();
        foreach (var vehicle in slots.Values)
        {
            if (vehicle.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase))
            {
                registrationNumbers.Add(vehicle.RegistrationNumber);
            }
        }
        Console.WriteLine(string.Join(", ", registrationNumbers));
    }

    public void SlotNumbersForVehiclesWithColour(string colour)
    {
        List<int> slotNumbers = new List<int>();
        foreach (var slot in slots)
        {
            if (slot.Value.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase))
            {
                slotNumbers.Add(slot.Key);
            }
        }
        Console.WriteLine(string.Join(", ", slotNumbers));
    }

    public void SlotNumberForRegistrationNumber(string registrationNumber)
    {
        foreach (var slot in slots)
        {
            if (slot.Value.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(slot.Key);
                return;
            }
        }
        Console.WriteLine("Not found");
    }

    private bool IsOddPlate(string registrationNumber)
    {
        string[] parts = registrationNumber.Split('-');
        int number;
        if (int.TryParse(parts[1], out number))
        {
            return number % 2 != 0;
        }
        return false;
    }
}
