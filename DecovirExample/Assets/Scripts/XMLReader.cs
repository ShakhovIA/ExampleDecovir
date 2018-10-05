using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class XMLReader : MonoBehaviour {

    [SerializeField] private string URLatXml;
    private XDocument XmlFile;
    private XElement XmlElement;

    [SerializeField] private PlayerConfig URLPlayerConfig;
    [SerializeField] private FigureConfig URLFigureConfig;

    private void Awake()
    {
        XMLInitialize();
    }

    public void NextWave(int waveNum)
    {
        XmlParserConfig(XmlElement,waveNum);
    }

    private void XMLInitialize()
    {
        XmlFile = XDocument.Load(URLatXml);
        XmlElement = XmlFile.Element("Config");
    }

    private void XmlParserConfig(XElement tempElement,int waveNum)
    {
        foreach (XElement Cfg in tempElement.Elements("PlayerConfigForWave"+waveNum))
        {
            float SizeX = float.Parse(Cfg.Attribute("SizeX").Value);
            float SizeY = float.Parse(Cfg.Attribute("SizeY").Value);
            float Speed = float.Parse(Cfg.Attribute("Speed").Value);
            //string Example = Cfg.Attribute("Example").Value;

            URLPlayerConfig.SizeX = SizeX;
            URLPlayerConfig.SizeY = SizeY;
            URLPlayerConfig.Speed = Speed;
            URLPlayerConfig.reSizePlayer();
        }

        foreach (XElement Cfg in tempElement.Elements("BlockConfigForWave" + waveNum))
        {
            float SizeX = float.Parse(Cfg.Attribute("SizeX").Value);
            float SizeY = float.Parse(Cfg.Attribute("SizeY").Value);
            float Speed = float.Parse(Cfg.Attribute("Speed").Value);
            string Example = Cfg.Attribute("ExampleAnswer").Value;

            URLFigureConfig.SizeX = SizeX;
            URLFigureConfig.SizeY = SizeY;
            URLFigureConfig.Speed = Speed;
            URLFigureConfig.NumText.text = Example;
            URLFigureConfig.CreateFigure();
        }
    }
}
