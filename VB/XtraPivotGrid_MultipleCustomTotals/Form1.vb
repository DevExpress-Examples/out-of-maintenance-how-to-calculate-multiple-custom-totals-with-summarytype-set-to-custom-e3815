Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Windows.Forms
Imports DevExpress.Data.PivotGrid
Imports DevExpress.XtraPivotGrid

Namespace XtraPivotGrid_MultipleCustomTotals
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

			' Binds the pivot grid to data.
			Dim adapter As New nwindDataSetTableAdapters.ProductReportsTableAdapter()
			pivotGridControl1.DataSource = adapter.GetData()


			' Creates a PivotGridCustomTotal object that defines the Median Custom Total.
			Dim medianCustomTotal As New PivotGridCustomTotal(PivotSummaryType.Custom)

			' Specifies a unique PivotGridCustomTotal.Tag property value 
			' that will be used to distinguish between two Custom Totals.
			medianCustomTotal.Tag = "Median"

			' Specifies formatting settings that will be used to display 
			' Custom Total column/row headers.
			medianCustomTotal.Format.FormatString = "{0} Median"
			medianCustomTotal.Format.FormatType = DevExpress.Utils.FormatType.Custom

			' Adds the Median Custom Total for the Category Name field.
			fieldCategoryName.CustomTotals.Add(medianCustomTotal)


			' Creates a PivotGridCustomTotal object that defines the Quartiles Custom Total.
			Dim quartileCustomTotal As New PivotGridCustomTotal(PivotSummaryType.Custom)

			' Specifies a unique PivotGridCustomTotal.Tag property value 
			' that will be used to distinguish between two Custom Totals.
			quartileCustomTotal.Tag = "Quartiles"

			' Specifies formatting settings that will be used to display
			' Custom Total column/row headers.
			quartileCustomTotal.Format.FormatString = "{0} Quartiles"
			quartileCustomTotal.Format.FormatType = DevExpress.Utils.FormatType.Custom

			' Adds the Quartiles Custom Total for the Category Name field.
			fieldCategoryName.CustomTotals.Add(quartileCustomTotal)


			' Enables the Custom Totals to be displayed instead of Automatic Totals.
			fieldCategoryName.TotalsVisibility = PivotTotalsVisibility.CustomTotals
		End Sub

		' Handles the CustomCellValue event. 
		' Fires for each data cell. If the processed cell is a Custom Total,
		' provides an appropriate Custom Total value.
        Private Sub pivotGridControl1_CustomCellValue(ByVal sender As Object, _
                                                      ByVal e As PivotCellValueEventArgs) _
                                                  Handles pivotGridControl1.CustomCellValue

            ' Exits if the processed cell does not belong to a Custom Total.
            If e.ColumnCustomTotal Is Nothing AndAlso e.RowCustomTotal Is Nothing Then
                Return
            End If

            ' Obtains a list of summary values against which
            ' the Custom Total will be calculated.
            Dim summaryValues As ArrayList = GetSummaryValues(e)

            ' Obtains the name of the Custom Total that should be calculated.
            Dim customTotalName As String = GetCustomTotalName(e)

            ' Calculates the Custom Total value and assigns it to the Value event parameter.
            e.Value = GetCustomTotalValue(summaryValues, customTotalName)
        End Sub

		' Returns the Custom Total name.
		Private Function GetCustomTotalName(ByVal e As PivotCellValueEventArgs) As String
            Return If(e.ColumnCustomTotal IsNot Nothing, e.ColumnCustomTotal.Tag.ToString(), _
                      e.RowCustomTotal.Tag.ToString())
		End Function

		' Returns a list of summary values against which
		' a Custom Total will be calculated.
		Private Function GetSummaryValues(ByVal e As PivotCellValueEventArgs) As ArrayList
			Dim values As New ArrayList()

			' Creates a summary data source.
			Dim sds As PivotSummaryDataSource = e.CreateSummaryDataSource()

			' Iterates through summary data source records
			' and copies summary values to an array.
			For i As Integer = 0 To sds.RowCount - 1
				Dim value As Object = sds.GetValue(i, e.DataField)
				If value Is Nothing Then
					Continue For
				End If
				values.Add(value)
			Next i

			' Sorts summary values.
			values.Sort()

			' Returns the summary values array.
			Return values
		End Function

		' Returns the Custom Total value by an array of summary values.
        Private Function GetCustomTotalValue(ByVal values As ArrayList, _
                                             ByVal customTotalName As String) As Object

            ' Returns a null value if the provided array is empty.
            If values.Count = 0 Then
                Return Nothing
            End If

            ' If the Median Custom Total should be calculated,
            ' calls the GetMedian method.
            If customTotalName = "Median" Then
                Return GetMedian(values)
            End If

            ' If the Quartiles Custom Total should be calculated,
            ' calls the GetQuartiles method.
            If customTotalName = "Quartiles" Then
                Return GetQuartiles(values)
            End If

            ' Otherwise, returns a null value.
            Return Nothing
        End Function

		' Calculates a median for the specified sorted sample.
        Private Function GetMedian(ByVal values As ArrayList) As Decimal
            If values.Count > 0 Then
                If values.Count Mod 2 = 0 Then
                    Return (CDec(values(CInt(values.Count / 2 - 1))) + _
                            CDec(values(CInt(values.Count / 2)))) / 2
                Else
                    Return CDec(values(CInt(Math.Truncate(values.Count / 2))))
                End If
            End If
            Return 0
        End Function

		' Calculates the first and third quartiles for the specified sorted sample
		' and returns them inside a formatted string.
		Private Function GetQuartiles(ByVal values As ArrayList) As String
			Dim part1 As New ArrayList()
			Dim part2 As New ArrayList()
			If (values.Count Mod 2) = 0 Then
                part1 = values.GetRange(0, CInt(Math.Truncate(values.Count / 2)))
                part2 = values.GetRange(CInt(Math.Truncate(values.Count / 2)), CInt(values.Count / 2))
			Else
                part1 = values.GetRange(0, CInt(Math.Truncate(values.Count / 2)))
                part2 = values.GetRange(CInt(Math.Truncate(values.Count / 2)), _
                                        values.Count - CInt(Math.Truncate(values.Count / 2)))
			End If
            Return String.Format("({0}, {1})", GetMedian(part1).ToString("c2"), _
                                 GetMedian(part2).ToString("c2"))
		End Function
	End Class
End Namespace