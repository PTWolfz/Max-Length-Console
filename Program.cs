// See https://aka.ms/new-console-template for more information
int n, m;
EnterLength:
Console.WriteLine("Enter the number of rows and columns of the matrix, separated by space.");
string firstInput = Console.ReadLine();
try
{
    n=  Int32.Parse(firstInput.Split(" ")[0]);
    m=  Int32.Parse(firstInput.Split(" ")[1]);
}
catch (Exception)
{
    Console.WriteLine("Wrong input, please enter again");
    goto EnterLength;
}
if(n<2||n>20||m<2||m>20)
{
    Console.WriteLine("Wrong input, please enter again. Remember 1 < n,m < 21.");
    goto EnterLength;
}
int[,] inputArray = new int[n, m];
//Enter Array
Console.WriteLine("Enter the matrix "+n.ToString()+"x"+m.ToString());
for (int i = 0; i<n; i++)
{
    string input = Console.ReadLine();
    string[] inputStringArray = input.Split(" ");
    for (int j = 0; j<m; j++)
    {
EnterArray:
        try
        {
            inputArray[i, j]=Int32.Parse(inputStringArray[j]);
        }
        catch (Exception)
        {
            Console.WriteLine("Wrong input, please enter again");
            goto EnterArray;
        }
    }
}
List<List<int>> roadList = new List<List<int>>();
calculateLength(0, 0, new List<int>());
List<int> lengthList = roadList.Select(x => x.Count()).ToList();
List<int> longestList = roadList.Where(x => x.Count()==lengthList.Max()).First().ToList();
Console.WriteLine("Max Length: "+lengthList.Max().ToString());
Console.ReadLine();

void calculateLength(int i, int j, List<int> indexList)
{
    int currentValue = inputArray[i, j];
    List<int> clonedIndexList = new List<int>(indexList);
    clonedIndexList.Add(currentValue);
    roadList.Add(clonedIndexList);
    if (j<m-1 && inputArray[i, j+1]>currentValue)
    {
        calculateLength(i, j+1, clonedIndexList);
    }
    if (i<n-1&&inputArray[i+1, j]>currentValue)
    {
        calculateLength(i+1, j, clonedIndexList);
    }
}