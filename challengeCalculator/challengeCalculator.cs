using System;
using System.Linq;

public class challengeCalculator{

// Requirement 6.
//   Support 1 custom delimiter of one character length
//      use the format: //{delimiter}\n{numbers} e.g. //;\n2;5 will return 7
//      all previous formats should also be supported
	public static void Main(string[] args){
		System.Console.WriteLine("Test");
        
		Console.Write("Enter String\n");
		String subjectString = Console.ReadLine();

        int sum = calculator(subjectString);
        System.Console.WriteLine("Calculated Result: {0}", sum);
    }

// Calculations
    public static int calculator(string str){
        
        int sum=0;
        foreach(int element in getVals(str)){
            sum = sum + element;
        }
        return sum;
    }


// Input formating/handling
    public static int[] getVals(string str){
        String [] delimiter = {",","\\n"};
        String [] customDelim;

        // When the input starts with a //, its an indication that custom delimiters will be present
        if(str.Substring(0,2) == "//"){
            // Split the input string based on the first '\n' and process the first half
            customDelim = getCustomDelimiter(str.Substring(0,str.IndexOf("\\n")));
            str = str.Substring(str.IndexOf("\\n"));
            delimiter = delimiter.Union(customDelim).ToArray();
        }

        String [] strList = str.Split(delimiter,StringSplitOptions.RemoveEmptyEntries);
        int[] intlist = new int[strList.Length];
        int count = 0;
        //int num;
        foreach (string element in strList)
        {
            
            //bool res = int.TryParse(element, out num);
            try{
            intlist[count] = isValid(element);
            }catch(ArgumentException e){
                Console.WriteLine("ExceptionThrow: Negative Num: {0}", e.Message);
            }           
            count++;
            Console.WriteLine($"Element: {element}");
        }
        return intlist;
    }

    public static int isValid(string element){
        int number;
        Boolean res = int.TryParse(element, out number);
        if (number<0){
            throw new System.ArgumentException($"{number}");
        }else if(number >=1000){
            number = 0;
        }
        return number;
    }

    public static string[] getCustomDelimiter(string str){
        // Trim off the leading '//'
        str = str.Substring(2);
        
        String[] delim = {"[","]"};
        String [] customDelim = str.Split(delim,StringSplitOptions.RemoveEmptyEntries);
        foreach(String element in customDelim){
            Console.WriteLine("CustDelim: {0}", element);
        }
        return customDelim;
    }

}