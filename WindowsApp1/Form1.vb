Public Class Form1

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

    Private Sub NumericUpDown_ValueChanged_massAssignedController(sender As NumericUpDown, e As EventArgs)
        Call asignColor(sender)
        sender.ForeColor = Color.Gainsboro
    End Sub
    Private Sub asignColor(ByRef target)
        Try

            If Not TypeOf target Is NumericUpDown Then
                Exit Sub
            End If

            If target.value < colors.length Then
                Dim newColor = colors(Val(target.value))
                Dim a As Byte = newColor.A
                a = normToRange(a + 128, 0, 256)
                Dim r As Byte = newColor.R
                r = normToRange(r + 128, 0, 256)
                Dim g As Byte = newColor.G
                g = normToRange(g + 128, 0, 256)
                Dim b As Byte = newColor.B
                b = normToRange(b + 128, 0, 256)
                target.BackColor = Color.FromArgb(r, g, b)
                target.forecolor = newColor
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function normToRange(val, min, max)
        normToRange = val Mod max
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
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
