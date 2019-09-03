using System;

public class challengeCalculator{

// 1)
//    Support a maximum of 2 numbers
// Use a comma delimited format e.g. 5000 will return 5000; 1,20 will return 21
// Invalid/Missing numbers should be converted to 0 e.g. "" will return 0; 5,tytyt will return 5
	public static void Main(string[] args){
		System.Console.WriteLine("Test");
        string subjectString;
		Console.Write("Enter String\n");
		subjectString = Console.ReadLine();

        
        

        int sum = calculator(subjectString);
        System.Console.WriteLine(sum);
    }

    public static int calculator(string str){
        

        //int[] nums = getVals(str);
        int sum=0;
        foreach(int element in getVals(str)){
            sum = sum + element;
        }
        return sum;
    }

    public static int[] getVals(string str){
        char delimiter = ',';
        String[] strList = str.Split(delimiter);
        int[] intlist = new int[strList.Length];
        int count = 0;
        int number;
        foreach (string element in strList)
        {
            
            bool res = int.TryParse(element, out number);
            intlist[count] = number;
            //Console.WriteLine($"Element: {element}");
            count++;
        }
        //int[] res = {1,2,3};



        return intlist;
    }

}