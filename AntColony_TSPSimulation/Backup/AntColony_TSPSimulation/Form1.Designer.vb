<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel_PathPic = New System.Windows.Forms.Panel
        Me.PictureBox_PathPic = New System.Windows.Forms.PictureBox
        Me.Panel_PherPic = New System.Windows.Forms.Panel
        Me.PictureBox_PherPic = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button_Simulate = New System.Windows.Forms.Button
        Me.TextBox_NCities = New System.Windows.Forms.TextBox
        Me.Label_Result = New System.Windows.Forms.Label
        Me.Label_Status = New System.Windows.Forms.Label
        Me.Panel_PathPic.SuspendLayout()
        CType(Me.PictureBox_PathPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_PherPic.SuspendLayout()
        CType(Me.PictureBox_PherPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_PathPic
        '
        Me.Panel_PathPic.BackColor = System.Drawing.Color.White
        Me.Panel_PathPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_PathPic.Controls.Add(Me.PictureBox_PathPic)
        Me.Panel_PathPic.Location = New System.Drawing.Point(14, 12)
        Me.Panel_PathPic.Name = "Panel_PathPic"
        Me.Panel_PathPic.Size = New System.Drawing.Size(350, 350)
        Me.Panel_PathPic.TabIndex = 0
        '
        'PictureBox_PathPic
        '
        Me.PictureBox_PathPic.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_PathPic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_PathPic.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox_PathPic.Name = "PictureBox_PathPic"
        Me.PictureBox_PathPic.Size = New System.Drawing.Size(346, 346)
        Me.PictureBox_PathPic.TabIndex = 0
        Me.PictureBox_PathPic.TabStop = False
        '
        'Panel_PherPic
        '
        Me.Panel_PherPic.BackColor = System.Drawing.Color.White
        Me.Panel_PherPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_PherPic.Controls.Add(Me.PictureBox_PherPic)
        Me.Panel_PherPic.Location = New System.Drawing.Point(370, 12)
        Me.Panel_PherPic.Name = "Panel_PherPic"
        Me.Panel_PherPic.Size = New System.Drawing.Size(350, 350)
        Me.Panel_PherPic.TabIndex = 1
        '
        'PictureBox_PherPic
        '
        Me.PictureBox_PherPic.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox_PherPic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_PherPic.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox_PherPic.Name = "PictureBox_PherPic"
        Me.PictureBox_PherPic.Size = New System.Drawing.Size(346, 346)
        Me.PictureBox_PherPic.TabIndex = 0
        Me.PictureBox_PherPic.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 389)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "No., of Cities :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 421)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Optimall Distance :"
        '
        'Button_Simulate
        '
        Me.Button_Simulate.Location = New System.Drawing.Point(330, 384)
        Me.Button_Simulate.Name = "Button_Simulate"
        Me.Button_Simulate.Size = New System.Drawing.Size(75, 23)
        Me.Button_Simulate.TabIndex = 4
        Me.Button_Simulate.Text = "SIMULATE"
        Me.Button_Simulate.UseVisualStyleBackColor = True
        '
        'TextBox_NCities
        '
        Me.TextBox_NCities.Location = New System.Drawing.Point(152, 386)
        Me.TextBox_NCities.Name = "TextBox_NCities"
        Me.TextBox_NCities.Size = New System.Drawing.Size(49, 21)
        Me.TextBox_NCities.TabIndex = 5
        Me.TextBox_NCities.Text = "5"
        '
        'Label_Result
        '
        Me.Label_Result.AutoSize = True
        Me.Label_Result.Location = New System.Drawing.Point(159, 421)
        Me.Label_Result.Name = "Label_Result"
        Me.Label_Result.Size = New System.Drawing.Size(47, 13)
        Me.Label_Result.TabIndex = 6
        Me.Label_Result.Text = "R_Text"
        '
        'Label_Status
        '
        Me.Label_Status.AutoSize = True
        Me.Label_Status.ForeColor = System.Drawing.Color.Green
        Me.Label_Status.Location = New System.Drawing.Point(327, 421)
        Me.Label_Status.Name = "Label_Status"
        Me.Label_Status.Size = New System.Drawing.Size(0, 13)
        Me.Label_Status.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(734, 490)
        Me.Controls.Add(Me.Label_Status)
        Me.Controls.Add(Me.Label_Result)
        Me.Controls.Add(Me.TextBox_NCities)
        Me.Controls.Add(Me.Button_Simulate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel_PherPic)
        Me.Controls.Add(Me.Panel_PathPic)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Form1"
        Me.Text = "Ant_Colony_Travelling Sales Person Simulation"
        Me.Panel_PathPic.ResumeLayout(False)
        CType(Me.PictureBox_PathPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_PherPic.ResumeLayout(False)
        CType(Me.PictureBox_PherPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel_PathPic As System.Windows.Forms.Panel
    Friend WithEvents Panel_PherPic As System.Windows.Forms.Panel
    Friend WithEvents PictureBox_PathPic As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox_PherPic As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button_Simulate As System.Windows.Forms.Button
    Friend WithEvents TextBox_NCities As System.Windows.Forms.TextBox
    Friend WithEvents Label_Result As System.Windows.Forms.Label
    Friend WithEvents Label_Status As System.Windows.Forms.Label

End Class
