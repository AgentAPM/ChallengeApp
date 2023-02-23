
int[] digitCounts = new int[10];
for (int i=0; i < 10; i++)
{
    digitCounts[i] = 0;
}

int number = 4566;
string numberInString = number.ToString();
char[] letters = numberInString.ToArray();
foreach(char c in letters)
{
    int digit = c - '0';
    digitCounts[digit]++;
}

for(int i=0; i < 10; i++)
{
    Console.WriteLine($"{i} => {digitCounts[i]}");
}