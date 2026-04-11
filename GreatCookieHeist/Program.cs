using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine($"{CookieJar.CookieJarStartAmount()} cookies are in the jar\n");

        List<Kid> kids = new List<Kid>()
        {
            new Kid("Kid A"),
            new Kid("Kid B"),
            new Kid("Kid C"),
            new Kid("Kid D")
        };

        List<Task> kidTasks = kids.Select(kid => kid.CookieKid()).ToList();
        await Task.WhenAll(kidTasks);

        Console.WriteLine("\nJar is empty. Final results:");
        foreach (Kid kid in kids)
        {
            Console.WriteLine($"{kid.Name} stole {kid.StolenCookies} cookies");
        }

        Kid winner = kids[0];
        foreach (Kid kid in kids)
        {
            if (kid.StolenCookies > winner.StolenCookies)
            {
                winner = kid;
            }
        }

        Console.WriteLine($"\n{winner.Name} stole the most cookies with {winner.StolenCookies}!");
    }
}

public static class CookieJar
{
    private static int cookienumber = 30;
    private static readonly object _lock = new object();

    public static int CookieJarStartAmount()
    {
        lock (_lock)
        {
            return cookienumber;
        }
    }

    public static async Task<bool> SnatchCookie(string kidName)
    {
        int timeDelayInt = Random.Shared.Next(1, 11) >= 5 ? 1000 * Random.Shared.Next(1, 6) : 2500;
        await Task.Delay(timeDelayInt);

        lock (_lock)
        {
            if (cookienumber <= 0)
            {
                Console.WriteLine($"{kidName} tried to take a cookie, but the jar is empty. {kidName} walks away sad");
                return false;
            }

            cookienumber--;
            Console.WriteLine($"{kidName} took a cookie. Cookies left: {cookienumber}");
            return true;
        }
    }
}

public class Kid
{
    public string Name { get; set; }
    public int StolenCookies { get; private set; }

    public Kid(string cookiekidname)
    {
        Name = cookiekidname;
    }

    public async Task CookieKid()
    {
        while (await CookieJar.SnatchCookie(Name))
        {
            StolenCookies++;
        }
    }
}