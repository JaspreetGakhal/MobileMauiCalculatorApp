// Ignore Spelling: App
using CalculatorApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using static CalculatorApp.Models.Calculator;


// Jaspreet Gakhal 8542862 Section 4
namespace CalculatorApp.ViewModels
{

    /// <summary>
    /// CalculatorPageViewModel class in inheriting from ObservableObject
    /// </summary>
    public partial class CalculatorPageViewModel : ObservableObject
    {
        /// <summary>
        /// Private calculator member
        /// can use new or new Calculator(); [Either or]
        /// </summary>
      
        private Calculator calculator = new();

        /// <summary>
        /// Private variables
        /// </summary>
        private double firstNumber;
        private double secondNumber;
        private string? mathOperator;
        /// <summary>
        /// CurrentState set with calculator member
        /// </summary>
        private Calculator.CurrentState currentState;


        /// <summary>
        /// Observable property for numbersLabel and EquationsLabel
        /// </summary>
        [ObservableProperty]
        private string numbersLabel = "0";

        [ObservableProperty]
        private string equationLabel = "0";


        /// <summary>
        /// RELAY command must be used for all event handling methods as they are used for data binding with UI
        /// Binding parameters area also used to ensure keystrokes are precise 
        /// Method for selectingNumber. Responsible for digit 0-9 plus .
        /// 
        /// </summary>
        /// <param name="number"></param>
        [RelayCommand]
        public void SelectNumber(string number)
        {
            try
            {

            if (currentState == CurrentState.CalculationDone)
            {
                Clear();
                currentState = CurrentState.FirstNumber;
            }

            if (number == "." && NumbersLabel.Contains('.'))
               {
                    Shell.Current.DisplayAlert("Invalid ", "Can only add one decimal per entry", "Continue"); return;
               }
               
            if(NumbersLabel =="0")
            {
                NumbersLabel = number;
            }
            else
            {
                NumbersLabel += number;
            }

            if (currentState == CurrentState.FirstNumber)
            {
                firstNumber = double.Parse(NumbersLabel);
                calculator.FirstNumber = firstNumber;
            }


            else
            {
                secondNumber = double.Parse(NumbersLabel);
                calculator.SecondNumber = secondNumber;
            }
            // Not mandatory but you did recommend putting everything in a try catch. I originally had to catch errors and find mistakes. Left it incase something happens or an un
            //expected input is handled correctly
            } catch (Exception)
            {

                //Used Shell.CurrentDisplay instead of Exception ex message, following class examples
                Shell.Current.DisplayAlert("Error", "Error with number handling/input", "OK");

            }

        }

        /// <summary>
        /// Relay Command for data binding with UI in CalculatorPage.Xaml
        /// SelectingMathOperator is method used for assigning math operator
        /// I am appending math operator to equationLabel. 
        /// This updates correspondingly allowing equation label to contain firstvalue mathopp then second value
        /// If 3 numbers entered first number is the combination of first two values calculated
        /// 
        /// </summary>
        /// <param name="mathOpp"></param>
        [RelayCommand]
        public void SelectMathOperator(string mathOpp)
        {

            try
            {

           
            if (currentState == CurrentState.SecondNumber)
            {
                Calculate();
            }

            mathOperator = mathOpp;
            calculator.MathOperator = mathOperator;

            EquationLabel = $"{firstNumber} {mathOperator}";
            NumbersLabel = "0";
            currentState = CurrentState.SecondNumber;
            } catch(Exception)
            {
                Shell.Current.DisplayAlert("Error", "Error with math operator handling/ entry", "OK");
            }
        }


        /// <summary>
        /// Again relay command for data binding
        /// I am calling the method from MathUtil that performs the corrosponding calculation of converting value to decimal
        /// Depending on the state (not that it matters what state) is converted to a percentage value
        /// </summary>
        [RelayCommand]
        private void SelectPercentage()
        {


            try
            {
                if (currentState == CurrentState.FirstNumber)
                {
                    firstNumber = MathUtil.Percentage(firstNumber);
                    NumbersLabel = firstNumber.ToString();
                }
                else
                {
                    secondNumber = MathUtil.Percentage(secondNumber);
                    NumbersLabel = secondNumber.ToString();
                }
            }  catch(Exception)
            {
                Shell.Current.DisplayAlert("Error", "Encountered an issue converting value to percentage", "OK");
            }
        }
        [RelayCommand]
      
        public void Clear()
        {
           try
           {
                firstNumber = 0;
                secondNumber = 0;
                mathOperator = "";
                currentState = CurrentState.FirstNumber;
                NumbersLabel = "0";
                EquationLabel = "";

           }  catch(Exception)
            {
                Shell.Current.DisplayAlert("Issue", "Error with C button", "OK");
            }

        }
       /// <summary>
       /// Relay command for dataBinding command
       /// if currentState is firstNum make it 0. If secondNumber make it 0. 
       /// Try catch is to ensure my button is working as required
       /// </summary>
        [RelayCommand]
        public void ClearEntry()
        {

            try
            {

                NumbersLabel = "0";
                if (currentState == CurrentState.FirstNumber)
                {
                    firstNumber = 0;

                }
                else
                {
                    secondNumber = 0;

                }
            } catch(Exception)
            {
                Shell.Current.DisplayAlert("Error", "CE button is not working as required", "OK");
            }

        }

        public CalculatorPageViewModel()
        {
            calculator = new Calculator();
        }

        /// <summary>
        /// Relay command for data binding Command 
        /// Negate method responsible for inversing the sign upon toggle
        /// Can modify number to - number, or number *-1
        /// If currentState is firstNum you multiply it by -1 to negate it. If state is secondNumber you also negate it
        /// Try catch is used for error handling and testing while creating the code and testing methods
        /// </summary>
        [RelayCommand]
        public void Negate()
        {
            try
            {
                if (currentState == CurrentState.FirstNumber)
                {
                    firstNumber = firstNumber * -1;
                    NumbersLabel = firstNumber.ToString();
                }

                else
                {
                    secondNumber = secondNumber * -1;
                    NumbersLabel = secondNumber.ToString();
                }

            } catch(Exception)
            {
                Shell.Current.DisplayAlert("Error", "Unable to negate value", "OK");
            }
        }
        
        /// <summary>
        /// Relay command used for data binding
        /// One of the most important and interesting methods
        /// Handling calculations which has already been done in MathUtil file. We are calling MathUtil class and the method associated with the calculation
        /// Even if I don't add case for %, the code still works as its handled in MathUtil as value. I added both numbers to ensure either first or second number can be calculated for
        /// Percentage
        /// </summary>
        /// <exception cref="DivideByZeroException"></exception>
        [RelayCommand]
        private void Calculate()
        {
        try
           {

        double answer;
        switch (mathOperator)
                {
        case "+":
        answer = MathUtil.Add(firstNumber, secondNumber);
        break;
       
        case "-":
        answer = MathUtil.Subtract(firstNumber, secondNumber);
        break;
                   
        case "×":
        answer = MathUtil.Multiply(firstNumber, secondNumber);
        break;
                
                   
        case "%":
                  if (currentState == Calculator.CurrentState.FirstNumber)
                  {
                      answer = MathUtil.Percentage(firstNumber);
                  }
                  else
                  {
                      answer = MathUtil.Percentage(secondNumber);
                  }

        break;
                   
        case "÷":
        // Second value cannot be = to 0. IF its not perform calculation else error.
        if (secondNumber != 0)
           {
              answer = MathUtil.Divide(firstNumber, secondNumber);
           }
        else
             {
              // Divided by 0
             throw new DivideByZeroException();
              }
         break;
         default:
         answer = 0;
         break;
         }


                // Updating equation and numbers label
                NumbersLabel = answer.ToString();
                EquationLabel = $"{firstNumber} {mathOperator} {secondNumber} = {answer}";

                // As per everything discussed in class and assignment, if two values are entered and a third operator
                //The firstNumber holds the calculated value (calculatedValueHolder) and the current state is set to firstNumber so user will enter the third number 
                // Which will be calculated as second number again.
                firstNumber = answer;
                currentState = CurrentState.FirstNumber;
            } catch(Exception)
            {
                Shell.Current.DisplayAlert("Error", "Cannot divide by 0", "Continue");
            }
            }


    }
}