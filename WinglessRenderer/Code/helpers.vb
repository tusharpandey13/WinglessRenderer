Imports System

Module Helpers
    Public Function sgn(v#) As Integer
        If v > 0 Then Return 1
        If v < 0 Then Return -1
        If v = 0 Then Return 0
    End Function
    Public Function clamp#(V#, Min#, Max#)
        Return sgn(V) * Math.Min(Math.Max(Math.Abs(V), Min), Max)
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