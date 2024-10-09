<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnSocios = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCuotas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnGastos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnIngresos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnInventarios = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnCategorias = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnRetiros = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.NI = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnSocios, Me.ToolStripSeparator1, Me.BtnCuotas, Me.ToolStripSeparator2, Me.BtnGastos, Me.ToolStripSeparator3, Me.BtnIngresos, Me.ToolStripSeparator7, Me.BtnInventarios, Me.ToolStripSeparator4, Me.BtnCategorias, Me.ToolStripSeparator5, Me.BtnRetiros, Me.ToolStripSeparator6, Me.ToolStripButton1, Me.ToolStripSeparator8, Me.BtnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(875, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnSocios
        '
        Me.BtnSocios.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSocios.Image = Global.SBP.My.Resources.Resources._1398323214_211731
        Me.BtnSocios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnSocios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSocios.Name = "BtnSocios"
        Me.BtnSocios.Size = New System.Drawing.Size(81, 36)
        Me.BtnSocios.Text = "Socios"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'BtnCuotas
        '
        Me.BtnCuotas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCuotas.Image = Global.SBP.My.Resources.Resources._1398324503_174782
        Me.BtnCuotas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnCuotas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCuotas.Name = "BtnCuotas"
        Me.BtnCuotas.Size = New System.Drawing.Size(83, 36)
        Me.BtnCuotas.Text = "Cuotas"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'BtnGastos
        '
        Me.BtnGastos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGastos.Image = Global.SBP.My.Resources.Resources._1398323260_211608
        Me.BtnGastos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnGastos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnGastos.Name = "BtnGastos"
        Me.BtnGastos.Size = New System.Drawing.Size(82, 36)
        Me.BtnGastos.Text = "Gastos"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'BtnIngresos
        '
        Me.BtnIngresos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIngresos.Image = Global.SBP.My.Resources.Resources._1398323196_211700
        Me.BtnIngresos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnIngresos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnIngresos.Name = "BtnIngresos"
        Me.BtnIngresos.Size = New System.Drawing.Size(93, 36)
        Me.BtnIngresos.Text = "Ingresos"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 39)
        '
        'BtnInventarios
        '
        Me.BtnInventarios.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnInventarios.Image = Global.SBP.My.Resources.Resources._1398324909_175432
        Me.BtnInventarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnInventarios.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInventarios.Name = "BtnInventarios"
        Me.BtnInventarios.Size = New System.Drawing.Size(107, 36)
        Me.BtnInventarios.Text = "Inventarios"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'BtnCategorias
        '
        Me.BtnCategorias.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCategorias.Image = Global.SBP.My.Resources.Resources._1398324875_175007
        Me.BtnCategorias.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnCategorias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnCategorias.Name = "BtnCategorias"
        Me.BtnCategorias.Size = New System.Drawing.Size(105, 36)
        Me.BtnCategorias.Text = "Categorias"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 39)
        '
        'BtnRetiros
        '
        Me.BtnRetiros.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRetiros.Image = Global.SBP.My.Resources.Resources._1398325030_175325
        Me.BtnRetiros.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnRetiros.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRetiros.Name = "BtnRetiros"
        Me.BtnRetiros.Size = New System.Drawing.Size(84, 36)
        Me.BtnRetiros.Text = "Retiros"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.SBP.My.Resources.Resources._1398322999_211775
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(96, 36)
        Me.ToolStripButton1.Text = "Minimizar"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 39)
        '
        'BtnSalir
        '
        Me.BtnSalir.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSalir.Image = Global.SBP.My.Resources.Resources._1398322913_211650
        Me.BtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(70, 36)
        Me.BtnSalir.Text = "Salir"
        '
        'NI
        '
        Me.NI.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NI.BalloonTipText = "Doble Click para abrir"
        Me.NI.BalloonTipTitle = "Sistema Biblioteca Popular"
        Me.NI.Icon = CType(resources.GetObject("NI.Icon"), System.Drawing.Icon)
        Me.NI.Text = "Sistema Biblioteca Popular"
        Me.NI.Visible = True
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 38)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistema de Gestion Biblioteca Popular"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnSocios As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnCuotas As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnGastos As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnInventarios As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnCategorias As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnRetiros As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnIngresos As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NI As System.Windows.Forms.NotifyIcon
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator

End Class
