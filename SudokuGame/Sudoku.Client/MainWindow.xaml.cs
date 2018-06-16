using PuzzleManagement.Core.Enums;
using PuzzleManagement.Core.Factories;
using PuzzleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.GameViewModel();
            //var boxes = new TextBox[,]
            //    {
            //        {textBox00, textBox01, textBox02, textBox03, textBox04, textBox05, textBox06, textBox07, textBox08},
            //        {textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18},
            //        {textBox20, textBox21, textBox22, textBox23, textBox24, textBox25, textBox26, textBox27, textBox28},
            //        {textBox30, textBox31, textBox32, textBox33, textBox34, textBox35, textBox36, textBox37, textBox38},
            //        {textBox40, textBox41, textBox42, textBox43, textBox44, textBox45, textBox46, textBox47, textBox48},
            //        {textBox50, textBox51, textBox52, textBox53, textBox54, textBox55, textBox56, textBox57, textBox58},
            //        {textBox60, textBox61, textBox62, textBox63, textBox64, textBox65, textBox66, textBox67, textBox68},
            //        {textBox70, textBox71, textBox72, textBox73, textBox74, textBox75, textBox76, textBox77, textBox78},
            //        {textBox80, textBox81, textBox82, textBox83, textBox84, textBox85, textBox86, textBox87, textBox88}
            //    };

            //Puzzle = PuzzleFactory.GetPuzzle(Difficulty.Empty);
            //Puzzle.CreatePuzzle();
            //MapPuzzleToTextBoxes(boxes);
        }

        public Puzzle Puzzle { get; private set; }

        private void MapPuzzleToTextBoxes(TextBox[,] boxes)
        {
            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {
                    boxes[i, j].Text = Puzzle.PuzzleArray[i, j].ToString();
                    System.Diagnostics.Debug.Write(Puzzle.PuzzleArray[i, j].ToString());
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }

    }
}
