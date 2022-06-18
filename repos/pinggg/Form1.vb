Imports System.Net.NetworkInformation
Imports System.Net
Imports System.Text
'Imports System.Text.Encoding


Public Class Form1

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged


    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim pingtarget As String = ""
        Dim numberOfpings As Integer = 0

        pingtarget = Me.TextBox1.Text
        numberOfpings = (Int(Me.TextBox2.Text))

        If ComboBox1.Text = "LAN" Then
            For i As Integer = 0 To numberOfpings - 1
                Dim ping As New Ping
                Dim pingreply = ping.Send(pingtarget)
                Dim b As Byte = Asc(TextBox1.Text & TextBox3.Text)
                Dim ttl = pingreply.Options.Ttl.ToString(TextBox4.Text)
                Dim time = pingreply.RoundtripTime.ToString(TextBox5.Text)

                Me.ListBox1.Items.Add("Reply from " & pingtarget & " Bytes " & b & " tll " & ttl & " Time = " & time & " ms")
                Threading.Thread.Sleep(200)
            Next

            Me.ListBox1.Items.Add("")
            'Me.ListBox1.Items.Add(" - --" & Me.TextBox1.Text & " ping statistics---")

        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListBox1.Items.Clear()
    End Sub
End Class
