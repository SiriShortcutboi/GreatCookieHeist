using System;


public class Program
{
	public static async Task Main()
	{
		

        //Call a static method in CookieJar to set the initial cookie count (e.g., 10 cookies).
        //ClassName.Method();
        Console.WriteLine($"{CookieJar.CookieJarStartAmount()} cookies are in the jar ");

        
        //Create several Kid objects and start each kid as an async task.
        //Each kid should continuously try to grab cookies until none are left.
        //Once the jar is empty, print out which kid stole the most cookies.
        
    }
}

public static class CookieJar
{   // doesnt need an instance constructor like usual cause its static

    //finished writing this class
    static int cookienumber = 30;
    public static int CookieJarStartAmount()
    {
        return cookienumber;
    }
    //int CookieChecker; might be helpful for refills later


    public static async Task SnatchCookie(/*string cookiekidName*/)
    {   
        int timeDelayInt = 2500;
        Random random = new Random();
        timeDelayInt = random.Next(1,11) >= 5 ? ( 1000 * random.Next(1,6)) : 2500;
        
        await Task.Delay(timeDelayInt);
        if (cookienumber == 0)
        {
            Console.WriteLine($"Kid tried to take a cookie, but the jar is empty!");
            Console.WriteLine($"kid walks away sad and hopes for a refill");
        }

        else
        {
            cookienumber--;
            Console.WriteLine($"Kid took a cookie. Cookies left: {cookienumber}");

        }
    }

}

public class Kid()
{
    public string Name {get; set;} = "KidA";
    
   /*  public Kid()
    {
        this.Name = 
        
    } */
    public async Task CookieKid(string cookiekidname)
    {
        this.Name = cookiekidname;
        await CookieJar.SnatchCookie();
    }


}


//public available to other classes
//static makes the method part of the whole class instead of 1 instance