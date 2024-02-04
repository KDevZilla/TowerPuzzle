﻿using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TowerPuzzle;
using static TowerPuzzle.Board;

namespace SkycraperTest
{
    [TestClass]
    public class IntegrateTest
    {

        private Boolean HasInitial = false;
        TowerPuzzle.Board OriginalBoard = null;
        int[,] arr2d = {
                    {3,2,1,4 },
                    {2,3,4,1 },
                    {4,1,2,3 },
                    {1,4,3,2 }
                };
        private void Initial()
        {
            if (HasInitial)
            {
                return;
            }


            Board.ManualGenerator manualGenerator = new Board.ManualGenerator(arr2d);

            //Kakurasu.KakurasuBoard.ManualGenerator manualGenerator = new KakurasuBoard.ManualGenerator(list);
            OriginalBoard = new Board(4, 4, manualGenerator);
            OriginalBoard.GenerateBoard();

            HasInitial = true;
        }
        [TestMethod]
        public void CheckCreateBoard()
        {
            Initial();


            Board Board2 = OriginalBoard.Clone();

            Assert.IsTrue(!Board2.IsFinshed);

            int i;
            int j;
            //The Correct Value
            for (i = 0; i < arr2d.GetUpperBound(0); i++)
            {
                for (j = 0; j < arr2d.GetUpperBound(1); j++)
                {

                    Assert.IsTrue(Board2.CorrectCellvalueMatrix[i, j] == arr2d[i, j], String.Format("{0},{1}", i, j));
                }
            }
            //Inital Value must be 0
            for (i = 0; i < arr2d.GetUpperBound(0); i++)
            {
                for (j = 0; j < arr2d.GetUpperBound(1); j++)
                {

                    Assert.IsTrue(Board2[i, j] == 0);
                }
            }

            int[] CorrectTopRow = { 2, 3, 2, 1 };
            int[] CorrectBottomRow = { 2, 1, 2, 3 };
            int[] CorrectRightRow = { 1, 2, 2, 3 };
            int[] CorrectLeftRow = { 2, 3, 1, 2 };
            for (i = 0; i < 4; i++)
            {
                Assert.IsTrue(Board2.DicCorrectAnswerlist[Board.Direction.Top][i] ==
                    CorrectTopRow[i]);

                Assert.IsTrue(Board2.DicCorrectAnswerlist[Board.Direction.Bottom][i] ==
                    CorrectBottomRow[i]);

                Assert.IsTrue(Board2.DicCorrectAnswerlist[Board.Direction.Right][i] ==
                    CorrectRightRow[i]);

                Assert.IsTrue(Board2.DicCorrectAnswerlist[Board.Direction.Left][i] ==
                    CorrectLeftRow[i]);

            }
            foreach (Direction dir in Board2.Directions)
            {
                for (i = 0; i < 4; i++)
                {
                    Assert.IsTrue(Board2.DicAnswerResultlist[dir][i] == AnswerResult.NotChooseYet);


                }
            }


        }

        [TestMethod]
        public void PutCell2()
        {
            int[,] arr2d = {
                    {3,2,1,4 },
                    {2,3,4,1 },
                    {4,1,2,3 },
                    {1,4,2,3 }
                };




                Board.ManualGenerator manualGenerator = new Board.ManualGenerator(arr2d);

                //Kakurasu.KakurasuBoard.ManualGenerator manualGenerator = new KakurasuBoard.ManualGenerator(list);
                OriginalBoard = new Board(4, 4, manualGenerator);
                OriginalBoard.GenerateBoard();



                //Board Board2 = OriginalBoard.Clone();

                Board boardResult = OriginalBoard.Clone(); ;
            boardResult.EnterCellValue(new Position(3, 0), 1);
            boardResult.EnterCellValue(new Position(3, 1), 4);
         //   boardResult.EnterCellValue(new Position(3, 2), 3);
            boardResult.EnterCellValue(new Position(3, 3), 2);

            /*
                     int[,] arr2d = {
                    {3,2,1,4 },
                    {2,3,4,1 },
                    {4,1,2,3 },
                    {1,4,3,2 }
                };
             */

            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Right][3] == AnswerResult.Correct );
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Left][3] == AnswerResult.Correct);
            //Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Top][1] == AnswerResult.SumIncorrect);
            //Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Bottom][1] == AnswerResult.SumIncorrect);



        }
        [TestMethod]
        public void PutCell()
        {
            Initial();

           
            Board Board2 = OriginalBoard.Clone();
            int[,] arrInvalidPoition = {
                {-1,-1},
                {-1,1},
                {0,5 },
                {0,6 },

            };
            int i;
            Board boardResult = null;
            for (i = 0; i < arrInvalidPoition.GetUpperBound(0); i++)
            {
                Position InValidPosition = new Position(arrInvalidPoition[i, 0], arrInvalidPoition[i, 1]);
                boardResult = Board2.Clone();
                boardResult.EnterCellValue(InValidPosition, 2);
                Assert.IsTrue(Utility.IsBoardInputValueTheSame(Board2, boardResult));
            }
            int[] arrInvalidCellValue =
            {
                -1,
                5
            };
            for (i = 0; i < arrInvalidCellValue.GetUpperBound(0); i++)
            {
                Position ValidPosition = new Position(0,0);
                boardResult = Board2.Clone();
                boardResult.EnterCellValue(ValidPosition, arrInvalidCellValue [i]);
                Assert.IsTrue(Utility.IsBoardInputValueTheSame(Board2, boardResult));
            }
            /*
            Fin
            int[,] arr2d = {
            {3,2,1,4 },
            {2,3,4,1 },
            {4,1,2,3 },
            {1,4,3,2 }
             */
            boardResult = Board2.Clone();
            boardResult.EnterCellValue(new Position(0, 0), 3);
            boardResult.EnterCellValue(new Position(1, 0), 2);
            boardResult.EnterCellValue(new Position(2, 0), 4);
            boardResult.EnterCellValue(new Position(3, 0), 1);

            /*
            int[,] arr2d = {
            {3, , ,  },
            {2, , ,  },
            {4, , ,  },
            {1, , ,  }
            */
            Assert.IsTrue(boardResult[0, 0] == 3);
            Assert.IsTrue(boardResult[1, 0] == 2);
            Assert.IsTrue(boardResult[2, 0] == 4);
            Assert.IsTrue(boardResult[3, 0] == 1);

            Assert.IsTrue(boardResult.DicUserAnswerlist[Direction.Top][0] == 2);
            Assert.IsTrue(boardResult.DicUserAnswerlist[Direction.Bottom][0] == 2);
            Assert.IsTrue(boardResult.DicUserAnswerlist[Direction.Left][0] == 1);
            Assert.IsTrue(boardResult.DicUserAnswerlist[Direction.Left][1] == 1);
            Assert.IsTrue(boardResult.DicUserAnswerlist[Direction.Left][2] == 1);
            Assert.IsTrue(boardResult.DicUserAnswerlist[Direction.Left][3] == 1);

           
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Top][0] == AnswerResult.Correct);
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Bottom][0] == AnswerResult.Correct);

            boardResult.EnterCellValue(new Position(0, 1), 2);
            boardResult.EnterCellValue(new Position(0, 2), 1);
            boardResult.EnterCellValue(new Position(0, 3), 4);
            /*
            int[,] arr2d = {
            {3, 2, 1, 4},
            {2,  ,  ,  },
            {4,  ,  ,  },
            {1,  ,  ,  }
            */
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Right][0] == AnswerResult.Correct);


            boardResult.EnterCellValue(0, 1, 3);
            /*
            int[,] arr2d = {
            {3, 3, 1, 4},
            {2,  ,  ,  },
            {4,  ,  ,  },
            {1,  ,  ,  }
            */
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Right][0] == AnswerResult.UniqueIncorrect);
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Left][0] == AnswerResult.UniqueIncorrect);

            boardResult.EnterCellValue(1, 0, 3);
            /*
            int[,] arr2d = {
            {3, 3, 1, 4},
            {3,  ,  ,  },
            {4,  ,  ,  },
            {1,  ,  ,  }
            */
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Top][0] == AnswerResult.UniqueIncorrect);
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Bottom][0] == AnswerResult.UniqueIncorrect);

            boardResult.EnterCellValue(1, 0, 2);
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Top][0] == AnswerResult.Correct );
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Bottom][0] == AnswerResult.Correct);

            boardResult.EnterCellValue(0, 1, 2);
            /*
            int[,] arr2d = {
            {3, 2, 1, 4},
            {2,  ,  ,  },
            {4,  ,  ,  },
            {1,  ,  ,  }
            */
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Right][0] == AnswerResult.Correct);
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Left][0] == AnswerResult.Correct);

            /*
            int[,] arr2d = {
            {3, 2, 1, 4},
            {2,  ,  ,  },
            {4,  ,  ,  },
            {1,  ,  ,  }
            */
            boardResult.EnterCellValue(1, 1, 1);


            /*
            int[,] arr2d = {
               (2),(3),(2),(1)
            (2){3,  2, 1, 4},
            (3){2,  1 ,  , }(2),
            (1){4,  ,  ,  },
            (2){1,  ,  ,  }
            */

            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Right][1] == AnswerResult.Correct);
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Left][1] == AnswerResult.SumIncorrect);
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Top][1] == AnswerResult.SumIncorrect);
            Assert.IsTrue(boardResult.DicAnswerResultlist[Direction.Bottom][1] == AnswerResult.SumIncorrect);


            boardResult.EnterCellValue(1, 1, 3);
            boardResult.EnterCellValue(1, 2, 4);
            boardResult.EnterCellValue(1, 3, 1);

            boardResult.EnterCellValue(2, 1, 1);
            boardResult.EnterCellValue(2, 2, 2);
            boardResult.EnterCellValue(2, 3, 3);

            boardResult.EnterCellValue(3, 1, 4);
            boardResult.EnterCellValue(3, 2, 3);
            boardResult.EnterCellValue(3, 3, 2);
            /*
            Fin
            int[,] arr2d = {
            {3,2,1,4 },
            {2,3,4,1 },
            {4,1,2,3 },
            {1,4,3,2 }
            */
            foreach (Direction dir in Board2.Directions)
            {
                for (i = 0; i < 4; i++)
                {
                    Assert.IsTrue(Board2.DicAnswerResultlist[dir][i] == AnswerResult.Correct);
                }
            }
            Assert.IsTrue(boardResult.IsFinshed);

           

        }

    }
}
