using CalculatorApp;
using static System.Net.Mime.MediaTypeNames;
using CalculatorApp.ViewModels;

namespace CalculatorApp.Views;

// Jaspreet Gakhal 8542862 Section 4
public partial class CalculatorPage : ContentPage
{

	private readonly CalculatorPageViewModel viewModel;

	public CalculatorPage()
	{

		InitializeComponent();
		//Instantiating  CalcualatorPageViewModel
		viewModel = new CalculatorPageViewModel();
		//Data binding. Links ViewModel to view, instead of code behind view file
		BindingContext = viewModel;

    }
}

