using System;
using System.Collections.Generic;

class ParkingLot
{
    private readonly int totalSlots; // Jumlah total slot parkir
    private readonly Dictionary<int, Vehicle> slots; // Dictionary untuk menyimpan kendaraan berdasarkan nomor slot

    public ParkingLot(int totalSlots)
    {
        this.totalSlots = totalSlots; // Inisialisasi jumlah total slot parkir
        slots = new Dictionary<int, Vehicle>(totalSlots); // Inisialisasi dictionary dengan kapasitas totalSlots
    }

    public void CreateParkingLot()
    {
        Console.WriteLine($"Created a parking lot with {totalSlots} slots"); // Cetak pesan ketika tempat parkir dibuat
    }

    public void Park(Vehicle vehicle)
    {
        // Mencari slot parkir yang kosong dan memarkir kendaraan di sana
        for (int i = 1; i <= totalSlots; i++)
        {
            if (!slots.ContainsKey(i)) // Jika slot i kosong
            {
                slots[i] = vehicle; // Parkir kendaraan di slot i
                Console.WriteLine($"Allocated slot number: {i}"); // Cetak pesan alokasi slot
                return;
            }
        }
        Console.WriteLine("Sorry, parking lot is full"); // Cetak pesan jika parkiran penuh
    }

    public void Leave(int slotNumber)
    {
        // Mengosongkan slot parkir
        if (slots.ContainsKey(slotNumber))
        {
            slots.Remove(slotNumber); // Hapus kendaraan dari slot
            Console.WriteLine($"Slot number {slotNumber} is free"); // Cetak pesan slot kosong
        }
        else
        {
            Console.WriteLine("Slot is already free"); // Cetak pesan jika slot sudah kosong
        }
    }

    public void Status()
    {
        // Cetak status parkiran (daftar kendaraan yang terparkir)
        Console.WriteLine("Slot\tNo.\t\tType\tRegistration No\tColour");
        foreach (var slot in slots)
        {
            Console.WriteLine($"{slot.Key}\t{slot.Value.RegistrationNumber}\t{slot.Value.Type}\t{slot.Value.Colour}");
        }
    }

    public void TypeOfVehicles(string type)
    {
        // Hitung jumlah kendaraan berdasarkan tipe
        int count = 0;
        foreach (var vehicle in slots.Values)
        {
            if (vehicle.Type.Equals(type, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }
        Console.WriteLine(count); // Cetak jumlah kendaraan dari tipe yang ditentukan
    }

    public void RegistrationNumbersForVehiclesWithOddPlate()
    {
        // Dapatkan daftar nomor registrasi kendaraan dengan plat ganjil
        List<string> registrationNumbers = new List<string>();
        foreach (var vehicle in slots.Values)
        {
            if (IsOddPlate(vehicle.RegistrationNumber))
            {
                registrationNumbers.Add(vehicle.RegistrationNumber);
            }
        }
        Console.WriteLine(string.Join(", ", registrationNumbers)); // Cetak daftar nomor registrasi
    }

    public void RegistrationNumbersForVehiclesWithEvenPlate()
    {
        // Dapatkan daftar nomor registrasi kendaraan dengan plat genap
        List<string> registrationNumbers = new List<string>();
        foreach (var vehicle in slots.Values)
        {
            if (!IsOddPlate(vehicle.RegistrationNumber))
            {
                registrationNumbers.Add(vehicle.RegistrationNumber);
            }
        }
        Console.WriteLine(string.Join(", ", registrationNumbers)); // Cetak daftar nomor registrasi
    }

    public void RegistrationNumbersForVehiclesWithColour(string colour)
    {
        // Dapatkan daftar nomor registrasi kendaraan berdasarkan warna
        List<string> registrationNumbers = new List<string>();
        foreach (var vehicle in slots.Values)
        {
            if (vehicle.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase))
            {
                registrationNumbers.Add(vehicle.RegistrationNumber);
            }
        }
        Console.WriteLine(string.Join(", ", registrationNumbers)); // Cetak daftar nomor registrasi
    }

    public void SlotNumbersForVehiclesWithColour(string colour)
    {
        // Dapatkan daftar nomor slot berdasarkan warna kendaraan
        List<int> slotNumbers = new List<int>();
        foreach (var slot in slots)
        {
            if (slot.Value.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase))
            {
                slotNumbers.Add(slot.Key);
            }
        }
        Console.WriteLine(string.Join(", ", slotNumbers)); // Cetak daftar nomor slot
    }

    public void SlotNumberForRegistrationNumber(string registrationNumber)
    {
        // Cari nomor slot berdasarkan nomor registrasi
        foreach (var slot in slots)
        {
            if (slot.Value.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(slot.Key); // Cetak nomor slot jika ditemukan
                return;
            }
        }
        Console.WriteLine("Not found"); // Cetak pesan jika tidak ditemukan
    }

    private bool IsOddPlate(string registrationNumber)
    {
        // Fungsi untuk menentukan apakah plat nomor ganjil
        string[] parts = registrationNumber.Split('-');
        int number;
        if (int.TryParse(parts[1], out number))
        {
            return number % 2 != 0; // Return true jika nomor ganjil
        }
        return false; // Return false jika tidak bisa diubah menjadi angka
    }
}
