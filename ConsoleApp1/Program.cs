// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

using Microsoft.VisualBasic.FileIO;

// Create a TextFieldParser to read the CSV file
using (TextFieldParser parser = new TextFieldParser("data.csv"))
{
    parser.TextFieldType = FieldType.Delimited;
    parser.SetDelimiters(",");

    // Read the header row to determine the column names and data types
    string[] headers = parser.ReadFields();
    Type[] columnTypes = new Type[headers.Length];

    for (int i = 0; i < headers.Length; i++)
    {
        // Assume that all columns are strings initially
        columnTypes[i] = typeof(string);

        // Try to parse the first value in the column to determine its data type
        while (!parser.EndOfData)
        {
            string[] fields = parser.ReadFields();
            if (fields[i] != null && fields[i].Length > 0)
            {
                if (int.TryParse(fields[i], out _))
                {
                    columnTypes[i] = typeof(int);
                    break;
                }
                else if (double.TryParse(fields[i], out _))
                {
                    columnTypes[i] = typeof(double);
                    break;
                }
                else if (DateTime.TryParse(fields[i], out _))
                {
                    columnTypes[i] = typeof(DateTime);
                    break;
                }
            }
        }

        // Reset the parser back to the beginning of the file
        parser.DiscardBufferedData();
        parser.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
    }

    // Now you can process the CSV data using the columnTypes array to determine the appropriate type conversions
}