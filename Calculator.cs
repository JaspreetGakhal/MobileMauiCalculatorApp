// Ignore Spelling: App


// Jaspreet Gakhal 8542862 Section 4
namespace CalculatorApp.Models
{


    /// <summary>
    /// Public Class Calculator
    /// </summary>
    public class Calculator
    {

        /// <summary>
        /// FirstNumber, SecondNumber, MathOpp, Result, Equation, and CurrentState is set.
        /// </summary>
        public double FirstNumber { get; set; } 
        public double SecondNumber { get; set; } 

        public string? MathOperator { get; set; } 
        public string? Result { get; set; } 
        public string? Equation { get; set; } 
        public CurrentState CurrState { get; set; }


        /// <summary>
        /// Enum as instructed to manage the state of FirstNumber and SecondNumber to perform calculations. ( 3 numbers) 
        /// </summary>
        public enum CurrentState
        {
            FirstNumber,
            SecondNumber,
            CalculationDone
        }


    }


}

   
