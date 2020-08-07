The `BezierConnectedLines` sample shows how to draw a sequence of lines that connect through Bezier curves to give a smoother appearance to the connection points.
The algorithm processes the list of points in groups of 3 points (pt1, pt2, pt3), pt2 being the connection point for the lines (pt1,pt2) and (pt2,pt3). The algorithm replaces pt2 with 3 intermediary points that define the Bezier curve. A smooth factor (between 0 and 0.5) specifies how much of the line is replaced by the Bezier curve (0 means no Bezier curve, 0.5 means half of the line is replaced by the curve).
The algorithm returns 5 points for the first 3 points in the input list, points that define the start line, joining curve and end line. For the other groups of 3 points in the list it returns 4 points that define the joining curve and end line.
The image below shows the same set of lines connected through Bezier curves using various smooth factors.
![Bezier connected lines](https://github.com/o2solutions/pdf4net/tree/master/GettingStarted/BezierConnectedLines/BezierConnectedLines.gif)
 
