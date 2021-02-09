﻿using UnityEngine;
using System.Collections.Generic;


namespace MazeAndBall
{
    internal class MapGenerator
    {
        private int Rows;
        private int Columns;
        public genCell[,] map;
        public List<genCell> corridors;

        internal struct genCell
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public bool Visited { get; set; }
            public int Value { get; set; }
        }

        public MapGenerator(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            map = new genCell[Rows, Columns];
        }

        internal void ClearMap(ref genCell[,] M)
        {
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    if ((i % 2 != 0 && j % 2 != 0) && (i < Rows - 1 && j < Columns - 1))
                    {
                        M[i, j].Value = 0;
                    }
                    else
                    {
                        M[i, j].Value = -1;
                    }
                    M[i, j].Row = i;
                    M[i, j].Col = j;
                    M[i, j].Visited = false;
                }
            }
        }

        internal void RemoveWall(ref genCell[,] M)
        {
            genCell current = M[1, 1];
            current.Visited = false;
            Stack<genCell> stack = new Stack<genCell>();
            corridors = new List<genCell>();
            do
            {
                List<genCell> cells = new List<genCell>();

                int row = current.Row;
                int col = current.Col;

                if (row - 1 > 0 && !M[row - 2, col].Visited) cells.Add(M[row - 2, col]);
                if (col - 1 > 0 && !M[row, col - 2].Visited) cells.Add(M[row, col - 2]);
                if (row < Rows - 3 && !M[row + 2, col].Visited) cells.Add(M[row + 2, col]);
                if (col < Columns - 3 && !M[row, col + 2].Visited) cells.Add(M[row, col + 2]);

                if (cells.Count > 0)
                {
                    genCell selected = cells[Random.Range(0, cells.Count)];
                    RemoveCurrentWall(ref M, current, selected);
                    selected.Visited = true;
                    M[selected.Row, selected.Col].Value = 0;
                    M[selected.Row, selected.Col].Visited = true;
                    stack.Push(selected);
                    current = selected;
                }
                else
                {
                    current = stack.Pop();
                }
            } while (stack.Count > 0);
        }

        internal void RemoveCurrentWall(ref genCell[,] M, genCell current, genCell selected)
        {
            if (current.Row == selected.Row)
            {
                if (current.Col > selected.Col) { M[current.Row, current.Col - 1].Value = 0; }
                else { M[current.Row, selected.Col - 1].Value = 0; }
                corridors.Add(selected);
            }
            else
            {
                if (current.Row > selected.Row) { M[current.Row - 1, selected.Col].Value = 0; }
                else { M[selected.Row - 1, selected.Col].Value = 0; }
            }
        }
    }
}