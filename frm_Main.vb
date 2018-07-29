Imports System.ComponentModel

Public Class frm_Main

    Const yh As String = """"
    Private threadEnd As Boolean = False

    Private Sub LockUnlockCtrl(Optional isUnlock As Boolean = True)
        txtSysImg.Enabled = isUnlock
        txtSysPartSize.Enabled = isUnlock
        txtGSI.Enabled = isUnlock
        txtDSSIOut.Enabled = isUnlock
        txtPropFiles.Enabled = isUnlock
        btnOpenGSI.Enabled = isUnlock
        btnOpenPropFiles.Enabled = isUnlock
        btnOpenSysImg.Enabled = isUnlock
        btnSaveDSSI.Enabled = isUnlock
        btnStart.Enabled = isUnlock
        If chkGetFileContext.Checked Then
            txtFileContexts.Enabled = isUnlock
            btnOpenFileContexts.Enabled = isUnlock
        End If
        chkGetFileContext.Enabled = isUnlock
        chkIsABDevice.Enabled = isUnlock
    End Sub

    Private Sub AppendTxtOut(ByVal text As String)
        Me.txtOut.SelectionStart = txtOut.TextLength
        Me.txtOut.ScrollToCaret()
        Me.txtOut.AppendText(text & vbCrLf)
    End Sub

    Private Sub RunExec()
        On Error Resume Next
        Dim tmppath As String, gsipath As String, syspath As String, outtmp As String, binpath As String

        tmppath = Application.UserAppDataPath & "\Temp\"
        binpath = Application.StartupPath & "\bin\"
        syspath = tmppath & "sysimg-out\"
        gsipath = tmppath & "gsiimg-out\"
        outtmp = tmppath & "system\"

        AppendTxtOut("I 临时文件目录: " & tmppath)
        If CheckFileDir(tmppath) Then
            AppendTxtOut("I 清理临时文件" & vbCrLf)
            My.Computer.FileSystem.DeleteDirectory(tmppath, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        CreatePath(tmppath)

        AppendTxtOut("")

        If Not CheckFileDir(txtSysImg.Text) Then
            AppendTxtOut("E 错误: 未找到System镜像文件!")
            GoTo exitD
        End If

        If Val(txtSysPartSize.Text.Length) <= 0 Then
            AppendTxtOut("E 错误: System分区大小设置错误!")
            GoTo exitD
        End If

        If Not CheckFileDir(txtGSI.Text) Then
            AppendTxtOut("E 错误: 未找到GSI镜像文件!")
            GoTo exitD
        End If

        If chkGetFileContext.Checked And (Not CheckFileDir(txtFileContexts.Text)) Then
            AppendTxtOut("W 警告: 找不到自定义file_contexts! 将自动生成!")
            chkGetFileContext.Checked = False
        End If

        If Trim(txtDSSIOut.Text).Length = 0 Then
            AppendTxtOut("W 警告: 未指定DSSI镜像文件的保存路径! 使用默认路径!")
            txtDSSIOut.Text = Application.StartupPath & "\DSSI.img"
            AppendTxtOut("I DSSI镜像文件的保存路径被设置为" & txtDSSIOut.Text & vbCrLf)
        End If

        AppendTxtOut("I System镜像输出到: " & syspath & vbCrLf)
        AppendTxtOut("I 解包System镜像 ")

        RunCommand(binpath & "Ext4Extractor.exe", yh & txtSysImg.Text & yh & " " & yh & syspath & yh, txtOut)

        AppendTxtOut("I GSI镜像输出到: " & gsipath & vbCrLf)
        AppendTxtOut("I 解包GSI镜像 ")
        RunCommand(binpath & "Ext4Extractor.exe", yh & txtGSI.Text & yh & " " & yh & gsipath & yh, txtOut)

        AppendTxtOut("I 复制文件 ")
        If chkIsABDevice.Checked Then
            My.Computer.FileSystem.CopyDirectory(syspath, outtmp)
            My.Computer.FileSystem.DeleteDirectory(outtmp & "system", FileIO.DeleteDirectoryOption.DeleteAllContents)
            My.Computer.FileSystem.CopyDirectory(gsipath, outtmp & "system")
        Else
            My.Computer.FileSystem.CopyDirectory(gsipath, outtmp)
        End If


        AppendTxtOut("I 删除vendor软链接 ")
        If chkIsABDevice.Checked Then
            System.IO.File.Delete(outtmp & "system\vendor")
        Else
            System.IO.File.Delete(outtmp & "vendor")
        End If

        AppendTxtOut("I 复制vendor文件夹" & vbCrLf)
        If chkIsABDevice.Checked Then
            My.Computer.FileSystem.CopyDirectory(syspath & "system\vendor", outtmp & "system\vendor")
        Else
            My.Computer.FileSystem.CopyDirectory(syspath & "vendor", outtmp & "vendor")
        End If

        If CheckFileDir(txtPropFiles.Text) Then
            AppendTxtOut("I 从proprietary-files.txt复制文件")
            ConvertDosUnix(txtPropFiles.Text, tmppath & "proprietary-files.txt")
            Dim strArr() As String = System.IO.File.ReadAllLines(tmppath & "proprietary-files.txt")
            Dim tmpInt As Int32, tmpLine As String
            For tmpInt = 0 To strArr.Max
                tmpLine = Trim(strArr(tmpInt))
                If tmpLine.Length = 0 Or Strings.Left(tmpLine, 1) = "#" Or InStr(tmpLine, "vendor") > 0 Then Continue For
                tmpLine = Replace(CutStr(tmpLine, ":", "|"), "/", "\")
                If chkIsABDevice.Checked Then tmpLine = "system\" & tmpLine
                If CheckFileDir(syspath & tmpLine) Then
                    CreatePath(outtmp & Mid(tmpLine, 1, InStrRev(tmpLine, "\")))
                    AppendTxtOut("  Copy: " & tmpLine)
                    System.IO.File.Copy(syspath & tmpLine, outtmp & tmpLine)
                End If
            Next
            AppendTxtOut("")
        End If

        If Not chkGetFileContext.Checked Then
            AppendTxtOut("I 生成file_contexts" & vbCrLf)
            If chkIsABDevice.Checked Then
                System.IO.File.AppendAllText(tmppath & "file_contexts", System.IO.File.ReadAllText(outtmp & "system\etc\selinux\plat_file_contexts"))
                System.IO.File.AppendAllText(tmppath & "file_contexts", vbLf)
                System.IO.File.AppendAllText(tmppath & "file_contexts", System.IO.File.ReadAllText(outtmp & "system\vendor\etc\selinux\nonplat_file_contexts"))
                SortFile(tmppath & "file_contexts")
                UniqFile(tmppath & "file_contexts")
            Else
                System.IO.File.AppendAllText(tmppath & "file_contexts", System.IO.File.ReadAllText(outtmp & "etc\selinux\plat_file_contexts"))
                System.IO.File.AppendAllText(tmppath & "file_contexts", vbLf)
                System.IO.File.AppendAllText(tmppath & "file_contexts", System.IO.File.ReadAllText(outtmp & "vendor\etc\selinux\nonplat_file_contexts"))
            End If
        Else
            AppendTxtOut("I 复制自定义file_context到临时文件夹" & vbCrLf)
            System.IO.File.Copy(txtFileContexts.Text, tmppath & "file_contexts")
        End If

        AppendTxtOut("I System分区大小: " & txtSysPartSize.Text & vbCrLf)

        AppendTxtOut("I 创建DSSI镜像")
        If chkIsABDevice.Checked Then
            RunCommand(binpath & "make_ext4fs.exe", "-T 0 -S " & yh & tmppath & "file_contexts" & yh & " -l " & txtSysPartSize.Text & " -s -L / -a / " & yh & txtDSSIOut.Text & yh & " " & yh & outtmp & yh, txtOut)
        Else
            RunCommand(binpath & "make_ext4fs.exe", "-T 0 -S " & yh & tmppath & "file_contexts" & yh & " -l " & txtSysPartSize.Text & " -s -L system -a system " & yh & txtDSSIOut.Text & yh & " " & yh & outtmp & yh, txtOut)
        End If

        AppendTxtOut("I 删除临时文件" & vbCrLf)
        My.Computer.FileSystem.DeleteDirectory(tmppath, FileIO.DeleteDirectoryOption.DeleteAllContents)

        AppendTxtOut("I 完成!")
        MsgBox("完成!", vbInformation)
exitD:
        SyncLock Threading.Thread.CurrentThread
            threadEnd = True
        End SyncLock
    End Sub

    Private Sub btnOpenSysImg_Click(sender As Object, e As EventArgs) Handles btnOpenSysImg.Click
        FileDialog("img镜像|*.img", "选择System镜像", txtSysImg)
    End Sub

    Private Sub btnOpenGSI_Click(sender As Object, e As EventArgs) Handles btnOpenGSI.Click
        FileDialog("img镜像|*.img", "选择GSI镜像", txtGSI)
    End Sub

    Private Sub btnOpenPropFiles_Click(sender As Object, e As EventArgs) Handles btnOpenPropFiles.Click
        FileDialog("txt文件|*.txt", "选择proprietary-files.txt", txtPropFiles)
    End Sub

    Private Sub btnSaveDSSI_Click(sender As Object, e As EventArgs) Handles btnSaveDSSI.Click
        FileDialog("img镜像|*.img", "保存DSSI镜像", txtDSSIOut, False)
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        LockUnlockCtrl(False)
        Dim tmpThread As System.Threading.Thread = New System.Threading.Thread(AddressOf RunExec)
        tmpThread.Start()
        'tmpThread.Join()
        Do While Not threadEnd
            My.Application.DoEvents()
            System.Threading.Thread.Sleep(5)
        Loop
        LockUnlockCtrl()
        AppendTxtOut(vbCrLf)
    End Sub

    Private Sub btnOpenFileContexts_Click(sender As Object, e As EventArgs) Handles btnOpenFileContexts.Click
        FileDialog("file_contexts|file_contexts", "选择file_contexts", txtFileContexts)
    End Sub

    Private Sub chkGetFileContext_CheckedChanged(sender As Object, e As EventArgs) Handles chkGetFileContext.CheckedChanged
        txtFileContexts.Enabled = chkGetFileContext.Checked
        btnOpenFileContexts.Enabled = chkGetFileContext.Checked
    End Sub

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'It's security because only one thread will change controls
        CheckForIllegalCrossThreadCalls = False
    End Sub
End Class
