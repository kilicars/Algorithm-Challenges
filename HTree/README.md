An H-tree is a geometric shape that consists of a repeating pattern resembles the letter “H”.

It can be constructed by starting with a line segment of arbitrary length, drawing two segments of the same length at right angles to the first through its endpoints, and continuing in the same vein, reducing (dividing) the length of the line segments drawn at each stage.

Here is an example of an H-Tree of depth 2: ![depth_2](https://github.com/kilicars/Algorithm-Challenges/blob/master/HTree/htree_depth2.jpg)

And this is an example of an H-Tree of depth 5:![depth_5](https://github.com/kilicars/Algorithm-Challenges/blob/master/HTree/htree_depth5.jpg)

To test the program I created a Windows Forms application and called the DrawHTree function in the Paint event of the form as below:

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //DrawHTree(e.Graphics, 400, 200, 200, 2); Depth 2
            DrawHTree(e.Graphics, 400, 200, 200, 5); //Depth 5
        }
        
The images added above are the outputs of these calls.
