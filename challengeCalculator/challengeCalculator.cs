using System;
using System.Linq;

public class challengeCalculator{

// Stretch Goals 2.
//Allow the application to process entered entries until Ctrl+C is used

    public static Boolean toggleNegative = false;
    public static int upperBound = 1000;
    public static String delimA = ",";
    public static String delimB = "\\n";
    public static String[] delimiter={delimA,delimB};

	public static void Main(string[] args){
        
        while(true){
            // Toggling for Negative Numbers
            Console.WriteLine("Allow Negative Numbers? (y/n)");
            String input = Console.ReadLine();
            while(!(input == "y" || input == "n")){
                Console.WriteLine("Invalid input. Please Try again. Allow Negative Numbers? (y/n)");
                input = Console.ReadLine();
            }
            if(input =="y")
                toggleNegative = true;
            else if(input =="n")
                toggleNegative = false;

            // Set new Upperbound
            Console.WriteLine("The upper bound is currently set to {0}. Do you want to change it? (y/n)", upperBound);
            input = "";
            input = Console.ReadLine();
            while(!(input == "y" || input == "n")){
                Console.WriteLine("Invalid input. Please Try again. Change upper bound? (y/n)");
                
        
                input = Console.ReadLine();
            }
            if(input =="y"){
                Console.Write("Please enter in the desired upper bound: ");
                int newUpperbound;
                while (!int.TryParse(Console.ReadLine(), out newUpperbound))
                {
                    Console.WriteLine("Please Enter a valid numerical value!");
                }
                upperBound = newUpperbound;           
                Console.WriteLine("The upperbound has been updated to be: {0}", upperBound);
            }
            else if(input =="n"){
                Console.WriteLine("The upperbound will remain at: {0}", upperBound);
            }
            
            // Toggle Delimiters in Requirement 3.  Both or ',' or '\n'.'
            Console.WriteLine("Currently the set Delimiters are set to: {0} ", String.Join(" ",delimiter));
            Console.WriteLine("Would you like to alternate the set Delimiters? (y/n)");
            input = Console.ReadLine();
            if(input =="y"){
                Console.WriteLine("Please Select which set delimiters you would like to use:");
                Console.WriteLine("1) ,");
                Console.WriteLine("2) \\n");
                Console.WriteLine("3) Both ");
                Console.WriteLine("Enter in 1 , 2 , or 3");
                do{
                    input = Console.ReadLine();
                    switch (input){
                    case "1":
                        delimiter[0] = ",";
                        delimiter[1] = "";
                        break;
                    case "2":
                        delimiter[0] = "";
                        delimiter[1] = "\\n";
                        break;
                    case "3":
                        delimiter[0] = ",";
                        delimiter[1] = "\\n";
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input of either 1 , 2 , or 3");
                        break;
                    }
                }
                while(!(input=="1") && !(input=="2") && !(input=="3"));
            }
            else if(input =="n"){
                Console.WriteLine("The set delimiters will remain as {0}", delimiter);
            }


            Console.Write("Enter String\n");
            String subjectString = Console.ReadLine();

            int sum = calculator(subjectString);
            System.Console.WriteLine("Calculated Result: {0}", sum);
        }
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
        //String [] delimiter = {",","\\n"};
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
        
        // Toggle Negative Numbers
        

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

        if(number >= upperBound)
            number = 0;
        
        if (number<0 && !toggleNegative){
            throw new System.ArgumentException($"{number}");
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