Imports Microsoft.VisualBasic
Imports System
Imports OpenTK.Graphics.OpenGL


Friend NotInheritable Class VertexAttribute
    Private ReadOnly name As String
    Private ReadOnly size As Integer
    Private ReadOnly type As VertexAttribPointerType
    Private ReadOnly normalize As Boolean
    Private ReadOnly stride As Integer
    Private ReadOnly offset As Integer
    Public Sub New(ByVal name As String, ByVal size As Integer, ByVal type As VertexAttribPointerType, ByVal stride As Integer, ByVal offset As Integer, Optional Noramalise As Boolean = False)
        Me.name = name
        Me.size = size
        Me.type = type
        Me.stride = stride
        Me.offset = offset
        Me.normalize = normalize
    End Sub

    Public Sub [Set](ByVal program As shaderprogram)
        ' get location of attribute from shader program
        Dim index As Integer = program.GetAttributeLocation(Me.name)

        ' enable and set attribute
        GL.EnableVertexAttribArray(index)
        GL.VertexAttribPointer(index, Me.size, Me.type, Me.normalize, Me.stride, Me.offset)
    End Sub
End Class

