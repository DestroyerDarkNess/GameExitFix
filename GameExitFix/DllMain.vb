Imports System.Runtime.InteropServices

Public Class DLLMain

    <UnmanagedFunctionPointer(CallingConvention.Cdecl)>
    Public Delegate Sub SAMP_ChatDelegate(ByVal ChatEntered As String)

    <DllImport("ChatHostHandler.asi", CallingConvention:=CallingConvention.Cdecl)>
    Public Shared Sub SetChatCallback(ByVal aCallback As SAMP_ChatDelegate)
    End Sub

    Public Shared Sub DllMain()
        Try

            Dim SAMP_Chat_Thread As SAMP_ChatDelegate = New SAMP_ChatDelegate(AddressOf MainCheat)
            SetChatCallback(SAMP_Chat_Thread)

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try


        Do While True : Loop

    End Sub

    Public Shared Sub MainCheat(ByVal ChatEnteredEx As String)
        If ChatEnteredEx.ToLower = "/qq" Then
            Process.GetCurrentProcess.Kill()
        End If
    End Sub

End Class
