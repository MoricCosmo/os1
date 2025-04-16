using System;

public class FCFS
{
    public static void Run(int[] processes, int[] burstTime)
    {
        int n = processes.Length;
        int[] waitingTime = new int[n];
        int[] turnaroundTime = new int[n];
        int totalWaitingTime = 0, totalTurnaroundTime = 0;

        // Waiting Time Calculation
        waitingTime[0] = 0;
        for (int i = 1; i < n; i++)
        {
            waitingTime[i] = burstTime[i - 1] + waitingTime[i - 1];
        }
        // Turnaround Time Calculation
        for (int i = 0; i < n; i++)
        {
            turnaroundTime[i] = burstTime[i] + waitingTime[i];
            totalTurnaroundTime += turnaroundTime[i];
            totalWaitingTime += waitingTime[i];
        }
        Console.WriteLine("FCFS Scheduling:");
        Console.WriteLine("Process\tBurst Time\tWaiting Time\tTurnaround Time");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{processes[i]}\t{burstTime[i]}\t\t{waitingTime[i]}\t\t{turnaroundTime[i]}");
        }

        Console.WriteLine($"Average Waiting Time: {(float)totalWaitingTime / n}");
        Console.WriteLine($"Average Turnaround Time: {(float)totalTurnaroundTime / n}");

    }
}
