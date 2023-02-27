using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

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
    List<List<double>> data = new List<List<double>>();

    while (!parser.EndOfData)
    {
        string[] fields = parser.ReadFields();
        List<double> row = new List<double>();

        for (int i = 0; i < fields.Length; i++)
        {
            if (columnTypes[i] == typeof(int))
            {
                int value;
                int.TryParse(fields[i], out value);
                row.Add((double)value);
            }
            else if (columnTypes[i] == typeof(double))
            {
                double value;
                double.TryParse(fields[i], out value);
                row.Add(value);
            }
            else if (columnTypes[i] == typeof(DateTime))
            {
                DateTime value;
                DateTime.TryParse(fields[i], out value);
                row.Add(value.Ticks);
            }
        }

        if (row.Count > 0)
        {
            data.Add(row);
        }
    }
}
















[Test]
public void TestBinaryTreeTraversal()
{
    // Arrange
    var root = Substitute.For<Node>();
    root.Value.Returns(1);
    var leftChild = Substitute.For<Node>();
    leftChild.Value.Returns(2);
    var rightChild = Substitute.For<Node>();
    rightChild.Value.Returns(3);

    root.Left = leftChild;
    root.Right = rightChild;

    // Act
    var result = TraverseBinaryTree(root);

    // Assert
    Assert.AreEqual(new List<int> { 1, 2, 3 }, result);
}

private List<int> TraverseBinaryTree(Node node)
{
    if (node == null) return new List<int>();

    var result = new List<int>();
    result.Add(node.Value);

    result.AddRange(TraverseBinaryTree(node.Left));
    result.AddRange(TraverseBinaryTree(node.Right));

    return result;
}




