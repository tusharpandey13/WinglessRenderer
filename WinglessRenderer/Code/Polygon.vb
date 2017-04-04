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
    Protected Sub GenLines(pts As List(Of Point), w!, Optional joinends As Boolean = True, Optional onesided As Boolean = False)
        For ii = 0 To pts.Count - 2
            Add(New Line(pts(ii), pts(ii + 1), w))
        Next
        If joinends Then Add(New Line(pts(pts.Count - 1), pts(0), w, onesided))
    End Sub
End Class

Class Rectangle : Inherits Polygon

#Region "Props"
    Private _x!, _y!, _w!, _h!
    Dim _tm As Matrix4 = Matrix4.Identity

    Public Property X!
        Get
            Return _x
        End Get
        Set(value!)
            _x = value
            setpoints()
        End Set
    End Property
    Public Property Y!
        Get
            Return _y
        End Get
        Set(value!)
            _y = value
            setpoints()
        End Set
    End Property
    Public Property Width!
        Get
            Return _w
        End Get
        Set(value!)
            _w = value
            setpoints()
        End Set
    End Property
    Public Property Height!
        Get
            Return _h
        End Get
        Set(value!)
            _h = value
            setpoints()
        End Set
    End Property

    ''' <summary>
    ''' Replaces the Transformation Matrix for this rectangle and applies the transformation.
    ''' </summary>
    ''' <returns></returns>
    Public Property TrnasformationMatrix As Matrix4
        Get
            Return _tm
        End Get
        Set(value As Matrix4)
            _tm = value
            Transform(_tm)
        End Set
    End Property
#End Region

#Region "Ctor"
    Sub New()
        MyBase.New()
    End Sub
    Sub New(x!, y!, w!, h!)
        MyBase.New()
        _x = x
        _y = y
        _w = w
        _h = h
        setpoints()
    End Sub
    Sub New(w!, h!)
        Me.New(0, 0, w, h)
    End Sub
    Sub New(R As System.Drawing.Rectangle)
        Me.New(R.X, R.Y, R.Width, R.Height)
    End Sub
#End Region

    Private Sub setpoints()
        P.Clear()
        P.AddRange({New Point(_x, _y), New Point(_x + _w, _y), New Point(_x + _w, _y + _h), New Point(_x, _y + _h)})
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