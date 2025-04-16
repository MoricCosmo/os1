using System;
public class SJF
{
    public static void Run(int[] processes, int[] burstTime, int[] priority)
    {
        int n = processes.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (burstTime[i] > burstTime[j])
                {
                    // Swap burstTime
                    int temp = burstTime[i];
                    burstTime[i] = burstTime[j];
                    burstTime[j] = temp;

                    // Swap processes
                    int tempP = processes[i];
                    processes[i] = processes[j];
                    processes[j] = tempP;

                    // Swap priority (optional, for display only)
                    int tempPr = priority[i];
                    priority[i] = priority[j];
                    priority[j] = tempPr;
                }
            }
        }
        int[] waitingTime = new int[n];
        int[] turnaroundTime = new int[n];
        int totalWaitingTime = 0, totalTurnaroundTime = 0;
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

        // Display Results
        Console.WriteLine("SJF Scheduling:");
        Console.WriteLine("Process\tBurst Time\tPriority\tWaiting Time\tTurnaround Time");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{processes[i]}\t{burstTime[i]}\t\t{priority[i]}\t\t{waitingTime[i]}\t\t{turnaroundTime[i]}");
        }

        Console.WriteLine($"Average Waiting Time: {(float)totalWaitingTime / n}");
        Console.WriteLine($"Average Turnaround Time: {(float)totalTurnaroundTime / n}");

    }
}
