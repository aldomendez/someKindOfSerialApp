Public Class Form1

    Public colors = New Object() {&HE1E4FF&, &H908070&, &HFF901E&, &HFFBF00&, &H7FFF00&, &H228B22&, &H20A5DA&, &H2222B2&}

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        Call asignColor(sender)
    End Sub
    Private Sub asignColor(ByRef target As Control)
        Try

            If Not TypeOf target Is NumericUpDown Then
                Exit Sub
            End If

            If target.value Then
                target.BackColor = colors(target.value)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
