// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


string[][] csvArray;

using (var reader = new StreamReader(filePath))
{
    List<string[]> rows = new List<string[]>();
    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        string[] row = line.Split(',');
        rows.Add(row);
    }
    csvArray = rows.ToArray();
}





string filePath = @"C:\example.csv";
string[][] dataArray;

using (var reader = new StreamReader(filePath))
{
    int rows = 0;
    while (!reader.EndOfStream)
    {
        reader.ReadLine();
        rows++;
    }

    dataArray = new string[rows][];
    reader.BaseStream.Seek(0, SeekOrigin.Begin);

    int row = 0;
    while (!reader.EndOfStream)
    {
        string line = reader.ReadLine();
        string[] values = line.Split(',');
        dataArray[row] = new string[values.Length];

        for (int i = 0; i < values.Length; i++)
        {
            dataArray[row][i] = values[i];
        }
        row++;
    }
}



