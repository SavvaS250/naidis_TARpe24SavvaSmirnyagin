namespace naidis_TARpe24SavvaSmirnyagin;

public partial class MainPage : ContentPage
{
    List<string> symbols =
    [
        "🍎","🍎",
        "🔥","🔥",
        "⚽","⚽",
        "🎮","🎮",
        "🐱","🐱",
        "🚗","🚗",
        "🎵","🎵",
        "🌙","🌙"
    ];

    List<Button> buttons = new();

    Button firstButton;
    Button secondButton;

    string firstSymbol;
    string secondSymbol;

    int score = 0;
    int currentTheme = 0;

    public MainPage()
    {
        InitializeComponent();

        Random rnd = new();
        symbols = symbols.OrderBy(x => rnd.Next()).ToList();

        CreateBoard();

        ApplyTheme();
    }

    void CreateBoard()
    {
        for (int i = 0; i < 4; i++)
        {
            GameGrid.RowDefinitions.Add(new RowDefinition());
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        int index = 0;

        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                Button btn = new()
                {
                    Text = "?",
                    FontSize = 30
                };

                string symbol = symbols[index];

                btn.Clicked += async (s, e) =>
                {
                    if (btn.Text != "?")
                        return;

                    btn.Text = symbol;

                    await btn.RotateYTo(360, 300);

                    if (firstButton == null)
                    {
                        firstButton = btn;
                        firstSymbol = symbol;
                    }
                    else
                    {
                        secondButton = btn;
                        secondSymbol = symbol;

                        if (firstSymbol == secondSymbol)
                        {
                            score++;

                            scoreLabel.Text = $"Score: {score}";

                            firstButton = null;
                            secondButton = null;

                            if (score == 8)
                            {
                                await DisplayAlert("Win", "You won the game!", "OK");
                            }
                        }
                        else
                        {
                            await Task.Delay(700);

                            firstButton.Text = "?";
                            secondButton.Text = "?";

                            firstButton = null;
                            secondButton = null;
                        }
                    }
                };

                buttons.Add(btn);

                GameGrid.Add(btn, col, row);

                index++;
            }
        }
    }

    void ApplyTheme()
    {
        if (currentTheme == 0)
        {
            BackgroundColor = Colors.White;

            scoreLabel.TextColor = Colors.Black;
        }
        else if (currentTheme == 1)
        {
            BackgroundColor = Colors.Black;

            scoreLabel.TextColor = Colors.White;
        }
        else
        {
            BackgroundColor = Colors.DarkMagenta;

            scoreLabel.TextColor = Colors.Yellow;
        }
    }

    void ThemeClicked(object sender, EventArgs e)
    {
        currentTheme++;

        if (currentTheme > 2)
            currentTheme = 0;

        ApplyTheme();
    }
   
    void RestartClicked(object sender, EventArgs e)
    {
        GameGrid.Children.Clear();
        GameGrid.RowDefinitions.Clear();
        GameGrid.ColumnDefinitions.Clear();

        score = 0;
        scoreLabel.Text = "Score: 0";

        firstButton = null;
        secondButton = null;

        Random rnd = new();
        symbols = symbols.OrderBy(x => rnd.Next()).ToList();

        CreateBoard();
    }


}
