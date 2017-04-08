Imports OpenTK
Imports OpenTK.Graphics.OpenGL

MustInherit Class GenericUniform(Of x As Structure)
    Private ReadOnly name As String
    Protected _Data As x
    Protected Location%
    Public Property Data As x
        Get
            Return _Data
        End Get
        Set(value As x)
            _Data = value
        End Set
    End Property
    Public Sub New(Name$)
        Me.name = Name
    End Sub
    Public Overridable Sub [Set](program As shaderprogram)
        ' get uniform location
        Location% = program.GetUniformLocation(Me.name)
    End Sub
End Class

Friend Class Matrix4Uniform : Inherits GenericUniform(Of Matrix4)
    Public Sub New(Name As String)
        MyBase.New(Name)
    End Sub
    Public Overrides Sub [Set](program As shaderprogram)
        MyBase.Set(program)
        GL.UniformMatrix4(Location, False, Data)
    End Sub
End Class

Friend Class Uniform1 : Inherits GenericUniform(Of Single)

    Public Sub New(Name As String)
        MyBase.New(Name)
    End Sub
    Public Overrides Sub [Set](program As shaderprogram)
        MyBase.Set(program)
        GL.Uniform1(Location, Data)
    End Sub
End Class




