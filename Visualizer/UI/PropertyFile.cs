using System.Xml.Serialization;

namespace AgGateway.ADAPT.Visualizer.UI
{
    [XmlRoot("settings")]
    public class PropertyFile
    {
        [XmlType("setting")]
        public class Property
        {
            [XmlAttribute("propertyName")] public string? PropertyName { get; set; }

            [XmlAttribute("propertyValue")] public string? PropertyValue { get; set; }
        }

        [XmlElement("setting")] public List<Property> Properties { get; } = new();

        public void Save(string fileName)
        {
            var serializer = new XmlSerializer(typeof(PropertyFile));
            using var writer = new StreamWriter(fileName);
            serializer.Serialize(writer, this);
        }

        public static PropertyFile? Load(string fileName)
        {
            var serializer = new XmlSerializer(typeof(PropertyFile));
            using var reader = new StreamReader(fileName);
            return serializer.Deserialize(reader) as PropertyFile;
        }
    }
}
