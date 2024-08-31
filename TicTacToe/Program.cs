// See https://aka.ms/new-console-template for more information

internal class TicTacToe
{
    public static char playerSignature = ' ';

    static int turns = 0; 

    static char[] ArrBoard = {'1', '2', '3','4', '5', '6','7', '8', '9'}; 



    public static void BoardReset() 
    {
        char[] ArrBoardInitialize = {'1', '2', '3','4', '5', '6','7', '8', '9'};

        ArrBoard = ArrBoardInitialize;
        DrawBoard();
        turns = 0;
    }

    public static void DrawBoard()
    {
        Console.Clear();
        Console.WriteLine("  -------");
        Console.WriteLine("  |{0}|{1}|{2}|", ArrBoard[0], ArrBoard[1], ArrBoard[2]);
        Console.WriteLine("  -------");
        Console.WriteLine("  |{0}|{1}|{2}|", ArrBoard[3], ArrBoard[4], ArrBoard[5]);
        Console.WriteLine("  -------");
        Console.WriteLine("  |{0}|{1}|{2}|", ArrBoard[6], ArrBoard[7], ArrBoard[8]);
        Console.WriteLine("  -------");
    } //Draws the player board to terminal.  

    public static void Intro()
    {
        Console.WriteLine("Игра Крестики-нолики, для продолжения, нажмите любую кнопочку");
        Console.ReadKey();
        Console.Clear();
    } 
    static void Main()
    {
        int player = 2;
        int input = 0;
        bool inputCorrect = true;
        Intro();
        do 
        {
            if (player == 2)
            {
                player = 1;
                XorO(player, input);
            }
            else if (player == 1)
            {
                player = 2;
                XorO(player, input);
            }

            DrawBoard();
            turns++;

            WinCheck();

            if (turns == 10)
            {
                Draw();
            }
            do
            {
                Console.WriteLine("\nИгрок № {0}: Ваш ход", player);
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число!");
                }

                if ((input == 1) && (ArrBoard[0] == '1'))
                    inputCorrect = true;
                else if ((input == 2) && (ArrBoard[1] == '2'))
                    inputCorrect = true;
                else if ((input == 3) && (ArrBoard[2] == '3'))
                    inputCorrect = true;
                else if ((input == 4) && (ArrBoard[3] == '4'))
                    inputCorrect = true;
                else if ((input == 5) && (ArrBoard[4] == '5'))
                    inputCorrect = true;
                else if ((input == 6) && (ArrBoard[5] == '6'))
                    inputCorrect = true;
                else if ((input == 7) && (ArrBoard[6] == '7'))
                    inputCorrect = true;
                else if ((input == 8) && (ArrBoard[7] == '8'))
                    inputCorrect = true;
                else if ((input == 9) && (ArrBoard[8] == '9'))
                    inputCorrect = true;
                else
                {
                    Console.WriteLine("Неправильнный ввод.");
                    inputCorrect = false;
                }
            } while (!inputCorrect);
        } while (true);
    }
    public static void XorO(int player, int input)
    {
        if (player == 1) playerSignature = 'X';
        else if (player == 2) playerSignature = 'O';

        switch (input)
        {
            case 1: ArrBoard[0] = playerSignature; break;
            case 2: ArrBoard[1] = playerSignature; break;
            case 3: ArrBoard[2] = playerSignature; break;
            case 4: ArrBoard[3] = playerSignature; break;
            case 5: ArrBoard[4] = playerSignature; break;
            case 6: ArrBoard[5] = playerSignature; break;
            case 7: ArrBoard[6] = playerSignature; break;
            case 8: ArrBoard[7] = playerSignature; break;
            case 9: ArrBoard[8] = playerSignature; break;
        }
    }
    public static void WinCheck()
    {
        char[] playerSignatures = { 'X', 'O' };
        bool flag = false;
        foreach (char playerSignatue in playerSignatures)
        {
            if (((ArrBoard[0] == playerSignatue) && (ArrBoard[1] == playerSignatue) && (ArrBoard[2] == playerSignatue))
                || ((ArrBoard[3] == playerSignatue) && (ArrBoard[4] == playerSignatue) && (ArrBoard[5] == playerSignatue))
                || ((ArrBoard[6] == playerSignatue) && (ArrBoard[7] == playerSignatue) && (ArrBoard[8] == playerSignatue))) //horizontal
            {
                flag = true;
                Console.Clear();
                if (playerSignatue == 'O')
                    Console.WriteLine("Поздравляю с победой Игрока №1");
                else if (playerSignatue == 'X')
                    Console.WriteLine("Поздравляю с победой Игрока №2");
            }
            if (((ArrBoard[0] == playerSignatue) && (ArrBoard[3] == playerSignatue) && (ArrBoard[6] == playerSignatue))
                || ((ArrBoard[1] == playerSignatue) && (ArrBoard[4] == playerSignatue) && (ArrBoard[7] == playerSignatue))
                || ((ArrBoard[2] == playerSignatue) && (ArrBoard[5] == playerSignatue) && (ArrBoard[8] == playerSignatue))) // vertical
            {
                flag = true;
                Console.Clear();
                if (playerSignatue == 'O')
                    Console.WriteLine("Поздравляю с победой Игрока №1");
                else if (playerSignatue == 'X')
                    Console.WriteLine("Поздравляю с победой Игрока №2");
            }
            if (((ArrBoard[0] == playerSignatue) && (ArrBoard[4] == playerSignatue) && (ArrBoard[8] == playerSignatue))
                || ((ArrBoard[6] == playerSignatue) && (ArrBoard[4] == playerSignatue) && (ArrBoard[2] == playerSignatue))) // diagonal
            {
                flag = true;
                Console.Clear();
                if (playerSignatue == 'O')
                    Console.WriteLine("Поздравляю с победой Игрока №1");
                else if (playerSignatue == 'X')
                    Console.WriteLine("Поздравляю с победой Игрока №2");
            }
            if (flag)
            {
                Console.WriteLine($"Ходов затрачено: {turns}");
                Console.WriteLine("Для продолжения веселья нажми любой символ");
                Console.ReadKey();
                BoardReset();
                break;
            }
        }
    }
    public static void Draw()
    {
        {
            Console.WriteLine("Ничья, для продолжения нажмите любой символ");
            Console.ReadKey();
            BoardReset();
        }
    } 
}

