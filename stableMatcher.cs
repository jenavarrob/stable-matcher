using System;
 
public class StableMatcher
{
    static public void Main ()
    {
        Console.WriteLine ("Gale-Shapley Stable Matching algorithm");
	int[,] menPrefs = LoadDemoPrefs(1);
	int[,] womenPrefs = LoadDemoPrefs(2);
	ShowPrefs(menPrefs, womenPrefs);
    }

    static public int[,] LoadDemoPrefs(int option)
    {
	const int size = 5;
        int[,] prefs = null;
	
	if (option == 1){
	   prefs = new int[size, size]{
	   {2, 5, 1, 3, 4},
	   {1, 2, 3, 4, 5},
	   {2, 3, 5, 4, 1},
	   {1, 3, 2, 4, 5},
	   {5, 3, 2, 1, 4}};
	}
	else if(option == 2){
	   prefs = new int[size,size]{
	   {5, 1, 4, 2, 3},
  	   {4, 5, 2, 1, 3},
	   {1, 4, 2, 3, 5},
  	   {3, 2, 4, 1, 5},
	   {4, 2, 3, 5, 1}};
	}
        return prefs;
    }

    static public void ShowPrefs(int[,] menPrefs, int[,] womenPrefs)
    {
	Console.WriteLine("Show preferences for men:");
	//TODO: add here function to show output
	Console.WriteLine("Show preferences for women:");
	//TODO: add here function to show output
    }
}