
Public Class Form1
    Private tdio As New DITop16Manager.Top16Manager


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Label1.Text = tdio.GetBoardName()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

    End Sub
End Class
