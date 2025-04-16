using System;
class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        
        Console.WriteLine("Enter the number of processes:");
        int n = Convert.ToInt32(Console.ReadLine());
        
        int[] processes = new int[n];
        int[] burstTime = new int[n];
        int[] priority = new int[n];  
        
        for (int i = 0; i < n; i++)
        {
            processes[i] = i + 1;  // Process ID from 1 to n
            burstTime[i] = rand.Next(1, 16);  
            priority[i] = rand.Next(1, 6);  
        }
        Console.WriteLine("Select Scheduling Algorithm:");
        Console.WriteLine("1. FCFS (First-Come, First-Served)");
        Console.WriteLine("2. SJF (Shortest Job First)");
        Console.WriteLine("3. Round Robin");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                FCFS.Run(processes, burstTime);
                break;
            case 2:
                SJF.Run(processes, burstTime, priority);
                break;
            case 3:
                Console.WriteLine("Enter the quantum time for Round Robin:");
                int quantum = Convert.ToInt32(Console.ReadLine());
                RoundRobin.Run(processes, burstTime, quantum);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

    }
}
