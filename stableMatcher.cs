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
            bool fianceStable = Utils.isStable(fiance, menPrefs, womenPrefs);
            for (int i = 0; i < fiance.Length; i++)
            {
                Console.Write("W{0}-M{1}, ", i, fiance[i]);
            }
            Console.WriteLine("Output from isStable: " + fianceStable.ToString());

            Console.WriteLine();
            Console.WriteLine("Trivial solution to stable matching problem:");
            bool trivialMatchingStable = Utils.isStable(trivialMatching, menPrefs, womenPrefs);
            for (int i = 0; i < trivialMatching.Length; i++)
            {
                Console.Write("W{0}-M{1}, ", i, trivialMatching[i]);
            }
            Console.WriteLine("Output from isStable: " + trivialMatchingStable.ToString());

            Console.WriteLine();
            Console.WriteLine("Random solution to stable matching problem:");
            bool randomMatchingStable = Utils.isStable(randomMatching, menPrefs, womenPrefs);
            for (int i = 0; i < randomMatching.Length; i++)
            {
                Console.Write("W{0}-M{1}, ", i, randomMatching[i]);
            }
            Console.WriteLine("Output from isStable: " + randomMatchingStable.ToString());

            Console.WriteLine ();
            Console.Read();
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