Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Net
Imports System.Text.Encoding
Imports System.Net.Sockets.UdpClient


Public Class Form1

    Dim pub As New Sockets.UdpClient(0)
    Dim Subs As New Sockets.UdpClient(2000)

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        ' Me.ListBox1.Items.Add()

        If ComboBox1.Text = "UDP" Then
            Dim ab As Integer = 0
            ab = (Int(Me.TextBox3.Text))
            For i As Integer = 0 To ab - 1
                pub.Connect(TextBox1.Text, TextBox2.Text)
                'Dim sendbytes() As Byte = ASCII.GetBytes(TextBox5.Text)
                ' pub.Send(sendbytes, sendbytes.Length)


                Dim b As Byte = Asc(Me.TextBox1.Text)
                ' Dim hex As String = TextBox1.Text
                'Dim y As Byte() = Encoding.ASCII.GetBytes(hex)

                ListBox1.Items.Add(TextBox1.Text & " " & b & " ms" & " " & pub.Ttl & " ms" & " " & " " & TimeString())
                ' ListBox1.Items.Add(y)
                Threading.Thread.Sleep(200)
            Next
            ListBox1.Items.Add("")
        Else
            Dim pingtarget As String = ""
                Dim numberOfpings As Integer = 0

                pingtarget = Me.TextBox1.Text
            numberOfpings = (Int(Me.TextBox3.Text))

            For i As Integer = 0 To numberOfpings - 1
                Dim ping As New Ping
                Dim pingreply = ping.Send(pingtarget)
                Dim b As Byte = Asc(TextBox1.Text & TextBox4.Text)
                Dim ttl = pingreply.Options.Ttl.ToString(TextBox4.Text)
                Dim time = pingreply.RoundtripTime.ToString(TextBox4.Text)

                Me.ListBox1.Items.Add(pingtarget & " " & b & " ms " & ttl & " ms " & time & " ms")
                Threading.Thread.Sleep(200)

            Next

            Me.ListBox1.Items.Add(" ")
        End If


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Subs.Client.ReceiveTimeout = 100
        Subs.Client.Blocking = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Try
            Dim ep As IPEndPoint = New IPEndPoint(IPAddress.Any, 0)
            Dim rcvbytes() As Byte = Subs.Receive(ep)

            ' For i As Integer = 0 To (Int(Me.TextBox3.Text)) - 1
            ' ListBox1.Text = ASCII.GetString(rcvbytes)

            'ListBox1.Items.Add(subs.RoundtripTime.ToString(TextBox4.Text))
            '  Threading.Thread.Sleep(200)
            ' Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)



    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' ComboBox2.Items.Add("LAN")
        ' ComboBox2.Items.Add("")

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class
