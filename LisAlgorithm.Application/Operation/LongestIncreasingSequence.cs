using LisAlgorithm.Application.Abstraction;
using System.Text.RegularExpressions;

namespace LisAlgorithm.Application.Operation;

public class LongestIncreasingSequence : ILongestIncreasingSequence
{

    public string FindLongestSequence(string inputText)
    {
        List<int> outputList = [];

        if (!IsNumeric(inputText))
            return string.Empty;

        int[] input = inputText.Split(" ").Select(n => int.Parse(n)).ToArray();

        int count = input.Length;
        int[] dataPosition = new int[count];
        int[] prevPosition = new int[count]; 

        for (int i = 0; i < count; i++)
        {
            dataPosition[i] = 1;
            prevPosition[i] = -1; 

            for (int j = 0; j < i; j++)
            {
                if (input[j] < input[i])
                {
                    if (dataPosition[i] < dataPosition[j] + 1)
                    {
                        dataPosition[i] = dataPosition[j] + 1;
                        prevPosition[i] = j; 
                    }
                }
            }
        }

        // Find the maximum value in dataPosition
        int maxLength = 0;
        int endIndex = -1; 
        for (int i = 0; i < count; i++)
        {
            if (dataPosition[i] > maxLength)
            {
                maxLength = dataPosition[i];
                endIndex = i;
            }
        }

        // Construct the Array
        
        while (endIndex != -1)
        {
            outputList.Add(input[endIndex]);
            endIndex = prevPosition[endIndex];
        }
        outputList.Reverse(); 


        return string.Join(" ", outputList);
    }


    #region Private Methods

    private static bool IsNumeric(string stringValue)
    {
        var pattern = @"^-?[0-9\s]+(?:\.[0-9\s]+)?$";
        var regex = new Regex(pattern);

        return regex.IsMatch(stringValue);
    }


    #endregion
}
