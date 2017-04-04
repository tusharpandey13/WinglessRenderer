Imports System.Math
Class Ellipse : Inherits Polygon
    Sub New()
        MyBase.New()
    End Sub
    Sub New(R As Rectangle, Optional n% = 360, Optional w! = 1)
        Me.New((R.X + R.Width) / 2, (R.Y + R.Height) / 2, R.Width / 2, R.Height / 2, n, w)
        R.Dispose()
    End Sub
    Sub New(cx!, cy!, rx!, ry!, Optional n% = 360, Optional w! = 1)
        Me.New()
        Dim tv As New List(Of Point)
        For i As Integer = 0 To n
            tv.Add(New Point(cx + (rx * Cos(i * 2 * PI / n)), cy + (ry * Sin(i * PI * 2 / n))))
        Next
        GenLines(tv, w)
    End Sub
End Class


Class CubicBezier : Inherits Polygon
    Dim A, B, C, D As Point
    Sub New()
    End Sub
    Sub New(BeginPt As Point, B As Point, C As Point, EndPt As Point, Optional w! = 1.0!)
        A = BeginPt
        Me.B = B
        Me.C = C
        D = EndPt
        calc(w)
    End Sub
    Private Function lerp(a As Point, b As Point, t!) As Point
        Return New Point(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t)
    End Function
    Private Function bezier(a As Point, b As Point, c As Point, d As Point, t!)
        Dim ab, bc, cd, abbc, bccd As Point
        ab = lerp(a, b, t)
        bc = lerp(b, c, t)
        cd = lerp(c, d, t)
        abbc = lerp(ab, bc, t)
        bccd = lerp(bc, cd, t)
        Return lerp(abbc, bccd, t)
    End Function
    Sub calc(w!)
        Dim tp As New List(Of Point)
        For j = 0 To 1000
            tp.Add(bezier(A, B, C, D, j / 1000))
        Next
        GenLines(tp, w, False)
    End Sub
End Class