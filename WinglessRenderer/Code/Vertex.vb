Imports System.Collections.Generic
Imports OpenTK
Imports OpenTK.Graphics


Friend Structure Vertex
    Public Shared ReadOnly Property Size As Integer
        Get
            Return Vector3.SizeInBytes + System.Runtime.InteropServices.Marshal.SizeOf(New Color4)
        End Get
    End Property

    Public Position As Vector3
    Public Color As Color4
    Public ReadOnly Property Point As Point
        Get
            Return New Point(Position)
        End Get
    End Property
    Public Sub New(Position As Point, Color As Color)
        Me.Position = Position.Vector3
        Me.Color = Color.Color4
    End Sub
    Public Sub New(ByVal position As Vector3, ByVal color As Color4)
        Me.Position = position
        Me.Color = color
    End Sub
    Public Shared Operator *(Vertex As Vertex, TransformMatrix As Matrix4) As Vertex
        Return New Vertex(New Point(Vertex.Position) * TransformMatrix, Vertex.Color)
    End Operator
End Structure



Class Model
    Public Property AntiAliased As Boolean = True
    Private _V As List(Of Vertex) : Public ReadOnly Property V As List(Of Vertex)
        Get
            Dim t As New List(Of Vertex)
            For Each vx As Vertex In _V
                t.Add(vx * TransformMatrix)
            Next
            Return t
            'Return _V
        End Get
    End Property
    Public ReadOnly I As List(Of UInteger)
    Public TransformMatrix As Matrix4

    Public Sub New()
        TransformMatrix = Matrix4.Identity
        _V = New List(Of Vertex)
        I = New List(Of UInteger)
    End Sub
    Public Sub New(Polygon As Polygon, ParamArray Color() As Color)
        Me.New
        Add(Polygon, Color)
    End Sub
    Public Sub Add(Polygon As Polygon, ParamArray c() As Color)
        Dim tc As New List(Of Color)
        If c.Length < Polygon.P.Count Then
            For j = 0 To c.Length - 1
                tc.Add(c(j))
            Next
            For l = c.Length To Polygon.P.Count - 1
                tc.Add(c(c.Length - 1))
            Next
        Else
            tc.AddRange(c)
        End If


        If AntiAliased Then
            Dim w! = 1
            Dim a As Byte = 50
            For j = 0 To Polygon.P.Count - 2
                _add(New Line(Polygon.P(j).X, Polygon.P(j).Y, Polygon.P(j + 1).X, Polygon.P(j + 1).Y, w, 1), {Col(a, tc(j)), Col(0, tc(j)), Col(0, tc(j + 1)), Col(a, tc(j + 1))})
            Next
            _add(New Line(Polygon.P(Polygon.P.Count - 1).X, Polygon.P(Polygon.P.Count - 1).Y, Polygon.P(0).X, Polygon.P(0).Y, w, 1), {Col(a, tc(Polygon.P.Count - 1)), Col(0, tc(Polygon.P.Count - 1)), Col(0, tc(0)), Col(a, tc(0))})
        End If
        _add(Polygon, tc)
    End Sub

    Private Sub _add(Polygon As Polygon, Color As IEnumerable(Of Color))
        For k = 0 To Polygon.I.Count - 1
            I.Add(CUInt(_V.Count + Polygon.I.Item(k)))
        Next
        For j = 0 To Polygon.P.Count - 1
            _V.Add(New Vertex(Polygon.P(j), Color(j)))
        Next
    End Sub

End Class

