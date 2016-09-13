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

