using System.Xml.Serialization;

namespace snipetrain_api.Models
{
    [XmlRoot(ElementName = "vendor")]
    public class Vendor
    {
        [XmlElement(ElementName = "label")]
        public string Label { get; set; }
        [XmlElement(ElementName = "webpage")]
        public string Webpage { get; set; }
        [XmlElement(ElementName = "license")]
        public string License { get; set; }
        [XmlElement(ElementName = "copyright")]
        public string Copyright { get; set; }
    }
    [XmlRoot(ElementName = "account")]
    public class Account
    {
        [XmlElement(ElementName = "webpage")]
        public string Webpage { get; set; }
    }
}

