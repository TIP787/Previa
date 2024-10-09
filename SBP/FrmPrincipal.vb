
Public Class FrmPrincipal

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Conectarse()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnSocios_Click(sender As Object, e As EventArgs) Handles BtnSocios.Click
        FrmSocios.ShowDialog()
    End Sub

    Private Sub BtnGastos_Click(sender As Object, e As EventArgs) Handles BtnGastos.Click
        FrmGastos.ShowDialog()
    End Sub

    Private Sub BtnCategorias_Click(sender As Object, e As EventArgs) Handles BtnCategorias.Click
        FrmCategoria.ShowDialog()
    End Sub

    Private Sub BtnInventarios_Click(sender As Object, e As EventArgs) Handles BtnInventarios.Click
        FrmInventario.ShowDialog()
    End Sub

    Private Sub BtnRetiros_Click(sender As Object, e As EventArgs) Handles BtnRetiros.Click
        FrmRetiros.ShowDialog()
    End Sub

    Private Sub BtnCuotas_Click(sender As Object, e As EventArgs) Handles BtnCuotas.Click
        FrmPagos.ShowDialog()
    End Sub

    Private Sub BtnIngresos_Click(sender As Object, e As EventArgs) Handles BtnIngresos.Click
        'MsgBox("En Desarrollo...", vbInformation, "SGB")
        FrmIngresos.ShowDialog()
    End Sub

    Private Sub NI_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NI.MouseDoubleClick
        NI.Visible = False
        Me.Show()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Hide()
        NI.Visible = True
        Me.ShowInTaskbar = True
        NI.ShowBalloonTip(3, "Sistema Bliblioteca Popular", "Doble Click para abrir", ToolTipIcon.Info)
    End Sub
End Class
