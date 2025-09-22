Public Class BaoCaoHoaDonNhap
    Private Sub BaoCaoHoaDonNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tạo DataSet và TableAdapter
        Dim ds As New dshoadonnhap()
        Dim adapter As New dshoadonnhapTableAdapters.HoaDonNhapTableAdapter()
        adapter.Fill(ds.HoaDonNhap)

        ' Tạo report và gán DataSource là DataSet đã có dữ liệu
        Dim report As New crphoadonnhap()
        report.SetDataSource(ds)

        ' Gán report cho CrystalReportViewer
        CrystalReportViewer1.ReportSource = report
    End Sub
End Class