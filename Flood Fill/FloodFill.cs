public class Solution {
    
    int r;
    int c;
    
    public void ChangeColor(int[,] image, int i, int j, int oldColor, int newColor){
        
        if (i >= r || i < 0 || j >= c || j < 0 || image[i,j] != oldColor){
            return;
        }
        image[i,j] = newColor;

        ChangeColor(image, i - 1, j, oldColor, newColor);
        ChangeColor(image, i + 1, j, oldColor, newColor);
        ChangeColor(image, i, j - 1, oldColor, newColor);
        ChangeColor(image, i, j + 1, oldColor, newColor);
        
    }
    
    
    public int[,] FloodFill(int[,] image, int sr, int sc, int newColor) {
        
        int oldColor = image[sr, sc];
        
        if (oldColor != newColor){
            r = image.GetLength(0);
            c = image.GetLength(1);

            ChangeColor(image, sr, sc, oldColor, newColor);            
        }
        
        return image;
    }
}
