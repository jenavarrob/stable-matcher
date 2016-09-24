# stable-matcher
Finds stable matching for two parties with a set of preferences. This code is for illustrative and learning purposes.

The Stable Matching algorithm used in this project is the Gale-Shapley algorithm which is very simple but very powerful algorithm to find stable matches for two parties each with a set of preferences. It was first introduced by D. Gale and L.S. Shapley in the article "College Admissions and the Stability of Marriage" published in 1962 in "The American Mathematical Monthly" (see http://www.jstor.org/stable/2312726). This algorithm and the theory behind it are so helpful and interesting that led Lloyd S. Shapley together with Alvin E. Roth to win the Nobel Prize in Economics in 2012 "for the theory of stable allocations and the practice of market design" (see http://www.nobelprize.org/nobel_prizes/economics/laureates/2012/).

## Setup mono
Follow the instructions here to install mono:
```
http://www.mono-project.com/docs/getting-started/install/linux/
```

Do not forget to install also these other packages:
```
sudo apt install mono-mcs
sudo apt install mono-devel
```

## How to compile and run
Compile:
```
mcs stableMatcher.cs utils.cs examples.cs
```
Run:
```
mono stableMatcher.exe
```

## Setup in Visual Studio (German version)

1. Start Visual Studio.
2. Go to the menu option "Datei->Neu->Projekt aus vorhandenem Code".
3. Choose "Visual C#" and click "Weiter".
4. You should see a dialog box "Wo sind die Daten?" Browse to the directory where you have clone the Git repository of the project and click on "Ordner auswählen".
5. Give a name to your visual studio program.
6. You should see a dialog box with the option "Ausgabetyp". Choose "Konsolenanwendung".
7. Click in "Fertigstellen".
8. Navigate to the file Program.cs generated by visual Studio and comment out the Main function and the program should now run.

Please just commit/push only those files that are needed to run the program in all platforms, i.e. please do not add/commit project files auto-generated by visual studio, for example: Program.cs and files with extensions .suo, .user, .sln, etc.
