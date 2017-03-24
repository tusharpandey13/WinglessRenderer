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