// This implementation of the calculator using
// multi-translating programming language Fusion.
// The main logic was written on the Fusion, 
// then translated into c#, 'out' module in FusionCalculator
// is a translated c# code, that used by SharpCalculator module.
// If you want to dive into the logic of the calculator,
// you need to check 'out' folder in FusionCalculator module.

using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Interactivity;
using FusionCalculator;
using Avalonia.Media;


namespace SharpCalculator.Avalonia;

public partial class MainWindow : Window
{
    private static readonly Random Random = new Random(); // Random object for rand() function in calculator
    private readonly double _randomNumber = Random.NextDouble(); // Random variable is between 0 to 1
    private readonly List<string> _history = new List<string>(); // History list to append expressions
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void AppendToHistory(string calculation) //function of appending expression to the history list
    {
        _history.Add(calculation);
        UpdateHistoryText();
    }

    private void UpdateHistoryText() //function to update history list 
    {
        int lastIndex = _history.Count - 1;

        if (lastIndex >= 0)
        {
            History1.Text = _history[lastIndex];
        }

        if (lastIndex - 1 >= 0)
        {
            History2.Text = _history[lastIndex - 1];
        }

        if (lastIndex - 2 >= 0)
        {
            History3.Text = _history[lastIndex - 2];
        }
    }

    private void MathButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button) // Checking if button exist, if not throw Exception
            throw new Exception();

        
        
        ClearButton.Content = "AC"; // clear button content changing to Accurate Clear mode
        
        switch (Input.Text) // Switch case for checking the inputting functions
        {
            case "rand": // rand function add random variable from 0 to 1 into Input 
                Input.Text = "";
                Input.Text += _randomNumber.ToString(CultureInfo.InvariantCulture);
                break;
            case "π": // Pi function add pi value into Input
                Input.Text = "";
                Input.Text += "3.1415";
                break;
            case "e": // euler function add e value into Input
                Input.Text = "";
                Input.Text += "2.71828";
                break;
            case "10^x": // ten in power of x function 
                Input.Text = "";
                Input.Text += "10^";
                break;
            case "1/x": // one over x function
                Input.Text = "";
                Input.Text += "1/";
                break;
            default: // if there is no function input, then just input Button content
                string text = button.Content!.ToString()!; // declaring text for using it in switch case 
                Input.Text += text;
                break;
        }
    }
    
    private void DeleteLastDigit() // function of deleting the digits and math operators one by one from right, like in real calculators
    {
        if (!string.IsNullOrEmpty(Input.Text))
        {
            Input.Text = Input.Text.Substring(0, Input.Text.Length - 1);
        }
    }

    private void ClearButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if ((string)ClearButton.Content! == "AC") // if clear button content equal to AC, clear one by one
        { 
            DeleteLastDigit();
        }
        else if ((string)ClearButton.Content! == "C") // if clear button content equal to C, clear all
        {
                Input.Text = "";
        }
    }
    
    private void ResultButton_OnClick(object? sender, RoutedEventArgs e)
    {
        History1.Foreground = new SolidColorBrush(Colors.Gray);
        History2.Foreground = new SolidColorBrush(Colors.Gray);
        History3.Foreground = new SolidColorBrush(Colors.Gray);

        string inputHistory = Input.Text!;
        
        if(Input.Text == null) // checking Input for nullability 
            return;
        string exprStr = Input.Text; // expression variable, for print result
        try
        {
            double result = Calculator.Calculate(exprStr); // result being processed by calculator object that implemented in FusionCalculator Module
            if (!double.IsNaN(result))
            {
                Input.Text = result.ToString(CultureInfo.InvariantCulture);
                AppendToHistory($"{inputHistory} = {result}");
            }
        }
        catch (Exception exception)
        {
            Input.Text = "Error";
            AppendToHistory($"Error: {exception.Message}");
        }

        ClearButton.Content = "C"; // if the expression is printed, then change clear button content ot C, for clearing expression totally
    }
}