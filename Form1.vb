Public Class MainConsole

    Public colors = New Object() {
        Color.AliceBlue,
        Color.AntiqueWhite,
        Color.Aquamarine,
        Color.Beige,
        Color.Bisque,
        Color.Black,
        Color.BlanchedAlmond,
        Color.BlueViolet,
        Color.BurlyWood,
        Color.CadetBlue,
        Color.Chartreuse,
        Color.Chocolate,
        Color.CornflowerBlue,
        Color.DarkBlue,
        Color.DarkCyan,
        Color.DarkGoldenrod,
        Color.DarkGreen,
        Color.DarkKhaki,
        Color.DarkMagenta,
        Color.DarkOliveGreen,
        Color.DarkOrchid,
        Color.DarkSalmon,
        Color.DarkSeaGreen,
        Color.DarkSlateBlue,
        Color.DarkSlateGray,
        Color.DarkTurquoise,
        Color.DeepPink,
        Color.DeepSkyBlue,
        Color.DodgerBlue,
        Color.Firebrick,
        Color.FloralWhite,
        Color.ForestGreen,
        Color.Gainsboro,
        Color.GhostWhite,
        Color.Goldenrod,
        Color.Green,
        Color.GreenYellow,
        Color.IndianRed,
        Color.Ivory,
        Color.Khaki,
        Color.Lavender,
        Color.LavenderBlush,
        Color.LemonChiffon,
        Color.LightCoral,
        Color.LightCyan,
        Color.LightGoldenrodYellow,
        Color.LightGreen,
        Color.LightPink,
        Color.LightSalmon,
        Color.LightSeaGreen,
        Color.LightSkyBlue,
        Color.LightSlateGray,
        Color.LightSteelBlue,
        Color.LimeGreen,
        Color.Magenta,
        Color.Maroon,
        Color.MediumAquamarine,
        Color.MediumOrchid,
        Color.MediumPurple,
        Color.MediumSeaGreen,
        Color.MediumSlateBlue,
        Color.MediumSpringGreen,
        Color.MediumVioletRed,
        Color.MistyRose,
        Color.Moccasin,
        Color.NavajoWhite,
        Color.OldLace,
        Color.OliveDrab,
        Color.OrangeRed,
        Color.PaleGoldenrod,
        Color.PaleTurquoise,
        Color.PaleVioletRed,
        Color.PeachPuff,
        Color.Pink,
        Color.Plum,
        Color.PowderBlue,
        Color.Red,
        Color.RosyBrown,
        Color.RoyalBlue,
        Color.SaddleBrown,
        Color.SandyBrown,
        Color.SeaGreen,
        Color.SeaShell,
        Color.Silver,
        Color.SkyBlue,
        Color.SlateBlue,
        Color.SlateGray,
        Color.SpringGreen,
        Color.Teal,
        Color.Thistle,
        Color.Tomato,
        Color.Transparent,
        Color.Wheat,
        Color.White,
        Color.WhiteSmoke,
        Color.YellowGreen
    }
    Public nmrUpDownControlers As NumericUpDown() = {}

    Private Sub NumericUpDown_ValueChanged_massAssignedController(sender As NumericUpDown, e As EventArgs)
        Call AsignColor(sender)
        sender.ForeColor = Color.Gainsboro
    End Sub
    Private Sub AsignColor(ByRef target)
        Try

            If Not TypeOf target Is NumericUpDown Then
                Exit Sub
            End If

            If target.value < colors.length Then
                Dim newColor = colors(Val(target.value))
                Dim a As Byte = NormToRange(newColor.A + 128, 0, 256)
                Dim r As Byte = NormToRange(newColor.R + 128, 0, 256)
                Dim g As Byte = NormToRange(newColor.G + 128, 0, 256)
                Dim b As Byte = NormToRange(newColor.B + 128, 0, 256)
                target.BackColor = Color.FromArgb(r, g, b)
                target.forecolor = newColor
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function NormToRange(val, min, max)
        NormToRange = val Mod max
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each control As Control In Me.Controls
                Dim target As NumericUpDown = TryCast(control, NumericUpDown)
                If Not target Is Nothing Then
                    AddHandler target.ValueChanged, AddressOf Me.NumericUpDown_ValueChanged_massAssignedController
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim letters As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P"}
        For letterIndex As Integer = 0 To 5
            For i As Integer = 1 To 5
                Dim ctrl = Me.Controls.Find("nmr" & letters(letterIndex) & i, True)
                If ctrl IsNot Nothing Then
                    For Each control In ctrl
                        nmrUpDownControlers = nmrUpDownControlers.Concat({control}).ToArray
                    Next
                End If
            Next
        Next
        Console.WriteLine("Hay " & nmrUpDownControlers.Length & " nmrUpDownControlers")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim repetitionsInThisEvent = nmrRepeticiones.Value

        lblStatusText.Text = "Iniciando iteraciones"
        ToolStripProgressBar.Value = 0

        Dim maxValue As Integer = FindMaxValueInRockers()

        For reps = 1 To repetitionsInThisEvent
            For runningValue As Integer = 0 To maxValue
                For Each control In nmrUpDownControlers
                    If control.Value = runningValue Then
                        Console.WriteLine(control.Name.Substring(3, 2) & ":" & control.Value)
                    End If
                Next
            Next

            lblStatusText.Text = "Iteracion " & reps & " completada de " & repetitionsInThisEvent
            ToolStripProgressBar.Value = (repetitionsInThisEvent / 100) * reps
            MsgBox("Iteracion " & reps & " completada", MsgBoxStyle.OkCancel, "Informacion")
        Next

        lblStatusText.Text = "Iteraciones completadas"
    End Sub

    Private Function FindMaxValueInRockers()
        Dim currentMaximum As Integer = 0
        For Each control In nmrUpDownControlers
            If currentMaximum < control.Value Then currentMaximum = control.Value
        Next
        FindMaxValueInRockers = currentMaximum
    End Function

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click

    End Sub
End Class
