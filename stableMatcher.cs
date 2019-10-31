using System;

namespace StableMatchingAlgorithm {
    public class StableMatcher {
        static public void Main() {
            Console.WriteLine("Gale-Shapley Stable Matching algorithm");
            Console.WriteLine();
            int[,] menPrefs = Examples.loadPrefsSize5(1);
            int[,] womenPrefs = Examples.loadPrefsSize5(2);

            Console.WriteLine("Show preferences for men");
            showPrefs(menPrefs);
            Console.WriteLine("Show preferences for women");
            showPrefs(womenPrefs);
            Console.WriteLine();

            int[] fiance = Utils.findStableMatchesUsingGaleShapleyAlgorithm(menPrefs, womenPrefs);

            int[] trivialMatching = Examples.loadTrivialMatching(5);

            int[] randomMatching = Examples.loadRandomMatching(5);

            //show results
            Console.WriteLine("Gale-Shapley solution to stable matching problem:");
            printMatching(fiance);
            Utils.isStable(fiance, menPrefs, womenPrefs, true);

            Console.WriteLine();
            Console.WriteLine("Trivial solution to stable matching problem:");
            printMatching(trivialMatching);
            Utils.isStable(trivialMatching, menPrefs, womenPrefs, true);

            Console.WriteLine();
            Console.WriteLine("Random solution to stable matching problem:");
            printMatching(randomMatching);
            Utils.isStable(randomMatching, menPrefs, womenPrefs, true);


            Console.WriteLine();
            Console.WriteLine("Press Enter to start the brute force method.");
            Console.ReadLine();
            int[] bruteForceMatching = Utils.findStableMatchesUsingBruteForce(menPrefs,womenPrefs, out bool successful);
            if (successful)
            {
                Console.WriteLine("Brute Force successful: ");
                printMatching(bruteForceMatching);
                Utils.isStable(bruteForceMatching, menPrefs, womenPrefs, true);
            }
            else
            {
                Console.WriteLine("Brute Force not succesful.");
            }

            Console.WriteLine ();
            Console.Write("Press Enter to close this window.");
            Console.ReadLine();
        }

        static public void printMatching(int[] matching)
        {
            for (int i = 0; i < matching.Length; i++)
            {
                Console.Write("W{0}-M{1}, ", i, matching[i]);
            }
        }

        static public void showPrefs (int[,] prefs) {
            int size = prefs.GetLength (0);
            for (int row = 0; row < size; row++) {
                Console.Write ("{0}: ", (row).ToString ());
                for (int col = 0; col < size; col++) {
                    Console.Write ("{0} ", prefs[row, col].ToString ());
                }
                Console.WriteLine ("");
            }
        }
    }
}