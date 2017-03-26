Imports OpenTK
Imports OpenTK.Graphics
Imports OpenTK.Graphics.OpenGL
Imports OpenTK.Input

Friend NotInheritable Class GameWindow
    Inherits OpenTK.GameWindow
    Private Buffer As Buffers
    Private shaderProgram As shaderprogram
    Private vertexArray As VertexArray(Of Vertex)
    Private projectionMatrix As Matrix4Uniform
    Private objects As List(Of Model)


    Public Sub New(w%, h%)
        MyBase.New(w, h, New GraphicsMode(32, 24, 0, 4), "OpenTK Intro", GameWindowFlags.Default, DisplayDevice.Default, 4, 3, GraphicsContextFlags.ForwardCompatible)
        Width = w : Height = h
        Console.WriteLine("Using OpenGL version " & GL.GetString(StringName.Version))
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        GL.Viewport(0, 0, Width, Height)
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)

        Buffer = New Buffers()
        objects = New List(Of Model)

        Dim m As New Model
        m.Add(New Ellipse(New Rectangle(100, 150, 700, 502), 1000, 2000), Color.Aqua)


        Buffer.Add({m})

        shaderProgram = New shaderprogram(VertexShader, FragShader)

        vertexArray = New VertexArray(Of Vertex)(Buffer, shaderProgram, New VertexAttribute("vPosition", 3, VertexAttribPointerType.Float, Vertex.Size, 0), New VertexAttribute("vColor", 4, VertexAttribPointerType.Float, Vertex.Size, 12))

        projectionMatrix = New Matrix4Uniform("projectionMatrix")
        projectionMatrix.Matrix = Matrix4.CreateOrthographicOffCenter(0, Width, Height, 0, 0.01, 100) * Matrix4.CreateTranslation(New Vector3(0, 0, 1))


        Buffer.Bind()
        vertexArray.Bind()

        Buffer.BufferData()

    End Sub

    Protected Overrides Sub OnUpdateFrame(ByVal e As FrameEventArgs)
    End Sub

    Protected Overrides Sub OnRenderFrame(ByVal e As FrameEventArgs)
        GL.ClearColor(Color4.Purple)
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)

        shaderProgram.use()
        projectionMatrix.Set(shaderProgram)



        Buffer.Draw()

        ' reset state for potential further draw calls (optional, but good practice)
        'GL.BindVertexArray(0)
        'GL.BindBuffer(BufferTarget.ArrayBuffer, 0)
        'GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0)
        'GL.UseProgram(0)


        ' swap backbuffer
        SwapBuffers()
    End Sub
    Protected Overrides Sub OnKeyDown(e As KeyboardKeyEventArgs)
        MyBase.OnKeyDown(e)
        If e.Key = Key.Escape Then Close()
    End Sub
End Class

