Class Circle : Inherits Polygon
    Sub New()
        MyBase.New()
    End Sub
    Sub New(cx!, cy!, rx!, ry!, n%)
        Me.New()
        Dim s! = Math.Sin(Math.PI * 2 / n)
        Dim c! = Math.Cos(Math.PI * 2 / n)
        Dim t!
        Dim x! = 1
        Dim y! = 0
        Dim tv(n - 1, 2) As Single
        For ii = 0 To n - 1
            tv(ii, 0) = x * rx + cx
            tv(ii, 1) = y * ry + cy

            t = x
            x = c * x - s * y
            y = s * t + c * y
        Next
        For j = 0 To n - 2
            'Add(New Polygon({New Point(cx, cy), New Point(tv(j, 0), tv(j, 1)), New Point(tv(j + 1, 0), tv(j + 1, 1))}))
            Add(New Line(tv(j, 0), tv(j, 1), tv(j + 1, 0), tv(j + 1, 1)))
        Next

        'Add(New Polygon({New Point(cx, cy), New Point(tv(0, 0), tv(0, 1)), New Point(tv(n - 1, 0), tv(n - 1, 1))}))
        Add(New Line(tv(n - 1, 0), tv(n - 1, 1), tv(0, 0), tv(0, 1)))
    End Sub
End Class