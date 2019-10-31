using System;
using System.Collections.Generic;

namespace StableMatchingAlgorithm {
    static public class Utils {
        /** Converts from a preference matrix to a ranked-preference matrix, i.e. 
         * converts from vector elements showing preferences sorted by column
         * to vector elements were each element shows their particular order in the array 
         * Example: Prefs = [4,0,3,1,2] -> RankedPrefs = [1,3,4,2,0]
         */
        static public int[,] getRankedMatrixWithDummy (int[,] preferenceMatrix) {
            int size = preferenceMatrix.GetLength (1);

            //add extra column to rank for initialization with a dummy
            int[,] rank = new int[size, size + 1];

            //convert from a preference matrix to a ranked-preference matrix
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    rank[i, preferenceMatrix[i, j]] = j;
                }
            }

            //initialize dummy column with largest possible value
            for (int i = 0; i < size; i++) {
                rank[i, size] = size;
            }

            return rank;
        }

        // Gale-Shapley Stable Matching Algorithm
        // Returns the fiances assigned to each woman, held in an int array
        //TODO: Currently buggy, since it returns an instable solution (connects M0 with W0, with W0 having bad preference (4) for M0)
        static public int[] findStableMatchesUsingGaleShapleyAlgorithm (int[,] menPrefs, int[,] womenPrefs) {
            int size = menPrefs.GetLength (1);
            int[,] rank = getRankedMatrixWithDummy (womenPrefs);

            //start stable marriage algorithm
            int[] fiance = new int[size];   //holds the assigned fiance of each woman
            int[] next = new int[size];     //to track the next in the list of women candidates

            for (int i = 0; i < size; i++) { //start counters to zero index
                fiance[i] = size;
                next[i] = -1;
            }

            for (int m = 0; m < size; m++) {
                int s = m;

                while (s != size) {
                    next[s] = next[s] + 1;
                    int w = menPrefs[s, next[s]];
                    if (rank[w, s] < rank[w, fiance[w]]) {
                        int t = fiance[w];
                        fiance[w] = s;
                        s = t;
                    }
                }
            }

            return fiance;
        }

        //Found here: https://stackoverflow.com/a/22595707
        public static Dictionary<TValue, TKey> Reverse<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            var dictionary = new Dictionary<TValue, TKey>();
            foreach (var entry in source)
            {
                if (!dictionary.ContainsKey(entry.Value))
                    dictionary.Add(entry.Value, entry.Key);
            }
            return dictionary;
        }

        static private Dictionary<int, int> convertArrayToDict(int[] array)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for(int i = 0; i<array.Length; i++)
            {
                dict.Add(i, array[i]);
            }
            return dict;
        }

		static public bool isStable(int[] fianceArray, int[,] menPrefs, int[,] womenPrefs, bool giveInfo = false){
            if(giveInfo) Console.WriteLine("isStable check:");

            int size = fianceArray.Length;
			if(size != menPrefs.GetLength(1) || size != womenPrefs.GetLength(1)){
                //Sizes do not match, so the matching is incomplete
                if (giveInfo) Console.WriteLine("Error: size of fianceArray doesnt match menPrefs or womenPrefs -- Returning false");
                return false;
			}

            Dictionary<int, int> fianceDict = convertArrayToDict(fianceArray);
            Dictionary<int, int> fianceeDict = Reverse<int,int>(fianceDict);
            //Go through all women
            for(int selectedWoman = 0; selectedWoman<size; selectedWoman++)
            {
                //Get current fiance
                int selectedWomanFiance = fianceDict[selectedWoman];
                //Go through all men
                for(int selectedMan = 0; selectedMan<size; selectedMan++)
                {
                    //Exclude currentfiance
                    if(selectedMan != selectedWomanFiance)
                    {
                        //Check if the selected man fits better to the selected woman (both prefer themselves over their current partners)
                        int selectedManFiancee = fianceeDict[selectedMan];
                        if( womenPrefs[selectedWoman, selectedMan] < womenPrefs[selectedWoman, selectedWomanFiance] && 
                            menPrefs[selectedMan, selectedWoman] < menPrefs[selectedMan, selectedManFiancee]
                            )
                        {
                            if (giveInfo) Console.WriteLine("M{0}({4} for W{1}) and W{1}({5} for M{0}) like each other more than their partners W{2}({6} from M{0}) and M{3}({7} from W{1})", selectedMan, selectedWoman, selectedManFiancee, selectedWomanFiance, menPrefs[selectedMan, selectedWoman], womenPrefs[selectedWoman, selectedMan], menPrefs[selectedMan, selectedManFiancee], womenPrefs[selectedWoman, selectedWomanFiance]);
                            return false;
                        }
                    }
                }
            }
            if (giveInfo) Console.WriteLine("This is a stable matching.");
            return true;
		}
    }
}