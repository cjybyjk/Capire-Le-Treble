Module mod_RunCommand
    Dim outTextbox As TextBox
    Sub RunCommand(ByVal strProc As String, ByVal strArgs As String, ByRef outputText As TextBox)
        On Error GoTo erro
        Dim process As New Process()
        process.StartInfo.FileName = strProc
        process.StartInfo.Arguments = strArgs
        process.StartInfo.UseShellExecute = False
        process.StartInfo.CreateNoWindow = True
        process.StartInfo.RedirectStandardOutput = True
        AddHandler process.OutputDataReceived, AddressOf OutputHandler
        outTextbox = outputText
        AppendTxtOut("I 运行: " & strProc & " " & strArgs)
        process.Start()
        process.BeginOutputReadLine()
        process.WaitForExit()
        process.Close()
ErrO:
        outTextbox = Nothing
    End Sub

    Private Sub AppendTxtOut(ByVal text As String)
        outTextbox.SelectionStart = outTextbox.TextLength
        outTextbox.ScrollToCaret()
        outTextbox.AppendText(text & vbCrLf)
    End Sub

    Sub OutputHandler(sender As Object, e As DataReceivedEventArgs)
        AppendTxtOut(e.Data)
    End Sub

End Module
