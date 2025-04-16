<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnNextTurn = New System.Windows.Forms.Button()
        Me.btnResetP1 = New System.Windows.Forms.Button()
        Me.btnResetP2 = New System.Windows.Forms.Button()
        Me.btnNewGame = New System.Windows.Forms.Button()
        Me.btnAttackP1 = New System.Windows.Forms.Button()
        Me.btnAttackP2 = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Silver
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Times New Roman", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(219, 25)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(903, 66)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNextTurn
        '
        Me.btnNextTurn.Location = New System.Drawing.Point(582, 125)
        Me.btnNextTurn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnNextTurn.Name = "btnNextTurn"
        Me.btnNextTurn.Size = New System.Drawing.Size(154, 55)
        Me.btnNextTurn.TabIndex = 1
        Me.btnNextTurn.Text = "Next &Turn"
        Me.btnNextTurn.UseVisualStyleBackColor = True
        '
        'btnResetP1
        '
        Me.btnResetP1.Location = New System.Drawing.Point(14, 270)
        Me.btnResetP1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnResetP1.Name = "btnResetP1"
        Me.btnResetP1.Size = New System.Drawing.Size(129, 55)
        Me.btnResetP1.TabIndex = 2
        Me.btnResetP1.Text = "Reset Player &1"
        Me.btnResetP1.UseVisualStyleBackColor = True
        '
        'btnResetP2
        '
        Me.btnResetP2.Location = New System.Drawing.Point(1205, 270)
        Me.btnResetP2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnResetP2.Name = "btnResetP2"
        Me.btnResetP2.Size = New System.Drawing.Size(127, 55)
        Me.btnResetP2.TabIndex = 3
        Me.btnResetP2.Text = "Reset Player &2"
        Me.btnResetP2.UseVisualStyleBackColor = True
        '
        'btnNewGame
        '
        Me.btnNewGame.Location = New System.Drawing.Point(597, 310)
        Me.btnNewGame.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnNewGame.Name = "btnNewGame"
        Me.btnNewGame.Size = New System.Drawing.Size(125, 56)
        Me.btnNewGame.TabIndex = 4
        Me.btnNewGame.Text = "New &Game"
        Me.btnNewGame.UseVisualStyleBackColor = True
        '
        'btnAttackP1
        '
        Me.btnAttackP1.Location = New System.Drawing.Point(253, 511)
        Me.btnAttackP1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAttackP1.Name = "btnAttackP1"
        Me.btnAttackP1.Size = New System.Drawing.Size(119, 55)
        Me.btnAttackP1.TabIndex = 5
        Me.btnAttackP1.Text = "P1 Attack!"
        Me.btnAttackP1.UseVisualStyleBackColor = True
        '
        'btnAttackP2
        '
        Me.btnAttackP2.Location = New System.Drawing.Point(946, 511)
        Me.btnAttackP2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAttackP2.Name = "btnAttackP2"
        Me.btnAttackP2.Size = New System.Drawing.Size(119, 55)
        Me.btnAttackP2.TabIndex = 6
        Me.btnAttackP2.Text = "P2 Attack!"
        Me.btnAttackP2.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(618, 510)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(93, 56)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Bshipgame.My.Resources.Resources.Screenshot_2025_04_09_162146
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1358, 595)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAttackP2)
        Me.Controls.Add(Me.btnAttackP1)
        Me.Controls.Add(Me.btnNewGame)
        Me.Controls.Add(Me.btnResetP2)
        Me.Controls.Add(Me.btnResetP1)
        Me.Controls.Add(Me.btnNextTurn)
        Me.Controls.Add(Me.lblStatus)
        Me.DoubleBuffered = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Battleship 1v1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblStatus As Label
    Friend WithEvents btnNextTurn As Button
    Friend WithEvents btnResetP1 As Button
    Friend WithEvents btnResetP2 As Button
    Friend WithEvents btnNewGame As Button
    Friend WithEvents btnAttackP1 As Button
    Friend WithEvents btnAttackP2 As Button
    Friend WithEvents btnExit As Button
End Class
