Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.IO
Imports System.Console
Imports Cards.CardHolder

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myDeck As Deck = New Deck()
        myDeck.shuffle()
        ListBox1.Items.Clear()
        For i As Integer = 0 To 52 - 1
            Dim tempCard As Card = myDeck.getCard(i)
            'Write(tempCard.ToString())
            ListBox1.Items.Add(tempCard)
            'If i <> 51 Then Write(",") Else WriteLine()
        Next
        'Console.Read()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim MyDeck As Deck = New Deck()

        MyDeck.shuffle()

        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()

        For i = 0 To 16 - 1

            Dim tmpCard As Card = MyDeck.getCard(i)

            Select Case i
                Case 0 To 3
                    ListBox2.Items.Add(tmpCard)
                Case 4 To 7
                    ListBox3.Items.Add(tmpCard)
                Case 8 To 11
                    ListBox4.Items.Add(tmpCard)
                Case 12 To 15
                    ListBox5.Items.Add(tmpCard)
            End Select

        Next

        For i As Integer = 0 To ListBox2.Items.Count - 1
            ListBox2.SelectedIndex = i
            If File.Exists("C:\Users\Muzamil\Documents\Visual Studio 2013\Projects\Cards\Cards\" & ListBox2.Text & ".png") Then
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Load("C:\Users\Muzamil\Documents\Visual Studio 2013\Projects\Cards\Cards\" & ListBox2.Text & ".png")
            Else
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Image = Nothing
            End If

        Next

        Dim a As Integer = 0

        For i As Integer = 4 To 7

            ListBox3.SelectedIndex = a

            If File.Exists("C:\Users\Muzamil\Documents\Visual Studio 2013\Projects\Cards\Cards\" & ListBox3.Text & ".png") Then
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Load("C:\Users\Muzamil\Documents\Visual Studio 2013\Projects\Cards\Cards\" & ListBox3.Text & ".png")
            Else
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Image = Nothing
            End If
            a = a + 1
        Next

        a = 0

        For i As Integer = 8 To 11

            ListBox4.SelectedIndex = a

            If File.Exists("C:\Users\Muzamil\Documents\Visual Studio 2013\Projects\Cards\Cards\" & ListBox4.Text & ".png") Then
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Load("C:\Users\Muzamil\Documents\Visual Studio 2013\Projects\Cards\Cards\" & ListBox4.Text & ".png")
            Else
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Image = Nothing
            End If
            a = a + 1
        Next

        a = 0

        For i As Integer = 12 To 15

            ListBox5.SelectedIndex = a

            If File.Exists("C:\Users\Muzamil\Documents\Visual Studio 2013\Projects\Cards\Cards\" & ListBox5.Text & ".png") Then
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Load("C:\Users\Muzamil\Documents\Visual Studio 2013\Projects\Cards\Cards\" & ListBox5.Text & ".png")
            Else
                CType(Me.Controls.Find("picturebox" + CStr(i), True)(0), PictureBox).Image = Nothing
            End If
            a = a + 1
        Next
    End Sub

End Class

Public Class CardHolder
    Public Enum Suit
        Club
        Diamond
        Heart
        Spade
    End Enum

    Public Enum Rank
        Ace = 1
        Deuce
        Three
        Four
        Five
        Six
        Seven
        Eight
        Nine
        Ten
        Jack
        Queen
        King
    End Enum

End Class

Public Class Card
    Public ReadOnly suit As Suit
    Public ReadOnly rank As Rank


    Public Sub New(ByVal newSuit As Suit, ByVal newRank As Rank)
        suit = newSuit
        rank = newRank
    End Sub

    Public Overrides Function ToString() As String
        Return "The" & rank.ToString() & "of" & suit.ToString() & "s"
    End Function

End Class


Public Class Deck
    Private cards As Card()

    Public Sub New()
        cards = New Card(51) {}
        Dim j As Integer = 0

        For suitval As Integer = 0 To 4 - 1
            For rankval As Integer = 1 To 14 - 1

                cards(j) = New Card(CType(suitval, Suit), CType(rankval, Rank))
                j = j + 1
                'cards(suitval * 13 + rankval - 1) = New Card(CType(suitval, Suit), CType(rankval, Rank))
            Next
        Next
    End Sub

    Public Function getCard(ByVal cardNum As Integer) As Card
        If cardNum >= 0 AndAlso cardNum <= 51 Then
            Return cards(cardNum)
        Else
            Throw (New System.ArgumentOutOfRangeException("CardNum", cardNum, "Value Must be between 0 adn 51."))
        End If
    End Function


    Public Sub shuffle()
        Dim newDecks As Card() = New Card(51) {}
        Dim assigend As Boolean() = New Boolean(51) {}
        Dim sourceGen As Random = New Random()

        For i As Integer = 0 To 52 - 1
            Dim destCard As Integer = 0
            Dim foundCard As Boolean = False
            While foundCard = False
                destCard = sourceGen.[Next](52)
                If assigend(destCard) = False Then foundCard = True
            End While

            assigend(destCard) = True
            newDecks(destCard) = cards(i)
        Next

        newDecks.CopyTo(cards, 0)
    End Sub

End Class