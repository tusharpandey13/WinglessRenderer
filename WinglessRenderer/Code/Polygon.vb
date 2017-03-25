Imports System.Collections.Generic
Imports OpenTK

Class Polygon
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
        MyBase.New({New Point(x1, y1), New Point(x1 + w, y1 + 0), New Point(x2 + w, y2 + 0), New Point(x2, y2)})
    End Sub
End Class

Class Dot : Inherits Rectangle
    Sub New()
    End Sub
    Sub New(x!, y!)
        MyBase.New(x, y, 1, 1)
    End Sub
End Class