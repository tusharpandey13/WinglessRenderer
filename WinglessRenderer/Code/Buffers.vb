Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports OpenTK.Graphics.OpenGL

Class Buffers : Implements IDisposable
    Dim vbo As GenericBuffer(Of Vertex)
    Dim ibo As GenericBuffer(Of UInteger)

    Sub New()
        vbo = New GenericBuffer(Of Vertex)(BufferTarget.ArrayBuffer)
        ibo = New GenericBuffer(Of UInteger)(BufferTarget.ElementArrayBuffer)
    End Sub
    Public Sub Add(Models As IEnumerable(Of Model))
        For Each m As Model In Models
            For i = 0 To m.I.Count - 1
                ibo.Add({CUInt(vbo.n + m.I.Item(i))})
            Next
            ibo.Add(m.I)
            vbo.Add(m.V)
        Next
    End Sub
    Public Sub Bind(Optional n% = -1)
        GL.EnableClientState(ArrayCap.VertexArray)
        vbo.Bind()
        GL.VertexPointer(3, VertexPointerType.Float, Vertex.Size, 0)
        ibo.Bind()
    End Sub
    Public Sub BufferData()
        vbo.BufferData()
        ibo.BufferData()
    End Sub
    Public Sub Draw()
        GL.DrawElements(PrimitiveType.Triangles, ibo.n, DrawElementsType.UnsignedInt, 0)
        'GL.DrawArrays(PrimitiveType.Triangles, 0, ibo.n)
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        vbo.Dispose()
        ibo.Dispose()
    End Sub
End Class


Class GenericBuffer(Of type As Structure) : Implements IDisposable
    Dim bt As BufferTarget
    Dim bu As BufferUsageHint
    Public handle%
    Protected Data As List(Of type)
    Public ReadOnly Property n%
        Get
            Return Data.Count
        End Get
    End Property
    Sub New(bt As BufferTarget, Optional bu As BufferUsageHint = BufferUsageHint.StaticDraw)
        Me.bt = bt
        Me.bu = bu
        GL.GenBuffers(1, handle)
        Data = New List(Of type)
    End Sub
    Public Sub Add(Data As IEnumerable(Of type))
        Me.Data.AddRange(Data)
    End Sub
    Public Sub Bind()
        GL.BindBuffer(bt, handle)
    End Sub
    Public Sub BufferData()
        GL.BufferData(Of type)(bt, CType(Data.Count * Sizeof(Of type)(), IntPtr), Data.ToArray, bu)
    End Sub

#Region "Disposing"
    Private disposed As Boolean
    Friend Sub Dispose() Implements IDisposable.Dispose
        Me.dispose(True)
    End Sub
    Protected Overridable Sub dispose(disposing As Boolean)
        If Me.disposed Then Return
        Data.Clear() : Data = Nothing
        GL.BindBuffer(bt, 0)
        Me.disposed = True
    End Sub
#End Region
End Class
