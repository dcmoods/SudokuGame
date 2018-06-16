using PuzzleManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.ApplicationLayer.Models
{
    public class GameBoard
    {
        public GameBoard(int[,] puzzleArray)
        {
            PuzzleArray = puzzleArray;
        }

        #region First Row of Cells

        public int[,] PuzzleArray { get; set; }

        public int Cell00
        {
            get { return PuzzleArray[0, 0]; }
            set { PuzzleArray[0, 0] = value; }
        }

        public int Cell01
        {
            get { return PuzzleArray[0, 1]; }
            set { PuzzleArray[0, 1] = value; }
        }

        public int Cell02
        {
            get { return PuzzleArray[0, 2]; }
            set { PuzzleArray[0, 2] = value; }
        }

        public int Cell03
        {
            get { return PuzzleArray[0, 3]; }
            set { PuzzleArray[0, 3] = value; }
        }

        public int Cell04
        {
            get { return PuzzleArray[0, 4]; }
            set { PuzzleArray[0, 4] = value; }
        }

        public int Cell05
        {
            get { return PuzzleArray[0, 5]; }
            set { PuzzleArray[0, 5] = value; }
        }

        public int Cell06
        {
            get { return PuzzleArray[0, 6]; }
            set { PuzzleArray[0, 6] = value; }
        }

        public int Cell07
        {
            get { return PuzzleArray[0, 7]; }
            set { PuzzleArray[0, 7] = value; }
        }

        public int Cell08
        {
            get { return PuzzleArray[0, 8]; }
            set { PuzzleArray[0, 8] = value; }
        }
        #endregion

        #region Second Row of Cells

        public int Cell10
        {
            get { return PuzzleArray[1, 0]; }
            set { PuzzleArray[1, 0] = value; }
        }

        public int Cell11
        {
            get { return PuzzleArray[1, 1]; }
            set { PuzzleArray[1, 1] = value; }
        }

        public int Cell12
        {
            get { return PuzzleArray[1, 2]; }
            set { PuzzleArray[1, 2] = value; }
        }

        public int Cell13
        {
            get { return PuzzleArray[1, 3]; }
            set { PuzzleArray[1, 3] = value; }
        }

        public int Cell14
        {
            get { return PuzzleArray[1, 4]; }
            set { PuzzleArray[1, 4] = value; }
        }

        public int Cell15
        {
            get { return PuzzleArray[1, 5]; }
            set { PuzzleArray[1, 5] = value; }
        }

        public int Cell16
        {
            get { return PuzzleArray[1, 6]; }
            set { PuzzleArray[1, 6] = value; }
        }

        public int Cell17
        {
            get { return PuzzleArray[1, 7]; }
            set { PuzzleArray[1, 7] = value; }
        }

        public int Cell18
        {
            get { return PuzzleArray[1, 8]; }
            set { PuzzleArray[1, 8] = value; }
        }
        #endregion

        #region Third Row of Cells

        public int Cell20
        {
            get { return PuzzleArray[2, 0]; }
            set { PuzzleArray[2, 0] = value; }
        }

        public int Cell21
        {
            get { return PuzzleArray[2, 1]; }
            set { PuzzleArray[2, 1] = value; }
        }

        public int Cell22
        {
            get { return PuzzleArray[2, 2]; }
            set { PuzzleArray[2, 2] = value; }
        }

        public int Cell23
        {
            get { return PuzzleArray[2, 3]; }
            set { PuzzleArray[2, 3] = value; }
        }

        public int Cell24
        {
            get { return PuzzleArray[2, 4]; }
            set { PuzzleArray[2, 4] = value; }
        }

        public int Cell25
        {
            get { return PuzzleArray[2, 5]; }
            set { PuzzleArray[2, 5] = value; }
        }

        public int Cell26
        {
            get { return PuzzleArray[2, 6]; }
            set { PuzzleArray[2, 6] = value; }
        }

        public int Cell27
        {
            get { return PuzzleArray[2, 7]; }
            set { PuzzleArray[2, 7] = value; }
        }

        public int Cell28
        {
            get { return PuzzleArray[2, 8]; }
            set { PuzzleArray[2, 8] = value; }
        }
        #endregion

        #region Fourth Row of Cells

        public int Cell30
        {
            get { return PuzzleArray[3, 0]; }
            set { PuzzleArray[3, 0] = value; }
        }

        public int Cell31
        {
            get { return PuzzleArray[3, 1]; }
            set { PuzzleArray[3, 1] = value; }
        }

        public int Cell32
        {
            get { return PuzzleArray[3, 2]; }
            set { PuzzleArray[3, 2] = value; }
        }

        public int Cell33
        {
            get { return PuzzleArray[3, 3]; }
            set { PuzzleArray[3, 3] = value; }
        }

        public int Cell34
        {
            get { return PuzzleArray[3, 4]; }
            set { PuzzleArray[3, 4] = value; }
        }

        public int Cell35
        {
            get { return PuzzleArray[3, 5]; }
            set { PuzzleArray[3, 5] = value; }
        }

        public int Cell36
        {
            get { return PuzzleArray[3, 6]; }
            set { PuzzleArray[3, 6] = value; }
        }

        public int Cell37
        {
            get { return PuzzleArray[3, 7]; }
            set { PuzzleArray[3, 7] = value; }
        }

        public int Cell38
        {
            get { return PuzzleArray[3, 8]; }
            set { PuzzleArray[3, 8] = value; }
        }
        #endregion

        #region Fifth Row of Cells

        public int Cell40
        {
            get { return PuzzleArray[4, 0]; }
            set { PuzzleArray[4, 0] = value; }
        }

        public int Cell41
        {
            get { return PuzzleArray[4, 1]; }
            set { PuzzleArray[4, 1] = value; }
        }

        public int Cell42
        {
            get { return PuzzleArray[4, 2]; }
            set { PuzzleArray[4, 2] = value; }
        }

        public int Cell43
        {
            get { return PuzzleArray[4, 3]; }
            set { PuzzleArray[4, 3] = value; }
        }

        public int Cell44
        {
            get { return PuzzleArray[4, 4]; }
            set { PuzzleArray[4, 4] = value; }
        }

        public int Cell45
        {
            get { return PuzzleArray[4, 5]; }
            set { PuzzleArray[4, 5] = value; }
        }

        public int Cell46
        {
            get { return PuzzleArray[4, 6]; }
            set { PuzzleArray[4, 6] = value; }
        }

        public int Cell47
        {
            get { return PuzzleArray[4, 7]; }
            set { PuzzleArray[4, 7] = value; }
        }

        public int Cell48
        {
            get { return PuzzleArray[4, 8]; }
            set { PuzzleArray[4, 8] = value; }
        }
        #endregion

        #region Sixth Row of Cells

        public int Cell50
        {
            get { return PuzzleArray[5, 0]; }
            set { PuzzleArray[5, 0] = value; }
        }

        public int Cell51
        {
            get { return PuzzleArray[5, 1]; }
            set { PuzzleArray[5, 1] = value; }
        }

        public int Cell52
        {
            get { return PuzzleArray[5, 2]; }
            set { PuzzleArray[5, 2] = value; }
        }

        public int Cell53
        {
            get { return PuzzleArray[5, 3]; }
            set { PuzzleArray[5, 3] = value; }
        }

        public int Cell54
        {
            get { return PuzzleArray[5, 4]; }
            set { PuzzleArray[5, 4] = value; }
        }

        public int Cell55
        {
            get { return PuzzleArray[5, 5]; }
            set { PuzzleArray[5, 5] = value; }
        }

        public int Cell56
        {
            get { return PuzzleArray[5, 6]; }
            set { PuzzleArray[5, 6] = value; }
        }

        public int Cell57
        {
            get { return PuzzleArray[5, 7]; }
            set { PuzzleArray[5, 7] = value; }
        }

        public int Cell58
        {
            get { return PuzzleArray[5, 8]; }
            set { PuzzleArray[5, 8] = value; }
        }
        #endregion

        #region Seventh Row of Cells

        public int Cell60
        {
            get { return PuzzleArray[6, 0]; }
            set { PuzzleArray[6, 0] = value; }
        }

        public int Cell61
        {
            get { return PuzzleArray[6, 1]; }
            set { PuzzleArray[6, 1] = value; }
        }

        public int Cell62
        {
            get { return PuzzleArray[6, 2]; }
            set { PuzzleArray[6, 2] = value; }
        }

        public int Cell63
        {
            get { return PuzzleArray[6, 3]; }
            set { PuzzleArray[6, 3] = value; }
        }

        public int Cell64
        {
            get { return PuzzleArray[6, 4]; }
            set { PuzzleArray[6, 4] = value; }
        }

        public int Cell65
        {
            get { return PuzzleArray[6, 5]; }
            set { PuzzleArray[6, 5] = value; }
        }

        public int Cell66
        {
            get { return PuzzleArray[6, 6]; }
            set { PuzzleArray[6, 6] = value; }
        }

        public int Cell67
        {
            get { return PuzzleArray[6, 7]; }
            set { PuzzleArray[6, 7] = value; }
        }

        public int Cell68
        {
            get { return PuzzleArray[6, 8]; }
            set { PuzzleArray[6, 8] = value; }
        }
        #endregion

        #region Eigth Row of Cells

        public int Cell70
        {
            get { return PuzzleArray[7, 0]; }
            set { PuzzleArray[7, 0] = value; }
        }

        public int Cell71
        {
            get { return PuzzleArray[7, 1]; }
            set { PuzzleArray[7, 1] = value; }
        }

        public int Cell72
        {
            get { return PuzzleArray[7, 2]; }
            set { PuzzleArray[7, 2] = value; }
        }

        public int Cell73
        {
            get { return PuzzleArray[7, 3]; }
            set { PuzzleArray[7, 3] = value; }
        }

        public int Cell74
        {
            get { return PuzzleArray[7, 4]; }
            set { PuzzleArray[7, 4] = value; }
        }

        public int Cell75
        {
            get { return PuzzleArray[7, 5]; }
            set { PuzzleArray[7, 5] = value; }
        }

        public int Cell76
        {
            get { return PuzzleArray[7, 6]; }
            set { PuzzleArray[7, 6] = value; }
        }

        public int Cell77
        {
            get { return PuzzleArray[7, 7]; }
            set { PuzzleArray[7, 7] = value; }
        }

        public int Cell78
        {
            get { return PuzzleArray[7, 8]; }
            set { PuzzleArray[7, 8] = value; }
        }
        #endregion

        #region Third Row of Cells

        public int Cell80
        {
            get { return PuzzleArray[8, 0]; }
            set { PuzzleArray[8, 0] = value; }
        }

        public int Cell81
        {
            get { return PuzzleArray[8, 1]; }
            set { PuzzleArray[8, 1] = value; }
        }

        public int Cell82
        {
            get { return PuzzleArray[8, 2]; }
            set { PuzzleArray[8, 2] = value; }
        }

        public int Cell83
        {
            get { return PuzzleArray[8, 3]; }
            set { PuzzleArray[8, 3] = value; }
        }

        public int Cell84
        {
            get { return PuzzleArray[8, 4]; }
            set { PuzzleArray[8, 4] = value; }
        }

        public int Cell85
        {
            get { return PuzzleArray[8, 5]; }
            set { PuzzleArray[8, 5] = value; }
        }

        public int Cell86
        {
            get { return PuzzleArray[8, 6]; }
            set { PuzzleArray[8, 6] = value; }
        }

        public int Cell87
        {
            get { return PuzzleArray[8, 7]; }
            set { PuzzleArray[8, 7] = value; }
        }

        public int Cell88
        {
            get { return PuzzleArray[8, 8]; }
            set { PuzzleArray[8, 8] = value; }
        }
        #endregion
    }
}
