using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuzzleManagement.Core.Enums;
using PuzzleManagement.Core.Models;

namespace PuzzleManagement.Tests.Models
{
    [TestClass]
    public class PuzzleTests
    {
        private string _log;
        private StringBuilder _logBuilder = new StringBuilder();

        [TestMethod]
        public void CreateNewEmptyPuzzleObject()
        {
            var emptyPuzzle = new EmptyPuzzle();
            Assert.IsInstanceOfType(emptyPuzzle, typeof(EmptyPuzzle));
            Assert.IsInstanceOfType(emptyPuzzle, typeof(Puzzle));
        }

        [TestMethod]
        public void CreateAnEmptyPuzzleFromGenerator()
        {
            var emptyPuzzle = new EmptyPuzzle();
            Assert.IsInstanceOfType(emptyPuzzle, typeof(EmptyPuzzle));
            Assert.IsInstanceOfType(emptyPuzzle, typeof(Puzzle));
            emptyPuzzle.CreatePuzzle();
            Assert.IsNotNull(emptyPuzzle.PuzzleArray);
            BuildLogString(emptyPuzzle.PuzzleArray);
            WriteLog();
            Assert.IsFalse(_log.Contains("0"));
        }

        [TestMethod]
        public void CreateAnEasyPuzzleFromGenerator()
        {
            var easyPuzzle = new EasyPuzzle();
            Assert.IsInstanceOfType(easyPuzzle, typeof(EasyPuzzle));
            Assert.IsInstanceOfType(easyPuzzle, typeof(Puzzle));
            easyPuzzle.CreatePuzzle();
            Assert.IsNotNull(easyPuzzle.PuzzleArray);
            BuildLogString(easyPuzzle.PuzzleArray);
            WriteLog();
            Assert.IsTrue(_log.Contains("0"));
            Assert.AreEqual((int)Difficulty.Easy, _log.Count(s => s == '0'));
        }

        [TestMethod]
        public void CreateAMediumPuzzleFromGenerator()
        {
            var mediumPuzzle = new MediumPuzzle();
            Assert.IsInstanceOfType(mediumPuzzle, typeof(MediumPuzzle));
            Assert.IsInstanceOfType(mediumPuzzle, typeof(Puzzle));
            mediumPuzzle.CreatePuzzle();
            Assert.IsNotNull(mediumPuzzle.PuzzleArray);
            BuildLogString(mediumPuzzle.PuzzleArray);
            WriteLog();
            Assert.IsTrue(_log.Contains("0"));
            Assert.AreEqual((int)Difficulty.Medium, _log.Count(s => s == '0'));
        }

        [TestMethod]
        public void CreateAHardPuzzleFromGenerator()
        {
            var hardPuzzle = new HardPuzzle();
            Assert.IsInstanceOfType(hardPuzzle, typeof(HardPuzzle));
            Assert.IsInstanceOfType(hardPuzzle, typeof(Puzzle));
            hardPuzzle.CreatePuzzle();
            Assert.IsNotNull(hardPuzzle.PuzzleArray);
            BuildLogString(hardPuzzle.PuzzleArray);
            WriteLog();
            Assert.IsTrue(_log.Contains("0"));
            Assert.AreEqual((int)Difficulty.Hard, _log.Count(s => s == '0'));
        }

        private void WriteLog()
        {
            Debug.WriteLine(_log);
        }


        private void BuildLogString(int[,] puzzle)
        {
            for(int i = 0; i < 9; i++)
                for(int j = 0; j < 9; j++)
                {
                    _logBuilder.Append(puzzle[i,j]);
                    _log = _logBuilder.ToString();
                }
        }
    }
}
