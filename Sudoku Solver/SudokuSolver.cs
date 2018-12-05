    public class Solution
    {

        private HashSet<char> ValidNumbers(char[,] board, int r, int c)
        {
            HashSet<char> hash = new HashSet<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int j = 0; j < 9; j++)
            {
                if (board[r, j] != '.')
                {
                    hash.Remove(board[r, j]);
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (board[i, c] != '.')
                {
                    hash.Remove(board[i, c]);
                }
            }
            int startRow = (r / 3) * 3;
            int startCol = (c / 3) * 3;
            for (int i = startRow; i < 9 && i <= startRow + 2; i++)
            {
                for (int j = startCol; j < 9 && j <= startCol + 2; j++)
                {
                    hash.Remove(board[i, j]);
                }
            }
            return hash;
        }

        private bool NextEmptyCell(char[,] board, int row, int col, out int nextRow, out int nextCol)
        {
            nextRow = -1;
            nextCol = -1;
            for (int j = col + 1; j < 9; j++)
            {
                if (board[row, j] == '.')
                {
                    nextRow = row;
                    nextCol = j;
                    return true;
                }
            }

            for (int i = row + 1; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    if (board[i, j] == '.')
                    {
                        nextRow = i;
                        nextCol = j;
                        return true;
                    }
            }
            return false;
        }

        private bool Dfs(char[,] board, int row, int col)
        {
            HashSet<char> numbers = ValidNumbers(board, row, col);
            if (!NextEmptyCell(board, row, col, out int nextRow, out int nextCol))
            {
                if (numbers.Count == 1)
                {
                    board[row, col] = numbers.ToList()[0];
                    return true;
                }
                else
                {
                    return false;
                }
            }

            foreach (var num in numbers)
            {
                board[row, col] = num;
                if (Dfs(board, nextRow, nextCol))
                {
                    return true;
                }
                board[row, col] = '.';
            }
            return false;
        }

        public void SolveSudoku(char[,] board)
        {
            if (board[0, 0] == '.')
            {
                Dfs(board, 0, 0);
            }
            else
            {
                NextEmptyCell(board, 0, 0, out int nextRow, out int nextCol);
                Dfs(board, nextRow, nextCol);
            }
        }
    }
