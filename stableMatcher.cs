using System;

namespace StableMatchingAlgorithm {
  public class StableMatcher
  {
      static public void Main ()
      {
	  Console.WriteLine ("Gale-Shapley Stable Matching algorithm");
	  int[,] menPrefs = Examples.loadPrefsSize5(1);
	  int[,] womenPrefs = Examples.loadPrefsSize5(2);

	  Console.WriteLine ("Show preferences for men");
	  showPrefs(menPrefs);
	  Console.WriteLine ("Show preferences for women");
	  showPrefs(womenPrefs);

	  int[] fiancee = Utils.findStableMatchesUsingGaleShapleyAlgorithm(menPrefs, womenPrefs);
	  //show results            
	  Console.WriteLine("Solution to stable matiching problem:");
	  for (int i = 0; i < fiancee.Length; i++){
	      Console.Write("W{0}-M{1}, ", i, fiancee[i]);
	  }
	  Console.WriteLine();
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
}