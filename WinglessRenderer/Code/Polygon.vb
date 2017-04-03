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

        If t >= 0 And t <= PI / 2 Then
            wx = w * (sgn(x1 - x2)) * Abs(Cos(t + PI / 2))
            wy = w * (-sgn(x1 - x2)) * Abs(Sin(t + PI / 2))
        ElseIf t < 0 And t >= -PI / 2 Then
            wx = w * (-sgn(x1 - x2)) * Abs(Cos(t + PI / 2))
            wy = w * (-sgn(x1 - x2)) * Abs(Sin(t + PI / 2))
        End If

        'wx = w * Cos(t + PI / 2)
        'wy = w * Sin(t + PI / 2)

        If Not Onesided Then
            P.AddRange({New Point(x1 - wx / 2, y1 - wy / 2), New Point(x1 + wx / 2, y1 + wy / 2), New Point(x2 + wx / 2, y2 + wy / 2), New Point(x2 - wx / 2, y2 - wy / 2)})
        Else
            P.AddRange({New Point(x1, y1), New Point(x1 + wx, y1 + wy), New Point(x2 + wx, y2 + wy), New Point(x2, y2)})
        End If
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