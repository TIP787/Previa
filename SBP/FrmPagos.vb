Imports MySql.Data.MySqlClient

Public Class FrmPagos

    ' Definir la conexión MySQL
    Dim conn As New MySqlConnection("Server=192.168.1.34;Port=3306;Database=base_biblioteca;Uid=tomas;Pwd=S3gura@2024;")

    Private Sub FrmPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Establece la fecha actual en el formato adecuado
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        txtNombre.Select()
        LlenarGrilla()
    End Sub

    Sub Limpiar()
        txtNombre.Clear()
        txtMonto.Clear()
        ' Restablece la fecha actual en el formato adecuado
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        txtNombre.Select()
        CodigoABuscar = 0
    End Sub

    Sub LlenarGrilla()
        Dim Sql As String = "SELECT * FROM TABLACUOTAS"
        Dim DAGrilla As New MySqlDataAdapter(Sql, conn)
        Dim DSGrilla As New DataSet
        DAGrilla.Fill(DSGrilla)
        GrillaCuotas.DataSource = DSGrilla.Tables(0)

        GrillaCuotas.Columns(0).Visible = False ' ID
        GrillaCuotas.Columns(1).Visible = True ' NOMBRE
        GrillaCuotas.Columns(2).Visible = True ' FECHA
        GrillaCuotas.Columns(3).Visible = True ' MONTO

        GrillaCuotas.Columns(1).HeaderText = "NOM. DEL SOCIO"
        GrillaCuotas.Columns(2).HeaderText = "ULT. PAGO"
        GrillaCuotas.Columns(3).HeaderText = "MONTO"

        GrillaCuotas.Columns(1).Width = 250
        GrillaCuotas.Columns(2).Width = 100
        GrillaCuotas.Columns(3).Width = 100

        GrillaCuotas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GrillaCuotas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        DAGrilla.Dispose()
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            FrmPagosSocios.ShowDialog()
            txtMonto.Clear()
            txtMonto.Select()
        End If

        If Asc(e.KeyChar) = 27 Then
            e.Handled = True
            txtNombre.Clear()
            txtNombre.Select()
        End If
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "," AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If

        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            BtnGuardar.Select()
        End If

        If Asc(e.KeyChar) = 27 Then
            e.Handled = True
            txtMonto.Text = ""
            txtMonto.Select()
        End If
    End Sub

    Private Sub txtMonto_Leave(sender As Object, e As EventArgs) Handles txtMonto.Leave
        If txtMonto.Text.Trim.Length > 0 Then
            Dim montoIngresado As String = txtMonto.Text.Replace(",", ".")

        End If
    End Sub





    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        On Error GoTo Salir
        If txtNombre.Text.Trim.Length = 0 Then MsgBox("Ingrese el Nombre!", vbInformation, "SGB") : txtNombre.Select() : Exit Sub
        If txtMonto.Text.Trim.Length = 0 Then MsgBox("Ingrese el Monto!", vbInformation, "SGB") : txtMonto.Select() : Exit Sub
        If CodigoABuscar <> 0 Then MsgBox("No puede ingresar estos registros porque ya existen en la base de datos quizas usted intento editarlo o eliminarlo", vbInformation, "SGB") : Exit Sub

        ' Convertir la fecha en el formato adecuado para SQL
        Dim fechaValida As String
        fechaValida = Date.ParseExact(txtFecha.Text, "dd/MM/yyyy", Nothing).ToString("yyyy-MM-dd")

        Dim Sql As String = "INSERT INTO TABLACUOTAS (NOMBRE, FECHA, MONTO) VALUES (@NOMBRE, @FECHA, @MONTO)"
        Using Comando As New MySqlCommand(Sql, conn)
            Comando.CommandType = CommandType.Text
            With Comando.Parameters
                .AddWithValue("@NOMBRE", Trim(txtNombre.Text))
                .AddWithValue("@FECHA", fechaValida)
                .AddWithValue("@MONTO", Trim(txtMonto.Text.Replace(",", ".")))
            End With
            conn.Open()
            Comando.ExecuteNonQuery()
            conn.Close()
        End Using

        LlenarGrilla()
        Limpiar()
        MsgBox("Datos ingresado correctamente!", vbInformation, "SGB")
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        conn.Close()
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        On Error GoTo Salir
        If CodigoABuscar = 0 Then MsgBox("Seleccione un socio de la grilla para editarlo", vbInformation, "SGB")
        If txtNombre.Text.Trim.Length = 0 Then MsgBox("Ingrese el Nombre!", vbInformation, "SGB") : txtNombre.Select() : Exit Sub
        If txtMonto.Text.Trim.Length = 0 Then MsgBox("Ingrese el Monto!", vbInformation, "SGB") : txtMonto.Select() : Exit Sub

        If MsgBox("Desea realmente editarlo?", vbYesNo, "SGB") = vbYes Then
            ' Convertir la fecha en el formato adecuado para SQL
            Dim fechaValida As String
            fechaValida = Date.ParseExact(txtFecha.Text, "dd/MM/yyyy", Nothing).ToString("yyyy-MM-dd")

            Dim Sql As String = "UPDATE TABLACUOTAS SET NOMBRE = @NOMBRE, FECHA = @FECHA, MONTO = @MONTO WHERE ID = @ID"
            Using Comando As New MySqlCommand(Sql, conn)
                Comando.CommandType = CommandType.Text
                With Comando.Parameters
                    .AddWithValue("@NOMBRE", Trim(txtNombre.Text))
                    .AddWithValue("@FECHA", fechaValida)
                    .AddWithValue("@MONTO", Trim(txtMonto.Text.Replace(",", ".")))
                    .AddWithValue("@ID", CodigoABuscar)
                End With
                conn.Open()
                Comando.ExecuteNonQuery()
                conn.Close()
            End Using

            LlenarGrilla()
            Limpiar()
            MsgBox("Los datos fueron editado correctamente!", vbInformation, "SGB")
        End If
        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        conn.Close()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        On Error GoTo Salir
        If CodigoABuscar = 0 Then MsgBox("Seleccione un socio de la grilla para eliminarlo", vbInformation, "SGB") : Exit Sub

        If MsgBox("Desea eliminarlo realmente", vbYesNo, "SGB") = vbYes Then
            Dim Sql As String = "DELETE FROM TABLACUOTAS WHERE ID = @ID"
            Using Comando As New MySqlCommand(Sql, conn)
                Comando.CommandType = CommandType.Text
                Comando.Parameters.AddWithValue("@ID", CodigoABuscar)
                conn.Open()
                Comando.ExecuteNonQuery()
                conn.Close()
            End Using

            LlenarGrilla()
            Limpiar()
            MsgBox("Los datos fueron eliminado correctamente!", vbInformation, "SGB")
        End If

        Exit Sub
Salir:
        MsgBox(Err.Number & " - " & Err.Description)
        conn.Close()
    End Sub

    Private Sub GrillaCuotas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaCuotas.CellContentClick
        If e.RowIndex >= 0 Then ' Asegurarse de que el índice de fila es válido
            CodigoABuscar = GrillaCuotas.Rows(e.RowIndex).Cells(0).Value
            txtNombre.Text = GrillaCuotas.Rows(e.RowIndex).Cells(1).Value.ToString()
            ' Obtener la fecha en el formato adecuado y convertirla
            txtFecha.Text = Date.Parse(GrillaCuotas.Rows(e.RowIndex).Cells(2).Value.ToString()).ToString("dd/MM/yyyy")
            txtMonto.Text = GrillaCuotas.Rows(e.RowIndex).Cells(3).Value.ToString()
        End If
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            Dim Sql As String = "SELECT * FROM TABLACUOTAS WHERE NOMBRE LIKE @filterText"
            Dim DABuscar As New MySqlDataAdapter(Sql, conn)
            DABuscar.SelectCommand.Parameters.AddWithValue("@filterText", "%" & Trim(txtBuscar.Text) & "%")
            Dim DSBuscar As New DataSet
            DABuscar.Fill(DSBuscar)
            GrillaCuotas.DataSource = DSBuscar.Tables(0)
            DABuscar.Dispose()
        End If

        If Asc(e.KeyChar) = 27 Then
            e.Handled = True
            txtBuscar.Clear()
            txtBuscar.Select()
        End If
    End Sub
End Class
