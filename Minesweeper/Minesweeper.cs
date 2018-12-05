public class Solution {
    
    int rows;
    int cols;   
        
    int[] addRow = new int[8]{-1, -1, -1,  1, 1, 1, 0, 0};   
    int[] addCol = new int[8]{-1,  1,  0, -1, 0, 1, 1, -1};    
    
    public int CheckAllAdjacent(char[,] b, int r, int c, char ch){
        
        int count = 0;
        
        for (int i = 0; i < addRow.Length; i++){
            int newr = r + addRow[i];
            int newc = c + addCol[i];
            if (newr >= 0 && newr < rows && newc >= 0 && newc < cols && b[newr, newc] == ch){
                count++;
            }
        }
        return count;        
    }
    
    public void Reveal(char[,] b, int r, int c){
        
        if (b[r,c] != 'E'){
            return;
        }
        
        int m = CheckAllAdjacent(b, r, c, 'M');
        
        if (m == 0){
            b[r,c] = 'B';
       
            for (int i = 0; i < addRow.Length; i++){
                int newr = r + addRow[i];
                int newc = c + addCol[i];
                if (newr >= 0 && newr < rows && newc >= 0 && newc < cols){
                    Reveal(b, newr, newc);
                }
            }            
        }
        else{
            b[r,c] = m.ToString()[0];
        }        
    }
        
    public char[,] UpdateBoard(char[,] b, int[] click) {
        
        int r = click[0];
        int c = click[1];
                
        if (b[r,c] == 'M'){
            b[r,c] = 'X';
            return b;
        }   
        
        rows = b.GetLength(0);
        cols = b.GetLength(1);
        
        Reveal(b, r, c);
        
        return b;
        
    }
}
