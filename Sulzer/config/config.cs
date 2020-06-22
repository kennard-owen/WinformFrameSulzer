using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sulzer.config {
    public class config {
       public static WholeConfig GetCheckPointList() {

            WholeConfig wholeConfig = new WholeConfig();
           string path= System.Windows.Forms.Application.StartupPath;

            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            XmlReader reader = XmlReader.Create($"{path}\\config.xml", settings);
            xmlDoc.Load(reader);
            XmlNode xn = xmlDoc.SelectSingleNode("CheckPoints");
            // 得到根节点的所有子节点
            
            XmlNodeList xnl = xn.ChildNodes;
              foreach (XmlNode xn1 in xnl)
              {
                CheckPoint point = new CheckPoint();
                  // 将节点转换为元素，便于得到节点的属性值
                  XmlElement xe = (XmlElement)xn1;
                  // 得到Type和ISBN两个属性的属性值
                  //point.BookISBN = xe.GetAttribute("ISBN").ToString();
                  //point.BookType = xe.GetAttribute("Type").ToString();
                  // 得到Book节点的所有子节点
                  XmlNodeList xnl0 = xe.ChildNodes;
                  point.Name = xnl0.Item(0).InnerText;
                  point.IOLinkIP = xnl0.Item(1).InnerText;
                  point.Port = xnl0.Item(2).InnerText;
                  point.Des = xnl0.Item(3).InnerText;
                  wholeConfig.CheckPointList.Add(point);
              }
            reader.Close();
            return wholeConfig;
        }
    }
}
