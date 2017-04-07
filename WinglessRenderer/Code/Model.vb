Imports OpenTK

Class Model
#Region "Fields"
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
    'Public ReadOnly Tx As List(Of Single)
    Public TransformMatrix As Matrix4
#End Region

#Region "Ctor"
    Public Sub New()
        TransformMatrix = Matrix4.Identity
        _V = New List(Of Vertex)
        I = New List(Of UInteger)
    End Sub
    Public Sub New(Polygon As Polygon, ParamArray Color() As Color)
        Me.New
        Add(Polygon, Color)
    End Sub
    'Public Sub New(Polygon As Polygon, TexCoords() As Single)
    '    Me.New()
    '    Add(Polygon, TexCoords)
    'End Sub
#End Region


#Region "Add"
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

    'Public Sub Add(Polygon As Polygon, TexCoords() As Single)
    '    For j = 0 To Polygon.P.Count - 1
    '        _V.Add(New Vertex(Polygon.P(j), Color.Transparent))
    '        Tx.Add(TexCoords(j))
    '    Next
    'End Sub

#End Region
End Class
