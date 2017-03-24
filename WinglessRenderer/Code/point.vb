Imports System
Imports System.Runtime.InteropServices
Imports OpenTK

<StructLayout(LayoutKind.Sequential)> Structure Point : Implements IEquatable(Of Point)


#Region "Fields"
    Private _x!, _y!, _z!
    Public Property X!
        Get
            Return _x
        End Get
        Set(value!)
            _x = value
        End Set
    End Property
    Public Property Y!
        Get
            Return _y
        End Get
        Set(value!)
            _y = value
        End Set
    End Property
    Public Property Z!
        Get
            Return _z
        End Get
        Set(value!)
            _z = value
        End Set
    End Property
    Public ReadOnly Property Vector2 As Vector2
        Get
            Return New Vector2(X, Y)
        End Get
    End Property
    Public ReadOnly Property Vector3 As Vector3
        Get
            Return New Vector3(X, Y, Z)
        End Get
    End Property
#End Region


#Region "Ctor"
    Sub New(x!, y!)
        Me.X = x
        Me.Y = y
    End Sub
    Sub New(x!, y!, z!)
        Me.New(x, y)
        Me.Z = z
    End Sub
    Sub New(V As Vector2)
        X = V.X
        Y = V.Y
    End Sub
    Sub New(V As Vector3)
        X = V.X
        Y = V.Y
        Z = V.Z
    End Sub


#End Region


#Region "Functions"
    Public Overloads Function Equals(other As Point) As Boolean Implements IEquatable(Of Point).Equals
        Return X = other.X AndAlso Me.Y = other.Y AndAlso Me.Z = other.Z
    End Function
    Public Overrides Function Equals(obj As Object) As Boolean
        If ReferenceEquals(Nothing, obj) Then
            Return False
        End If
        Return TypeOf obj Is Point AndAlso Equals(CType(obj, Point))
    End Function
    Public Overrides Function ToString() As String
        Return "X:" + CStr(X) + " Y:" + CStr(Y) + " Z:" + CStr(Z)
    End Function
#End Region


#Region "Operators"
    ''' <summary>
    ''' Casts the Point to the equivalent <see cref="System.Drawing.Point"/>
    ''' </summary>
    ''' <param name="Point">The Point.</param>
    ''' <returns><see cref="System.Drawing.Point"/></returns>
    Public Shared Widening Operator CType(Point As Point) As System.Drawing.Point
        Return New Drawing.Point(CInt(Point.X), CInt(Point.Y))
    End Operator
    ''' <summary>
    ''' Casts the Point to the equivalent <see cref="OpenTK.Vector2"/>
    ''' </summary>
    ''' <param name="Point">The Point.</param>
    ''' <returns><see cref="OpenTK.Vector2"/></returns>
    Public Shared Widening Operator CType(Point As Point) As OpenTK.Vector2
        Return New Vector2(Point.X, Point.Y)
    End Operator
    ''' <summary>
    ''' Casts the Point to the equivalent <see cref="OpenTK.Vector3"/>
    ''' </summary>
    ''' <param name="Point">The Point.</param>
    ''' <returns><see cref="OpenTK.Vector3"/></returns>
    Public Shared Widening Operator CType(Point As Point) As OpenTK.Vector3
        Return New Vector3(Point.X, Point.Y, Point.Z)
    End Operator
    ''' <summary>
    ''' Compares two Points for equality.
    ''' </summary>
    Public Shared Operator =(Point1 As Point, Point2 As Point) As Boolean
        Return Point1.Equals(Point2)
    End Operator

    ''' <summary>
    ''' Compares two Points for inequality.
    ''' </summary>
    Public Shared Operator <>(Point1 As Point, Point2 As Point) As Boolean
        Return Not (Point1 = Point2)
    End Operator

    ''' <summary>
    ''' Multiplies all components of the Point by a given scalar.
    ''' Note that scalar values outside the range of 0 to 1 may result in overflow and cause unexpected results.
    ''' </summary>
    Public Shared Operator *(Point As Point, scalar As Single) As Point
        Return New Point(scalar * Point.X, scalar * Point.Y, scalar * Point.Z)
    End Operator

    ''' <summary>
    ''' Multiplies all components of the Point by a given scalar.
    ''' Note that scalar values outside the range of 0 to 1 may result in overflow and cause unexpected results.
    ''' </summary>
    Public Shared Operator *(scalar As Single, Point As Point) As Point
        Return Point * scalar
    End Operator

    Public Shared Operator *(Point As Point, TransformMatrix As Matrix4) As Point
        Return New Point(
                            TransformMatrix.M11 * Point.X +
                            TransformMatrix.M12 * Point.Y +
                            TransformMatrix.M13 * Point.Z +
                            TransformMatrix.M41 * 1,
                            TransformMatrix.M21 * Point.X +
                            TransformMatrix.M22 * Point.Y +
                            TransformMatrix.M23 * Point.Z +
                            TransformMatrix.M42 * 1,
                            TransformMatrix.M31 * Point.X +
                            TransformMatrix.M32 * Point.Y +
                            TransformMatrix.M33 * Point.Z +
                            TransformMatrix.M43 * 1
                         )
    End Operator


    ''' <summary>
    ''' Adds the respective co-ordinates of 2 points.
    ''' </summary>
    ''' <param name="Point1">The first point</param>
    ''' <param name="Point2">The second point</param>
    ''' <returns></returns>
    Public Shared Operator +(Point1 As Point, Point2 As Point) As Point
        Return New Point(Point1.X + Point2.X, Point1.Y + Point2.Y, Point1.Z + Point2.Z)
    End Operator

    ''' <summary>
    ''' Subtracts the respective co-ordinates of the second point from the first point.
    ''' </summary>
    ''' <param name="Point1">The first point</param>
    ''' <param name="Point2">The second point</param>
    ''' <returns></returns>
    Public Shared Operator -(Point1 As Point, Point2 As Point) As Point
        Return New Point(Point1.X - Point2.X, Point1.Y - Point2.Y, Point1.Z - Point2.Z)
    End Operator

#End Region

End Structure
