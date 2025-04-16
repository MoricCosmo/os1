using System;

public class RoundRobin
{
    public static void Run(int[] processes, int[] burstTime, int quantum)
    {
        int n = processes.Length;
        int[] remainingBurstTime = new int[n];
        Array.Copy(burstTime, remainingBurstTime, n);

        int time = 0;
        bool done;

        //fill this line with the code on the right side
        do
        {
            done = true;
            for (int i = 0; i < n; i++)
            {
                if (remainingBurstTime[i] > 0)
                {
                    done = false;
                    if (remainingBurstTime[i] > quantum)
                    {
                        remainingBurstTime[i] -= quantum;
                        time += quantum;
                    }
                    else
                    {
                        time += remainingBurstTime[i];
                        remainingBurstTime[i] = 0;
                    }
                }
            }
        } while (!done);

        Console.WriteLine("Round Robin Scheduling:");
        Console.WriteLine($"Total time: {time}");
    }
}
