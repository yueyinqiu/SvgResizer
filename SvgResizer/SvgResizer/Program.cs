using System.Xml.Linq;

#nullable disable

Console.Write("Read From: ");
var path = Console.ReadLine();

XDocument document;
using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
    document = XDocument.Load(stream);

var svg = document.Root;

int width = (int)svg.Attribute("width");
int height = (int)svg.Attribute("height");

if (svg.Attribute("viewBox") is null)
{
    width = (int)svg.Attribute("width");
    height = (int)svg.Attribute("height");
    svg.SetAttributeValue("viewBox", $"0 0 {width} {height}");
}

Console.WriteLine($"Width: {width}");
Console.WriteLine($"Height: {height}");

Console.Write($"Change Width To: ");
width = int.Parse(Console.ReadLine());

Console.Write($"Change Height To: ");
height = int.Parse(Console.ReadLine());

svg.SetAttributeValue("width", width);
svg.SetAttributeValue("height", height);

Console.Write("Save To: ");
path = Console.ReadLine();

if (File.Exists(path))
{
    Console.Write("File Exists. Enter Anything To Overwrite: ");
    _ = Console.ReadLine();
}

document.Save(path);
