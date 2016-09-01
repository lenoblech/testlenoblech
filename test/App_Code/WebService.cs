using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        // Init Trace
        InitTrace();


        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    void InitTrace()
    { 
        // init log4net
    }

    void Trace(string message)
    { 
        // sent message log4net
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    [WebMethod]
    public string XmlToJson(string val) {
        try
        {
            Trace("XmlToJson "+val); 

            string res = "";
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(val);

            foreach (System.Xml.XmlNode item in doc.ChildNodes)
                res += Parser(0, item);

            Trace("XmlToJson " + val+" -> "+res);
            return res;
        }
        catch (Exception ex)
        {
            Trace("XmlToJson Error "+ex.Message ); 

            return "Bad Xml format";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rank"></param>
    /// <param name="node"></param>
    /// <returns></returns>
    string Parser(int rank, System.Xml.XmlNode node)
    {
        string res = "";
        if (node.ChildNodes.Count == 0 ||
            (node.ChildNodes.Count == 1 && node.ChildNodes[0] is System.Xml.XmlText))
        {
            // if value
            if (node.InnerText == "")
            {
                // node null -> no message
                return "";
            }
            else
            {
                // format message
                if (rank == 0)
                    res += "{ \"" + node.Name + "\" : \"" + node.InnerText + "\" },";
                else
                    res += Rank(rank + 1) + "\"" + node.Name + "\" : \"" + node.InnerText + "\",\n";
            }
            return res;
        }
        else
        {
            // multi node
            if (rank == 0)
                res += Rank(rank) + "{\n";
            res += Rank(rank + 1) + "\"" + node.Name + "\" : {\n";
            
            // list sub node
            foreach (System.Xml.XmlNode item in node.ChildNodes)
                res += Parser(rank + 1, item);

            // remove last ","
            if (res[res.Length - 1] == ',')
                res = res.Substring(0, res.Length - 1);
            if (res[res.Length - 2] == ',' && res[res.Length - 1] == '\n')
                res = res.Substring(0, res.Length - 2) + "\n";

            if (rank == 0)
            {
                res += Rank(rank + 1) + "}\n";
                res += Rank(rank) + "}";
            }
            else
                res += Rank(rank + 1) + "},\n";
        }

        return res;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rank"></param>
    /// <returns></returns>
    string Rank(int rank)
    {
        string str = "";
        for (int i = 0; i < rank; i++)
            str += "  ";
        return str;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    [WebMethod]
    public int Fibonacci(int n)
    {
        Trace("Fibonacci" + n);
        // check limit
        if(n<=0)
            return -1;
        if (n > 100)
            return -1;

        int a = 0;
        int b = 1;
        for (int i = 0; i < n; i++)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }
        Trace("Fibonacci" + n+ "->"+ a);
        return a;
    }


}
