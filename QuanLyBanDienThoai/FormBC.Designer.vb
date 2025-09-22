<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBC
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_thoat = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.btn_home = New System.Windows.Forms.Button()
        Me.btn_back = New System.Windows.Forms.Button()
        Me.pnl_nen = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.pnl_nen.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_thoat
        '
        Me.btn_thoat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_thoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_thoat.Location = New System.Drawing.Point(1218, 285)
        Me.btn_thoat.Name = "btn_thoat"
        Me.btn_thoat.Size = New System.Drawing.Size(73, 119)
        Me.btn_thoat.TabIndex = 25
        Me.btn_thoat.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.meadow_7215825_1280
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.GroupBox15)
        Me.Panel1.Location = New System.Drawing.Point(133, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1053, 632)
        Me.Panel1.TabIndex = 28
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.Label74)
        Me.GroupBox15.Controls.Add(Me.Label73)
        Me.GroupBox15.Controls.Add(Me.Label72)
        Me.GroupBox15.Controls.Add(Me.Label71)
        Me.GroupBox15.Controls.Add(Me.Label70)
        Me.GroupBox15.Controls.Add(Me.Label69)
        Me.GroupBox15.Controls.Add(Me.Label68)
        Me.GroupBox15.Location = New System.Drawing.Point(0, 46)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(1052, 539)
        Me.GroupBox15.TabIndex = 0
        Me.GroupBox15.TabStop = False
        '
        'Label74
        '
        Me.Label74.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label74.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.Location = New System.Drawing.Point(-2, 467)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(1050, 65)
        Me.Label74.TabIndex = 6
        Me.Label74.Text = "Báo cáo nhân viên"
        Me.Label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label73
        '
        Me.Label73.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label73.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.Location = New System.Drawing.Point(0, 392)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(1050, 65)
        Me.Label73.TabIndex = 5
        Me.Label73.Text = "Báo cáo nhà cung cấp"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label72
        '
        Me.Label72.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label72.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(-2, 317)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(1050, 65)
        Me.Label72.TabIndex = 4
        Me.Label72.Text = "Báo cáo khách hàng"
        Me.Label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label71
        '
        Me.Label71.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label71.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(-2, 243)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(1050, 65)
        Me.Label71.TabIndex = 3
        Me.Label71.Text = "Báo cáo hóa đơn nhập"
        Me.Label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label70
        '
        Me.Label70.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label70.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(-3, 167)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(1050, 65)
        Me.Label70.TabIndex = 2
        Me.Label70.Text = "Báo cáo hóa đơn bán"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label69
        '
        Me.Label69.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label69.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(-2, 92)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(1050, 65)
        Me.Label69.TabIndex = 1
        Me.Label69.Text = "Báo cáo chi tiết nhập"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label68
        '
        Me.Label68.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label68.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(2, 17)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(1050, 65)
        Me.Label68.TabIndex = 0
        Me.Label68.Text = "Báo cáo chi tiết bán"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_home
        '
        Me.btn_home.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.house
        Me.btn_home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_home.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_home.Location = New System.Drawing.Point(1218, 498)
        Me.btn_home.Name = "btn_home"
        Me.btn_home.Size = New System.Drawing.Size(73, 119)
        Me.btn_home.TabIndex = 27
        Me.btn_home.UseVisualStyleBackColor = True
        '
        'btn_back
        '
        Me.btn_back.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.chevron_left
        Me.btn_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_back.Location = New System.Drawing.Point(1218, 116)
        Me.btn_back.Name = "btn_back"
        Me.btn_back.Size = New System.Drawing.Size(73, 119)
        Me.btn_back.TabIndex = 26
        Me.btn_back.UseVisualStyleBackColor = True
        '
        'pnl_nen
        '
        Me.pnl_nen.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.phone2
        Me.pnl_nen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnl_nen.Controls.Add(Me.Panel1)
        Me.pnl_nen.Controls.Add(Me.btn_thoat)
        Me.pnl_nen.Controls.Add(Me.btn_home)
        Me.pnl_nen.Controls.Add(Me.btn_back)
        Me.pnl_nen.Location = New System.Drawing.Point(0, 0)
        Me.pnl_nen.Name = "pnl_nen"
        Me.pnl_nen.Size = New System.Drawing.Size(1326, 688)
        Me.pnl_nen.TabIndex = 29
        '
        'FormBC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1325, 687)
        Me.Controls.Add(Me.pnl_nen)
        Me.Name = "FormBC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormBC"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.pnl_nen.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox15 As GroupBox
    Friend WithEvents Label74 As Label
    Friend WithEvents Label73 As Label
    Friend WithEvents Label72 As Label
    Friend WithEvents Label71 As Label
    Friend WithEvents Label70 As Label
    Friend WithEvents Label69 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents btn_home As Button
    Friend WithEvents btn_back As Button
    Friend WithEvents btn_thoat As Button
    Friend WithEvents pnl_nen As Panel
End Class
