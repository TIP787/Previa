Imports MySql.Data.MySqlClient

Public Class FrmInventario

    ' Definir la conexión MySQL
    Dim conn As New MySqlConnection("Server=192.168.1.34;Port=3306;Database=base_biblioteca;Uid=tomas;Pwd=S3gura@2024;")

    Private Sub FrmInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombre.Select()
        LlenarGrilla()
        LlenarCategoria()
    End Sub

    Sub Limpiar()
        txtNombre.Clear()
        txtCodigo.Clear()
        txtUbicacion.Clear()
        cboCategoria.Text = ""
        txtNombre.Select()
        CodigoABuscar = 0
    End Sub

    Sub LlenarGrilla()
        Dim Sql As String = "SELECT * FROM TABLAINVENTARIOS"
        Dim InvDA As New MySqlDataAdapter(Sql, conn)
        Dim InvDS As New DataSet
        InvDA.Fill(InvDS)
        GrillaInventario.DataSource = InvDS.Tables(0)

        GrillaInventario.Columns(0).Visible = False 'ID
        GrillaInventario.Columns(1).Visible = True 'NOMBRE
        GrillaInventario.Columns(2).Visible = True 'CODIGO
        GrillaInventario.Columns(3).Visible = True 'CATEGORIA
        GrillaInventario.Columns(4).Visible = True 'UBICACION

        GrillaInventario.Columns(1).Width = 200
        GrillaInventario.Columns(2).Width = 100
        GrillaInventario.Columns(3).Width = 150
        GrillaInventario.Columns(4).Width = 70

        InvDA.Dispose()
    End Sub

    Sub LlenarCategoria()
        cboCategoria.Items.Clear()

        Dim Sql As String = "SELECT * FROM TABLACATEGORIAS"
        Using cmd As New MySqlCommand(Sql, conn)
            cmd.CommandType = CommandType.Text
            conn.Open()
            Using dr As MySqlDataReader = cmd.ExecuteReader()
                If dr.HasRows Then
                    While dr.Read()
                        cboCategoria.Items.Add(dr.GetValue(1))
                    End While
                End If
            End Using
            conn.Close()
        End Using
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        On Error GoTo Salir

        If txtNombre.Text.Trim.Length = 0 Then MsgBox("Ingrese el nombre del libro", vbInformation, "SGB") : txtNombre.Select() : Exit Sub
        If txtCodigo.Text.Trim.Length = 0 Then MsgBox("Ingrese el código del libro", vbInformation, "SGB") : txtCodigo.Select() : Exit Sub
        If txtUbicacion.Text.Trim.Length = 0 Then MsgBox("Ingrese la ubicación del libro", vbInformation, "SGB") : txtUbicacion.Select() : Exit Sub
        If cboCategoria.Text = "" Then MsgBox("Ingrese la categoría del libro", vbInformation, "SGB") : Exit Sub
        If CodigoABuscar <> 0 Then MsgBox("No puede ingresar estos registros porque ya existen en la base de datos, quizás usted intentó editarlo o eliminarlo", vbInformation, "SGB") : Exit Sub

        Dim Sql As String = "INSERT INTO TABLAINVENTARIOS (NOMBRE, CODIGO, CATEGORIA, UBICACION) VALUES (@NOMBRE, @CODIGO, @CATEGORIA, @UBICACION)"
        Using Comando As New MySqlCommand(Sql, conn)
            Comando.CommandType = CommandType.Text
            With Comando.Parameters
                .AddWithValue("@NOMBRE", Trim(txtNombre.Text))
                .AddWithValue("@CODIGO", Trim(txtCodigo.Text))
                .AddWithValue("@CATEGORIA", Trim(cboCategoria.Text))
                .AddWithValue("@UBICACION", Trim(txtUbicacion.Text))
            End With
            conn.Open()
            Comando.ExecuteNonQuery()
            conn.Close()
        End Using

        MsgBox("Se insertaron los datos correctamente!", vbInformation, "SGB")
        LlenarGrilla()
        LlenarCategoria()
        Limpiar()
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        conn.Close()
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        On Error GoTo Salir

        If CodigoABuscar = 0 Then MsgBox("Seleccione un libro de la grilla", vbInformation, "SGB") : Exit Sub

        Dim Sql As String = "UPDATE TABLAINVENTARIOS SET NOMBRE = @NOMBRE, CODIGO = @CODIGO, CATEGORIA = @CATEGORIA, UBICACION = @UBICACION WHERE ID = @ID"
        Using Comando As New MySqlCommand(Sql, conn)
            Comando.CommandType = CommandType.Text
            With Comando.Parameters
                .AddWithValue("@NOMBRE", Trim(txtNombre.Text))
                .AddWithValue("@CODIGO", Trim(txtCodigo.Text))
                .AddWithValue("@CATEGORIA", Trim(cboCategoria.Text))
                .AddWithValue("@UBICACION", Trim(txtUbicacion.Text))
                .AddWithValue("@ID", CodigoABuscar)
            End With
            conn.Open()
            Comando.ExecuteNonQuery()
            conn.Close()
        End Using

        MsgBox("Los datos se editaron correctamente", vbInformation, "SGB")
        LlenarCategoria()
        LlenarGrilla()
        Limpiar()
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        conn.Close()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        On Error GoTo Salir

        If CodigoABuscar = 0 Then MsgBox("Seleccione un libro de la grilla", vbInformation, "SGB") : Exit Sub
        If MsgBox("¿Desea eliminarlo realmente?", vbYesNo, "SGB") = vbYes Then
            Dim Sql As String = "DELETE FROM TABLAINVENTARIOS WHERE ID = @ID"
            Using Comando As New MySqlCommand(Sql, conn)
                Comando.CommandType = CommandType.Text
                Comando.Parameters.AddWithValue("@ID", CodigoABuscar)
                conn.Open()
                Comando.ExecuteNonQuery()
                conn.Close()
            End Using

            MsgBox("Los datos fueron borrados correctamente", vbInformation, "SGB")
            LlenarCategoria()
            LlenarGrilla()
            Limpiar()
        End If
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        conn.Close()
    End Sub

    Private Sub GrillaInventario_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaInventario.CellContentClick
        If e.RowIndex >= 0 Then ' Asegurarse de que el índice de fila es válido
            CodigoABuscar = GrillaInventario.Rows(e.RowIndex).Cells(0).Value
            txtNombre.Text = GrillaInventario.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtCodigo.Text = GrillaInventario.Rows(e.RowIndex).Cells(2).Value.ToString()
            cboCategoria.Text = GrillaInventario.Rows(e.RowIndex).Cells(3).Value.ToString()
            txtUbicacion.Text = GrillaInventario.Rows(e.RowIndex).Cells(4).Value.ToString()
        End If
    End Sub

    Private Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles BtnFiltrar.Click
        If RdoNombre.Checked Then
            Dim Sql As String = "SELECT * FROM TABLAINVENTARIOS WHERE NOMBRE LIKE @filterText"
            Dim DAFiltro As New MySqlDataAdapter(Sql, conn)
            DAFiltro.SelectCommand.Parameters.AddWithValue("@filterText", Trim(txtFiltrar.Text) & "%")
            Dim DSFiltro As New DataSet
            DAFiltro.Fill(DSFiltro)
            GrillaInventario.DataSource = DSFiltro.Tables(0)
            DAFiltro.Dispose()
        End If

        If RdoCodigo.Checked Then
            Dim Sql As String = "SELECT * FROM TABLAINVENTARIOS WHERE CODIGO LIKE @filterText"
            Dim DAFiltro As New MySqlDataAdapter(Sql, conn)
            DAFiltro.SelectCommand.Parameters.AddWithValue("@filterText", Trim(txtFiltrar.Text) & "%")
            Dim DSFiltro As New DataSet
            DAFiltro.Fill(DSFiltro)
            GrillaInventario.DataSource = DSFiltro.Tables(0)
            DAFiltro.Dispose()
        End If
    End Sub

    Private Sub txtFiltrar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltrar.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True

            If RdoNombre.Checked Then
                Dim Sql As String = "SELECT * FROM TABLAINVENTARIOS WHERE NOMBRE LIKE @filterText"
                Dim DAFiltro As New MySqlDataAdapter(Sql, conn)
                DAFiltro.SelectCommand.Parameters.AddWithValue("@filterText", Trim(txtFiltrar.Text) & "%")
                Dim DSFiltro As New DataSet
                DAFiltro.Fill(DSFiltro)
                GrillaInventario.DataSource = DSFiltro.Tables(0)
                DAFiltro.Dispose()
            End If

            If RdoCodigo.Checked Then
                Dim Sql As String = "SELECT * FROM TABLAINVENTARIOS WHERE CODIGO LIKE @filterText"
                Dim DAFiltro As New MySqlDataAdapter(Sql, conn)
                DAFiltro.SelectCommand.Parameters.AddWithValue("@filterText", Trim(txtFiltrar.Text) & "%")
                Dim DSFiltro As New DataSet
                DAFiltro.Fill(DSFiltro)
                GrillaInventario.DataSource = DSFiltro.Tables(0)
                DAFiltro.Dispose()
            End If
        End If
    End Sub
End Class

