Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1

    Dim authors As New List(Of String) From {"Roald Dahl", "J.K. Rowling", "Dr. Seuss", "Maurice Sendak", "Shel Silverstein", "Eric Carle"}
    Dim booksByAuthor As New Dictionary(Of String, List(Of String))
    Dim versionsByBook As New Dictionary(Of String, List(Of String))
    Dim versionsPublisher As New Dictionary(Of String, List(Of String))
    Dim versionsPublication As New Dictionary(Of String, List(Of String))
    Dim versionsBinding As New Dictionary(Of String, List(Of String))
    Dim selectedAuthor As String
    Dim selectedBook As String
    Dim selectedVersions As String
    Dim selectedPublisher As String
    Dim selectedPublication As String
    Dim selectedBinding As String
    Dim selectedCategory As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Children.Click
        GroupBox1.Visible = True
        selectedCategory = "Children"
        InitializeChildrenData()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If ComboBox1.SelectedItem IsNot Nothing AndAlso ComboBox3.SelectedItem IsNot Nothing AndAlso ComboBox4.SelectedItem IsNot Nothing Then
            selectedAuthor = ComboBox1.SelectedItem.ToString()
            selectedBook = ComboBox3.SelectedItem.ToString()
            selectedVersions = ComboBox4.SelectedItem.ToString()

            Label16.Text = selectedBook & ", Version: " & selectedVersions
            Label17.Text = selectedAuthor
            Label21.Text = selectedCategory
            Label22.Text = selectedVersions
            Label20.Text = selectedBinding
            Label19.Text = selectedPublication
            Label18.Text = selectedPublisher

        Else
            MessageBox.Show("Please select an author, book, and version before saving.")
        End If

    End Sub
    Private Sub InitializeChildrenData()
        booksByAuthor("Roald Dahl") = New List(Of String) From {"Charlie and the Chocolate Factory", "BFG"}
        booksByAuthor("J.K. Rowling") = New List(Of String) From {"Harry Potter and the Philosopher's Stone", "Harry Potter and the Chamber of Secrets"}
        booksByAuthor("Dr. Seuss") = New List(Of String) From {"Cat in the Hat", "Green Eggs and Ham"}
        booksByAuthor("Maurice Sendak") = New List(Of String) From {"Where the Wild Things Are"}
        booksByAuthor("Shel Silverstein") = New List(Of String) From {"The Giving Tree"}
        booksByAuthor("Eric Carle") = New List(Of String) From {"The Very Hungry Caterpillar"}

        versionsByBook("Charlie and the Chocolate Factory") = New List(Of String) From {"Wersja 1", "Wersja 2"}
        versionsByBook("BFG") = New List(Of String) From {"Wersja 1"}
        versionsByBook("Harry Potter and the Philosopher's Stone") = New List(Of String) From {"Wersja 1", "Wersja 2"}
        versionsByBook("Harry Potter and the Chamber of Secrets") = New List(Of String) From {"Wersja 1"}
        versionsByBook("Cat in the Hat") = New List(Of String) From {"Wersja 1"}
        versionsByBook("Green Eggs and Ham") = New List(Of String) From {"Wersja 1"}
        versionsByBook("Where the Wild Things Are") = New List(Of String) From {"Wersja 1"}
        versionsByBook("The Giving Tree") = New List(Of String) From {"Wersja 1"}
        versionsByBook("The Very Hungry Caterpillar") = New List(Of String) From {"Wersja 1"}

        versionsPublisher("Charlie and the Chocolate Factory") = New List(Of String) From {"Lira"}
        versionsPublication("Charlie and the Chocolate Factory") = New List(Of String) From {"2020"}
        versionsBinding("Charlie and the Chocolate Factory") = New List(Of String) From {"Hardcover"}
        ComboBox1.Items.AddRange(authors.ToArray())
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim selectedAuthor As String = ComboBox1.SelectedItem.ToString()
        Dim books As List(Of String) = booksByAuthor(selectedAuthor)

        ComboBox3.Items.Clear()
        ComboBox4.Items.Clear()

        ComboBox3.Items.AddRange(books.ToArray())
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim selectedBook As String = ComboBox3.SelectedItem.ToString()
        Dim versions As List(Of String) = versionsByBook(selectedBook)



        ComboBox4.Items.Clear()
        ComboBox4.Items.AddRange(versions.ToArray())

        If versionsPublisher.ContainsKey(selectedBook) Then
            selectedPublisher = versionsPublisher(selectedBook)(0)
        Else
            selectedPublisher = ""
        End If

        If versionsPublication.ContainsKey(selectedBook) Then
            selectedPublication = versionsPublication(selectedBook)(0)
        Else
            selectedPublication = ""
        End If

        If versionsBinding.ContainsKey(selectedBook) Then
            selectedBinding = versionsBinding(selectedBook)(0)
        Else
            selectedBinding = ""
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GroupBox1.Visible = False
        MsgBox("The book has been ordered and you will be informed when it is ready for collection.")


    End Sub
End Class
