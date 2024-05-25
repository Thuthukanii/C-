using System;

class HotelReservationSystem
{
    static bool[] rooms = new bool[20];

    static void Main()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i] = false;
        }

        ReserveRoom();
    }

    static void ReserveRoom()
    {
        int floor;
        bool roomAssigned = false;

        while (!roomAssigned)
        {
            Console.WriteLine("Please type a number for the floor (1-10):\n1 for First floor\n2 for Second floor\n... up to\n10 for Tenth floor");
            if (!int.TryParse(Console.ReadLine(), out floor) || floor < 1 || floor > 10)
            {
                Console.WriteLine("Invalid floor number. Please enter a number between 1 and 10.");
                continue;
            }

            int assignedRoom = CheckAndAssignRoom(floor);

            while (assignedRoom == -1)
            {
                Console.WriteLine($"Both executive rooms on floor {floor} are occupied. Would you like to choose another floor? (yes/no)");
                string response = Console.ReadLine().Trim().ToLower();
                if (response != "yes")
                {
                    Console.WriteLine("We are sorry, we could not provide you a room on the floor of your choice.");
                    return;
                }

                Console.WriteLine("Please enter another floor number (1-10):");
                if (!int.TryParse(Console.ReadLine(), out floor) || floor < 1 || floor > 10)
                {
                    Console.WriteLine("Invalid floor number. Please enter a number between 1 and 10.");
                    continue;
                }

                assignedRoom = CheckAndAssignRoom(floor);
            }

            Console.WriteLine("Please enter the guest's name:");
            string guestName = Console.ReadLine();
            Console.WriteLine("Please enter the duration of the stay (in days):");
            string stayDuration = Console.ReadLine();
            Console.WriteLine("Please specify any food allergies (or type 'none'):");
            string foodAllergies = Console.ReadLine();

            Console.WriteLine(
                $"Reservation confirmed!\nGuest Name: {guestName}\nFloor: {floor}\nRoom Number: {assignedRoom}\nDuration of Stay: {stayDuration} days\nFood Allergies: {foodAllergies}"
            );

            roomAssigned = true;
        }
    }

    static int CheckAndAssignRoom(int floor)
    {
        int room1Index = (floor - 1) * 2;
        int room2Index = room1Index + 1;

        if (!rooms[room1Index])
        {
            rooms[room1Index] = true;
            return room1Index + 11;
        }
        else if (!rooms[room2Index])
        {
            rooms[room2Index] = true;
            return room2Index + 11;
        }
        return -1;
    }
}
