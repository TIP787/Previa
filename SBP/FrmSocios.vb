Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class FrmSocios

    ' Definir la conexión MySQL
    Dim conn As New MySqlConnection("Server=192.168.1.34;Port=3306;Database=base_biblioteca;Uid=tomas;Pwd=S3gura@2024;")
    Dim cmd As New MySqlCommand
    Dim dr As MySqlDataReader

    Private Sub FrmSocios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CodigoABuscar = 0
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        LlenarGrilla()
        txtNombre.Select()
    End Sub

    Sub LlenarGrilla()
        Dim Sql As String = "SELECT * FROM TABLASOCIOS"
        Dim LlenarAdp As New MySqlDataAdapter(Sql, conn)
        Dim LlenaDS As New DataSet

        LlenarAdp.Fill(LlenaDS)
        GrillaSocios.DataSource = LlenaDS.Tables(0)

        GrillaSocios.Columns(0).Visible = False ' ID
        GrillaSocios.Columns(1).Visible = True ' NOMBRE
        GrillaSocios.Columns(2).Visible = True ' DNI
        GrillaSocios.Columns(3).Visible = False ' DIRECCION
        GrillaSocios.Columns(4).Visible = True ' TELEFONO
        GrillaSocios.Columns(5).Visible = False ' CORREO
        GrillaSocios.Columns(6).Visible = False ' FECHA

        GrillaSocios.Columns(1).Width = 200
        GrillaSocios.Columns(2).Width = 150
        GrillaSocios.Columns(4).Width = 150

        GrillaSocios.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GrillaSocios.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        GrillaSocios.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Sub Limpiar()
        txtFecha.Text = Date.Now.ToString("dd/MM/yyyy")
        txtNombre.Clear()
        txtDni.Clear()
        txtDireccion.Clear()
        txtTelefono.Clear()
        txtCorreo.Clear()
        txtNombre.Select()
        CodigoABuscar = 0
    End Sub

#Region "Validaciones"
    Private Sub txtNombre_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If Me.txtNombre.Text.Trim.Length = 0 Then
            Me.ValidarErrores.SetError(Me.txtNombre, "Por favor, Ingrese el nombre del Socio.")
        Else
            Me.ValidarErrores.SetError(Me.txtNombre, Nothing)
        End If
    End Sub

    Private Sub txtDni_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If Me.txtDni.Text.Trim.Length = 0 Then
            Me.ValidarErrores.SetError(Me.txtDni, "Por favor, Ingrese el DNI del Socio.")
        Else
            Me.ValidarErrores.SetError(Me.txtDni, Nothing)
        End If
    End Sub

    Private Sub txtTelefono_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If Me.txtTelefono.Text.Trim.Length = 0 Then
            Me.ValidarErrores.SetError(Me.txtTelefono, "Por favor, Ingrese el Telefono del Socio.")
        Else
            Me.ValidarErrores.SetError(Me.txtTelefono, Nothing)
        End If
    End Sub
#End Region

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If CodigoABuscar <> 0 Then
                MsgBox("No puede ingresar estos registros porque ya existen en la base de datos, quizás usted intentó editarlo o eliminarlo.", vbInformation, "SGB")
                Exit Sub
            End If

            ' Validar que la fecha sea válida
            Dim fechaValida As DateTime
            If Not DateTime.TryParseExact(txtFecha.Text, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, fechaValida) Then
                MsgBox("La fecha ingresada no es válida. Use el formato dd/MM/yyyy.", vbInformation, "SGB")
                txtFecha.Select()
                Exit Sub
            End If

            ' PASO 1: CHEQUEAR QUE NO EXISTA OTRO SOCIO CON EL MISMO DNI
            Dim Sql As String = "SELECT * FROM TABLASOCIOS WHERE DNI = @DNI"
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = Sql
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@DNI", Trim(txtDni.Text))

            ' Cierra el DataReader si ya está abierto
            If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                dr.Close()
            End If

            conn.Open() ' Asegúrate de abrir la conexión antes de ejecutar el comando
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                MsgBox("Está intentando ingresar un socio que ya existe, por favor revise los datos del socio a ingresar!", vbInformation, "SGB")
                dr.Close()
                Exit Sub
            Else
                dr.Close()

                ' PASO 2: GUARDAR LOS DATOS
                If txtNombre.Text.Trim.Length = 0 Then
                    MsgBox("Ingrese el Nombre del Socio!", vbInformation, "SGB")
                    txtNombre.Select()
                    Exit Sub
                End If

                Sql = "INSERT INTO TABLASOCIOS (NOMBRE, DNI, DIRECCION, TELEFONO, CORREO, FECHA) VALUES " &
                      "(@NOMBRE, @DNI, @DIRECCION, @TELEFONO, @CORREO, @FECHA)"
                Dim Comando As New MySqlCommand(Sql, conn)
                Comando.CommandType = CommandType.Text
                With Comando.Parameters
                    .AddWithValue("@NOMBRE", Trim(txtNombre.Text))
                    .AddWithValue("@DNI", Trim(txtDni.Text))
                    .AddWithValue("@DIRECCION", Trim(txtDireccion.Text))
                    .AddWithValue("@TELEFONO", Trim(txtTelefono.Text))
                    .AddWithValue("@CORREO", Trim(txtCorreo.Text))
                    .AddWithValue("@FECHA", fechaValida)
                End With

                Comando.ExecuteNonQuery()
                MsgBox("Se ingresó correctamente", vbInformation, "SGB")
                Limpiar()
                LlenarGrilla()
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub GrillaSocios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaSocios.CellContentClick
        CodigoABuscar = GrillaSocios.Rows(GrillaSocios.CurrentRow.Index).Cells(0).Value
        txtNombre.Text = GrillaSocios.Rows(GrillaSocios.CurrentRow.Index).Cells(1).Value
        txtDni.Text = GrillaSocios.Rows(GrillaSocios.CurrentRow.Index).Cells(2).Value
        txtDireccion.Text = GrillaSocios.Rows(GrillaSocios.CurrentRow.Index).Cells(3).Value
        txtTelefono.Text = GrillaSocios.Rows(GrillaSocios.CurrentRow.Index).Cells(4).Value
        txtCorreo.Text = GrillaSocios.Rows(GrillaSocios.CurrentRow.Index).Cells(5).Value


        Dim fecha As Date
        If Date.TryParse(GrillaSocios.Rows(GrillaSocios.CurrentRow.Index).Cells(6).Value.ToString(), fecha) Then
            txtFecha.Text = fecha.ToString("dd/MM/yyyy")
        Else
            txtFecha.Text = "Fecha no válida" ' Maneja el caso donde la fecha no es válida
        End If
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles BtnEditar.Click
        Try
            If CodigoABuscar = 0 Then
                MsgBox("Seleccione un socio de la grilla para poder editarlo!", vbInformation, "SGB")
                Exit Sub
            End If

            If MsgBox("Desea realmente editar los cambios?", vbYesNo, "SGB") = vbYes Then
                If txtNombre.Text.Trim.Length = 0 Then
                    MsgBox("Ingrese el Nombre del Socio!", vbInformation, "SGB")
                    txtNombre.Select()
                    Exit Sub
                End If
                If txtDni.Text.Trim.Length = 0 Then
                    MsgBox("Ingrese el DNI del Socio!", vbInformation, "SGB")
                    txtDni.Select()
                    Exit Sub
                End If
                If txtTelefono.Text.Trim.Length = 0 Then
                    MsgBox("Ingrese el Teléfono del Socio!", vbInformation, "SGB")
                    txtTelefono.Select()
                    Exit Sub
                End If

                Dim fechaValida As DateTime
                If Not DateTime.TryParseExact(txtFecha.Text, "dd/MM/yyyy", Nothing, Globalization.DateTimeStyles.None, fechaValida) Then
                    MsgBox("La fecha ingresada no es válida. Use el formato dd/MM/yyyy.", vbInformation, "SGB")
                    txtFecha.Select()
                    Exit Sub
                End If

                Dim Sql As String = "UPDATE TABLASOCIOS SET NOMBRE = @NOMBRE, DNI = @DNI, DIRECCION = @DIRECCION, TELEFONO = @TELEFONO, CORREO = @CORREO, FECHA = @FECHA WHERE ID = @ID"
                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = Sql
                cmd.Parameters.Clear()

                cmd.Parameters.AddWithValue("@NOMBRE", Trim(txtNombre.Text))
                cmd.Parameters.AddWithValue("@DNI", Trim(txtDni.Text))
                cmd.Parameters.AddWithValue("@DIRECCION", Trim(txtDireccion.Text))
                cmd.Parameters.AddWithValue("@TELEFONO", Trim(txtTelefono.Text))
                cmd.Parameters.AddWithValue("@CORREO", Trim(txtCorreo.Text))
                cmd.Parameters.AddWithValue("@FECHA", fechaValida)
                cmd.Parameters.AddWithValue("@ID", CodigoABuscar)

                conn.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Se editó correctamente", vbInformation, "SGB")
                Limpiar()
                LlenarGrilla()
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            If CodigoABuscar = 0 Then
                MsgBox("Seleccione un socio de la grilla para poder eliminarlo!", vbInformation, "SGB")
                Exit Sub
            End If

            If MsgBox("Desea realmente eliminar este socio?", vbYesNo, "SGB") = vbYes Then
                Dim Sql As String = "DELETE FROM TABLASOCIOS WHERE ID = @ID"
                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = Sql
                cmd.Parameters.Clear()

                cmd.Parameters.AddWithValue("@ID", CodigoABuscar)

                conn.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Se eliminó correctamente", vbInformation, "SGB")
                Limpiar()
                LlenarGrilla()
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If Asc(e.KeyChar) = 13 Then ' Si se presiona Enter
            e.Handled = True
            Dim Sql As String = "SELECT * FROM TABLASOCIOS WHERE NOMBRE LIKE @FILTRO"

            Dim cmd As New MySqlCommand(Sql, conn)
            cmd.Parameters.AddWithValue("@FILTRO", "%" & Trim(txtBuscar.Text) & "%")

            Dim DABuscar As New MySqlDataAdapter(cmd)
            Dim DSBuscar As New DataSet()

            Try
                conn.Open() ' Asegúrate de abrir la conexión
                DABuscar.Fill(DSBuscar)
                GrillaSocios.DataSource = DSBuscar.Tables(0)
            Catch ex As Exception
                MsgBox("Error al buscar: " & ex.Message)
            Finally
                conn.Close() ' Asegúrate de cerrar la conexión siempre en el bloque Finally
            End Try
        End If

        If Asc(e.KeyChar) = 27 Then ' Si se presiona Esc
            e.Handled = True
            txtBuscar.Clear()
            txtBuscar.Select()
        End If
    End Sub


End Class

