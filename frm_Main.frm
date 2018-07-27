VERSION 5.00
Begin VB.Form frm_Main 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Capire-Le-Treble"
   ClientHeight    =   5325
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   8850
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   5325
   ScaleWidth      =   8850
   StartUpPosition =   3  '窗口缺省
   Begin VB.CommandButton cmdAB2A 
      Caption         =   "AB2A"
      Enabled         =   0   'False
      Height          =   315
      Left            =   7680
      TabIndex        =   15
      Top             =   180
      Width           =   1035
   End
   Begin VB.Timer timGetCmdResult 
      Enabled         =   0   'False
      Interval        =   500
      Left            =   7260
      Top             =   1320
   End
   Begin VB.CheckBox chkABdevice 
      Caption         =   "A/B分区"
      Enabled         =   0   'False
      Height          =   255
      Left            =   7680
      TabIndex        =   14
      Top             =   600
      Width           =   1035
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "退出"
      Height          =   375
      Left            =   4860
      TabIndex        =   13
      Top             =   1320
      Width           =   915
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "开始"
      Height          =   375
      Left            =   2700
      TabIndex        =   12
      Top             =   1320
      Width           =   915
   End
   Begin VB.TextBox txtLOG 
      Height          =   3375
      Left            =   180
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   11
      Text            =   "frm_Main.frx":0000
      Top             =   1800
      Width           =   8475
   End
   Begin VB.TextBox txtFile 
      Height          =   270
      Index           =   2
      Left            =   5160
      TabIndex        =   10
      Text            =   "(可选)"
      Top             =   900
      Width           =   2775
   End
   Begin VB.TextBox txtSystemSize 
      Height          =   270
      Left            =   1680
      TabIndex        =   9
      Text            =   "1200M"
      Top             =   900
      Width           =   1335
   End
   Begin VB.CommandButton cmdOpen 
      Caption         =   "浏览"
      Height          =   315
      Index           =   2
      Left            =   8040
      TabIndex        =   8
      Top             =   900
      Width           =   615
   End
   Begin VB.CommandButton cmdOpen 
      Caption         =   "浏览"
      Height          =   315
      Index           =   1
      Left            =   6960
      TabIndex        =   7
      Top             =   540
      Width           =   615
   End
   Begin VB.TextBox txtFile 
      Height          =   270
      Index           =   1
      Left            =   1320
      TabIndex        =   6
      Top             =   540
      Width           =   5595
   End
   Begin VB.CommandButton cmdOpen 
      Caption         =   "浏览"
      Height          =   315
      Index           =   0
      Left            =   6960
      TabIndex        =   5
      Top             =   180
      Width           =   615
   End
   Begin VB.TextBox txtFile 
      Height          =   270
      Index           =   0
      Left            =   1320
      TabIndex        =   4
      Top             =   180
      Width           =   5595
   End
   Begin VB.Label lbl 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "proprietary-files.txt"
      Height          =   240
      Index           =   2
      Left            =   3180
      TabIndex        =   3
      Top             =   960
      Width           =   1950
   End
   Begin VB.Label lbl 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "System 分区大小"
      Height          =   180
      Index           =   3
      Left            =   240
      TabIndex        =   2
      Top             =   960
      Width           =   1350
   End
   Begin VB.Label lbl 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "GSI 镜像"
      Height          =   180
      Index           =   1
      Left            =   240
      TabIndex        =   1
      Top             =   600
      Width           =   720
   End
   Begin VB.Label lbl 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "System 镜像"
      Height          =   180
      Index           =   0
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   990
   End
End
Attribute VB_Name = "frm_Main"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Long, ByVal bInheritHandle As Long, ByVal dwProcessId As Long) As Long
Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Long) As Long

Const yh = """"

Dim cmdResultTmp As String, cmdPID As Long, cmdOutputFile As String, strOuttmp As String, closeAtNexttime As Boolean
Dim AppPath As String, tmppath As String

Private Sub killtmp()
On Error Resume Next
    Dim lpid As Long
    lpid = Shell("cmd.exe /c rmdir /S /Q " & yh & tmppath & yh, vbHide)
    Do While checkpid(lpid)
        DoEvents
        Sleep 1
    Loop
End Sub

Private Function checkpid(pid As Long) As Boolean
On Error Resume Next
    Dim hProcess As Long
    hProcess = OpenProcess(&H400, 0, pid)
    If hProcess = 0 Then
        checkpid = False
    Else
        CloseHandle hProcess
        checkpid = True
    End If
End Function

Private Sub RunCommand(strCmd As String, Optional isAtbin As Boolean = False)
    Dim fileNum As Long
    
    logadd "  使用命令: " & strCmd & vbCrLf, ""
    
    fileNum = FreeFile
    cmdOutputFile = AppPath & "tmp\" & Format(Now, "hhmmss")
    If isAtbin Then strCmd = "cd /d " & yh & AppPath & "bin\" & yh & " && " & strCmd
    cmdPID = Shell("cmd.exe /c " & strCmd & " > " & yh & cmdOutputFile & yh, vbHide)
    closeAtNexttime = False
    timGetCmdResult.Enabled = True
    Do While timGetCmdResult.Enabled
        Sleep 1
        DoEvents
    Loop
    logadd "", ""
End Sub

Private Sub logadd(txt As String, Optional logtype As String = "I ", Optional addCrlf As Boolean = True)
    txtLOG.Text = txtLOG.Text & logtype & txt
    If addCrlf Then txtLOG.Text = txtLOG.Text & vbCrLf
    txtLOG.SelStart = Len(txtLOG.Text)
End Sub

Private Sub cmdExit_Click()
    Unload Me
    End
End Sub

Private Sub cmdOpen_Click(Index As Integer)
    Dim strFilter As String
    strFilter = "img文件 (*.img)|*.img|所有文件 (*.*)|*.*"
    If Index = 2 Then strFilter = "txt文件 (*.txt)|*.txt|所有文件 (*.*)|*.*"
    txtFile(Index).Text = FileDialog(Me, False, "选择 " & lbl(Index).Caption, strFilter)
End Sub

Private Sub cmdStart_Click()
    On Error GoTo erro
    cmdStart.Enabled = False
    cmdExit.Enabled = False
    txtSystemSize.Enabled = False
    'chkABdevice.Enabled =False
    Dim i As Integer
    For i = 0 To 2
        txtFile(i).Enabled = False
        cmdOpen(i).Enabled = False
    Next
    logadd "", ""
    logadd "开始处理"
    killtmp

    Dim syspath As String, gsipath As String, proppath As String
    syspath = tmppath & "system\"
    gsipath = tmppath & "gsi\"
    proppath = tmppath & "vendorprop\"

    logadd "临时文件目录: " & tmppath

    If FileExists(txtFile(0).Text) = False Or Trim(txtFile(0).Text) = "" Then
        logadd "错误: 未找到System镜像文件!", "E "
        GoTo reenable
    End If
    If FileExists(txtFile(1).Text) = False Or Trim(txtFile(1).Text) = "" Then
        logadd "错误: 未找到GSI镜像文件!", "E "
        GoTo reenable
    End If

    Dim sysimg As String, gsiimg As String, sysout As String, syssize As String
    sysout = FileDialog(Me, True, "将生成的system.img保存到", "img文件 (*.img)|*.img", "system.img")
    If sysout = "" Then GoTo reenable
    syssize = txtSystemSize.Text
    
    logadd "System镜像输出到: " & sysout
    logadd "System分区大小: " & syssize

    sysimg = txtFile(0).Text

    Dim cmdline As String
    logadd "解包System镜像"
    cmdline = "Ext4Extractor.exe " & yh & sysimg & yh & " " & yh & syspath & yh
    CreatePath syspath
    RunCommand cmdline, True

    gsiimg = txtFile(1).Text
    logadd "解包GSI镜像"
    cmdline = "Ext4Extractor.exe " & yh & gsiimg & yh & " " & yh & gsipath & yh
    CreatePath gsipath
    RunCommand cmdline, True

    logadd "删除vendor软链接"
    RunCommand "del /A /Q " & yh & gsipath & "vendor" & yh

    logadd "复制Vendor文件夹到GSI目录"
    CreateObject("Scripting.FileSystemObject").CopyFolder syspath & "vendor", gsipath & "vendor"

    Dim filenumA As Long, tmpLine As String
    If FileExists(txtFile(2).Text) Then
        logadd "从proprietary-files.txt复制文件"
        Dim folderoffile As String
        Unix2Dos txtFile(2).Text, tmppath & "proprietary-files.txt"
        filenumA = FreeFile
        Open tmppath & "proprietary-files.txt" For Input As #filenumA
            Do While Not EOF(filenumA) And Err.Number <> 62
                Line Input #filenumA, tmpLine
                tmpLine = Trim(tmpLine)
                If Not (tmpLine = "" Or InStr(tmpLine, "vendor") > 0 Or Left(tmpLine, 1) = "#") Then
                    If Left(tmpLine, 1) = "-" Then tmpLine = Right(tmpLine, Len(tmpLine) - 1)
                    tmpLine = CutStr(tmpLine, ":", "|")
                    tmpLine = Replace(tmpLine, "/", "\")
                    folderoffile = Mid(tmpLine, 1, InStrRev(tmpLine, "\"))
                    CreatePath gsipath & folderoffile
                    If FileExists(gsipath & tmpLine) Then Kill gsipath & tmpLine
                    FileCopy syspath & tmpLine, gsipath & tmpLine
                    logadd "  Copied: " & tmpLine, ""
                End If
            Loop
        Close #filenumA
    End If

    logadd "生成file_contexts"
    Dim fcontexts As String
    filenumA = FreeFile
    If FileExists(gsipath & "etc\selinux\plat_file_contexts") Then Shell "cmd.exe /c type " & yh & gsipath & "etc\selinux\plat_file_contexts" & yh & " > " & yh & tmppath & "file_contexts" & yh
    If FileExists(gsipath & "vendor\etc\selinux\plat_file_contexts") Then Shell "cmd.exe /c type " & yh & gsipath & "vendor\etc\selinux\nonplat_file_contexts" & yh & " >> " & yh & tmppath & "file_contexts" & yh
    If FileExists(tmppath & "file_contexts") Then fcontexts = "-S " & yh & tmppath & "file_contexts" & yh

    logadd "创建修改后的system镜像"
    RunCommand "make_ext4fs -T 0 " & fcontexts & " -l " & syssize & " -s -L system -a system " & yh & sysout & yh & " " & yh & gsipath & yh, True

    logadd "删除临时文件"
    killtmp
    logadd "完成!"
    MsgBox "完成!", vbInformation
reenable:
    cmdStart.Enabled = True
    cmdExit.Enabled = True
    txtSystemSize.Enabled = True
    'chkABdevice.Enabled = True
    For i = 0 To 2
        txtFile(i).Enabled = True
        cmdOpen(i).Enabled = True
    Next
Exit Sub
erro:
    logadd "错误: " & Err.Number & " " & Err.Description, "E "
    Resume Next
End Sub


Private Sub Form_Load()
On Error Resume Next
    If Right(App.Path, 1) = "\" Then AppPath = App.Path Else AppPath = App.Path & "\"
    tmppath = AppPath & "tmp\"
    killtmp
    CreatePath tmppath
End Sub

Private Sub Form_Unload(Cancel As Integer)
    killtmp
End Sub

Private Sub timGetCmdResult_Timer()
On Error GoTo erro
    Dim strOut As String, fileNum As Long, tmpBinary() As Byte, strbinary As String
    timGetCmdResult.Enabled = checkpid(cmdPID)
    fileNum = FreeFile
    Open cmdOutputFile For Binary As #fileNum
        ReDim tmpBinary(LOF(fileNum) - 1)
        Get #fileNum, , tmpBinary
    Close #fileNum
    strbinary = StrConv(tmpBinary, vbUnicode)
    If strOuttmp <> strbinary Then logadd Replace(strbinary, strOuttmp, ""), "", False
    strOuttmp = strbinary
    Erase tmpBinary
erro:
End Sub
