Imports OpenTK.Graphics.OpenGL
Imports OpenTK.Graphics

Class shaderprogram : Implements IDisposable


    Public Handle%
    Public ShaderHandles As New List(Of Integer)
    Private ReadOnly attributeLocations As New Dictionary(Of String, Integer)()
    Private ReadOnly uniformLocations As New Dictionary(Of String, Integer)()


    Sub New(ParamArray Shaders As Shader())
        Handle = GL.CreateProgram()
        For Each s As Shader In Shaders
            LoadShader(s)
        Next
        Link()
    End Sub

    Public Sub LoadShader(ByRef Shader As Shader)
        Shader.Handle = GL.CreateShader(Shader.ShaderType)
        ShaderHandles.Add(Shader.Handle)
        GL.ShaderSource(Shader.Handle, Shader.Code)
        GL.CompileShader(Shader.Handle)
        GL.AttachShader(Handle, Shader.Handle)
    End Sub

    Public Sub Link()
        GL.LinkProgram(Handle)
        For Each h% In ShaderHandles
            GL.DetachShader(Handle, h)
        Next
        GetError()
    End Sub

    Public Sub GetError()
        ' throw exception if linking failed
        Dim statusCode As Integer
        GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, statusCode)

        If statusCode <> 1 Then
            Dim info As String = ""
            GL.GetProgramInfoLog(Handle, info)
            Throw New ApplicationException(String.Format("Could not link shader: {0}", info))
            writeerror(String.Format("Could not link shader: {0}", info))
        Else
            writesuccess(":D  -  No errors while loading shaders.")
        End If
    End Sub


    ' <summary>
    ' Sets the vertex attributes.
    ' </summary>
    ' <param name="vertexAttributes">The vertex attributes to set.</param>
    Friend Sub SetVertexAttributes(vertexAttributes As VertexAttribute())
        For i As Integer = 0 To vertexAttributes.Length - 1
            vertexAttributes(i).Set(Me)
        Next
    End Sub

    ''' <summary>
    ''' Gets an attribute's location.
    ''' </summary>
    ''' <param name="name">The name of the attribute.</param>
    ''' <returns>The attribute's location, or -1 if not found.</returns>
    Friend Function GetAttributeLocation(name As String) As Integer
        Dim i As Integer
        If Not Me.attributeLocations.TryGetValue(name, i) Then
            i = GL.GetAttribLocation(Me, name)
            Me.attributeLocations.Add(name, i)
        End If
        Return i
    End Function

    ''' <summary>
    ''' Gets a uniform's location.
    ''' </summary>
    ''' <param name="name">The name of the uniform.</param>
    ''' <returns>The uniform's location, or -1 if not found.</returns>
    Friend Function GetUniformLocation(name As String) As Integer
        Dim i As Integer
        If Not Me.uniformLocations.TryGetValue(name, i) Then
            i = GL.GetUniformLocation(Me, name)
            Me.uniformLocations.Add(name, i)
        End If
        Return i
    End Function


    ''' <summary>
    ''' Casts the shader program object to its GLSL program object handle, for easy use with OpenGL functions.
    ''' </summary>
    ''' <param name="program">The program.</param>
    ''' <returns>GLSL program object handle.</returns>
    Public Shared Widening Operator CType(program As shaderprogram) As Integer
        Return program.Handle
    End Operator

#Region "Disposing"
    Private disposed As Boolean
    Friend Sub Dispose() Implements IDisposable.Dispose
        Me.dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
    Protected Overridable Sub dispose(disposing As Boolean)
        If Me.disposed Then Return
        If GraphicsContext.CurrentContext Is Nothing OrElse GraphicsContext.CurrentContext.IsDisposed Then Return
        GL.DeleteProgram(Me)
        Me.disposed = True
    End Sub
    Protected Overrides Sub Finalize()
        Try
            Me.dispose(False)
        Finally
            MyBase.Finalize()
        End Try
    End Sub
    Friend Sub use()
        GL.UseProgram(Me.Handle)
    End Sub
    'friend Sub UseOnSurface(surface As Surface)
    '    surface.SetShaderProgram(Me)
    'End Sub

#End Region

End Class

Structure Shader
    Dim Code$
    Dim Handle%
    Dim ShaderType As ShaderType
    Sub New(Code$, ShaderType As ShaderType)
        Me.Code = Code
        Me.ShaderType = ShaderType
    End Sub
End Structure


Module Shaders
    Public VertexShader As New Shader(
"#version 330

in  vec3 vPosition;
in  vec4 vColor;
//in  vec2 vTexCoord;


out vec4 fColor;
//out vec2 fTexCoord;

uniform mat4 projectionMatrix;

void main()
{
    gl_Position = projectionMatrix * vec4(vPosition, 1.0); 
    fColor = vColor;
//    fTexCoord = vTexCoord;
}",
                                        ShaderType.VertexShader)

    Public FragShader As New Shader(
"#version 330

in vec4 fColor;
//in vec2 fTexCoord;

out vec4 fragColor;

uniform float sat;

void main()
{
    fragColor = vec4(fColor.xyz,sat*fColor.w);
}",
                                                    ShaderType.FragmentShader)
End Module