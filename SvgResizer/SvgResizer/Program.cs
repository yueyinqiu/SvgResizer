using System.Xml.Linq;

#nullable disable

Console.Write("Read From: ");
var path = Console.ReadLine();

XDocument document;
using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
    document = XDocument.Load(stream);

var svg = document.Root;

if (svg.Attribute("viewBox") is null)
{
    var width = (int)svg.Attribute("width");
    var height = (int)svg.Attribute("height");
    svg.SetAttributeValue("viewBox", $"0 0 {width} {height}");
}

Console.WriteLine($"Width: {(string)svg.Attribute("width")}");
Console.WriteLine($"Height: {(string)svg.Attribute("height")}");

Console.Write($"Change Width To: ");
svg.SetAttributeValue("width", Console.ReadLine());

Console.Write($"Change Height To: ");
svg.SetAttributeValue("height", Console.ReadLine());

Console.Write("Save To: ");
path = Console.ReadLine();

if (File.Exists(path))
{
    Console.Write("File Exists. Enter Anything To Overwrite: ");
    _ = Console.ReadLine();
}

document.Save(path);
