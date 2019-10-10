namespace StableMatchingAlgorithm {
    static public class Examples {
        static public int[,] loadPrefsSize5 (int option) {
            const int size = 5;
            int[,] prefs = null;

            if (option == 1) {
                prefs = new int[size, size] { 
                    { 1, 4, 0, 2, 3 }, 
                    { 0, 1, 2, 3, 4 }, 
                    { 1, 2, 4, 3, 0 }, 
                    { 0, 2, 1, 3, 4 }, 
                    { 4, 2, 1, 0, 3 }
                };
            } else if (option == 2) {
                prefs = new int[size, size] { 
                    { 4, 0, 3, 1, 2 }, 
                    { 3, 4, 1, 0, 2 }, 
                    { 0, 3, 1, 2, 4 }, 
                    { 2, 1, 3, 0, 4 }, 
                    { 3, 1, 2, 4, 0 }
                };
            }
            return prefs;
        }
    }
}