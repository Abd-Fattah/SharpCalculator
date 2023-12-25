// This implementation of the calculator using
// multi-translating programming language Fusion.
// The main logic was written on the Fusion, 
// then retranslated into c#, 'out' module in FusionCalculator
// is a translated c# code, that used by SharpCalculator module.
// If you want to dive into the logic of the calculator,
// you need to check 'out' folder in FusionCalculator module.

using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using FusionCalculator;

namespace SharpCalculator.Avalonia;

public partial class MainWindow : Window
{
    static Random _random = new(); // Random object for rand() function in calculator
    private int _currentIndex; // Current index for checking the length of input text, accordingly for clear Button Classes="cirlce"
    
    private List<string> _history = new();
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MathButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button) // Checking if button exist, if not throw Exception
            throw new Exception();

        string text; // declaring text for using it in switch case 
        
        ClearButton.Content = "AC"; // clear button content changing to Accurate Clear mode
        
        switch (Input.Text) // Switch case for checking the inputting functions
        {
            case "rand": // rand function add random variable from 0 to 1 into Input 
                Input.Text = "";
                Input.Text += _random.NextDouble().ToString(CultureInfo.InvariantCulture);
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
                text = button.Content!.ToString()!;
                Input.Text += text;
                break;
        }
    }

    private void ClearButton_OnClick(object? sender, RoutedEventArgs e)
    {
        // Checking the indexes and the emptiness of the input for clearing one by one
        if (Input.Text != "" && _currentIndex < Input.Text!.Length)
        {
            if ((string)ClearButton.Content! == "AC") // if clear button content equal to AC, clear one by one
            {
                Input.Text = Input.Text.Remove(_currentIndex, 1);
                _currentIndex++;
            }
            else if ((string)ClearButton.Content! == "C") // if clear button content equal to C, clear all
            {
                Input.Text = "";
            }
        }
        else
        {
            // Handle the case when there's no text or all characters are cleared
            _currentIndex = 0; // Reset the index for the next round
        }
    }
    
    private void ResultButton_OnClick(object? sender, RoutedEventArgs e)
    {
        History1.Foreground = new SolidColorBrush(Colors.Gray);
        History2.Foreground = new SolidColorBrush(Colors.Gray);
        History3.Foreground = new SolidColorBrush(Colors.Gray);
        
        if(Input.Text == null) // checking Input for nullability 
            return;
        string exprStr = Input.Text; // expression variable, for print result
        try
        {
            double rezult = Calculator.Calculate(exprStr); // result being processed by calculator object that implemented in FusionCalculator Module
            if (!double.IsNaN(rezult))
            {
                Input.Text = rezult.ToString(CultureInfo.InvariantCulture);
                _history.Add(rezult.ToString(CultureInfo.InvariantCulture));
            }
        }
        catch (Exception exception)
        {
            Input.Text = "Error: "+exception.Message;
        }
        
        // Display the calculation history in the three TextBlocks
        if (_history.Count > 0)
            History1.Text = _history[0];
        if (_history.Count > 1)
            History2.Text = _history[1];
        if (_history.Count > 2)
            History3.Text = _history[2];

        ClearButton.Content = "C"; // if the expression is printed, then change clear button content ot C, for clearing expression totally
    }
}