using System;
using System.Linq;

public class challengeCalculator{

// Stretch Goals 6.
//   Display the formula used to calculate the result e.g. 2,4,rrrr,1001,6 will return 2+4+0+0+6 = 12
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
        int [] res = getVals(str);
        foreach(int element in res){
            sum = sum + element;
        }
        displayRes(res,'+');
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

    public static void displayRes(int[] res, char sign){
        String result="";
        for(int i=0 ;i<res.Length; i++){
            result = result + " " + res[i] + " ";
            if(i != res.Length-1)
                result = result + sign;
        }
        Console.WriteLine("Result: {0}",result);
    }

}