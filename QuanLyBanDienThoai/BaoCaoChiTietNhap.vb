Public Class BaoCaoChiTietNhap
    Private Sub BaoCaoChiTietNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tạo DataSet và TableAdapter
        Dim ds As New dschitietnhap()
        Dim adapter As New dschitietnhapTableAdapters.ChiTietNhapTableAdapter()
        adapter.Fill(ds.ChiTietNhap)

        ' Tạo report và gán DataSource là DataSet đã có dữ liệu
        Dim report As New crpchitietnhap()
        report.SetDataSource(ds)

        ' Gán report cho CrystalReportViewer
        CrystalReportViewer1.ReportSource = report
    End Sub
End Class