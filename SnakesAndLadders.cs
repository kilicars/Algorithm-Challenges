public class Solution {
    public int SnakesAndLadders(int[][] board) {
        
        int n = board.GetLength(0);              
        int total = n * n + 1;        
        int[] map = new int[total];       
        bool[] visited = new bool[total];
        Queue<int> q = new Queue<int>();
        //Map each square number to its value in the grid
        int start = 1;
        for (int i = n - 1, row = 0; i >= 0; i--, row++){
            if (row % 2 == 0){
                for (int j = 0; j < n; j++, start++){
                    map[start] = board[i][j];
                }                
            }
            else{
                for (int j = n - 1; j >= 0; j--, start++){
                    map[start] = board[i][j];
                }                
            }
        }
        //Calculate the shortest path using BFS
        q.Enqueue(1);
        visited[1] = true;
        for (int level = 0; q.Count > 0; level++){
            int size = q.Count;
            for (int i = 0; i < size; i++){
                int u = q.Dequeue();
                if (u == total - 1){
                    return level;
                }
                for (int j = 1; u + j < total && j <= 6; j++){
                    int v = u + j;
                    int y = map[v] == -1 ? v : map[v];
                    if (!visited[y]){
                        q.Enqueue(y);
                        visited[y] = true;
                    }                    
                }
            }
        }
        return -1;
    }
}
//Time complexity : O(n^2)
//Space complexity : O(n^2)
