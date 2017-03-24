Imports System

Module Helpers
    Public Function clamp#(V#, Min#, Max#)
        Return Math.Min(Math.Max(V, Min), Max)
    End Function
    Public Sub writesuccess(s$)
        Dim t As ConsoleColor = Console.ForegroundColor
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine(s)
        Console.ForegroundColor = t
    End Sub
    Public Sub writeerror(s$)
        Dim t As ConsoleColor = Console.ForegroundColor
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine(s)
        Console.ForegroundColor = t
    End Sub
    Public Function Sizeof(Of x As Structure)() As Integer
        Return Runtime.InteropServices.Marshal.SizeOf(New x)
    End Function
End Module