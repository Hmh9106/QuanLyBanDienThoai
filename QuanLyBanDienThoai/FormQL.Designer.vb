<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormQL
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
        Me.pnl_nen = New System.Windows.Forms.Panel()
        Me.pnl_nhanvien = New System.Windows.Forms.Panel()
        Me.btn_xdlnv = New System.Windows.Forms.Button()
        Me.btn_themnv = New System.Windows.Forms.Button()
        Me.btn_huynv = New System.Windows.Forms.Button()
        Me.btn_luunv = New System.Windows.Forms.Button()
        Me.btn_xoanv = New System.Windows.Forms.Button()
        Me.btn_suanv = New System.Windows.Forms.Button()
        Me.txt_timkiemnv = New System.Windows.Forms.TextBox()
        Me.btn_tknv = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cb_gt = New System.Windows.Forms.ComboBox()
        Me.txt_mnv = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_sdtnv = New System.Windows.Forms.TextBox()
        Me.txt_tennv = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_cvnv = New System.Windows.Forms.TextBox()
        Me.txt_dcnv = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_luong = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dg_nhanvien = New System.Windows.Forms.DataGridView()
        Me.pnl_quanly = New System.Windows.Forms.Panel()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.pnl_khachhang = New System.Windows.Forms.Panel()
        Me.btn_xdlkh = New System.Windows.Forms.Button()
        Me.btn_themkh = New System.Windows.Forms.Button()
        Me.btn_huykh = New System.Windows.Forms.Button()
        Me.btn_luukh = New System.Windows.Forms.Button()
        Me.btn_xoakh = New System.Windows.Forms.Button()
        Me.btn_suakh = New System.Windows.Forms.Button()
        Me.txt_timkiemkh = New System.Windows.Forms.TextBox()
        Me.btn_timkiemkh = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txt_makh = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_sdtkh = New System.Windows.Forms.TextBox()
        Me.txt_tenkh = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_emailkh = New System.Windows.Forms.TextBox()
        Me.txt_diachikh = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dg_khachhang = New System.Windows.Forms.DataGridView()
        Me.pnl_ncc = New System.Windows.Forms.Panel()
        Me.btn_xdlncc = New System.Windows.Forms.Button()
        Me.btn_themncc = New System.Windows.Forms.Button()
        Me.btn_huyncc = New System.Windows.Forms.Button()
        Me.btn_luuncc = New System.Windows.Forms.Button()
        Me.btn_xoancc = New System.Windows.Forms.Button()
        Me.btn_suancc = New System.Windows.Forms.Button()
        Me.txt_timkiemncc = New System.Windows.Forms.TextBox()
        Me.btn_timkiemncc = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txt_mancc = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_sdtncc = New System.Windows.Forms.TextBox()
        Me.txt_tenncc = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txt_emailncc = New System.Windows.Forms.TextBox()
        Me.txt_diachincc = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dg_ncc = New System.Windows.Forms.DataGridView()
        Me.btn_home = New System.Windows.Forms.Button()
        Me.btn_back = New System.Windows.Forms.Button()
        Me.btn_thoat = New System.Windows.Forms.Button()
        Me.pnl_nen.SuspendLayout()
        Me.pnl_nhanvien.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dg_nhanvien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_quanly.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.pnl_khachhang.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dg_khachhang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_ncc.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dg_ncc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnl_nen
        '
        Me.pnl_nen.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.phone2
        Me.pnl_nen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnl_nen.Controls.Add(Me.pnl_quanly)
        Me.pnl_nen.Controls.Add(Me.pnl_nhanvien)
        Me.pnl_nen.Controls.Add(Me.pnl_khachhang)
        Me.pnl_nen.Controls.Add(Me.pnl_ncc)
        Me.pnl_nen.Controls.Add(Me.btn_home)
        Me.pnl_nen.Controls.Add(Me.btn_back)
        Me.pnl_nen.Controls.Add(Me.btn_thoat)
        Me.pnl_nen.Location = New System.Drawing.Point(-5, 1)
        Me.pnl_nen.Name = "pnl_nen"
        Me.pnl_nen.Size = New System.Drawing.Size(1331, 688)
        Me.pnl_nen.TabIndex = 34
        '
        'pnl_nhanvien
        '
        Me.pnl_nhanvien.Controls.Add(Me.btn_xdlnv)
        Me.pnl_nhanvien.Controls.Add(Me.btn_themnv)
        Me.pnl_nhanvien.Controls.Add(Me.btn_huynv)
        Me.pnl_nhanvien.Controls.Add(Me.btn_luunv)
        Me.pnl_nhanvien.Controls.Add(Me.btn_xoanv)
        Me.pnl_nhanvien.Controls.Add(Me.btn_suanv)
        Me.pnl_nhanvien.Controls.Add(Me.txt_timkiemnv)
        Me.pnl_nhanvien.Controls.Add(Me.btn_tknv)
        Me.pnl_nhanvien.Controls.Add(Me.GroupBox2)
        Me.pnl_nhanvien.Controls.Add(Me.dg_nhanvien)
        Me.pnl_nhanvien.Location = New System.Drawing.Point(135, 32)
        Me.pnl_nhanvien.Name = "pnl_nhanvien"
        Me.pnl_nhanvien.Size = New System.Drawing.Size(1056, 633)
        Me.pnl_nhanvien.TabIndex = 38
        Me.pnl_nhanvien.Visible = False
        '
        'btn_xdlnv
        '
        Me.btn_xdlnv.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_xdlnv.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.xdl
        Me.btn_xdlnv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_xdlnv.Location = New System.Drawing.Point(68, 442)
        Me.btn_xdlnv.Name = "btn_xdlnv"
        Me.btn_xdlnv.Size = New System.Drawing.Size(309, 145)
        Me.btn_xdlnv.TabIndex = 23
        Me.btn_xdlnv.Text = "Xuất dữ liệu ra excel"
        Me.btn_xdlnv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_xdlnv.UseVisualStyleBackColor = True
        '
        'btn_themnv
        '
        Me.btn_themnv.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_themnv.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.them
        Me.btn_themnv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_themnv.Location = New System.Drawing.Point(397, 523)
        Me.btn_themnv.Name = "btn_themnv"
        Me.btn_themnv.Size = New System.Drawing.Size(95, 75)
        Me.btn_themnv.TabIndex = 22
        Me.btn_themnv.Text = "Thêm"
        Me.btn_themnv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_themnv.UseVisualStyleBackColor = True
        '
        'btn_huynv
        '
        Me.btn_huynv.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_huynv.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.huy_
        Me.btn_huynv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_huynv.Location = New System.Drawing.Point(941, 523)
        Me.btn_huynv.Name = "btn_huynv"
        Me.btn_huynv.Size = New System.Drawing.Size(95, 75)
        Me.btn_huynv.TabIndex = 21
        Me.btn_huynv.Text = "Hủy"
        Me.btn_huynv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_huynv.UseVisualStyleBackColor = True
        '
        'btn_luunv
        '
        Me.btn_luunv.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_luunv.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.luu
        Me.btn_luunv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_luunv.Location = New System.Drawing.Point(809, 523)
        Me.btn_luunv.Name = "btn_luunv"
        Me.btn_luunv.Size = New System.Drawing.Size(95, 75)
        Me.btn_luunv.TabIndex = 20
        Me.btn_luunv.Text = "Lưu"
        Me.btn_luunv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_luunv.UseVisualStyleBackColor = True
        '
        'btn_xoanv
        '
        Me.btn_xoanv.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_xoanv.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.xoa
        Me.btn_xoanv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_xoanv.Location = New System.Drawing.Point(676, 523)
        Me.btn_xoanv.Name = "btn_xoanv"
        Me.btn_xoanv.Size = New System.Drawing.Size(95, 75)
        Me.btn_xoanv.TabIndex = 19
        Me.btn_xoanv.Text = "Xóa"
        Me.btn_xoanv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_xoanv.UseVisualStyleBackColor = True
        '
        'btn_suanv
        '
        Me.btn_suanv.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_suanv.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.sua_1
        Me.btn_suanv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_suanv.Location = New System.Drawing.Point(537, 523)
        Me.btn_suanv.Name = "btn_suanv"
        Me.btn_suanv.Size = New System.Drawing.Size(95, 75)
        Me.btn_suanv.TabIndex = 18
        Me.btn_suanv.Text = "Sửa"
        Me.btn_suanv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_suanv.UseVisualStyleBackColor = True
        '
        'txt_timkiemnv
        '
        Me.txt_timkiemnv.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_timkiemnv.Location = New System.Drawing.Point(161, 45)
        Me.txt_timkiemnv.Name = "txt_timkiemnv"
        Me.txt_timkiemnv.Size = New System.Drawing.Size(280, 30)
        Me.txt_timkiemnv.TabIndex = 17
        '
        'btn_tknv
        '
        Me.btn_tknv.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_tknv.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.timkiem
        Me.btn_tknv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_tknv.Location = New System.Drawing.Point(24, 28)
        Me.btn_tknv.Name = "btn_tknv"
        Me.btn_tknv.Size = New System.Drawing.Size(123, 65)
        Me.btn_tknv.TabIndex = 16
        Me.btn_tknv.Text = "Tìm kiếm"
        Me.btn_tknv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_tknv.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cb_gt)
        Me.GroupBox2.Controls.Add(Me.txt_mnv)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txt_sdtnv)
        Me.GroupBox2.Controls.Add(Me.txt_tennv)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.txt_cvnv)
        Me.GroupBox2.Controls.Add(Me.txt_dcnv)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txt_luong)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 111)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(417, 325)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Thông tin"
        '
        'cb_gt
        '
        Me.cb_gt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_gt.FormattingEnabled = True
        Me.cb_gt.Items.AddRange(New Object() {"Nam", "Nữ"})
        Me.cb_gt.Location = New System.Drawing.Point(132, 105)
        Me.cb_gt.Name = "cb_gt"
        Me.cb_gt.Size = New System.Drawing.Size(271, 24)
        Me.cb_gt.TabIndex = 17
        '
        'txt_mnv
        '
        Me.txt_mnv.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_mnv.Location = New System.Drawing.Point(132, 25)
        Me.txt_mnv.Name = "txt_mnv"
        Me.txt_mnv.Size = New System.Drawing.Size(271, 30)
        Me.txt_mnv.TabIndex = 15
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(10, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(116, 22)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Mã nhân viên"
        '
        'txt_sdtnv
        '
        Me.txt_sdtnv.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sdtnv.Location = New System.Drawing.Point(132, 152)
        Me.txt_sdtnv.Name = "txt_sdtnv"
        Me.txt_sdtnv.Size = New System.Drawing.Size(271, 30)
        Me.txt_sdtnv.TabIndex = 14
        '
        'txt_tennv
        '
        Me.txt_tennv.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tennv.Location = New System.Drawing.Point(132, 65)
        Me.txt_tennv.Name = "txt_tennv"
        Me.txt_tennv.Size = New System.Drawing.Size(271, 30)
        Me.txt_tennv.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(10, 157)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(114, 22)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Số điện thoại"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(10, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 22)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Họ tên"
        '
        'txt_cvnv
        '
        Me.txt_cvnv.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_cvnv.Location = New System.Drawing.Point(132, 241)
        Me.txt_cvnv.Name = "txt_cvnv"
        Me.txt_cvnv.Size = New System.Drawing.Size(271, 30)
        Me.txt_cvnv.TabIndex = 10
        '
        'txt_dcnv
        '
        Me.txt_dcnv.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dcnv.Location = New System.Drawing.Point(132, 195)
        Me.txt_dcnv.Name = "txt_dcnv"
        Me.txt_dcnv.Size = New System.Drawing.Size(271, 30)
        Me.txt_dcnv.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 242)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 22)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Chức vụ"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 200)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 22)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Địa chỉ"
        '
        'txt_luong
        '
        Me.txt_luong.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_luong.Location = New System.Drawing.Point(132, 283)
        Me.txt_luong.Name = "txt_luong"
        Me.txt_luong.Size = New System.Drawing.Size(271, 30)
        Me.txt_luong.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 111)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 22)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Giới tính"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 288)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 22)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Lương"
        '
        'dg_nhanvien
        '
        Me.dg_nhanvien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dg_nhanvien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_nhanvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_nhanvien.Location = New System.Drawing.Point(468, 38)
        Me.dg_nhanvien.Name = "dg_nhanvien"
        Me.dg_nhanvien.RowHeadersWidth = 51
        Me.dg_nhanvien.RowTemplate.Height = 24
        Me.dg_nhanvien.Size = New System.Drawing.Size(582, 436)
        Me.dg_nhanvien.TabIndex = 14
        '
        'pnl_quanly
        '
        Me.pnl_quanly.AutoScroll = True
        Me.pnl_quanly.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.iceland_5104347_1280
        Me.pnl_quanly.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnl_quanly.Controls.Add(Me.GroupBox13)
        Me.pnl_quanly.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnl_quanly.Location = New System.Drawing.Point(134, 39)
        Me.pnl_quanly.Name = "pnl_quanly"
        Me.pnl_quanly.Size = New System.Drawing.Size(1058, 626)
        Me.pnl_quanly.TabIndex = 34
        Me.pnl_quanly.Visible = False
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.Label62)
        Me.GroupBox13.Controls.Add(Me.Label61)
        Me.GroupBox13.Controls.Add(Me.Label60)
        Me.GroupBox13.Location = New System.Drawing.Point(0, 64)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(1056, 508)
        Me.GroupBox13.TabIndex = 5
        Me.GroupBox13.TabStop = False
        '
        'Label62
        '
        Me.Label62.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label62.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(2, 149)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(1050, 65)
        Me.Label62.TabIndex = 7
        Me.Label62.Text = "Quản lý nhà khách hàng"
        '
        'Label61
        '
        Me.Label61.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label61.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(0, 82)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(1050, 65)
        Me.Label61.TabIndex = 6
        Me.Label61.Text = "Quản lý nhà cung cấp"
        '
        'Label60
        '
        Me.Label60.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label60.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(5, 17)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(1050, 65)
        Me.Label60.TabIndex = 5
        Me.Label60.Text = "Quản lý nhân viên"
        '
        'pnl_khachhang
        '
        Me.pnl_khachhang.Controls.Add(Me.btn_xdlkh)
        Me.pnl_khachhang.Controls.Add(Me.btn_themkh)
        Me.pnl_khachhang.Controls.Add(Me.btn_huykh)
        Me.pnl_khachhang.Controls.Add(Me.btn_luukh)
        Me.pnl_khachhang.Controls.Add(Me.btn_xoakh)
        Me.pnl_khachhang.Controls.Add(Me.btn_suakh)
        Me.pnl_khachhang.Controls.Add(Me.txt_timkiemkh)
        Me.pnl_khachhang.Controls.Add(Me.btn_timkiemkh)
        Me.pnl_khachhang.Controls.Add(Me.GroupBox3)
        Me.pnl_khachhang.Controls.Add(Me.dg_khachhang)
        Me.pnl_khachhang.Location = New System.Drawing.Point(137, 32)
        Me.pnl_khachhang.Name = "pnl_khachhang"
        Me.pnl_khachhang.Size = New System.Drawing.Size(1053, 633)
        Me.pnl_khachhang.TabIndex = 39
        Me.pnl_khachhang.Visible = False
        '
        'btn_xdlkh
        '
        Me.btn_xdlkh.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_xdlkh.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.xdl
        Me.btn_xdlkh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_xdlkh.Location = New System.Drawing.Point(68, 449)
        Me.btn_xdlkh.Name = "btn_xdlkh"
        Me.btn_xdlkh.Size = New System.Drawing.Size(309, 145)
        Me.btn_xdlkh.TabIndex = 33
        Me.btn_xdlkh.Text = "Xuất dữ liệu ra excel"
        Me.btn_xdlkh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_xdlkh.UseVisualStyleBackColor = True
        '
        'btn_themkh
        '
        Me.btn_themkh.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_themkh.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.them
        Me.btn_themkh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_themkh.Location = New System.Drawing.Point(391, 530)
        Me.btn_themkh.Name = "btn_themkh"
        Me.btn_themkh.Size = New System.Drawing.Size(109, 75)
        Me.btn_themkh.TabIndex = 32
        Me.btn_themkh.Text = "Thêm"
        Me.btn_themkh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_themkh.UseVisualStyleBackColor = True
        '
        'btn_huykh
        '
        Me.btn_huykh.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_huykh.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.huy_
        Me.btn_huykh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_huykh.Location = New System.Drawing.Point(919, 530)
        Me.btn_huykh.Name = "btn_huykh"
        Me.btn_huykh.Size = New System.Drawing.Size(109, 75)
        Me.btn_huykh.TabIndex = 31
        Me.btn_huykh.Text = "Hủy"
        Me.btn_huykh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_huykh.UseVisualStyleBackColor = True
        '
        'btn_luukh
        '
        Me.btn_luukh.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_luukh.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.luu
        Me.btn_luukh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_luukh.Location = New System.Drawing.Point(794, 530)
        Me.btn_luukh.Name = "btn_luukh"
        Me.btn_luukh.Size = New System.Drawing.Size(109, 75)
        Me.btn_luukh.TabIndex = 30
        Me.btn_luukh.Text = "Lưu"
        Me.btn_luukh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_luukh.UseVisualStyleBackColor = True
        '
        'btn_xoakh
        '
        Me.btn_xoakh.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_xoakh.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.xoa
        Me.btn_xoakh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_xoakh.Location = New System.Drawing.Point(657, 530)
        Me.btn_xoakh.Name = "btn_xoakh"
        Me.btn_xoakh.Size = New System.Drawing.Size(109, 75)
        Me.btn_xoakh.TabIndex = 29
        Me.btn_xoakh.Text = "Xóa"
        Me.btn_xoakh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_xoakh.UseVisualStyleBackColor = True
        '
        'btn_suakh
        '
        Me.btn_suakh.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_suakh.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.sua_1
        Me.btn_suakh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_suakh.Location = New System.Drawing.Point(522, 530)
        Me.btn_suakh.Name = "btn_suakh"
        Me.btn_suakh.Size = New System.Drawing.Size(109, 75)
        Me.btn_suakh.TabIndex = 28
        Me.btn_suakh.Text = "Sửa"
        Me.btn_suakh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_suakh.UseVisualStyleBackColor = True
        '
        'txt_timkiemkh
        '
        Me.txt_timkiemkh.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_timkiemkh.Location = New System.Drawing.Point(161, 52)
        Me.txt_timkiemkh.Name = "txt_timkiemkh"
        Me.txt_timkiemkh.Size = New System.Drawing.Size(280, 30)
        Me.txt_timkiemkh.TabIndex = 27
        '
        'btn_timkiemkh
        '
        Me.btn_timkiemkh.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_timkiemkh.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.timkiem
        Me.btn_timkiemkh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_timkiemkh.Location = New System.Drawing.Point(24, 35)
        Me.btn_timkiemkh.Name = "btn_timkiemkh"
        Me.btn_timkiemkh.Size = New System.Drawing.Size(123, 65)
        Me.btn_timkiemkh.TabIndex = 26
        Me.btn_timkiemkh.Text = "Tìm kiếm"
        Me.btn_timkiemkh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_timkiemkh.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_makh)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txt_sdtkh)
        Me.GroupBox3.Controls.Add(Me.txt_tenkh)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txt_emailkh)
        Me.GroupBox3.Controls.Add(Me.txt_diachikh)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Location = New System.Drawing.Point(24, 141)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(424, 238)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Thông tin"
        '
        'txt_makh
        '
        Me.txt_makh.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_makh.Location = New System.Drawing.Point(146, 26)
        Me.txt_makh.Name = "txt_makh"
        Me.txt_makh.Size = New System.Drawing.Size(271, 30)
        Me.txt_makh.TabIndex = 15
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(10, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(127, 22)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Mã khách hàng"
        '
        'txt_sdtkh
        '
        Me.txt_sdtkh.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sdtkh.Location = New System.Drawing.Point(146, 108)
        Me.txt_sdtkh.Name = "txt_sdtkh"
        Me.txt_sdtkh.Size = New System.Drawing.Size(271, 30)
        Me.txt_sdtkh.TabIndex = 14
        '
        'txt_tenkh
        '
        Me.txt_tenkh.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tenkh.Location = New System.Drawing.Point(146, 66)
        Me.txt_tenkh.Name = "txt_tenkh"
        Me.txt_tenkh.Size = New System.Drawing.Size(271, 30)
        Me.txt_tenkh.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(10, 112)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 22)
        Me.Label18.TabIndex = 13
        Me.Label18.Text = "Số điện thoại"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(10, 70)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 22)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "Họ tên"
        '
        'txt_emailkh
        '
        Me.txt_emailkh.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_emailkh.Location = New System.Drawing.Point(146, 197)
        Me.txt_emailkh.Name = "txt_emailkh"
        Me.txt_emailkh.Size = New System.Drawing.Size(271, 30)
        Me.txt_emailkh.TabIndex = 10
        '
        'txt_diachikh
        '
        Me.txt_diachikh.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_diachikh.Location = New System.Drawing.Point(146, 151)
        Me.txt_diachikh.Name = "txt_diachikh"
        Me.txt_diachikh.Size = New System.Drawing.Size(271, 30)
        Me.txt_diachikh.TabIndex = 7
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(10, 197)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(57, 22)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "Email"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(10, 155)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 22)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "Địa chỉ"
        '
        'dg_khachhang
        '
        Me.dg_khachhang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dg_khachhang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_khachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_khachhang.Location = New System.Drawing.Point(468, 45)
        Me.dg_khachhang.Name = "dg_khachhang"
        Me.dg_khachhang.RowHeadersWidth = 51
        Me.dg_khachhang.RowTemplate.Height = 24
        Me.dg_khachhang.Size = New System.Drawing.Size(582, 436)
        Me.dg_khachhang.TabIndex = 24
        '
        'pnl_ncc
        '
        Me.pnl_ncc.Controls.Add(Me.btn_xdlncc)
        Me.pnl_ncc.Controls.Add(Me.btn_themncc)
        Me.pnl_ncc.Controls.Add(Me.btn_huyncc)
        Me.pnl_ncc.Controls.Add(Me.btn_luuncc)
        Me.pnl_ncc.Controls.Add(Me.btn_xoancc)
        Me.pnl_ncc.Controls.Add(Me.btn_suancc)
        Me.pnl_ncc.Controls.Add(Me.txt_timkiemncc)
        Me.pnl_ncc.Controls.Add(Me.btn_timkiemncc)
        Me.pnl_ncc.Controls.Add(Me.GroupBox4)
        Me.pnl_ncc.Controls.Add(Me.dg_ncc)
        Me.pnl_ncc.Location = New System.Drawing.Point(134, 32)
        Me.pnl_ncc.Name = "pnl_ncc"
        Me.pnl_ncc.Size = New System.Drawing.Size(1058, 633)
        Me.pnl_ncc.TabIndex = 40
        Me.pnl_ncc.Visible = False
        '
        'btn_xdlncc
        '
        Me.btn_xdlncc.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_xdlncc.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.xdl
        Me.btn_xdlncc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_xdlncc.Location = New System.Drawing.Point(66, 449)
        Me.btn_xdlncc.Name = "btn_xdlncc"
        Me.btn_xdlncc.Size = New System.Drawing.Size(309, 145)
        Me.btn_xdlncc.TabIndex = 43
        Me.btn_xdlncc.Text = "Xuất dữ liệu ra excel"
        Me.btn_xdlncc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_xdlncc.UseVisualStyleBackColor = True
        '
        'btn_themncc
        '
        Me.btn_themncc.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_themncc.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.them
        Me.btn_themncc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_themncc.Location = New System.Drawing.Point(393, 529)
        Me.btn_themncc.Name = "btn_themncc"
        Me.btn_themncc.Size = New System.Drawing.Size(108, 75)
        Me.btn_themncc.TabIndex = 42
        Me.btn_themncc.Text = "Thêm"
        Me.btn_themncc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_themncc.UseVisualStyleBackColor = True
        '
        'btn_huyncc
        '
        Me.btn_huyncc.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_huyncc.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.huy_
        Me.btn_huyncc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_huyncc.Location = New System.Drawing.Point(938, 529)
        Me.btn_huyncc.Name = "btn_huyncc"
        Me.btn_huyncc.Size = New System.Drawing.Size(108, 75)
        Me.btn_huyncc.TabIndex = 41
        Me.btn_huyncc.Text = "Hủy"
        Me.btn_huyncc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_huyncc.UseVisualStyleBackColor = True
        '
        'btn_luuncc
        '
        Me.btn_luuncc.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_luuncc.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.luu
        Me.btn_luuncc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_luuncc.Location = New System.Drawing.Point(800, 529)
        Me.btn_luuncc.Name = "btn_luuncc"
        Me.btn_luuncc.Size = New System.Drawing.Size(108, 75)
        Me.btn_luuncc.TabIndex = 40
        Me.btn_luuncc.Text = "Lưu"
        Me.btn_luuncc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_luuncc.UseVisualStyleBackColor = True
        '
        'btn_xoancc
        '
        Me.btn_xoancc.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_xoancc.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.xoa
        Me.btn_xoancc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_xoancc.Location = New System.Drawing.Point(662, 529)
        Me.btn_xoancc.Name = "btn_xoancc"
        Me.btn_xoancc.Size = New System.Drawing.Size(108, 75)
        Me.btn_xoancc.TabIndex = 39
        Me.btn_xoancc.Text = "Xóa"
        Me.btn_xoancc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_xoancc.UseVisualStyleBackColor = True
        '
        'btn_suancc
        '
        Me.btn_suancc.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_suancc.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.sua_1
        Me.btn_suancc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_suancc.Location = New System.Drawing.Point(525, 529)
        Me.btn_suancc.Name = "btn_suancc"
        Me.btn_suancc.Size = New System.Drawing.Size(108, 75)
        Me.btn_suancc.TabIndex = 38
        Me.btn_suancc.Text = "Sửa"
        Me.btn_suancc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_suancc.UseVisualStyleBackColor = True
        '
        'txt_timkiemncc
        '
        Me.txt_timkiemncc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_timkiemncc.Location = New System.Drawing.Point(159, 52)
        Me.txt_timkiemncc.Name = "txt_timkiemncc"
        Me.txt_timkiemncc.Size = New System.Drawing.Size(280, 30)
        Me.txt_timkiemncc.TabIndex = 37
        '
        'btn_timkiemncc
        '
        Me.btn_timkiemncc.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_timkiemncc.Image = Global.QuanLyBanDienThoai.My.Resources.Resources.timkiem
        Me.btn_timkiemncc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_timkiemncc.Location = New System.Drawing.Point(22, 35)
        Me.btn_timkiemncc.Name = "btn_timkiemncc"
        Me.btn_timkiemncc.Size = New System.Drawing.Size(123, 65)
        Me.btn_timkiemncc.TabIndex = 36
        Me.btn_timkiemncc.Text = "Tìm kiếm"
        Me.btn_timkiemncc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_timkiemncc.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txt_mancc)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.txt_sdtncc)
        Me.GroupBox4.Controls.Add(Me.txt_tenncc)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.txt_emailncc)
        Me.GroupBox4.Controls.Add(Me.txt_diachincc)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.Label26)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 141)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(447, 238)
        Me.GroupBox4.TabIndex = 35
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Thông tin"
        '
        'txt_mancc
        '
        Me.txt_mancc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_mancc.Location = New System.Drawing.Point(158, 20)
        Me.txt_mancc.Name = "txt_mancc"
        Me.txt_mancc.Size = New System.Drawing.Size(271, 30)
        Me.txt_mancc.TabIndex = 15
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(10, 30)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(142, 22)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "Mã nhà cung cấp"
        '
        'txt_sdtncc
        '
        Me.txt_sdtncc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_sdtncc.Location = New System.Drawing.Point(158, 102)
        Me.txt_sdtncc.Name = "txt_sdtncc"
        Me.txt_sdtncc.Size = New System.Drawing.Size(271, 30)
        Me.txt_sdtncc.TabIndex = 14
        '
        'txt_tenncc
        '
        Me.txt_tenncc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_tenncc.Location = New System.Drawing.Point(158, 60)
        Me.txt_tenncc.Name = "txt_tenncc"
        Me.txt_tenncc.Size = New System.Drawing.Size(271, 30)
        Me.txt_tenncc.TabIndex = 11
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(10, 112)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(114, 22)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "Số điện thoại"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(10, 70)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(146, 22)
        Me.Label24.TabIndex = 12
        Me.Label24.Text = "Tên nhà cung cấp"
        '
        'txt_emailncc
        '
        Me.txt_emailncc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_emailncc.Location = New System.Drawing.Point(158, 191)
        Me.txt_emailncc.Name = "txt_emailncc"
        Me.txt_emailncc.Size = New System.Drawing.Size(271, 30)
        Me.txt_emailncc.TabIndex = 10
        '
        'txt_diachincc
        '
        Me.txt_diachincc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_diachincc.Location = New System.Drawing.Point(158, 145)
        Me.txt_diachincc.Name = "txt_diachincc"
        Me.txt_diachincc.Size = New System.Drawing.Size(271, 30)
        Me.txt_diachincc.TabIndex = 7
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(10, 197)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(57, 22)
        Me.Label25.TabIndex = 9
        Me.Label25.Text = "Email"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(10, 155)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(68, 22)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "Địa chỉ"
        '
        'dg_ncc
        '
        Me.dg_ncc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dg_ncc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dg_ncc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg_ncc.Location = New System.Drawing.Point(466, 45)
        Me.dg_ncc.Name = "dg_ncc"
        Me.dg_ncc.RowHeadersWidth = 51
        Me.dg_ncc.RowTemplate.Height = 24
        Me.dg_ncc.Size = New System.Drawing.Size(587, 436)
        Me.dg_ncc.TabIndex = 34
        '
        'btn_home
        '
        Me.btn_home.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.house
        Me.btn_home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_home.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_home.Location = New System.Drawing.Point(1223, 473)
        Me.btn_home.Name = "btn_home"
        Me.btn_home.Size = New System.Drawing.Size(73, 119)
        Me.btn_home.TabIndex = 37
        Me.btn_home.UseVisualStyleBackColor = True
        '
        'btn_back
        '
        Me.btn_back.BackgroundImage = Global.QuanLyBanDienThoai.My.Resources.Resources.chevron_left
        Me.btn_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_back.Location = New System.Drawing.Point(1223, 109)
        Me.btn_back.Name = "btn_back"
        Me.btn_back.Size = New System.Drawing.Size(73, 119)
        Me.btn_back.TabIndex = 36
        Me.btn_back.UseVisualStyleBackColor = True
        '
        'btn_thoat
        '
        Me.btn_thoat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_thoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_thoat.Location = New System.Drawing.Point(1223, 286)
        Me.btn_thoat.Name = "btn_thoat"
        Me.btn_thoat.Size = New System.Drawing.Size(73, 119)
        Me.btn_thoat.TabIndex = 35
        Me.btn_thoat.UseVisualStyleBackColor = True
        '
        'FormQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1325, 687)
        Me.Controls.Add(Me.pnl_nen)
        Me.Name = "FormQL"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormQL"
        Me.pnl_nen.ResumeLayout(False)
        Me.pnl_nhanvien.ResumeLayout(False)
        Me.pnl_nhanvien.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dg_nhanvien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_quanly.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.pnl_khachhang.ResumeLayout(False)
        Me.pnl_khachhang.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dg_khachhang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_ncc.ResumeLayout(False)
        Me.pnl_ncc.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dg_ncc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnl_nen As Panel
    Friend WithEvents pnl_nhanvien As Panel
    Friend WithEvents btn_xdlnv As Button
    Friend WithEvents btn_themnv As Button
    Friend WithEvents btn_huynv As Button
    Friend WithEvents btn_luunv As Button
    Friend WithEvents btn_xoanv As Button
    Friend WithEvents btn_suanv As Button
    Friend WithEvents txt_timkiemnv As TextBox
    Friend WithEvents btn_tknv As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cb_gt As ComboBox
    Friend WithEvents txt_mnv As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txt_sdtnv As TextBox
    Friend WithEvents txt_tennv As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txt_cvnv As TextBox
    Friend WithEvents txt_dcnv As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txt_luong As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents dg_nhanvien As DataGridView
    Friend WithEvents pnl_quanly As Panel
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents Label62 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents pnl_khachhang As Panel
    Friend WithEvents btn_xdlkh As Button
    Friend WithEvents btn_themkh As Button
    Friend WithEvents btn_huykh As Button
    Friend WithEvents btn_luukh As Button
    Friend WithEvents btn_xoakh As Button
    Friend WithEvents btn_suakh As Button
    Friend WithEvents txt_timkiemkh As TextBox
    Friend WithEvents btn_timkiemkh As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txt_makh As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txt_sdtkh As TextBox
    Friend WithEvents txt_tenkh As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txt_emailkh As TextBox
    Friend WithEvents txt_diachikh As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents dg_khachhang As DataGridView
    Friend WithEvents pnl_ncc As Panel
    Friend WithEvents btn_xdlncc As Button
    Friend WithEvents btn_themncc As Button
    Friend WithEvents btn_huyncc As Button
    Friend WithEvents btn_luuncc As Button
    Friend WithEvents btn_xoancc As Button
    Friend WithEvents btn_suancc As Button
    Friend WithEvents txt_timkiemncc As TextBox
    Friend WithEvents btn_timkiemncc As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txt_mancc As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txt_sdtncc As TextBox
    Friend WithEvents txt_tenncc As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents txt_emailncc As TextBox
    Friend WithEvents txt_diachincc As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents dg_ncc As DataGridView
    Friend WithEvents btn_home As Button
    Friend WithEvents btn_back As Button
    Friend WithEvents btn_thoat As Button
End Class
