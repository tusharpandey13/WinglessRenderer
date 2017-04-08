Imports OpenTK
Imports OpenTK.Graphics


Friend Structure Vertex
    Public Shared ReadOnly Property Size As Integer
        Get
            Return Vector3.SizeInBytes + System.Runtime.InteropServices.Marshal.SizeOf(New Color4) ' + Vector2.SizeInBytes
        End Get
    End Property

    Public Position As Vector3
    Public Color As Color4
    'Public TexCoord As Vector2
    Public ReadOnly Property Point As Point
        Get
            Return New Point(Position)
        End Get
    End Property
    Public Sub New(Position As Point, Color As Color) ', TexCoord As Point)
        Me.Position = Position.Vector3
        Me.Color = Color.Color4
        ' Me.TexCoord = TexCoord.Vector2
    End Sub
    Public Sub New(ByVal position As Vector3, ByVal color As Color4) ', TexCoord As Vector2)
        Me.Position = position
        Me.Color = color
        'Me.TexCoord = TexCoord
    End Sub
    Public Shared Operator *(Vertex As Vertex, TransformMatrix As Matrix4) As Vertex
        Return New Vertex(New Point(Vertex.Position) * TransformMatrix, Vertex.Color) ', Vertex.TexCoord)
    End Operator
End Structure
