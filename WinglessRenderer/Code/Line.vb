Imports System.Math
Class Line : Inherits Polygon
    Sub New()
    End Sub
    Sub New(pt1 As Point, pt2 As Point, Optional w! = 1, Optional Onesided As Boolean = False)
        Me.New(pt1.X, pt1.Y, pt2.X, pt2.Y, w, Onesided)
    End Sub
    Sub New(x1!, y1!, x2!, y2!, Optional w! = 1, Optional Onesided As Boolean = False)

        Dim m = (y2 - y1) / (x2 - x1)
        Dim t = Atan(m)
        Dim wx!, wy!

        wx = Abs((w * Sin(t)) ^ 2)
        wy = Abs((w * Cos(t)) ^ 2)


        wx *= sgn(t) * (sgn(x1 - x2))
        wy *= (-sgn(x1 - x2))


        If Not Onesided Then
            P.AddRange({New Point(x1 - wx / 2, y1 - wy / 2), New Point(x1 + wx / 2, y1 + wy / 2), New Point(x2 + wx / 2, y2 + wy / 2), New Point(x2 - wx / 2, y2 - wy / 2)})
        Else
            P.AddRange({New Point(x1, y1), New Point(x1 + wx, y1 + wy), New Point(x2 + wx, y2 + wy), New Point(x2, y2)})
        End If
        SetIndices()
    End Sub
End Class
