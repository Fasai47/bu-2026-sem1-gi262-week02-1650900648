using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assignment
{
    public class Lecture : MonoBehaviour
    {
        void Start()
        {
            LCT01_SyntaxArray();
            LCT02_ArrayInitialize();
            LCT03_SyntaxLoop();
            LCT04_LoopAndArray();
            LCT05_Syntax2DArray();
            LCT06_SizeOf2DArray();
            LCT07_SyntaxNestedLoop();
        }

        #region Lecture

        public void LCT01_SyntaxArray()
        {
            string[] ironManSuit = new string[2];
            ironManSuit[0] = "Mark I";
            ironManSuit[1] = "Mark II";

            string currentSuit = ironManSuit[1];
            Debug.Log($"tonyStark Wear {currentSuit}");
            Debug.Log($"Room size {ironManSuit.Length}");

            Debug.Log(ironManSuit[0]);
            Debug.Log(ironManSuit[1]);
        }

        public void LCT02_ArrayInitialize()
        {
            string[] spidermanSuit = new string[] { "Classic", "Black Suit", "Iron Spider" };
            string[] batmanSuit = new string[2] { "Classic bat", "White bat" };

            Debug.Log($"Room size {spidermanSuit.Length}");
            for (int idx = 0; idx < spidermanSuit.Length; idx++)
            {
                Debug.Log(spidermanSuit[idx]);
            }

            Debug.Log($"Room size {batmanSuit.Length}");
            for (int idx = 0; idx < batmanSuit.Length; idx++)
            {
                Debug.Log(batmanSuit[idx]);
            }
        }

        public void LCT03_SyntaxLoop()
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("<10 : " + i);
            }

            Debug.Log("======================");

            for (int i = 1; i <= 10; i++)
            {
                Debug.Log("<=10 : " + i);
            }
        }

        [Header("LCT04_LoopAndArray")]
        public string[] lct04_ironManSuitNames = new string[] { "Mark I", "Mark II", "Mark III" };
        
        public void LCT04_LoopAndArray()
        {
            if (lct04_ironManSuitNames == null || lct04_ironManSuitNames.Length == 0) return;

            Debug.Log("====== Log by One incrementer ======");
            for (int i = 0; i < lct04_ironManSuitNames.Length; i++)
            {
                Debug.Log(lct04_ironManSuitNames[i]);
            }

            Debug.Log("====== Log by Two incrementer ======");
            for (int i = 0; i < lct04_ironManSuitNames.Length; i += 2)
            {
                Debug.Log(lct04_ironManSuitNames[i]);
            }
        }

        public void LCT05_Syntax2DArray()
        {
            int[,] my2DArray = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            for (int row = 0; row < my2DArray.GetLength(0); row++)
            {
                StringBuilder sb = new StringBuilder();
                for (int col = 0; col < my2DArray.GetLength(1); col++)
                {
                    sb.Append(my2DArray[row, col]).Append(" ");
                }
                Debug.Log(sb.ToString().TrimEnd());
            }
        }

        [Header("LCT06_SizeOf2DArray")]
        public Grid2DInt lct06_my2DArray = new Grid2DInt
        {
            rows = 3,
            cols = 5,
            data = new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 }
        };

        public void LCT06_SizeOf2DArray()
        {
            int[,] my2DArray = lct06_my2DArray.Get2DArray();
            int rows = my2DArray.GetLength(0);
            int cols = my2DArray.GetLength(1);

            Debug.Log($"rows = {rows}");
            Debug.Log($"cols = {cols}");
        }

        [Header("LCT07_SyntaxNestedLoop")]
        public int lct07_columns = 3;
        public int lct07_rows = 4;

        public void LCT07_SyntaxNestedLoop()
        {
            Debug.Log("Column ...");
            Debug.Log(lct07_columns);
            Debug.Log("Row ...");
            Debug.Log(lct07_rows);

            for (int r = 0; r < lct07_rows; r++)
            {
                StringBuilder line = new StringBuilder();
                for (int c = 0; c < lct07_columns; c++)
                {
                    line.Append("*");
                }
                Debug.Log(line.ToString());
            }
        }

        #endregion

        private void PrintBoard(string[,] board)
        {
            StringBuilder sb = new();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("-------------");
                sb.AppendLine("| " + board[i, 0] + " | " + board[i, 1] + " | " + board[i, 2] + " |");
            }
            sb.AppendLine("-------------");
            Debug.Log(sb.ToString());
        }
    }
}