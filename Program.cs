using System;

class Program
{
    static void Main(string[] args)
    {
        ParkingLot parkingLot = null; // Variabel untuk menyimpan instance ParkingLot yang akan diinisialisasi nanti.

        // Tampilkan daftar perintah saat program dimulai.
        ShowHelp();

        while (true)
        {
            // Membaca perintah dari input pengguna.
            string command = Console.ReadLine();
            if (command == null) continue; // Jika input null, lanjutkan loop.
            var inputs = command.Split(' '); // Memisahkan perintah dan argumen berdasarkan spasi.

            // Memeriksa perintah pertama (command) untuk menentukan tindakan yang harus dilakukan.
            switch (inputs[0])
            {
                case "create_parking_lot":
                    // Membuat instance ParkingLot baru dengan jumlah slot yang diberikan.
                    int slots = int.Parse(inputs[1]);
                    parkingLot = new ParkingLot(slots);
                    parkingLot.CreateParkingLot();
                    break;
                case "park":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Parking lot not created. Use 'create_parking_lot' command first.");
                        break;
                    }
                    // Memarkir kendaraan di slot yang tersedia.
                    string regNo = inputs[1]; // Mengambil nomor registrasi kendaraan.
                    string colour = inputs[2]; // Mengambil warna kendaraan.
                    string type = inputs[3]; // Mengambil tipe kendaraan.
                    parkingLot.Park(new Vehicle(regNo, colour, type));
                    break;
                case "leave":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Parking lot not created. Use 'create_parking_lot' command first.");
                        break;
                    }
                    // Membebaskan slot parkir berdasarkan nomor slot yang diberikan.
                    int slotNumber = int.Parse(inputs[1]);
                    parkingLot.Leave(slotNumber);
                    break;
                case "status":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Parking lot not created. Use 'create_parking_lot' command first.");
                        break;
                    }
                    // Menampilkan status semua slot parkir (kendaraan yang terparkir di setiap slot).
                    parkingLot.Status();
                    break;
                case "type_of_vehicles":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Parking lot not created. Use 'create_parking_lot' command first.");
                        break;
                    }
                    // Menghitung dan menampilkan jumlah kendaraan berdasarkan tipe yang diberikan.
                    string vehicleType = inputs[1];
                    parkingLot.TypeOfVehicles(vehicleType);
                    break;
                case "registration_numbers_for_vehicles_with_odd_plate":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Parking lot not created. Use 'create_parking_lot' command first.");
                        break;
                    }
                    // Menampilkan nomor registrasi kendaraan dengan pelat ganjil.
                    parkingLot.RegistrationNumbersForVehiclesWithOddPlate();
                    break;
                case "registration_numbers_for_vehicles_with_even_plate":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Parking lot not created. Use 'create_parking_lot' command first.");
                        break;
                    }
                    // Menampilkan nomor registrasi kendaraan dengan pelat genap.
                    parkingLot.RegistrationNumbersForVehiclesWithEvenPlate();
                    break;
                case "registration_numbers_for_vehicles_with_colour":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Parking lot not created. Use 'create_parking_lot' command first.");
                        break;
                    }
                    // Menampilkan nomor registrasi kendaraan berdasarkan warna yang diberikan.
                    string vehicleColour = inputs[1];
                    parkingLot.RegistrationNumbersForVehiclesWithColour(vehicleColour);
                    break;
                case "slot_numbers_for_vehicles_with_colour":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Parking lot not created. Use 'create_parking_lot' command first.");
                        break;
                    }
                    // Menampilkan nomor slot kendaraan berdasarkan warna yang diberikan.
                    string slotColour = inputs[1];
                    parkingLot.SlotNumbersForVehiclesWithColour(slotColour);
                    break;
                case "slot_number_for_registration_number":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Parking lot not created. Use 'create_parking_lot' command first.");
                        break;
                    }
                    // Menampilkan nomor slot untuk kendaraan dengan nomor registrasi tertentu.
                    string regNoToFind = inputs[1];
                    parkingLot.SlotNumberForRegistrationNumber(regNoToFind);
                    break;
                case "exit":
                    // Menghentikan program.
                    return;
                default:
                    // Menangani perintah yang tidak dikenali.
                    Console.WriteLine("Invalid command. Here are the available commands:");
                    ShowHelp(); // Tampilkan daftar perintah jika perintah tidak dikenali.
                    break;
            }
        }
    }

    static void ShowHelp()
    {
        Console.WriteLine("Available commands:");
        Console.WriteLine("--------------------------------------------");
        Console.WriteLine("  create_parking_lot <number_of_slots>");
        Console.WriteLine("    Create a parking lot with the given number of slots.");
        Console.WriteLine();
        Console.WriteLine("  park <registration_number> <colour> <type>");
        Console.WriteLine("    Park a vehicle with the given registration number, colour, and type.");
        Console.WriteLine();
        Console.WriteLine("  leave <slot_number>");
        Console.WriteLine("    Vacate the parking slot with the given slot number.");
        Console.WriteLine();
        Console.WriteLine("  status");
        Console.WriteLine("    Show the status of all parking slots.");
        Console.WriteLine();
        Console.WriteLine("  type_of_vehicles <vehicle_type>");
        Console.WriteLine("    Show the number of vehicles of a particular type.");
        Console.WriteLine();
        Console.WriteLine("  registration_numbers_for_vehicles_with_odd_plate");
        Console.WriteLine("    Show registration numbers of vehicles with odd plate numbers.");
        Console.WriteLine();
        Console.WriteLine("  registration_numbers_for_vehicles_with_even_plate");
        Console.WriteLine("    Show registration numbers of vehicles with even plate numbers.");
        Console.WriteLine();
        Console.WriteLine("  registration_numbers_for_vehicles_with_colour <colour>");
        Console.WriteLine("    Show registration numbers of vehicles with the given colour.");
        Console.WriteLine();
        Console.WriteLine("  slot_numbers_for_vehicles_with_colour <colour>");
        Console.WriteLine("    Show slot numbers for vehicles with the given colour.");
        Console.WriteLine();
        Console.WriteLine("  slot_number_for_registration_number <registration_number>");
        Console.WriteLine("    Show the slot number for a vehicle with the given registration number.");
        Console.WriteLine();
        Console.WriteLine("  exit");
        Console.WriteLine("    Exit the program.");
        Console.WriteLine("--------------------------------------------");
    }
}
