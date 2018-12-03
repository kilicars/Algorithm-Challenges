        public void DrawLine(Graphics g, double x1, double y1, double x2, double y2)
        {
            Pen redPen = new Pen(Color.Red, 1);
            g.DrawLine(redPen, (float)x1, (float)y1, (float)x2, (float)y2);
        }
        public void DrawHTree(Graphics g, double x, double y, double length, int depth)
        {
            if (depth == 0)
            {
                return;
            }
            double newLength = length / 2;
                                           
            //middle of left line
            double xMiddleLeft = x - (length / 2);
            double yMiddleLeft = y;

            //top left corner 
            double xTopLeft = xMiddleLeft;
            double yTopLeft = yMiddleLeft + (length / 2);

            //bottom left corner 
            double xBottomLeft = xMiddleLeft;
            double yBottomLeft = yMiddleLeft - (length / 2);

            //middle of right line
            double xMiddleRight = x + (length / 2);
            double yMiddleRight = y;

            //top right corner 
            double xTopRight = xMiddleRight;
            double yTopRight = yMiddleRight + (length / 2);

            //bottom right corner 
            double xBottomRight = xMiddleRight;
            double yBottomRight = yMiddleRight - (length / 2);

            //Draw the left vertical line
            DrawLine(g, xTopLeft, yTopLeft, xBottomLeft, yBottomLeft);
            //Draw the right vertical line
            DrawLine(g, xTopRight, yTopRight, xBottomRight, yBottomRight);
            //Draw the horizontal line
            DrawLine(g, xMiddleLeft, yMiddleLeft, xMiddleRight, yMiddleRight);

            //Draw top left H tree
            DrawHTree(g, xTopLeft, yTopLeft, newLength, depth - 1);
            //Draw bottom left H tree
            DrawHTree(g, xBottomLeft, yBottomLeft, newLength, depth - 1);
            //Draw top right H tree
            DrawHTree(g, xTopRight, yTopRight, newLength, depth - 1);
            //Draw bottom right H tree
            DrawHTree(g, xBottomRight, yBottomRight, newLength, depth - 1);
        }
