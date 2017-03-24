Imports Microsoft.VisualBasic
Imports System
Imports OpenTK
Imports OpenTK.Graphics.OpenGL


Friend NotInheritable Class Matrix4Uniform
    Private ReadOnly name As String
    Private matrix_Renamed As Matrix4

    Public Property Matrix() As Matrix4
        Get
            Return Me.matrix_Renamed
        End Get
        Set(ByVal value As Matrix4)
            Me.matrix_Renamed = value
        End Set
    End Property

    Public Sub New(ByVal name As String)
        Me.name = name
    End Sub

    Public Sub [Set](ByVal program As ShaderProgram)
        ' get uniform location
        Dim i = program.GetUniformLocation(Me.name)

        ' set uniform value
        GL.UniformMatrix4(i, False, Me.matrix_Renamed)
    End Sub
End Class

