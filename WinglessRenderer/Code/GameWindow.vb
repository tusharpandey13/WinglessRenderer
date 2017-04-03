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

        Dim m As New Model With {.AntiAliased = 1}
        m.Add(New Line(100, 100, 500, 150), Color.Blue)
        m.Add(New Ellipse(400, 400, 100, 100,, 50), Color.YellowGreen)
        m.Add(New Polygon({New Point(0, 0), New Point(100, 500), New Point(200, 200)}), {Col(51), Color.LavenderBlush, Color.Indigo})

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
        GL.ClearColor(Color4.Black)
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
        'GL.Enable(EnableCap.DepthTest) don't enable
        GL.Enable(EnableCap.Blend)
        GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha)



        shaderProgram.use()
        projectionMatrix.Set(shaderProgram)



        Buffer.Draw()

        '''Reset state For potential further draw calls (Optional, but good practice)
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

