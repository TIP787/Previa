Imports MySql.Data.MySqlClient

Public Class FrmPagosSocios

    Dim conn As New MySqlConnection("Server=192.168.1.34;Port=3306;Database=base_biblioteca;Uid=tomas;Pwd=S3gura@2024;")
    Dim cmd As New MySqlCommand
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim Sql As String

    Private Sub FrmPagosSocios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarGrilla()
        txtBuscar.Select()
    End Sub

    Sub LlenarGrilla()
        Sql = "SELECT * FROM TABLASOCIOS"
        da = New MySqlDataAdapter(Sql, conn)
        ds = New DataSet()

        da.Fill(ds)
        GrillaSocios.DataSource = ds.Tables(0)

        GrillaSocios.Columns(0).Visible = False ' ID
        GrillaSocios.Columns(1).Visible = True ' NOMBRE
        GrillaSocios.Columns(2).Visible = True ' DNI
        GrillaSocios.Columns(3).Visible = False ' DIRECCION
        GrillaSocios.Columns(4).Visible = True ' TELEFONO
        GrillaSocios.Columns(5).Visible = False ' CORREO
        GrillaSocios.Columns(6).Visible = False ' FECHA_ALTA

        GrillaSocios.Columns(1).Width = 200
        GrillaSocios.Columns(2).Width = 150
        GrillaSocios.Columns(4).Width = 150

        GrillaSocios.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GrillaSocios.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GrillaSocios.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            Dim buscarTexto As String = Trim(txtBuscar.Text)
            Dim parametroBusqueda As String = "%" & buscarTexto & "%"

            If RdoNombre.Checked Then
                Sql = "SELECT * FROM TABLASOCIOS WHERE NOMBRE LIKE @BuscarTexto"
            ElseIf RdoDNI.Checked Then
                Sql = "SELECT * FROM TABLASOCIOS WHERE DNI LIKE @BuscarTexto"
            ElseIf RdoDireccion.Checked Then
                Sql = "SELECT * FROM TABLASOCIOS WHERE DIRECCION LIKE @BuscarTexto"
            ElseIf RdoTelefono.Checked Then
                Sql = "SELECT * FROM TABLASOCIOS WHERE TELEFONO LIKE @BuscarTexto"
            End If

            da = New MySqlDataAdapter(Sql, conn)
            da.SelectCommand.Parameters.AddWithValue("@BuscarTexto", parametroBusqueda)
            ds = New DataSet()

            da.Fill(ds)
            GrillaSocios.DataSource = ds.Tables(0)
        End If
    End Sub

    Private Sub GrillaSocios_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaSocios.CellContentDoubleClick
        FrmPagos.txtNombre.Text = GrillaSocios.Rows(GrillaSocios.CurrentRow.Index).Cells(1).Value.ToString()
        Me.Close()
    End Sub

End Class
