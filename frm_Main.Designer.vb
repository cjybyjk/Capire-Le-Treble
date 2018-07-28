<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Main
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTip1 = New System.Windows.Forms.Label()
        Me.lblTip2 = New System.Windows.Forms.Label()
        Me.lblTip3 = New System.Windows.Forms.Label()
        Me.lblTip4 = New System.Windows.Forms.Label()
        Me.txtSysImg = New System.Windows.Forms.TextBox()
        Me.txtGSI = New System.Windows.Forms.TextBox()
        Me.txtSysPartSize = New System.Windows.Forms.TextBox()
        Me.txtPropFiles = New System.Windows.Forms.TextBox()
        Me.btnOpenSysImg = New System.Windows.Forms.Button()
        Me.btnOpenGSI = New System.Windows.Forms.Button()
        Me.btnOpenPropFiles = New System.Windows.Forms.Button()
        Me.txtOut = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblTip5 = New System.Windows.Forms.Label()
        Me.txtDSSIOut = New System.Windows.Forms.TextBox()
        Me.btnSaveDSSI = New System.Windows.Forms.Button()
        Me.chkGetFileContext = New System.Windows.Forms.CheckBox()
        Me.chkIsABDevice = New System.Windows.Forms.CheckBox()
        Me.txtFileContexts = New System.Windows.Forms.TextBox()
        Me.btnOpenFileContexts = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTip1
        '
        Me.lblTip1.AutoEllipsis = True
        Me.lblTip1.AutoSize = True
        Me.lblTip1.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.lblTip1.Location = New System.Drawing.Point(12, 15)
        Me.lblTip1.Name = "lblTip1"
        Me.lblTip1.Size = New System.Drawing.Size(101, 12)
        Me.lblTip1.TabIndex = 0
        Me.lblTip1.Text = "System 镜像(img)"
        '
        'lblTip2
        '
        Me.lblTip2.AutoEllipsis = True
        Me.lblTip2.AutoSize = True
        Me.lblTip2.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.lblTip2.Location = New System.Drawing.Point(12, 39)
        Me.lblTip2.Name = "lblTip2"
        Me.lblTip2.Size = New System.Drawing.Size(83, 12)
        Me.lblTip2.TabIndex = 1
        Me.lblTip2.Text = "GSI 镜像(img)"
        '
        'lblTip3
        '
        Me.lblTip3.AutoEllipsis = True
        Me.lblTip3.AutoSize = True
        Me.lblTip3.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.lblTip3.Location = New System.Drawing.Point(12, 63)
        Me.lblTip3.Name = "lblTip3"
        Me.lblTip3.Size = New System.Drawing.Size(95, 12)
        Me.lblTip3.TabIndex = 2
        Me.lblTip3.Text = "System 分区大小"
        '
        'lblTip4
        '
        Me.lblTip4.AutoEllipsis = True
        Me.lblTip4.AutoSize = True
        Me.lblTip4.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.lblTip4.Location = New System.Drawing.Point(172, 63)
        Me.lblTip4.Name = "lblTip4"
        Me.lblTip4.Size = New System.Drawing.Size(131, 12)
        Me.lblTip4.TabIndex = 3
        Me.lblTip4.Text = "proprietary-files.txt"
        '
        'txtSysImg
        '
        Me.txtSysImg.Location = New System.Drawing.Point(113, 11)
        Me.txtSysImg.Name = "txtSysImg"
        Me.txtSysImg.Size = New System.Drawing.Size(457, 21)
        Me.txtSysImg.TabIndex = 4
        '
        'txtGSI
        '
        Me.txtGSI.Location = New System.Drawing.Point(113, 35)
        Me.txtGSI.Name = "txtGSI"
        Me.txtGSI.Size = New System.Drawing.Size(457, 21)
        Me.txtGSI.TabIndex = 5
        '
        'txtSysPartSize
        '
        Me.txtSysPartSize.Location = New System.Drawing.Point(113, 59)
        Me.txtSysPartSize.Name = "txtSysPartSize"
        Me.txtSysPartSize.Size = New System.Drawing.Size(53, 21)
        Me.txtSysPartSize.TabIndex = 6
        Me.txtSysPartSize.Text = "1200M"
        '
        'txtPropFiles
        '
        Me.txtPropFiles.Location = New System.Drawing.Point(309, 59)
        Me.txtPropFiles.Name = "txtPropFiles"
        Me.txtPropFiles.Size = New System.Drawing.Size(261, 21)
        Me.txtPropFiles.TabIndex = 7
        Me.txtPropFiles.Text = "(可选)"
        '
        'btnOpenSysImg
        '
        Me.btnOpenSysImg.Location = New System.Drawing.Point(576, 11)
        Me.btnOpenSysImg.Name = "btnOpenSysImg"
        Me.btnOpenSysImg.Size = New System.Drawing.Size(66, 20)
        Me.btnOpenSysImg.TabIndex = 8
        Me.btnOpenSysImg.Text = "浏览"
        Me.btnOpenSysImg.UseVisualStyleBackColor = True
        '
        'btnOpenGSI
        '
        Me.btnOpenGSI.Location = New System.Drawing.Point(576, 35)
        Me.btnOpenGSI.Name = "btnOpenGSI"
        Me.btnOpenGSI.Size = New System.Drawing.Size(66, 21)
        Me.btnOpenGSI.TabIndex = 9
        Me.btnOpenGSI.Text = "浏览"
        Me.btnOpenGSI.UseVisualStyleBackColor = True
        '
        'btnOpenPropFiles
        '
        Me.btnOpenPropFiles.Location = New System.Drawing.Point(576, 59)
        Me.btnOpenPropFiles.Name = "btnOpenPropFiles"
        Me.btnOpenPropFiles.Size = New System.Drawing.Size(66, 21)
        Me.btnOpenPropFiles.TabIndex = 10
        Me.btnOpenPropFiles.Text = "浏览"
        Me.btnOpenPropFiles.UseVisualStyleBackColor = True
        '
        'txtOut
        '
        Me.txtOut.Location = New System.Drawing.Point(14, 163)
        Me.txtOut.MaxLength = 2147483647
        Me.txtOut.Multiline = True
        Me.txtOut.Name = "txtOut"
        Me.txtOut.ReadOnly = True
        Me.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOut.Size = New System.Drawing.Size(628, 262)
        Me.txtOut.TabIndex = 11
        Me.txtOut.Text = "Capire-Le-Treble" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "原作者: Erfan Abdi <erfangplus@gmail.com>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Windows版作者: cjybyjk <cj" &
    "ybyjk@gmail.com>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "这个工具可以将GSI镜像转成DSSI镜像" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "需要的文件: 原始System镜像 要转换的GSI镜像 (可选)propri" &
    "etary-files.txt (可选)file_contexts" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(268, 134)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(97, 23)
        Me.btnStart.TabIndex = 12
        Me.btnStart.Text = "开始"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblTip5
        '
        Me.lblTip5.AutoEllipsis = True
        Me.lblTip5.AutoSize = True
        Me.lblTip5.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.lblTip5.Location = New System.Drawing.Point(12, 111)
        Me.lblTip5.Name = "lblTip5"
        Me.lblTip5.Size = New System.Drawing.Size(95, 12)
        Me.lblTip5.TabIndex = 13
        Me.lblTip5.Text = "DSSI 镜像保存到"
        '
        'txtDSSIOut
        '
        Me.txtDSSIOut.Location = New System.Drawing.Point(112, 107)
        Me.txtDSSIOut.Name = "txtDSSIOut"
        Me.txtDSSIOut.Size = New System.Drawing.Size(458, 21)
        Me.txtDSSIOut.TabIndex = 14
        '
        'btnSaveDSSI
        '
        Me.btnSaveDSSI.Location = New System.Drawing.Point(576, 108)
        Me.btnSaveDSSI.Name = "btnSaveDSSI"
        Me.btnSaveDSSI.Size = New System.Drawing.Size(66, 20)
        Me.btnSaveDSSI.TabIndex = 15
        Me.btnSaveDSSI.Text = "浏览"
        Me.btnSaveDSSI.UseVisualStyleBackColor = True
        '
        'chkGetFileContext
        '
        Me.chkGetFileContext.AutoSize = True
        Me.chkGetFileContext.Location = New System.Drawing.Point(141, 85)
        Me.chkGetFileContext.Name = "chkGetFileContext"
        Me.chkGetFileContext.Size = New System.Drawing.Size(162, 16)
        Me.chkGetFileContext.TabIndex = 16
        Me.chkGetFileContext.Text = "使用自定义file_contexts"
        Me.chkGetFileContext.UseVisualStyleBackColor = True
        '
        'chkIsABDevice
        '
        Me.chkIsABDevice.AutoSize = True
        Me.chkIsABDevice.Enabled = False
        Me.chkIsABDevice.Location = New System.Drawing.Point(14, 85)
        Me.chkIsABDevice.Name = "chkIsABDevice"
        Me.chkIsABDevice.Size = New System.Drawing.Size(114, 16)
        Me.chkIsABDevice.TabIndex = 17
        Me.chkIsABDevice.Text = "A/B分区设备支持"
        Me.chkIsABDevice.UseVisualStyleBackColor = True
        '
        'txtFileContexts
        '
        Me.txtFileContexts.Enabled = False
        Me.txtFileContexts.Location = New System.Drawing.Point(311, 83)
        Me.txtFileContexts.Name = "txtFileContexts"
        Me.txtFileContexts.Size = New System.Drawing.Size(259, 21)
        Me.txtFileContexts.TabIndex = 18
        '
        'btnOpenFileContexts
        '
        Me.btnOpenFileContexts.Enabled = False
        Me.btnOpenFileContexts.Location = New System.Drawing.Point(576, 83)
        Me.btnOpenFileContexts.Name = "btnOpenFileContexts"
        Me.btnOpenFileContexts.Size = New System.Drawing.Size(66, 21)
        Me.btnOpenFileContexts.TabIndex = 19
        Me.btnOpenFileContexts.Text = "浏览"
        Me.btnOpenFileContexts.UseVisualStyleBackColor = True
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(656, 437)
        Me.Controls.Add(Me.btnOpenFileContexts)
        Me.Controls.Add(Me.txtFileContexts)
        Me.Controls.Add(Me.chkIsABDevice)
        Me.Controls.Add(Me.chkGetFileContext)
        Me.Controls.Add(Me.btnSaveDSSI)
        Me.Controls.Add(Me.txtDSSIOut)
        Me.Controls.Add(Me.lblTip5)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.txtOut)
        Me.Controls.Add(Me.btnOpenPropFiles)
        Me.Controls.Add(Me.btnOpenGSI)
        Me.Controls.Add(Me.btnOpenSysImg)
        Me.Controls.Add(Me.txtPropFiles)
        Me.Controls.Add(Me.txtSysPartSize)
        Me.Controls.Add(Me.txtGSI)
        Me.Controls.Add(Me.txtSysImg)
        Me.Controls.Add(Me.lblTip4)
        Me.Controls.Add(Me.lblTip3)
        Me.Controls.Add(Me.lblTip2)
        Me.Controls.Add(Me.lblTip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frm_Main"
        Me.Text = "Capire-Le-Treble "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTip1 As Label
    Friend WithEvents lblTip2 As Label
    Friend WithEvents lblTip3 As Label
    Friend WithEvents lblTip4 As Label
    Friend WithEvents txtSysImg As TextBox
    Friend WithEvents txtGSI As TextBox
    Friend WithEvents txtSysPartSize As TextBox
    Friend WithEvents txtPropFiles As TextBox
    Friend WithEvents btnOpenSysImg As Button
    Friend WithEvents btnOpenGSI As Button
    Friend WithEvents btnOpenPropFiles As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents lblTip5 As Label
    Friend WithEvents txtDSSIOut As TextBox
    Friend WithEvents btnSaveDSSI As Button
    Friend WithEvents txtOut As TextBox
    Friend WithEvents chkGetFileContext As CheckBox
    Friend WithEvents chkIsABDevice As CheckBox
    Friend WithEvents txtFileContexts As TextBox
    Friend WithEvents btnOpenFileContexts As Button
End Class
