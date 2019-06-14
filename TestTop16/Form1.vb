
Public Class Form1
    Private tdio As New DITop16Manager.Top16Manager


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Label1.Text = tdio.GetName()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim id As Integer = 0
        tdio.GetDigitalInput(id)
        Label2.Text = id
    End Sub

End Class
