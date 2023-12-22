using System;
using System.Diagnostics;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Interactivity;
using FusionCalculator;

namespace SharpCalculator.Avalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MathButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            throw new Exception();
        string text = button.Content!.ToString()!;
        Input.Text += text;
    }

    private void ClearButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Input.Text = "";
        Output.Text = "";
    }

    private void Input_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Input.Text == null)
            return;
        string exprStr = Input.Text;
        try
        {
            double rezult = Calculator.Calculate(exprStr);
            if(!double.IsNaN(rezult))
                Output.Text = rezult.ToString(CultureInfo.InvariantCulture);
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception.ToString());
        }
    }
}