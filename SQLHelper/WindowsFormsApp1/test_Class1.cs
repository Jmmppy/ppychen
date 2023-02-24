using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace WindowsFormsApp1
{
    public class test_Class1
    {
        public string url { get; set; }
        public string html { get; set; }
        public test_Class1(string _url)
        {
            url = _url;

        }
        public void DoRequest()
        {

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            //设置请求方法
            request.Method = "GET";
            //设置请求头
            request.UserAgent = "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:94.0) Gecko/20100101 Firefox/94.0";
            //获取resonse
            WebResponse response = request.GetResponse();
            //获取结果转化为string
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    this.html = reader.ReadToEnd();
                }
            }
            System.Console.WriteLine(html);
        }



        //static void Main(string[] args)
        //{
        //    test_Class1 robj = new test_Class1("https://www.baidu.com/");
        //    robj.DoRequest();
        //}






    }
}
