// See https://aka.ms/new-console-template for more information
//Console.WriteLine(DecimalToBinary(Convert.ToInt32(Console.ReadLine())));
using System.Text;

//Console.WriteLine(BinaryToDecimal(Console.ReadLine()));
//Console.WriteLine(LongestAndSmallestWordsInText(Console.ReadLine()));
//Console.WriteLine(TheMostRepeatedNumbers(new int[] {1,2,3,4,5,2,4,1,1}));
//Console.WriteLine(Power(3,4));


string DecimalToBinary(int decimalNumber)
{
    if (decimalNumber == 0)
        return "0";
    else if (decimalNumber < 0)
        return "something went wrong";

    string binaryNumber = "";
    while (decimalNumber > 0)
    {
        int remainder = decimalNumber % 2;
        binaryNumber = remainder.ToString() + binaryNumber;
        decimalNumber = decimalNumber / 2;
    }

    return binaryNumber;
}

//1010
int BinaryToDecimal(string binaryNumbers)
{
    int resoult = 0;
    int j = 0;
    for (int i = binaryNumbers.Length-1; i >=0; i--)
    {
        int demo = Convert.ToInt32(binaryNumbers[i].ToString());
        if (demo!=0&&demo!=1)
        {
            return -1;
        }
        //resoult += (int)Math.Pow(2, j) * Convert.ToInt32(demo);
        resoult += Power(2, j) * demo;
        j++;
    }
    return resoult;
}
//salam necesen men  kod yaziram
string LongestAndSmallestWordsInText(string text)
{

    string longestWord = "";
    string smallestWord = "";
    StringBuilder stringBuilder = new();
    List<string> longests = new();
    List<string> smallests = new();
    for (int i = 0; i < text.Length; i++)
    {
        if (text[i] != ' '||i==text.Length-1)
        {
            stringBuilder.Append(text[i]);
        }
        if (text[i] == ' ' || i == text.Length-1)
        {

            if (longestWord.Length<=stringBuilder.ToString().Length)
            {
                longestWord = stringBuilder.ToString();
               
                longests.Add(stringBuilder.ToString());
                    
            }
            else if (smallestWord==""||smallestWord.Length>=stringBuilder.ToString().Length)
            {
                smallestWord = stringBuilder.ToString();
                smallests.Add(stringBuilder.ToString());
            }
            stringBuilder.Clear();
        }
       

    }

    longests.RemoveAll(w => w.Length < longestWord.Length);
    smallests.RemoveAll(w => w.Length < smallestWord.Length);
  

    return $"Longests:{string.Join(",",longests)}\nLongest Length:{longestWord.Length}\n\nSmallests:{string.Join(",",smallests)}\nSmallest Length:{smallestWord.Length}";
}

//[1,2,3,5,2,6,4,2]
string TheMostRepeatedNumbers(int[] arr)
{
    int resoult = -1;
    int count = 0;
    Dictionary<int, int> RepeatedNumbersAndCount = new();
    for (int i = 0; i < arr.Length-1; i++)
    {
        int temp = 0;
        for (int j = i+1; j < arr.Length; j++)
        {
            if (arr[i] == arr[j])
            {
                temp++;
            }
        }
        if (temp>=count)
        {
            count = temp;
            resoult = arr[i];
            RepeatedNumbersAndCount.Add(resoult, count);
            if (RepeatedNumbersAndCount.Count>1)
            {
                RepeatedNumbersAndCount.Remove(RepeatedNumbersAndCount.FirstOrDefault(c => c.Value < temp).Key);
            }
          
        }

    }
   
    return resoult!=-1? $"The Most Repeated Numbers:{string.Join(",",RepeatedNumbersAndCount.Keys)}\nCount:{count+1}":"Something went wrong";
}


int Power(int number,int degre)
{
    int resoult = 1;
    for (int i = 0; i < degre; i++)
    {
        resoult *= number;
    }

    return resoult;
}