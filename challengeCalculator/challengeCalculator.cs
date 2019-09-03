using System;

public class challengeCalculator{

// Requirement 5.
//    Ignore any number greater than 1000 e.g. 2,1001,6 will return 8
	public static void Main(string[] args){
		System.Console.WriteLine("Test");
        
		Console.Write("Enter String\n");
		String subjectString = Console.ReadLine();

        String s = "4,6,8\n9,4";
        string [] split = s.Split(new Char [] {',' , '\n' });
        foreach (var a in split){
            //System.Diagnostics.Debug.WriteLine(a);
            System.Console.WriteLine(a);

        }

        string strings = "4,6,8\n9,4";

        
        int sum = calculator(subjectString);
        System.Console.WriteLine(sum);
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
        string [] strList = str.Split(delimiter,StringSplitOptions.RemoveEmptyEntries);
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

}