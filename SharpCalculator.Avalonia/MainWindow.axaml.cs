using FusionCalculator;

namespace SharpCalculator.Avalonia;

public partial class MainWindow : Window
{
    private readonly Random Random = new();
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void AppendToHistory(string line) //function of appending expression to the history list
    {
        // begin new line if not empty
        if (!string.IsNullOrEmpty(History.Text))
            History.Text += '\n';
        /// add line without space characters
        History.Text += line
            .Replace("\t", " ")
            .Replace("\n", " ")
            .Replace("\r", " ")
            .Replace("  ", " ");
    }

    private void MathButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            throw new Exception();
        
        string buttonText = button.Content!.ToString()!; // declaring text for using it in switch case 
        Input.Text += buttonText switch
        {
            "rand" => // random number from 0 to 1 into Input 
                Random.NextDouble().ToString("0.#####", CultureInfo.InvariantCulture),
            "π" => // Pi constant
                "3.14159",
            "e" => // E constant
                "2.71828",
            "10^x" => // ten in power of x function 
                "10^",
            "1/x" => // one over x function
                "1/",
            "sin" or "cos" or "tg" or "ctg"
            or "asin" or "acos" or "atg" or "actg"
            or "ln" => buttonText+'(',
            _ => buttonText
        };
    }
    
    private void ClearButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Input.Text = "";
        Output.Text = "";
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
        if(Input.Text == null || Output.Text == null || Output.Text.StartsWith("Error"))
            return;
        string expression = Input.Text;
        string result = Output.Text;
        AppendToHistory($"{expression}={result}");
        Input.Text = result;
    }

    private void Input_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Input.Text == null)
            return;
        
        string exprStr = Input.Text; // mathematical expression
        try
        {
            // expression is being processed by Calculator class that implemented in FusionCalculator Module
            double result = Calculator.Calculate(exprStr);
            if (double.IsNaN(result))
                Output.Text = "";
            // scientific notation with 5-digit precision for big and small numbers
            else if (result > 10e+15 || result < 10e-5)
                Output.Text = result.ToString("0.#####E0", CultureInfo.InvariantCulture);
            // decimal number with 5-digit precision for regular numbers
            else Output.Text = result.ToString("0.#####", CultureInfo.InvariantCulture);
        }
        catch (Exception exception)
        {
            Output.Text = $"Error: {exception.Message}";
        }
    }
}