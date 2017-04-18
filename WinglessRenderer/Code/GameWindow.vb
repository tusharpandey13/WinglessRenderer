Imports OpenTK
Imports OpenTK.Graphics
Imports OpenTK.Graphics.OpenGL
Imports OpenTK.Input

Friend NotInheritable Class GameWindow
    Inherits OpenTK.GameWindow
    Private Buffer As Buffers 'buffer objects to store vertex and indice data
    Private shaderProgram As shaderprogram 'this encapsulates and manages all shaders
    Private vertexArray As VertexArray(Of Vertex) 'another buffer
    Private projectionMatrix As Matrix4Uniform 'this the default matrix that our shader uses. 
    Friend sat As Uniform1 'unsused

    Public Sub New(w%, h%)
        'New GraphicsMode(32, 24, 4, 1)  the 3rd param specifyies msaa level. 4 for best results.
        MyBase.New(w, h, New GraphicsMode(32, 24, 4, 1), "OpenTK Intro", GameWindowFlags.Default, DisplayDevice.Default, 4, 3, GraphicsContextFlags.ForwardCompatible)
        Width = w : Height = h
        Console.WriteLine("Using OpenGL version " & GL.GetString(StringName.Version))
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        GL.Viewport(0, 0, Width, Height) 'resize the viewport when window is resized
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)

        Buffer = New Buffers()

        'in wingless, models can contain multiple polygons and can have their own transformation matrices
        'models encapsulates all the vertices and their indices

        Dim m As New Model With {.AntiAliased = 1}

        m.Add(New Rectangle(0, 0, 100, 100), Color.Yellow)
        m.Add(New CubicBezier(New Point(40, 200), New Point(40, 100 + 4 / 3 * Math.Tan(Math.PI / 2000)), New Point(140 - 4 / 3 * Math.Tan(Math.PI / 2000), 200), New Point(140, 100)), Color.Black)
        m.Add(New Ellipse(400, 300, 100, 100), Color.Black)


        'models need to be added to the buffer to be drawn
        Buffer.Add({m})


        shaderProgram = New shaderprogram(VertexShader, FragShader)

        vertexArray = New VertexArray(Of Vertex)(Buffer, shaderProgram,
                                                 New VertexAttribute("vPosition", 3, VertexAttribPointerType.Float, Vertex.Size, 0),
                                                 New VertexAttribute("vColor", 4, VertexAttribPointerType.Float, Vertex.Size, 12),
                                                 New VertexAttribute("vTexCoord", 2, VertexAttribPointerType.Float, Vertex.Size, 28)
                                                )

        'this gl command auto creates an orthographic proj. matrix for us
        'needed for 2d
        projectionMatrix = New Matrix4Uniform("projectionMatrix")
        projectionMatrix.Data = Matrix4.CreateOrthographicOffCenter(0, Width, Height, 0, 0.01, 100) * Matrix4.CreateTranslation(New Vector3(0, 0, 1))

        sat = New Uniform1("sat")
        sat.Data = 1.0!

        'buffers are bound to their respective variables
        Buffer.Bind()
        vertexArray.Bind()

        'at last, the data in the buffers is copied to graphics memory
        Buffer.BufferData()

    End Sub

    Protected Overrides Sub OnUpdateFrame(ByVal e As FrameEventArgs)
    End Sub

    Protected Overrides Sub OnRenderFrame(ByVal e As FrameEventArgs)

        'we can change clear color here
        GL.ClearColor(Color4.White)
        'specify which masks to clear
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
        'GL.Enable(EnableCap.DepthTest) don't enable
        GL.Enable(EnableCap.Blend) 'this enables alpha blending
        'specify the default method for blending colors
        'dont touch
        GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha)



        shaderProgram.use() 'use our shaders
        projectionMatrix.Set(shaderProgram) 'set the matrix for use
        sat.Set(shaderProgram) 'unused


        Buffer.Draw() 'draw our models


        ''Reset state For potential further draw calls (Optional, but good practice)
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



