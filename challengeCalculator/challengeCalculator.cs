using System;

public class challengeCalculator{

// 1)
//    Support a maximum of 2 numbers
// Use a comma delimited format e.g. 5000 will return 5000; 1,20 will return 21
// Invalid/Missing numbers should be converted to 0 e.g. "" will return 0; 5,tytyt will return 5
	public static void Main(string[] args){
		//System.Console.WriteLine("Test");
        string subjectString;
		Console.Write("Enter String");
		subjectString = Console.ReadLine();


        string res = calculator(subjectString);
        System.Console.WriteLine(res);
    }

    public static string calculator(string str){
        

        int[] nums = getVals(str);
        return "test";
    }

    public static int[] getVals(string str){
        string delimiter = ",";
        
        //int[] strlist = int.Parse(str.Split(delimiter));
        //foreach (int element in strList)
        //{
            //Console.WriteLine($"Element: {element}");
        //}
        int[] res = {1,2,3};
        return res;
    }

}