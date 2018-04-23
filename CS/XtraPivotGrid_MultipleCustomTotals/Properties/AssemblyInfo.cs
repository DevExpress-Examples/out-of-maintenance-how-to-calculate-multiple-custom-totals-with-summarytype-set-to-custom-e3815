// Developer Express Code Central Example:
// How to calculate multiple Custom Totals with SummaryType set to Custom
// 
// The following example demonstrates how to calculate and display multiple Custom
// Totals for a field.
// 
// In this example, two Custom Totals are implemented for
// the Category Name field. The first one displays a median calculated against
// summary values, while the second one displays the first and third
// quartiles.
// 
// To accomplish this task, we create two PivotGridCustomTotal
// objects and set their summary type to PivotSummaryType.Custom. We also assign
// the Custom Totals' names to PivotGridCustomTotalBase.Tag properties to be able
// to distinguish between the Custom Totals when we calculate their values.
// Finally, we add the created objects to the Category Name field's
// PivotGridField.CustomTotals collection and enable the Custom Totals to be
// displayed for this field by setting the PivotGridFieldBase.TotalsVisibility
// property to PivotTotalsVisibility.CustomTotals.
// 
// Custom Total values are
// actually calculated in the PivotGridControl.CustomCellValue event. First, the
// event handler prepares a list of summary values against which a Custom Total
// will be calculated. For this purpose, it creates a summary datasource and copies
// the summary values to an array. After that, the array is sorted and passed to an
// appropriate method that calculates a median or quartile value against the
// provided array. Finally, the resulting value is assigned to the event
// parameter's PivotCellValueEventArgs.Value property.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3815

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("XtraPivotGrid_MultipleCustomTotals")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("XtraPivotGrid_MultipleCustomTotals")]
[assembly: AssemblyCopyright("Copyright ©  2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("f21c6343-fc1b-40b4-9ba9-ef69f432b9e0")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
