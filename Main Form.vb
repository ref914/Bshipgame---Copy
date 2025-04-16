Public Class frmMain

    Dim P1Grid(4, 4) As Label
    Dim P2Grid(4, 4) As Label
    Dim P1Ships(4, 4) As Boolean
    Dim P2Ships(4, 4) As Boolean
    Dim P1Hits(4, 4) As Boolean
    Dim P2Hits(4, 4) As Boolean
    Dim playerTurn As Integer = 1
    Dim placingShips As Boolean = True
    Dim P1ShipCount As Integer = 0
    Dim P2ShipCount As Integer = 0
    Dim P1Score As Integer = 0
    Dim P2Score As Integer = 0
    Dim maxShips As Integer = 2
    Dim gameOver As Boolean = False
    Dim awaitingAttackClick As Boolean = False
    Dim readyToAttack As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateGrid(P1Grid, 125, 100, "P1")   ' Left grid
        CreateGrid(P2Grid, 550, 100, "P2")  ' Right grid
        lblStatus.Text = "Player 1: Place 2 ships"
        btnAttackP1.Visible = False
        btnAttackP2.Visible = False
        btnNextTurn.Visible = True
        UpdateGridVisibility()
    End Sub

    Private Sub CreateGrid(ByRef grid(,) As Label, startX As Integer, startY As Integer, tagPrefix As String)
        For row As Integer = 0 To 4
            For col As Integer = 0 To 4
                Dim lbl As New Label With {
                    .Width = 40,
                    .Height = 40,
                    .BackColor = Color.LightGray,
                    .BorderStyle = BorderStyle.FixedSingle,
                    .Location = New Point(startX + col * 42, startY + row * 42),
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Tag = $"{tagPrefix}_{row}_{col}"
                }
                AddHandler lbl.Click, AddressOf GridLabel_Click
                Me.Controls.Add(lbl)
                grid(row, col) = lbl
            Next
        Next
    End Sub

    Private Sub UpdateGridVisibility()
        ' Hide or show grids based on phase and current player
        Dim showP1 = False
        Dim showP2 = False

        ' Show only the current player's grid
        ' During attack, players use their OWN grid to target the same cell on opponent's
        If placingShips Then
            If playerTurn = 1 Then showP1 = True Else showP2 = True
        ElseIf awaitingAttackClick And readyToAttack Then
            If playerTurn = 1 Then showP1 = True Else showP2 = True
        End If

        For row = 0 To 4
            For col = 0 To 4
                P1Grid(row, col).Visible = showP1
                P2Grid(row, col).Visible = showP2
            Next
        Next
    End Sub

    Private Sub GridLabel_Click(sender As Object, e As EventArgs)
        If gameOver Then Return

        Dim lbl As Label = CType(sender, Label)
        Dim parts = lbl.Tag.ToString().Split("_"c)
        Dim player = parts(0)
        Dim row = Integer.Parse(parts(1))
        Dim col = Integer.Parse(parts(2))

        'Ship placement
        ' Placing ships on your own grid
        If placingShips Then
            If playerTurn = 1 AndAlso player = "P1" Then
                If Not P1Ships(row, col) AndAlso P1ShipCount < maxShips Then
                    P1Ships(row, col) = True
                    P1ShipCount += 1
                    Dim original As Image = Image.FromFile("C:\Users\rayvo\OneDrive\Desktop\Updated Battleship\Bshipgame - Copy\Resources\ship 2.png")
                    Dim resized As New Bitmap(original, New Size(30, 30))
                    lbl.Image = resized
                    lblStatus.Text = $"Player 1: {P1ShipCount}/2 ships placed"
                End If
            ElseIf playerTurn = 2 AndAlso player = "P2" Then
                If Not P2Ships(row, col) AndAlso P2ShipCount < maxShips Then
                    P2Ships(row, col) = True
                    P2ShipCount += 1
                    lbl.BackColor = Color.Blue
                    lblStatus.Text = $"Player 2: {P2ShipCount}/2 ships placed"
                End If
            End If
        End If



        ' ATTACK PHASE: player clicks their own grid, but fires at opponent's grid
        If Not placingShips And awaitingAttackClick And readyToAttack Then
                If playerTurn = 1 AndAlso player = "P1" Then
                    If Not P1Hits(row, col) Then
                        P1Hits(row, col) = True
                        If P2Ships(row, col) Then
                            P2Grid(row, col).BackColor = Color.Red
                            lblStatus.Text = "Player 1 HIT!"
                            'PlaySound("hit.wav")
                            P1Score += 1
                            CheckWinner()
                        Else
                            P2Grid(row, col).BackColor = Color.White
                            lbl.Text = "X"
                            lblStatus.Text = "Player 1 Missed!"
                            'PlaySound("miss.wav")
                        End If
                        awaitingAttackClick = False
                        readyToAttack = False
                    End If
                ElseIf playerTurn = 2 AndAlso player = "P2" Then
                    If Not P2Hits(row, col) Then
                        P2Hits(row, col) = True
                        If P1Ships(row, col) Then
                            P1Grid(row, col).BackColor = Color.Red
                            lblStatus.Text = "Player 2 HIT!"
                            'PlaySound("hit.wav")
                            P2Score += 1
                            CheckWinner()
                        Else
                            P1Grid(row, col).BackColor = Color.White
                            lbl.Text = "X"
                            lblStatus.Text = "Player 2 Missed!"
                            'PlaySound("miss.wav")
                        End If
                        awaitingAttackClick = False
                        readyToAttack = False
                    End If
                End If
            End If
    End Sub
    Private Sub btnResetP1_Click(sender As Object, e As EventArgs) Handles btnResetP1.Click
        For row = 0 To 4
            For col = 0 To 4
                P1Ships(row, col) = False
                P2Hits(row, col) = False
                P1Grid(row, col).BackColor = Color.LightGray
                P1Grid(row, col).Text = ""
                P1Grid(row, col).Image = Nothing
            Next
        Next
        P1ShipCount = 0
        lblStatus.Text = "Player 1 grid reset"
    End Sub

    Private Sub btnResetP2_Click(sender As Object, e As EventArgs) Handles btnResetP2.Click
        For row = 0 To 4
            For col = 0 To 4
                P2Ships(row, col) = False
                P1Hits(row, col) = False
                P2Grid(row, col).BackColor = Color.LightGray
                P2Grid(row, col).Text = ""
                P2Grid(row, col).Image = Nothing
            Next
        Next
        P2ShipCount = 0
        lblStatus.Text = "Player 2 grid reset"
    End Sub

    Private Sub btnNextTurn_Click(sender As Object, e As EventArgs) Handles btnNextTurn.Click
        If gameOver Then Return

        If placingShips Then
            ' Move from P1 to P2 placement
            If playerTurn = 1 And P1ShipCount = maxShips Then
                playerTurn = 2
                lblStatus.Text = "Player 2: Place 2 ships"
                UpdateGridVisibility()
                Return
            End If
            ' End of ship placement
            If playerTurn = 2 And P2ShipCount = maxShips Then
                placingShips = False
                playerTurn = 1
                lblStatus.Text = "Player 1: Click Attack to begin"
                btnAttackP1.Visible = True
                UpdateGridVisibility()
                Return
            End If
        Else
            ' Switch turns during gameplay
            playerTurn = If(playerTurn = 1, 2, 1)
            awaitingAttackClick = False
            readyToAttack = False
            If playerTurn = 1 Then
                lblStatus.Text = "Player 1: Click Attack when ready"
                btnAttackP1.Visible = True
            Else
                lblStatus.Text = "Player 2: Click Attack when ready"
                btnAttackP2.Visible = True
            End If
            UpdateGridVisibility()
        End If

    End Sub

    Private Sub btnNewGame_Click(sender As Object, e As EventArgs) Handles btnNewGame.Click
        For row = 0 To 4
            For col = 0 To 4
                P1Ships(row, col) = False
                P2Ships(row, col) = False
                P1Hits(row, col) = False
                P2Hits(row, col) = False
                P1Grid(row, col).BackColor = Color.LightGray
                P2Grid(row, col).BackColor = Color.LightGray
                P1Grid(row, col).Text = ""
                P2Grid(row, col).Text = ""
                P1Grid(row, col).Image = Nothing
                P2Grid(row, col).Image = Nothing
            Next
        Next

        P1ShipCount = 0
        P2ShipCount = 0
        P1Score = 0
        P2Score = 0
        playerTurn = 1
        placingShips = True
        gameOver = False
        awaitingAttackClick = False
        readyToAttack = False
        btnAttackP1.Visible = False
        btnAttackP2.Visible = False
        lblStatus.Text = "Player 1: Place 2 ships"
        UpdateGridVisibility()
    End Sub

    Private Sub CheckWinner()
        If P1Score = maxShips Then
            lblStatus.Text = "Player 1 wins!"
            gameOver = True
        ElseIf P2Score = maxShips Then
            lblStatus.Text = "Player 2 wins!"
            gameOver = True
        End If
    End Sub

    Private Sub btnAttackP1_Click(sender As Object, e As EventArgs) Handles btnAttackP1.Click
        awaitingAttackClick = True
        readyToAttack = True
        btnAttackP1.Visible = False
        lblStatus.Text = "Player 1: Click a cell to fire"
        UpdateGridVisibility()
    End Sub

    Private Sub btnAttackP2_Click(sender As Object, e As EventArgs) Handles btnAttackP2.Click
        awaitingAttackClick = True
        readyToAttack = True
        btnAttackP2.Visible = False
        lblStatus.Text = "Player 2: Click a cell to fire"
        UpdateGridVisibility()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
