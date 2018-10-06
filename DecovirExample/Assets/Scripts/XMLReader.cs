using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class XMLReader : MonoSingleton<XMLReader> {

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
        PlayZone.CurrentZonePlay++;
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
            string MathExample = Cfg.Attribute("Example").Value;
            int ExampleAnswer = int.Parse(Cfg.Attribute("ExampleAnswer").Value);
            //string Example = Cfg.Attribute("Example").Value;

            URLPlayerConfig.SizeX = SizeX;
            URLPlayerConfig.SizeY = SizeY;
            URLPlayerConfig.Speed = Speed;
            URLPlayerConfig.MathExample.text = MathExample;
            URLPlayerConfig.NeedNum = ExampleAnswer;
            URLPlayerConfig.reSizePlayer();
        }

        foreach (XElement Cfg in tempElement.Elements("BlockConfigForWave" + waveNum))
        {
            int MaxFigure = int.Parse(Cfg.Attribute("MaxEnemy").Value);
            float SizeX = float.Parse(Cfg.Attribute("SizeX").Value);
            float SizeY = float.Parse(Cfg.Attribute("SizeY").Value);
            float Speed = float.Parse(Cfg.Attribute("Speed").Value);
            int Example = int.Parse(Cfg.Attribute("ExampleAnswer").Value);

            URLFigureConfig.SizeX = SizeX;
            URLFigureConfig.SizeY = SizeY;
            URLFigureConfig.Speed = Speed;
            StartCoroutine(CreateNewFigure(MaxFigure,SizeX, SizeY, Speed, Example));
            
        }
    }

    private IEnumerator CreateNewFigure(int maxfigure,float sizex,float sizey,float speed,int example)
    {

        while (maxfigure > 0)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1.3f));
            int Temp = Random.Range(example, example + Random.Range(example - 2, example + 2));
            if (maxfigure - 1 <= 0)
                Temp = example;
            URLFigureConfig.Num = Temp;
            URLFigureConfig.NumText.text = Temp.ToString();
            URLFigureConfig.CreateFigure();
            maxfigure--;
        }
        yield return 0;
    }
}
