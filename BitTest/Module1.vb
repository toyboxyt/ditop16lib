Module Module1
    Sub Main()
        'Main2()
        Main3()
    End Sub

    Sub Main1()
        Dim i As Integer = 0
        'i = 1 << 0 ' 0001(1) -> 0010(2)
        'i = i Or 1 << 1 ' 0001(1) -> 0010(2)
        'i = i << 2 ' 0010(1) -> 0100(4)
        'i = i Or 1 << 2 ' 0010(1) -> 0110(6)

        i = 1 << 0 Or 0 << 1 Or 1 << 2 Or 1 << 3 ' 1101 ( 13)

        Console.WriteLine(i)
        Console.WriteLine(Convert.ToString(i, 2))
    End Sub

    Sub Main2()
        Dim a As Byte
        Dim i As Integer = 13
        a = i And 1 << 3
        Console.WriteLine(a)

        Console.WriteLine(Convert.ToString(a, 2))
    End Sub

    Sub Main3()

        Dim ba(8) As Byte
        ba(0) = 0
        ba(1) = 1
        ba(2) = 1
        ba(3) = 1
        ba(4) = 1
        ba(5) = 1
        ba(6) = 1
        ba(7) = 1
        Dim id As Integer

        '2進数計算
        id = ba(0) * 1 _
               + ba(1) * (1 << 1) _
               + ba(2) * (1 << 2) _
               + ba(3) * (1 << 3) _
               + ba(4) * (1 << 4) _
               + ba(5) * (1 << 5) _
               + ba(6) * (1 << 6) _
               + ba(7) * (1 << 7)


        Console.WriteLine(id)
        Console.WriteLine(Convert.ToString(id, 2))

        Dim idd As Integer = 0
        'For i = 0 To 3
        '    idd = idd Or IIf(ba(i), 1, 0) << i
        'Next
        'Console.WriteLine(idd)
        'Console.WriteLine(Convert.ToString(idd, 2))

        idd = idd Or (id And (1 << 0))
        idd = idd Or (id And (1 << 1))
        idd = idd Or (id And (1 << 2))
        idd = idd Or (id And (1 << 3))
        Console.WriteLine(idd)
        Console.WriteLine(Convert.ToString(idd, 2))

    End Sub

End Module

