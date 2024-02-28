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
        if (tableName == null)
            tableName = "";

        Console.WriteLine("\n \n");
        
        Console.WriteLine("Executed this!");
        
        ConsoleTableBuilder
            .From(tableData)
            .WithColumn(tableName)
            .ExportAndWriteLine();
        Console.WriteLine("\n \n");
    }   
}