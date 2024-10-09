Imports MySql.Data.MySqlClient

Public Class FrmRetiros

    ' Definir la conexión MySQL
    Dim conn As New MySqlConnection("Server=192.168.1.34;Port=3306;Database=base_biblioteca;Uid=tomas;Pwd=S3gura@2024;")

    Private Sub FrmRetiros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now
        txtNombre.Select()
        LlenarGrilla()
    End Sub

    Sub Limpiar()
        txtNombre.Clear()
        txtLibro.Clear()
        txtTelefono.Clear()
        txtCodigo.Clear()
        dtpFecha.Value = Date.Now
        txtNombre.Select()
        CodigoABuscar = 0
    End Sub

    Sub LlenarGrilla()
        Dim Sql As String = "SELECT * FROM TABLARETIROS"
        Dim DARetiro As New MySqlDataAdapter(Sql, conn)
        Dim DSRetiro As New DataSet
        DARetiro.Fill(DSRetiro)
        GrillaRetiros.DataSource = DSRetiro.Tables(0)

        GrillaRetiros.Columns(0).Visible = False 'ID
        GrillaRetiros.Columns(1).Visible = True 'FECHA
        GrillaRetiros.Columns(2).Visible = True 'CODIGO
        GrillaRetiros.Columns(3).Visible = True 'LIBRO
        GrillaRetiros.Columns(4).Visible = True 'NOMBRE
        GrillaRetiros.Columns(5).Visible = True 'TELEFONO

        GrillaRetiros.Columns(1).Width = 80
        GrillaRetiros.Columns(2).Width = 100
        GrillaRetiros.Columns(3).Width = 150
        GrillaRetiros.Columns(4).Width = 150
        GrillaRetiros.Columns(5).Width = 100
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        On Error GoTo Salir
        If txtNombre.Text.Trim.Length = 0 Then MsgBox("Ingrese el nombre del socio", vbInformation, "SGB") : txtNombre.Select() : Exit Sub
        If txtLibro.Text.Trim.Length = 0 Then MsgBox("Ingrese el libro del socio", vbInformation, "SGB") : txtLibro.Select() : Exit Sub
        If CodigoABuscar <> 0 Then MsgBox("No puede Guardar porque ya existe estos registros quizas intenta editar usted!", vbInformation, "SGB") : Exit Sub

        ' Convertir la fecha en el formato adecuado para MySQL
        Dim fechaValida As String = dtpFecha.Value.ToString("yyyy-MM-dd")

        Dim Sql As String = "INSERT INTO TABLARETIROS (FECHA, CODIGO, LIBRO, NOMBRE, TELEFONO) VALUES (@FECHA, @CODIGO, @LIBRO, @NOMBRE, @TELEFONO)"
        Using Comando As New MySqlCommand(Sql, conn)
            Comando.CommandType = CommandType.Text
            With Comando.Parameters
                .AddWithValue("@FECHA", fechaValida)
                .AddWithValue("@CODIGO", Trim(txtCodigo.Text))
                .AddWithValue("@LIBRO", Trim(txtLibro.Text))
                .AddWithValue("@NOMBRE", Trim(txtNombre.Text))
                .AddWithValue("@TELEFONO", Trim(txtTelefono.Text))
            End With
            conn.Open()
            Comando.ExecuteNonQuery()
            conn.Close()
        End Using

        LlenarGrilla()
        Limpiar()
        MsgBox("Datos ingresados Correctamente", vbInformation, "SGB")
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        conn.Close()
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        On Error GoTo Salir
        If CodigoABuscar = 0 Then MsgBox("Seleccione un dato de la grilla para editarlo", vbInformation, "SGB") : Exit Sub

        If txtNombre.Text.Trim.Length = 0 Then MsgBox("Ingrese el nombre del socio", vbInformation, "SGB") : txtNombre.Select() : Exit Sub
        If txtLibro.Text.Trim.Length = 0 Then MsgBox("Ingrese el libro del socio", vbInformation, "SGB") : txtLibro.Select() : Exit Sub

        ' Convertir la fecha en el formato adecuado para MySQL
        Dim fechaValida As String = dtpFecha.Value.ToString("yyyy-MM-dd")

        Dim Sql As String = "UPDATE TABLARETIROS SET FECHA = @FECHA, CODIGO = @CODIGO, LIBRO = @LIBRO, NOMBRE = @NOMBRE, TELEFONO = @TELEFONO WHERE ID = @ID"
        Using Comando As New MySqlCommand(Sql, conn)
            Comando.CommandType = CommandType.Text
            With Comando.Parameters
                .AddWithValue("@FECHA", fechaValida)
                .AddWithValue("@CODIGO", Trim(txtCodigo.Text))
                .AddWithValue("@LIBRO", Trim(txtLibro.Text))
                .AddWithValue("@NOMBRE", Trim(txtNombre.Text))
                .AddWithValue("@TELEFONO", Trim(txtTelefono.Text))
                .AddWithValue("@ID", CodigoABuscar)
            End With
            conn.Open()
            Comando.ExecuteNonQuery()
            conn.Close()
        End Using

        LlenarGrilla()
        Limpiar()
        MsgBox("Los datos se editaron correctamente", vbInformation, "SGB")
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        conn.Close()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        On Error GoTo Salir

        If CodigoABuscar = 0 Then MsgBox("Seleccione un dato de la grilla para eliminarlo", vbInformation, "SGB") : Exit Sub

        If MsgBox("Desea Eliminarlo Realmente?", vbYesNo, "SGB") = vbYes Then
            Dim Sql As String = "DELETE FROM TABLARETIROS WHERE ID = @ID"
            Using Comando As New MySqlCommand(Sql, conn)
                Comando.CommandType = CommandType.Text
                Comando.Parameters.AddWithValue("@ID", CodigoABuscar)
                conn.Open()
                Comando.ExecuteNonQuery()
                conn.Close()
            End Using

            LlenarGrilla()
            Limpiar()
            MsgBox("Los datos se eliminaron correctamente", vbInformation, "SGB")
        End If
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        conn.Close()
    End Sub

    Private Sub GrillaRetiros_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaRetiros.CellContentClick
        If e.RowIndex >= 0 Then ' Asegurarse de que el índice de fila es válido
            CodigoABuscar = GrillaRetiros.Rows(e.RowIndex).Cells(0).Value
            dtpFecha.Value = Date.Parse(GrillaRetiros.Rows(e.RowIndex).Cells(1).Value.ToString())
            txtCodigo.Text = GrillaRetiros.Rows(e.RowIndex).Cells(2).Value.ToString()
            txtLibro.Text = GrillaRetiros.Rows(e.RowIndex).Cells(3).Value.ToString()
            txtNombre.Text = GrillaRetiros.Rows(e.RowIndex).Cells(4).Value.ToString()
            txtTelefono.Text = GrillaRetiros.Rows(e.RowIndex).Cells(5).Value.ToString()
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            FrmRetiroSocios.ShowDialog()
            txtLibro.Select()
        End If

        If Asc(e.KeyChar) = 27 Then
            e.Handled = True
            txtNombre.Clear()
            txtNombre.Select()
        End If
    End Sub

    Private Sub txtLibro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLibro.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            FrmRetiroLibros.ShowDialog()
            BtnGuardar.Select()
        End If

        If Asc(e.KeyChar) = 27 Then
            e.Handled = True
            txtLibro.Clear()
            txtLibro.Select()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            Dim Sql As String = "SELECT * FROM TABLARETIROS WHERE NOMBRE LIKE @filterText"
            Using DABuscar As New MySqlDataAdapter(Sql, conn)
                DABuscar.SelectCommand.Parameters.AddWithValue("@filterText", "%" & Trim(txtBuscar.Text) & "%")
                Dim DSBuscar As New DataSet
                DABuscar.Fill(DSBuscar)
                GrillaRetiros.DataSource = DSBuscar.Tables(0)
            End Using
        End If

        If Asc(e.KeyChar) = 27 Then
            e.Handled = True
            txtBuscar.Clear()
            txtBuscar.Select()
        End If
    End Sub
End Class
