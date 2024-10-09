Imports MySql.Data.MySqlClient

Public Class FrmRetiroLibros

    Dim conn As New MySqlConnection("Server=192.168.1.34;Port=3306;Database=base_biblioteca;Uid=tomas;Pwd=S3gura@2024;")
    Dim cmd As New MySqlCommand
    Dim dr As MySqlDataReader
    Dim Sql As String

    Private Sub FrmRetiroLibros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarGrilla()
        txtBuscar.Select()
    End Sub

    Sub LlenarGrilla()
        Sql = "SELECT * FROM TABLAINVENTARIOS"
        Dim InvDA As New MySqlDataAdapter(Sql, conn)
        Dim InvDS As New DataSet
        InvDA.Fill(InvDS)
        GrillaInventario.DataSource = InvDS.Tables(0)

        GrillaInventario.Columns(0).Visible = False 'ID
        GrillaInventario.Columns(1).Visible = True 'NOMBRE
        GrillaInventario.Columns(2).Visible = True 'CODIGO
        GrillaInventario.Columns(3).Visible = True 'CATEGORIA
        GrillaInventario.Columns(4).Visible = True 'UBICACION

        GrillaInventario.Columns(1).Width = 220
        GrillaInventario.Columns(2).Width = 100
        GrillaInventario.Columns(3).Width = 150
        GrillaInventario.Columns(4).Width = 70
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            Dim DABuscar As MySqlDataAdapter = Nothing ' Inicialización predeterminada
            Dim DSBuscar As New DataSet

            If RdoNombre.Checked Then
                Sql = "SELECT * FROM TABLAINVENTARIOS WHERE NOMBRE LIKE @Buscar"
                DABuscar = New MySqlDataAdapter(Sql, conn)
                DABuscar.SelectCommand.Parameters.AddWithValue("@Buscar", "%" & Trim(txtBuscar.Text) & "%")
            ElseIf RdoCodigo.Checked Then
                Sql = "SELECT * FROM TABLAINVENTARIOS WHERE CODIGO LIKE @Buscar"
                DABuscar = New MySqlDataAdapter(Sql, conn)
                DABuscar.SelectCommand.Parameters.AddWithValue("@Buscar", "%" & Trim(txtBuscar.Text) & "%")
            ElseIf RdoCategoria.Checked Then
                Sql = "SELECT * FROM TABLAINVENTARIOS WHERE CATEGORIA LIKE @Buscar"
                DABuscar = New MySqlDataAdapter(Sql, conn)
                DABuscar.SelectCommand.Parameters.AddWithValue("@Buscar", "%" & Trim(txtBuscar.Text) & "%")
            End If

            ' Solo intenta llenar el DataSet si DABuscar ha sido inicializado
            If DABuscar IsNot Nothing Then
                DABuscar.Fill(DSBuscar)
                GrillaInventario.DataSource = DSBuscar.Tables(0)
            End If

            ' Liberar recursos
            DABuscar = Nothing
        End If
    End Sub

    Private Sub GrillaInventario_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaInventario.CellContentDoubleClick
        FrmRetiros.txtLibro.Text = GrillaInventario.Rows(GrillaInventario.CurrentRow.Index).Cells(1).Value.ToString()
        FrmRetiros.txtCodigo.Text = GrillaInventario.Rows(GrillaInventario.CurrentRow.Index).Cells(2).Value.ToString()
        Me.Close()
    End Sub
End Class
