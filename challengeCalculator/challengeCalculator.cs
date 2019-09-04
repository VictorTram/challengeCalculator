
using System;
using System.Linq;

public class challengeCalculator{

    public static void Main(string[] args){
        //AddCalculator newCalculator = new AddCalculator();
        operationsCalculator newCalculator;
        while(true){
            do{
                Console.WriteLine("Please Enter in the Symbol for the calculator you'd like to use:");
                Console.WriteLine("+ : Addition \n- : Subtration \n* : Multiplication \n/ : Division");

                String input = Console.ReadLine();
                switch(input){
                    case "+":
                        newCalculator= new operationsCalculator();
                        newCalculator.changeOperator('+');
                        loopCalculator(newCalculator);
                        break;
                    case "-":
                        newCalculator= new operationsCalculator();
                        newCalculator.changeOperator('-');
                        loopCalculator(newCalculator);
                        break;
                    case "*":
                        newCalculator= new operationsCalculator();
                        newCalculator.changeOperator('*');
                        loopCalculator(newCalculator);
                        break;
                    case "/":
                        newCalculator= new operationsCalculator();
                        newCalculator.changeOperator('/');
                        loopCalculator(newCalculator);
                        break;
                    default:
                        break;
                }

            }while(true);
        }
        
    }
    public static void loopCalculator(operationsCalculator newCalculator){
        while(true){

            Console.Write("Enter String\n");
            String subjectString = Console.ReadLine();
            newCalculator.initialize(subjectString);
            newCalculator.results();          
            Console.WriteLine("Do you want to change settings(Upper Bound, Allow Negatives, Alternate Set Delimiters)?[y/n] \nType 'exit' to try a different caluclator!");
            subjectString = Console.ReadLine();
            while(!(subjectString == "y" || subjectString == "n" || subjectString == "exit")){
                Console.WriteLine("Invalid input. Please Try again. Do you want to Change Settings? (y/n)\nIf you want to try a different Calculator type 'exit'.");
                subjectString = Console.ReadLine();
            }
            if(subjectString == "y")
                newCalculator.change();
            else if(subjectString == "exit")
                break;
        }
    }	

    
}

public class Calculator{
    public static String[] delimiter = {",","\\n"};
    public static String[] customDelimiter{get; set;}
    public static int[] formulaValues{get; set;}
    public static Boolean allowNegatives{get; set;}
    public static int upperBound{ get; set;}
    public static char calcOperator{get;set;}
    public static String formula{get; set;}

    public static int[] getFormulaValues(){
        return formulaValues;
    }
    public static void customDelimiters(String str){
        //Trim off the leading '//'
        str = str.Substring(2);
        
        String[] delim = {"[","]"};
        String [] customDelim = str.Split(delim,StringSplitOptions.RemoveEmptyEntries);
        foreach(String element in customDelim){
            Console.WriteLine("CustDelim: {0}", element);
         }
        delimiter = delimiter.Union(customDelim).ToArray();;
    }

    public static void setFormulaValues(string str){
        String [] strList = str.Split(delimiter,StringSplitOptions.RemoveEmptyEntries);
        int[] intList = new int[strList.Length];
        int count = 0;       
        foreach (string element in strList)
        {       
            try{
                intList[count] = isValid(element);
            }catch(ArgumentException e){
                Console.WriteLine("ExceptionThrow: Negative Num: {0}", e.Message);
            }           
            count++;
            Console.WriteLine($"Element: {element}");
        }
        formulaValues = intList;
    }

    public static void writeFormula(){
        string str="";      
        for(int i=0 ;i<formulaValues.Length; i++){
            str = str + " " + formulaValues[i] + " ";
            if(i != formulaValues.Length-1)
                str = str + calcOperator;
        }
        formula = str;
    }  

    public static void formatValues(String str){
        String customDelim;
        // When the input starts with a <//> , its an indication that custom delimiters will be present
        if(str.Length>=2){
            if(str.Substring(0,2) == "//"){
                // Split the input string based on the first '\n' and process the first half
                customDelimiters(str.Substring(0,str.IndexOf("\\n")));
                str = str.Substring(str.IndexOf("\\n"));
            }
        }
        setFormulaValues(str);
        

    }

    public static void changeSettings(){
     // Toggling for Negative Numbers
        Console.WriteLine("Allow Negative Numbers? (y/n)");
        String input = Console.ReadLine();
        while(!(input == "y" || input == "n")){
            Console.WriteLine("Invalid input. Please Try again. Allow Negative Numbers? (y/n)");
            input = Console.ReadLine();
        }
        if(input =="y")
            allowNegatives = true;
        else if(input =="n")
            allowNegatives = false;

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
            Console.WriteLine("The set delimiters will remain as {0}", String.Join(" ",delimiter));
        }  
    }



    public static int isValid(string element){
        int number;
        Boolean res = int.TryParse(element, out number);
        if(number >= upperBound)
            number = 0;
        
        if (number<0 && !allowNegatives){
            throw new System.ArgumentException($"{number}");
        }
        return number;
    }

    public static void initializeCalc(String str){
        formatValues(str);
        writeFormula();
    }

}

public class operationsCalculator : Calculator{
    public void results(){
        double res=0;

        switch(calcOperator){
            case '+':
                res = sum();
                break;
            case '-':
                res = min();
                break;
            case '*':
                res = mul();
                break;
            case '/':
                res = div();
                break;
            default:
                break;
        }
        writeFormula();
        Console.WriteLine(formula + " = "+res);
    }

    public int sum(){
        int res=0;
        Boolean firstElement = false;
        foreach(int element in getFormulaValues()){
            if(!firstElement){
                res = element;
                firstElement = true;
            }
            else
                res = res + element;
        }
        return res;
    }
    public int min(){
        int res=0;
        Boolean firstElement = false;
        foreach(int element in getFormulaValues()){
            if(!firstElement){
                res = element;
                firstElement = true;
            }
            else
                res = res - element;
        }
        return res;
    }
    public int mul(){
        int res=1;
        Boolean firstElement = false;
        foreach(int element in getFormulaValues()){
            if(!firstElement){
                res = element;
                firstElement = true;
            }
            else
                res = res * element;
        }
        return res;
    }
    public double div(){
        double res =0;
        Boolean firstElement = false;
        foreach(int element in getFormulaValues()){
            if(!firstElement){
                res = element;
                firstElement = true;
            }
            else
                res = res/element;        }
        return res;
    }
    public operationsCalculator(){       
        changeSettings();
    }
    public void initialize(String str){
        initializeCalc(str);
    }
    public void change(){
        changeSettings();
    }

    public void changeOperator(char sign){
        calcOperator = sign;
    }

    
}




