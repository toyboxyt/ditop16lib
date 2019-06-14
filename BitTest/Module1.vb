Module Module1

    Sub Main()
        Dim i As Integer = 0
        'i = 1 << 0 ' 0001(1) -> 0010(2)
        'i = i Or 1 << 1 ' 0001(1) -> 0010(2)
        'i = i << 2 ' 0010(1) -> 0100(4)
        'i = i Or 1 << 2 ' 0010(1) -> 0110(6)

        i = 1 << 0 Or 0 << 1 Or 1 << 2 Or 1 << 3 ' 1101 ( 13)

        Console.WriteLine(i)
        Console.WriteLine(Convert.ToString(i, 2))



    End Sub

End Module
