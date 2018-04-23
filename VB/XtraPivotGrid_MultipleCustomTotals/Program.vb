' Developer Express Code Central Example:
' How to calculate multiple Custom Totals with SummaryType set to Custom
' 
' The following example demonstrates how to calculate and display multiple Custom
' Totals for a field.
' 
' In this example, two Custom Totals are implemented for
' the Category Name field. The first one displays a median calculated against
' summary values, while the second one displays the first and third
' quartiles.
' 
' To accomplish this task, we create two PivotGridCustomTotal
' objects and set their summary type to PivotSummaryType.Custom. We also assign
' the Custom Totals' names to PivotGridCustomTotalBase.Tag properties to be able
' to distinguish between the Custom Totals when we calculate their values.
' Finally, we add the created objects to the Category Name field's
' PivotGridField.CustomTotals collection and enable the Custom Totals to be
' displayed for this field by setting the PivotGridFieldBase.TotalsVisibility
' property to PivotTotalsVisibility.CustomTotals.
' 
' Custom Total values are
' actually calculated in the PivotGridControl.CustomCellValue event. First, the
' event handler prepares a list of summary values against which a Custom Total
' will be calculated. For this purpose, it creates a summary datasource and copies
' the summary values to an array. After that, the array is sorted and passed to an
' appropriate method that calculates a median or quartile value against the
' provided array. Finally, the resulting value is assigned to the event
' parameter's PivotCellValueEventArgs.Value property.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3815


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace XtraPivotGrid_MultipleCustomTotals
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace