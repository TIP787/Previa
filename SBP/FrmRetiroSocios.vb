Imports MySql.Data.MySqlClient

Public Class FrmRetiroSocios

    Dim conn As New MySqlConnection("Server=192.168.1.34;Port=3306;Database=base_biblioteca;Uid=tomas;Pwd=S3gura@2024;")
    Dim cmd As New MySqlCommand
    Dim dr As MySqlDataReader
    Dim Sql As String

    Private Sub FrmRetiroSocios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarGrilla()
        txtBuscar.Select()
    End Sub

    Sub LlenarGrilla()
        Dim LlenarAdp As New MySqlDataAdapter("SELECT * FROM TABLASOCIOS", conn)
        Dim LlenaDS As New DataSet

        LlenarAdp.Fill(LlenaDS)
        GrillaSocios.DataSource = LlenaDS.Tables(0)

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
            Dim DABuscar As MySqlDataAdapter = Nothing ' Inicializar a Nothing
            Dim DSBuscar As New DataSet

            If RdoNombre.Checked Then
                Sql = "SELECT * FROM TABLASOCIOS WHERE NOMBRE LIKE @Buscar"
                DABuscar = New MySqlDataAdapter(Sql, conn)
                DABuscar.SelectCommand.Parameters.AddWithValue("@Buscar", "%" & Trim(txtBuscar.Text) & "%")
            ElseIf RdoDNI.Checked Then
                Sql = "SELECT * FROM TABLASOCIOS WHERE DNI LIKE @Buscar"
                DABuscar = New MySqlDataAdapter(Sql, conn)
                DABuscar.SelectCommand.Parameters.AddWithValue("@Buscar", "%" & Trim(txtBuscar.Text) & "%")
            ElseIf RdoDireccion.Checked Then
                Sql = "SELECT * FROM TABLASOCIOS WHERE DIRECCION LIKE @Buscar"
                DABuscar = New MySqlDataAdapter(Sql, conn)
                DABuscar.SelectCommand.Parameters.AddWithValue("@Buscar", "%" & Trim(txtBuscar.Text) & "%")
            ElseIf RdoTelefono.Checked Then
                Sql = "SELECT * FROM TABLASOCIOS WHERE TELEFONO LIKE @Buscar"
                DABuscar = New MySqlDataAdapter(Sql, conn)
                DABuscar.SelectCommand.Parameters.AddWithValue("@Buscar", "%" & Trim(txtBuscar.Text) & "%")
            End If

            ' Solo intenta llenar el DataSet si DABuscar ha sido inicializado
            If DABuscar IsNot Nothing Then
                DABuscar.Fill(DSBuscar)
                GrillaSocios.DataSource = DSBuscar.Tables(0)
            End If

            ' Liberar recursos
            DABuscar = Nothing
        End If
    End Sub

    Private Sub GrillaSocios_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaSocios.CellContentDoubleClick
        FrmRetiros.txtNombre.Text = GrillaSocios.Rows(GrillaSocios.CurrentRow.Index).Cells(1).Value.ToString()
        FrmRetiros.txtTelefono.Text = GrillaSocios.Rows(GrillaSocios.CurrentRow.Index).Cells(4).Value.ToString()
        Me.Close()
    End Sub
End Class