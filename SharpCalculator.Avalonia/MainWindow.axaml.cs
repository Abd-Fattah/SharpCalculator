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
        _currentOperation = _initialOperation;
        InitializeComponent();
    }

    private double _prevNumber;
    private StringBuilder _currentNumberB = new();

    private double ParseCurrentNumber() => double.Parse(_currentNumberB.ToString(), CultureInfo.InvariantCulture);

    readonly Func<double, double, double> _initialOperation = (_, firstN) => firstN;
    private Func<double, double, double> _currentOperation;
    
    private void NewOperation(Func<double, double, double> operation, Func<string> operationText)
    {
        // operation replacement
        if (_currentNumberB.Length == 0) 
            Input.Redo();
        else
        {
            _prevNumber = _currentOperation( _prevNumber, ParseCurrentNumber());
            Output.Text = _prevNumber.ToString(CultureInfo.InvariantCulture);
            _currentNumberB.Clear();
        }
        Input.Text += operationText();
        _currentOperation = operation;
    }

    private void NumberButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            throw new Exception();
        
        string text = button.Content!.ToString()!;
        Input.Text += text;
        _currentNumberB.Append(text);
        Output.Text = "= " + _currentOperation(_prevNumber, ParseCurrentNumber()).ToString(CultureInfo.InvariantCulture);
    }

    private void OperationButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            throw new Exception();
        string text = button.Content?.ToString()!;
        switch (text)
        {
            case "+":
                NewOperation((a, b) => a + b, () => text);
                break;
            case "-":
                NewOperation((a, b) => a - b, () => text);
                break;
            case "*":
                NewOperation((a, b) => a * b, () => text);
                break;
            case "/":
                NewOperation((a, b) => a / b, () => text);
                break;
            case "^":
                NewOperation(Math.Pow, () => text);
                break;
            case "=":
                NewOperation((_, newNumber) => newNumber, () => $"={_prevNumber}\n");
                break;
            default:
                throw new Exception("incorrect button text: ");
        }
    }

    private void ClearButton_OnClick(object? sender, RoutedEventArgs e)
    {
        _prevNumber = 0;
        _currentOperation = _initialOperation;
        _currentNumberB.Clear();
        Input.Text = "";
        Output.Text = "= 0";
    }
}