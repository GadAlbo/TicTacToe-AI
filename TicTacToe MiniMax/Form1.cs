using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_MiniMax
{
    public partial class Form1 : Form
    {
        int TurnsCounter = 1; // Tell us what turn it is. we know there can only be 9.
        // Creastes a represating int array.
        // x is represanted by 1
        // o is represented by -1
        // empty spot is 0
        int[,] IntBoard = new int[3, 3];
        PictureBox[,] Board = new PictureBox[3, 3]; // The actual board.
       // int[,] IntBoardTest= new int[3, 3] { { -1, 1, 1 }, { -1, 1, 1 }, { 0, 1, 0 } }; // a board i use for testing bugs.

        public Form1()
        {
            InitializeComponent();

            // fill the represantative its board with 0 = empty space.
            for (int a = 0; a < 3; a++)          
                for (int b = 0; b < 3; b++)
                    IntBoard[a, b] = 0;


            // Build the board
            for (int a = 0; a < 3; a++)
                for (int b = 0; b < 3; b++)
                {
                    Board[a, b] = new PictureBox();
                    Board[a, b].Size= new Size(60, 60);
                    Board[a, b].BackColor = Color.White;
                    Board[a, b].Location= new Point(30 + a*66, 70 + b*66);
                    Board[a, b].Click += Form1_Click;
                    this.Controls.Add(Board[a, b]);
                }
        } //Game load

        private void Form1_Click(object sender, EventArgs e)
        {
            PictureBox Sender = (PictureBox) sender ;

            // Get the matrix x and y cordinates using the senders location.
            int b = (Sender.Location.X - 30) / 66;
            int a = (Sender.Location.Y - 70) / 66;
            Sender.BackgroundImageLayout = ImageLayout.Stretch;

            if (IntBoard[a, b] == 0)
            {
                if (TurnsCounter % 2 != 0) // Human's turn
                {
                    IntBoard[a, b] = 1;
                    Sender.BackgroundImage = Properties.Resources.X_tictactoe;
                    if (GameOver(a, b)) { MessageBox.Show("X WON! lets play again..."); Application.Restart(); } //checks for a win
                    TurnsCounter++;
                    AImove();
                }
                else // AI's turn
                {
                    IntBoard[a, b] = -1;
                    Sender.BackgroundImage = Properties.Resources.O_tictactoe;
                    TurnText.Text = "YOUR TURN";
                    if (GameOver(a, b)) { MessageBox.Show("O WON! lets play again..."); Application.Restart(); }
                    TurnsCounter++;
                }
            }  
        } // A function that is called when your click (make a move).

        /*
        function that determins if someone won the game
        X won: returns true
        O won: returns true
        undetermind: returns false
        */
        public bool GameOver(int a, int b)
        {
            if (IntBoard[0, b] == IntBoard[1, b] && IntBoard[1, b] == IntBoard[2, b] && IntBoard[0, b] != 0)
                return true;
            if (IntBoard[a, 0] == IntBoard[a, 1] && IntBoard[a, 1] == IntBoard[a, 2] && IntBoard[a, 0] != 0)
                return true;
            if (IntBoard[0, 0] == IntBoard[1, 1] && IntBoard[1, 1] == IntBoard[2, 2] && IntBoard[0, 0] != 0)
                return true;
            if (IntBoard[0, 2] == IntBoard[1, 1] && IntBoard[1, 1] == IntBoard[2, 0] && IntBoard[0, 2] != 0)
                return true;

            return false;
        } // A function that check if someone won the game by cheking rows, colomns and diagonals

        public void AImove()
        {
            // AI to make its turn
            int bestScore = -100;
            int[] move = new int[2];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Is the spot available?
                    if (IntBoard[i, j] == 0)
                    {
                        IntBoard[i, j] = -1;
                        int score = minimax(IntBoard, TurnsCounter + 1, i, j);
                        IntBoard[i, j] = 0;
                        if (score > bestScore)
                        {
                            bestScore = score;
                            move[0] = j;
                            move[1] = i;
                        }
                    }
                }
            }
            if (TurnsCounter != 10) Form1_Click(Board[move[0], move[1]], null); // Checks that the game didt end to make sure its not a tie
            else { MessageBox.Show("its a tie! lets play again..."); Application.Restart(); } // if its a tie
        
        }

        public int minimax(int [,] board, int counter, int i, int j)
        {
            
            if (GameOver(i,j))
            {
                if (counter % 2 != 0)
                    return 1;
                else return -1;

            }
            if (counter == 10) return 0;

            if (counter % 2 == 0)
            {
                int bestScore = -100;
                for (int a = 0; a < 3; a++)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        // Is the spot available?
                        if (board[a,b] == 0)
                        {
                            board[a, b] = -1;
                            int score = minimax(board, counter+1,a,b);
                            board[a, b] = 0;
                            bestScore = Math.Max(score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = 100;
                for (int a = 0; a < 3; a++)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        // Is the spot available?
                        if (board[a,b] == 0)
                        {
                            board[a, b] = 1;
                            int score = minimax(board, counter+1,a,b);
                            board[a, b] = 0;
                            bestScore = Math.Min(score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
        }
        
    }
}
