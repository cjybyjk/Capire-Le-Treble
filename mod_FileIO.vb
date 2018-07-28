Module mod_FileIO

    Public Function CheckFileDir(ByVal strPath As String) As Boolean
        CheckFileDir = (System.IO.Directory.Exists(strPath) Or System.IO.File.Exists(strPath)) And strPath.Length > 0
    End Function

    Public Sub FileDialog(ByVal strFilter As String, ByVal strTitle As String, ByRef txtbox As TextBox, Optional ByVal isOpen As Boolean = True)
        Dim objDialog As Object
        If isOpen Then
            objDialog = New OpenFileDialog
        Else
            objDialog = New SaveFileDialog
        End If
        objDialog.Title = strTitle
        objDialog.Filter = strFilter
        objDialog.ShowDialog()
        If objDialog.filename <> "" Then txtbox.Text = objDialog.filename
    End Sub

    Public Sub CreatePath(ByVal strPath As String)
        System.IO.Directory.CreateDirectory(strPath)
    End Sub

    Public Sub ConvertDosUnix(ByVal strSource As String, ByVal strOut As String, Optional isToUnix As Boolean = False)
        Dim strTmp As String
        strTmp = System.IO.File.ReadAllText(strSource)
        If isToUnix Then
            strTmp = Replace(strTmp, vbCr, "")
        Else
            If InStr(strTmp, vbCr) = 0 Then strTmp = Replace(strTmp, vbLf, vbCrLf)
        End If

        System.IO.File.WriteAllText(strOut, strTmp)
    End Sub

    Public Function CutStr(ByVal str As String, ByVal Lefts As String, ByVal Rights As String, Optional ByVal start As Integer = 1) As String
        On Error Resume Next
        Dim startp As Integer, Last As Integer
        startp = start
        startp = InStr(startp, str, Lefts) + Len(Lefts)
        Last = InStr(startp + 1, str, Rights)
        If Rights = "" Or Last = 0 Then Last = Len(str) + 1
        CutStr = Mid(str, startp, Last - startp)
    End Function

End Module
