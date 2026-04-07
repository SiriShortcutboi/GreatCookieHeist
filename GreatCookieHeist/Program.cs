using System;


public class Program
{
	public static async Task Main()
	{
		Console.WriteLine("Hello World");
	    // no new-ing it up, CookieJar cookiejar = new CookieJar();


    }
}

public static class CookieJar
{   // doesnt need an instance constructor like usual cause its static
    static int CookiesAmount= 30;
    //int CookieChecker; might be helpful for refills later

}
    

public class SNIPPETS {
    public void CookiesNeverZero() 
    {
        if (CookiesAmount <= 1)
        {
            CookiesAmount = 0;
            //probably throw the next line under this into an interface,
            // or just call from here over to there. 
            Console.WriteLine($"{GetKidName()} walks away sad");
        }

        if (CookiesAmount <= 10)
        {
            CookiesAmount += 25;
        }
    }

    private static object GetKidName()
    {
        KidName = GetKidCaller();
        return KidName; //need to make polymorphic constructor for kids

    }

    public static async Task SnatchCookie(CookieJar.CookiesAmount)
    {
        await Task.Delay(2500);
        if (CookiesAmount == 0)
        {
            Console.WriteLine($"Kid A took a cookie. Cookies left: {CookiesAmount}";);
        }

        else
        {
             "Kid B tried to take a cookie, but the jar is empty!"
        }
    }


}