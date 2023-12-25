using FusionCalculator;

namespace SharpCalculator.Avalonia;

public partial class MainWindow : Window
{
    private static readonly Random Random = new();
    private readonly List<string> _history = new(); // History list to append expressions
    
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
            History1.Text = _history[lastIndex];
        if (lastIndex - 1 >= 0) 
            History2.Text = _history[lastIndex - 1];
        if (lastIndex - 2 >= 0) 
            History3.Text = _history[lastIndex - 2];
    }

    private void MathButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            throw new Exception();
        
        switch (Input.Text) // Switch case for checking the inputting functions
        {
            case "rand": // rand function add random variable from 0 to 1 into Input 
                Input.Text = "";
                Input.Text += Random.NextDouble().ToString(CultureInfo.InvariantCulture);
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
    

    private void ClearButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Input.Text = "";
    }

    private void UndoButton_OnClick(object? sender, RoutedEventArgs e)
    {
        // delete last digit
        // if (!string.IsNullOrEmpty(Input.Text)) 
        //     Input.Text = Input.Text.Remove(Input.Text.Length - 1);
        Input.Undo();
    }
    
    private void ResultButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if(Input.Text == null)
            return;
        
        string exprStr = Input.Text; // mathematical expression
        try
        {
            double result = Calculator.Calculate(exprStr); // result being processed by calculator object that implemented in FusionCalculator Module
            if (!double.IsNaN(result))
            {
                AppendToHistory($"{exprStr} = {result}");
                Input.Text = result.ToString(CultureInfo.InvariantCulture);
            }
        }
        catch (Exception exception)
        {
            AppendToHistory($"Error: {exception.Message}");
        }
    }
}