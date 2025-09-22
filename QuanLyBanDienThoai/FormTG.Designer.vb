<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTG
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTG))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.LabelCompanyName = New System.Windows.Forms.Label()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.pnl_maingame = New System.Windows.Forms.Panel()
        Me.lbl_turn = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_newgame = New System.Windows.Forms.Button()
        Me.btn_next = New System.Windows.Forms.Button()
        Me.DiemO = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.diemX = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_maingame.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 2
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
        Me.TableLayoutPanel.Controls.Add(Me.LogoPictureBox, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelProductName, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelVersion, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCompanyName, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxDescription, 1, 4)
        Me.TableLayoutPanel.Controls.Add(Me.OKButton, 1, 5)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(12, 11)
        Me.TableLayoutPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 6
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(1271, 709)
        Me.TableLayoutPanel.TabIndex = 0
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogoPictureBox.Image = Global.QuanLyBanDienThoai.My.Resources.Resources._395654397_1044127046706298_1620811481343154989_n
        Me.LogoPictureBox.Location = New System.Drawing.Point(4, 4)
        Me.LogoPictureBox.Margin = New System.Windows.Forms.Padding(4)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.TableLayoutPanel.SetRowSpan(Me.LogoPictureBox, 6)
        Me.LogoPictureBox.Size = New System.Drawing.Size(411, 701)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'LabelProductName
        '
        Me.LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProductName.Location = New System.Drawing.Point(427, 0)
        Me.LabelProductName.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.LabelProductName.MaximumSize = New System.Drawing.Size(0, 21)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(840, 21)
        Me.LabelProductName.TabIndex = 0
        Me.LabelProductName.Text = "Product Name: QUẢN LÝ BÁN ĐIỆN THOẠI"
        Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelVersion
        '
        Me.LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelVersion.Location = New System.Drawing.Point(427, 70)
        Me.LabelVersion.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.LabelVersion.MaximumSize = New System.Drawing.Size(0, 21)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(840, 21)
        Me.LabelVersion.TabIndex = 0
        Me.LabelVersion.Text = "Version 1.0"
        Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCopyright
        '
        Me.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCopyright.Location = New System.Drawing.Point(427, 140)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 21)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(840, 21)
        Me.LabelCopyright.TabIndex = 0
        Me.LabelCopyright.Text = "Copyright: Hoàng Minh Hiếu"
        Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCompanyName
        '
        Me.LabelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCompanyName.Location = New System.Drawing.Point(427, 210)
        Me.LabelCompanyName.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
        Me.LabelCompanyName.MaximumSize = New System.Drawing.Size(0, 21)
        Me.LabelCompanyName.Name = "LabelCompanyName"
        Me.LabelCompanyName.Size = New System.Drawing.Size(840, 21)
        Me.LabelCompanyName.TabIndex = 0
        Me.LabelCompanyName.Text = "Company Name: HUBT_TH29.12"
        Me.LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDescription.Location = New System.Drawing.Point(427, 284)
        Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(8, 4, 4, 4)
        Me.TextBoxDescription.Multiline = True
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDescription.Size = New System.Drawing.Size(840, 346)
        Me.TextBoxDescription.TabIndex = 0
        Me.TextBoxDescription.TabStop = False
        Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(1167, 677)
        Me.OKButton.Margin = New System.Windows.Forms.Padding(4)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(100, 28)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&OK"
        '
        'pnl_maingame
        '
        Me.pnl_maingame.Controls.Add(Me.lbl_turn)
        Me.pnl_maingame.Controls.Add(Me.Label2)
        Me.pnl_maingame.Controls.Add(Me.btn_newgame)
        Me.pnl_maingame.Controls.Add(Me.btn_next)
        Me.pnl_maingame.Controls.Add(Me.DiemO)
        Me.pnl_maingame.Controls.Add(Me.Label4)
        Me.pnl_maingame.Controls.Add(Me.diemX)
        Me.pnl_maingame.Controls.Add(Me.Label1)
        Me.pnl_maingame.Controls.Add(Me.Button7)
        Me.pnl_maingame.Controls.Add(Me.Button8)
        Me.pnl_maingame.Controls.Add(Me.Button9)
        Me.pnl_maingame.Controls.Add(Me.Button4)
        Me.pnl_maingame.Controls.Add(Me.Button5)
        Me.pnl_maingame.Controls.Add(Me.Button6)
        Me.pnl_maingame.Controls.Add(Me.Button3)
        Me.pnl_maingame.Controls.Add(Me.Button2)
        Me.pnl_maingame.Controls.Add(Me.Button1)
        Me.pnl_maingame.Location = New System.Drawing.Point(434, 295)
        Me.pnl_maingame.Name = "pnl_maingame"
        Me.pnl_maingame.Size = New System.Drawing.Size(826, 346)
        Me.pnl_maingame.TabIndex = 1
        '
        'lbl_turn
        '
        Me.lbl_turn.Font = New System.Drawing.Font("Times New Roman", 25.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_turn.Location = New System.Drawing.Point(626, 256)
        Me.lbl_turn.Name = "lbl_turn"
        Me.lbl_turn.Size = New System.Drawing.Size(56, 47)
        Me.lbl_turn.TabIndex = 31
        Me.lbl_turn.Text = "O"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 25.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(493, 256)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 47)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Turn:"
        '
        'btn_newgame
        '
        Me.btn_newgame.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_newgame.Location = New System.Drawing.Point(284, 282)
        Me.btn_newgame.Name = "btn_newgame"
        Me.btn_newgame.Size = New System.Drawing.Size(116, 44)
        Me.btn_newgame.TabIndex = 29
        Me.btn_newgame.Text = "NEW GAME"
        Me.btn_newgame.UseVisualStyleBackColor = True
        '
        'btn_next
        '
        Me.btn_next.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_next.Location = New System.Drawing.Point(131, 282)
        Me.btn_next.Name = "btn_next"
        Me.btn_next.Size = New System.Drawing.Size(116, 44)
        Me.btn_next.TabIndex = 28
        Me.btn_next.Text = "NEXT"
        Me.btn_next.UseVisualStyleBackColor = True
        '
        'DiemO
        '
        Me.DiemO.AutoSize = True
        Me.DiemO.Font = New System.Drawing.Font("Times New Roman", 25.0!, System.Drawing.FontStyle.Bold)
        Me.DiemO.Location = New System.Drawing.Point(707, 161)
        Me.DiemO.Name = "DiemO"
        Me.DiemO.Size = New System.Drawing.Size(41, 48)
        Me.DiemO.TabIndex = 27
        Me.DiemO.Text = "0"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(493, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 54)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Player O:"
        '
        'diemX
        '
        Me.diemX.AutoSize = True
        Me.diemX.Font = New System.Drawing.Font("Times New Roman", 25.0!, System.Drawing.FontStyle.Bold)
        Me.diemX.Location = New System.Drawing.Point(707, 50)
        Me.diemX.Name = "diemX"
        Me.diemX.Size = New System.Drawing.Size(41, 48)
        Me.diemX.TabIndex = 25
        Me.diemX.Text = "0"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(493, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(210, 54)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Player X:"
        '
        'Button7
        '
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Font = New System.Drawing.Font("Times New Roman", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(79, 191)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(99, 62)
        Me.Button7.TabIndex = 23
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.Font = New System.Drawing.Font("Times New Roman", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(215, 191)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(99, 62)
        Me.Button8.TabIndex = 22
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Font = New System.Drawing.Font("Times New Roman", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(348, 191)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(99, 62)
        Me.Button9.TabIndex = 21
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("Times New Roman", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(79, 102)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(99, 62)
        Me.Button4.TabIndex = 20
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Font = New System.Drawing.Font("Times New Roman", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(215, 102)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(99, 62)
        Me.Button5.TabIndex = 19
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Font = New System.Drawing.Font("Times New Roman", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(348, 102)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(99, 62)
        Me.Button6.TabIndex = 18
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(348, 20)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(99, 62)
        Me.Button3.TabIndex = 17
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(215, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 62)
        Me.Button2.TabIndex = 16
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(79, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 62)
        Me.Button1.TabIndex = 15
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormTG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(1295, 731)
        Me.Controls.Add(Me.pnl_maingame)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormTG"
        Me.Padding = New System.Windows.Forms.Padding(12, 11, 12, 11)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormTG"
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_maingame.ResumeLayout(False)
        Me.pnl_maingame.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnl_maingame As Panel
    Friend WithEvents btn_newgame As Button
    Friend WithEvents btn_next As Button
    Friend WithEvents DiemO As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents diemX As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents lbl_turn As Label
    Friend WithEvents Label2 As Label
End Class
