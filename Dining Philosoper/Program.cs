using System;
using System.Threading;

class DiningPhilosophers
{
    const int N = 5;
    const int THINKING = 2;
    const int HUNGRY = 1;
    const int EATING = 0;
    const int TIMES = 200;

    int[] state = new int[N];
    AutoResetEvent[] self = new AutoResetEvent[N];
    object lockObj = new object();

    public DiningPhilosophers()
    {
        for (int i = 0; i < N; i++)
        {
            state[i] = THINKING;
            self[i] = new AutoResetEvent(false);
        }
    }

    int Left(int i) => (i + N - 1) % N;
    int Right(int i) => (i + 1) % N;

    void Test(int i)
    {
        if (state[i] == HUNGRY &&
            state[Left(i)] != EATING &&
            state[Right(i)] != EATING)
        {
            state[i] = EATING;
            self[i].Set(); // Allow philosopher to eat
        }
    }

    public void TakeForks(int i)
    {
        lock (lockObj)
        {
            state[i] = HUNGRY;
            Test(i);
        }

        if (state[i] != EATING)
            self[i].WaitOne();
        
        Console.WriteLine($"Philosopher {i} is Eating");
    }

    public void PutForks(int i)
    {
        lock (lockObj)
        {
            state[i] = THINKING;
            Test(Left(i));
            Test(Right(i));
        }
    }
    public void Philosopher(int i)
    {
        for (int c = 0; c < TIMES; c++)
        {
            Thread.Sleep(1000);
            TakeForks(i);
            Thread.Sleep(500);
            PutForks(i);
        }
    }
    public static void Main()
    {
        DiningPhilosophers dp = new DiningPhilosophers();
        Thread[] threads = new Thread[N];

        for (int i = 0; i < N; i++)
        {
            int local = i; // local copy for closure
            threads[i] = new Thread(() => dp.Philosopher(local));
            Console.WriteLine($"Philosopher {i} is thinking...");
            threads[i].Start();
        }

        foreach (var t in threads)
            t.Join();
    }

 }
