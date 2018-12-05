public class Solution {
    
    IList<IList<string>> result = new List<IList<string>>();
    
    private void PutQueen(int r, int c, char[][] board, int[,] allowed, bool[] visitedCol, int numQueens, int n){
                
        board[r][c] = 'Q';
        visitedCol[c] = true;
        if (numQueens == n){
            List<string> list = new List<string>();
            for (int i = 0; i < n; i++){
                list.Add(new string(board[i]));
            }
            result.Add(list);
        }
        else{
            int[,] allowedCopy = new int[n,n];
            for (int i = 0; i < n; i++){
                for (int j = 0; j < n; j++){
                    allowedCopy[i,j] = allowed[i,j];

                }
            }

            int[] addRow = new int[4]{-1, -1, 1, 1};
            int[] addCol = new int[4]{-1,  1, -1, 1};

            for (int i = 0; i < 4; i++){
                int row = r;
                int col = c;
                while (row >= 0 && row < n && col >= 0 && col < n){
                    allowedCopy[row, col] = 1;
                    row += addRow[i];
                    col += addCol[i];
                }

            }   
                
            for (int j = 0; j < n; j++){                                   
                if (!visitedCol[j] && allowedCopy[r + 1,j] == 0){                       
                    PutQueen(r + 1, j, board, allowedCopy, visitedCol, numQueens + 1, n);                   
                }              
            }                   
        }
      
        board[r][c] = '.';       
        visitedCol[c] = false;
    }
    
    public IList<IList<string>> SolveNQueens(int n) {
        
        char[][] board = new char[n][];
        for (int i = 0; i < n; i++){
            board[i] = string.Empty.PadLeft(n, '.').ToCharArray();
        }
        
        int[,] allowed = new int[n,n];
        bool[] visitedCol = new bool[n];
                  
        for (int j = 0; j < n; j++){                                 
            PutQueen(0, j, board, allowed, visitedCol, 1, n);              
        }       
       
        return result;
    }
}
