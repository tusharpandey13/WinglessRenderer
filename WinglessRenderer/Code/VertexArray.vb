Imports Microsoft.VisualBasic
Imports System
Imports OpenTK.Graphics.OpenGL


Friend NotInheritable Class VertexArray(Of TVertex As Structure)
    Private ReadOnly handle As Integer

    Public Sub New(ByVal Buffer As Buffers, ByVal program As shaderprogram, ParamArray ByVal attributes() As VertexAttribute)
        ' create new vertex array object
        GL.GenVertexArrays(1, Me.handle)

        ' bind the object so we can modify it
        Me.Bind()

        ' bind the vertex buffer object
        Buffer.Bind()

        ' set all attributes
        For Each attribute In attributes
            attribute.Set(program)
        Next attribute

        ' unbind objects to reset state
        GL.BindVertexArray(0)
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0)
    End Sub

    Public Sub Bind()
        ' bind for usage (modification or rendering)
        GL.BindVertexArray(Me.handle)
    End Sub
End Class