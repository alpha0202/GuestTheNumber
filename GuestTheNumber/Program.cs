string? player;
Random random = new Random();
int attempts = 0;
int highestScoreAttempts = 0;

Console.WriteLine("Guess the number!");

StartGame();



void StartGame()
{
    Console.WriteLine("Hello, Welcome to the Game.");
    Console.WriteLine("What´s your name?");

    player = Console.ReadLine();

    if (String.IsNullOrEmpty(player?.Trim()))
    {
        Console.WriteLine("please enter the name.");
        StartGame();
    }
    else
    {

        var randomNumber = random.Next(1, 10);
        WantToPlay(randomNumber);
    }



}



void WantToPlay(int randomNumber, bool playAgain = false)
{
    if (!playAgain)//validación si la persona decide volver a jugar despues de terminar el anterior juego
        Console.WriteLine($"hi {player}, are you ready to play? press (yes/no)");
    else
        Console.WriteLine($"{player}, are you ready to play again? press (yes/no)");


    var wantToPlay = Console.ReadLine();

    switch (wantToPlay?.ToLower().Trim())
    {
        case "yes":
            Play(randomNumber);
            break;
        case "no":
            DontPlay();
            break;

        default:
            Console.WriteLine("That is a incorrect option, please enter yes or no");
            WantToPlay(randomNumber);
            break;
    }

}



void Play(int randomNumber)
{
    int valor;
    bool result;


    try
    {
        Console.WriteLine("Pick a number between 1 and 10.");
        var pickedNumber = Console.ReadLine();
        result = int.TryParse(pickedNumber, out valor);

        if (result == false)
        {
            throw new Exception("Enter a number");
        }

        if (valor < 1 || valor > 10)
            throw new Exception("Please pick a number between 1 and 10.");

        //adivinar el número, despues de las validaciones.
        if (valor.Equals(randomNumber))
        {
            YouGuessed();
        }
        else if (valor < randomNumber)
        {
            Console.WriteLine("Try again! The number is higher...");
            attempts++;
            Play(randomNumber);
        }
        else if (valor > randomNumber)
        {
            Console.WriteLine("Try again! The number is lower...");
            attempts++;
            Play(randomNumber);
        }



    }
    catch (Exception ex)
    {
        Console.WriteLine($"There has been an error: {ex.Message} ");
        Play(randomNumber);
    }

}



void DontPlay()
{
    Console.WriteLine($"No worries!, have a good one!");
}


void YouGuessed()
{
    Console.WriteLine("Nice! You guessed the number!");
    attempts++;

    if (highestScoreAttempts == 0 || attempts < highestScoreAttempts)
        highestScoreAttempts = attempts;

    Console.WriteLine($"It has taken you {attempts} attempts to guess the number.");
    ShowScore();
    attempts = 0;

    var randomNumber = random.Next(1, 10);
    WantToPlay(randomNumber, true);

}


void ShowScore()
{
    if (highestScoreAttempts == 0)
        Console.WriteLine("There is currently no high score, it's your for the taking!");
    else
        Console.WriteLine($"The current high score {highestScoreAttempts} attempts");
}