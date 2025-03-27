// Ignore Spelling: Util App


//Jaspreet Gakhal 8542862 Section 4 
namespace CalculatorApp.Models
{

    /// <summary>
    /// Static class MathUtil responsible for handling math logic and operations
    /// All methods return a calculated value later used in CalculatorPageViewModel.cs
    /// </summary>
    public static class MathUtil
    {
        /// <summary>
        /// Not a void method so must return double value
        /// Static method Add to perform add calculation. Two double values FirstNumber and secondNumber. They are returning firstNumber + secondNumber
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        public static double Add(double firstNumber, double secondNumber) => firstNumber + secondNumber;

        /// <summary>
        /// Static double method returns a double value
        /// Method subtracts two values
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
      public static double Subtract(double firstNumber, double secondNumber) => firstNumber - secondNumber;

        /// <summary>
        /// Returns a double value
        /// Multiplies firstNumber by SecondNumber
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
       public static double Multiply(double firstNumber, double secondNumber) => firstNumber * secondNumber;
        /// <summary>
        /// Returns a double value. Divides first value by second value'
        /// Throws a divideByZero Exception when user tries dividing by 0.
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        /// <exception cref="DivideByZeroException"></exception>


        public static double Divide(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0)
                throw new DivideByZeroException();
            return firstNumber / secondNumber;
        }
        /// <summary>
        /// Percentage method. Returns a double value
        /// The value is multiplied by 0.01 to turn the value into a percentage calculation. Example 80 x 0.01 = 0.8 expressed as a decimal. Thus any value x 0.01 makes this button work
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Percentage(double value) => value * 0.01;
    }

 
}
