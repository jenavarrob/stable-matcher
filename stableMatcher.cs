using System;
 
public class StableMatcher
{
    static public void Main ()
    {
        Console.WriteLine ("Gale-Shapley Stable Matching algorithm");
	int[,] menPrefs = loadDemoPrefs(1);
	int[,] womenPrefs = loadDemoPrefs(2);
	
	Console.WriteLine ("Show preferences for men");
	showPrefs(menPrefs);
	Console.WriteLine ("Show preferences for women");
	showPrefs(womenPrefs);

	int[] fiancee = runStableMatchingAlgorithm(menPrefs, womenPrefs);
	//show results            
        Console.WriteLine("Solution to stable matiching problem:");
        for (int i = 0; i < fiancee.Length; i++){
            Console.Write("W{0}-M{1}, ", i, fiancee[i]);
        }
    }

    //Stable Matching Algorithm
    static public int[] runStableMatchingAlgorithm(int[,] menPrefs, int[,] womenPrefs)
    {
	int size = menPrefs.GetLength(1);
	int[,] rank = getRankedMatrixWithDummy(womenPrefs);

	//start stable marriage algorithm
	int[] fiancee = new int[size];
	int[] next = new int[size];  //to track the next in the list of women candidates

	for (int i = 0; i < size; i++){  //start counters to zero index
	    fiancee[i] = size;
	    next[i] = -1;
	}

	for (int m = 0; m < size; m++){
	    int s = m;

	    while (s != size){
		next[s] = next[s] + 1;
		int w = menPrefs[s, next[s]];
		if (rank[w, s] < rank[w, fiancee[w]]){
		    int t = fiancee[w];
		    fiancee[w] = s;
		    s = t;
		}
	    }
	}

	return fiancee;
    }

    /** Converts from a preference matrix to a ranked-preference matrix, i.e. 
     * converts from vector elements showing preferences sorted by column
     * to vector elements were each element shows their particular order in the array 
     * Example: Prefs = [4,0,3,1,2] -> RankedPrefs = [1,3,4,2,0]
     */
    static public int[,] getRankedMatrixWithDummy(int[,] preferenceMatrix)
    {
	int size = preferenceMatrix.GetLength(1);

	//add extra column to rank for initialization with a dummy
	int[,] rank = new int[size, size + 1];

	//convert from a preference matrix to a ranked-preference matrix
	for (int i = 0; i < size; i++){
	    for (int j = 0; j < size; j++){
		rank[i, preferenceMatrix[i, j]] = j;
	    }
	}

	//initialize dummy column with largest possible value
	for (int i = 0; i < size; i++){
	    rank[i, size] = size;
	}

	return rank;
    }


    static public int[,] loadDemoPrefs(int option)
    {
	const int size = 5;
        int[,] prefs = null;
	
	if (option == 1){
	   prefs = new int[size, size]{
	   {1, 4, 0, 2, 3},
	   {0, 1, 2, 3, 4},
	   {1, 2, 4, 3, 0},
	   {0, 2, 1, 3, 4},
	   {4, 2, 1, 0, 3}};
	}
	else if(option == 2){
	   prefs = new int[size,size]{
	   {4, 0, 3, 1, 2},
  	   {3, 4, 1, 0, 2},
	   {0, 3, 1, 2, 4},
  	   {2, 1, 3, 0, 4},
	   {3, 1, 2, 4, 0}};
	}
        return prefs;
    }
    
    static public void showPrefs(int[,] prefs)
    {
        int size = prefs.GetLength(0);
	for(int row = 0; row < size; row++){
	    Console.Write("{0}: ", (row).ToString());
	    for(int col = 0; col < size; col++){
		Console.Write("{0} ", prefs[row,col].ToString());
	    }
	    Console.WriteLine("");
	}
    }
}