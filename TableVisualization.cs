using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace drinks_info;

public class TableVisualization
{
    // T must be a reference type(class). Can only be used with reference types and not value types(int, string)
    public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : 
    class 
    {   
        Console.Clear();

        // Set table name if not provided
        if (tableName == null)
            tableName = "";
            
        // Write row and column data
        ConsoleTableBuilder
            .From(tableData)
            .WithColumn(tableName)
            .ExportAndWriteLine();

        Console.WriteLine("\n \n");
    }   
}