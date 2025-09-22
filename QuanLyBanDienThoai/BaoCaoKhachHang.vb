Public Class BaoCaoKhachHang

    Private Sub BaoCaoKhachHang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tạo DataSet và TableAdapter
        Dim ds As New dskhachhang()
        Dim adapter As New dskhachhangTableAdapters.KhachHangTableAdapter()
        adapter.Fill(ds.KhachHang)

        ' Tạo report và gán DataSource là DataSet đã có dữ liệu
        Dim report As New crpkhachhang()
        report.SetDataSource(ds)

        ' Gán report cho CrystalReportViewer
        CrystalReportViewer1.ReportSource = report
    End Sub
End Class