using System;
using System.Globalization;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SharpCalculator.Avalonia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private double _rezult;
    private StringBuilder currentNumberB = new();

    private double CompleteCurrentNumber()
    {
        var n = double.Parse(currentNumberB.ToString(), CultureInfo.InvariantCulture);
        currentNumberB.Clear();
        return n;
    }

    private void UpdateOutput()
    {
        Output.Text = "= " + _rezult;
    }

    private Func<double, double, double> prevOperation = (_, firstN) => firstN;
    
    private void TryUpdateRezult(Func<double, double, double> operation, string text)
    {
        if (currentNumberB.Length > 0)
        {
            _rezult = prevOperation(_rezult, CompleteCurrentNumber());
            prevOperation = operation;
            Input.Text += " " + text + " ";
        }

        UpdateOutput();
    }

    private void NumberButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            throw new Exception();
        string text = button.Content?.ToString()!;
        Input.Text += text;
        currentNumberB.Append(text);
    }

    private void OperationButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            throw new Exception();
        string text = button.Content?.ToString()!;
        switch (text)
        {
            case "+":
                TryUpdateRezult((a, b) => a + b, text);
                break;
            case "-":
                TryUpdateRezult((a, b) => a - b, text);
                break;
            case "*":
                TryUpdateRezult((a, b) => a * b, text);
                break;
            case "/":
                TryUpdateRezult((a, b) => a / b, text);
                break;
            case "^":
                TryUpdateRezult(Math.Pow, text);
                break;
            case "=":
                TryUpdateRezult((a, _) => a, "");
                break;
            default:
                throw new Exception("incorrect button text: " + text);
        }
    }

    private void ClearButton_OnClick(object? sender, RoutedEventArgs e)
    {
        _rezult = 0;
        UpdateOutput();
        Input.Text = "";
    }
}