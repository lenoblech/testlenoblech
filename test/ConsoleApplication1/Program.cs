using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceReference.WebServiceSoapClient obj = new ServiceReference.WebServiceSoapClient();
            
            System.Diagnostics.Debug.Assert(obj.Fibonacci(-1)== -1);
            System.Diagnostics.Debug.Assert(obj.Fibonacci(0) == -1);
            System.Diagnostics.Debug.Assert(obj.Fibonacci(1) == 1);
            System.Diagnostics.Debug.Assert(obj.Fibonacci(2) == 1);
            System.Diagnostics.Debug.Assert(obj.Fibonacci(3) == 2);
            System.Diagnostics.Debug.Assert(obj.Fibonacci(4) == 3);
            System.Diagnostics.Debug.Assert(obj.Fibonacci(5) == 5);
            System.Diagnostics.Debug.Assert(obj.Fibonacci(6) == 8);

            System.Diagnostics.Debug.Assert(obj.Fibonacci(99) == -889489150);
            System.Diagnostics.Debug.Assert(obj.Fibonacci(100) == -980107325);
            System.Diagnostics.Debug.Assert(obj.Fibonacci(101) == -1);    
        
            string s1= "<foo>bar</foo>";
            string r1= "{ \"foo\" : \"bar\" }";

            string s2= "<foo>hello</bar>";
            string r2= "Bad Xml format";

            string s3a = "<TRANS><HPAY></HPAY></TRANS>";
            string s3b = "<TRANS><HPAY><lD>'103</lD></HPAY></TRANS>";
            string s3 = "<TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>projectOl</MTOKEN></HPAY></TRANS>";

            string res1 = obj.XmlToJson(s1);
            string res2 = obj.XmlToJson(s2);
            string res3a = obj.XmlToJson(s3a);
            string res3b = obj.XmlToJson(s3b);
            string res3 = obj.XmlToJson(s3);
 
        }
    }
}
