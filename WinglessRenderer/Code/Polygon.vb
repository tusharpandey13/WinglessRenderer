Imports OpenTK
Imports System.Math
Class Polygon : Implements IDisposable
    Public P As List(Of Point)
    Public I As List(Of UInteger)

    Sub New()
        P = New List(Of Point)
        I = New List(Of UInteger)
    End Sub
    Sub New(Points As IEnumerable(Of Point))
        Me.New()
        P.Clear()
        P.AddRange(Points)
        SetIndices()
        For Each p As Point In Points
            Console.WriteLine(p.ToString())
        Next
    End Sub
    Sub New(Polygon As Polygon)
        Me.New()
        Add(Polygon)
    End Sub
    Public Sub Add(Polygon As Polygon)
        For j = 0 To Polygon.I.Count - 1
            I.Add(P.Count + Polygon.I.Item(j))
        Next
        P.AddRange(Polygon.P)
    End Sub
    Protected Sub SetIndices()
        For j = 0 To P.Count - 3
            I.AddRange({CUInt(P.Count - 1), CUInt(j), CUInt(j + 1)})
        Next
    End Sub
    Public Sub Transform(TransformMatrix As Matrix4)
        Dim t As New List(Of Point)
        For Each pt As Point In P
            t.Add(pt * TransformMatrix)
        Next
        P = t
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        P.Clear() : P = Nothing
        I.Clear() : I = Nothing
    End Sub
End Class

Class Rectangle : Inherits Polygon
    Sub New()
    End Sub
    Sub New(x!, y!, w!, h!)
        MyBase.New({New Point(x, y), New Point(x + w, y), New Point(x + w, y + h), New Point(x, y + h)})
    End Sub
    Sub New(w!, h!)
        Me.New(0, 0, w, h)
    End Sub
End Class

Class Line : Inherits Polygon
    Sub New()
    End Sub
    Sub New(x1!, y1!, x2!, y2!, Optional w! = 1)
        Dim m = (y2 - y1) / (x2 - x1)
        Dim t = Atan(m)
        Dim wx!, wy!

        If t >= 0 And t <= PI / 2 Then
            wx = w * (sgn(x1 - x2)) * Abs(t) / PI * 2
            wy = w * (-sgn(x1 - x2)) * ((PI / 2) - Abs(t)) / PI * 2
        ElseIf t < 0 And t >= -PI / 2 Then
            wx = w * (-sgn(x1 - x2)) * Abs(t) / PI * 2
            wy = w * (-sgn(x1 - x2)) * ((PI / 2) - Abs(t)) / PI * 2
        End If

        P.AddRange({New Point(x1, y1), New Point(x1 + wx, y1 + wy), New Point(x2 + wx, y2 + wy), New Point(x2, y2)})
        SetIndices()
    End Sub
End Class

Class Dot : Inherits Rectangle
    Sub New()
    End Sub
    Sub New(x!, y!)
        MyBase.New(x, y, 1, 1)
    End Sub
End Class