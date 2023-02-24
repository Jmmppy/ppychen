using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    //20220514
    //爬虫类 
    class ClassCheck
    {
        //需要初操作的网页控件
        public System.Windows.Forms.WebBrowser webBrowser;
        //处理状态值
        public int sta;
        //处理结果值
        public int adopt;
        HtmlElement htmlEle;

        //自动处理网页
        public bool CheckStr(string str)
        {
            //传入需要审查的文本
            if (str != "")
            {
                //sta==0 为初始化网页文本状态
                if (sta == 0)
                {
                    htmlEle = webBrowser.Document.GetElementById("text-content");
                    if (htmlEle == null)
                        return false;//提示不成功反回失败
                    htmlEle.SetAttribute("value", str);
                    htmlEle = webBrowser.Document.GetElementById("btn-start");
                    if (htmlEle == null)
                        return false;//同上
                    htmlEle.InvokeMember("click");
                    return true;//提交完成，结果为异步反回。准备检查结果 CheckStr(string str)str为""时可以检查结果
                }
                //sta == 1 为正在等待网页审查状态
                else if (sta == 1)
                {
                    try
                    {
                        //检查提交的文本是否审查完成
                        HtmlElementCollection elemColl = null;
                        int count;
                        webBrowser.Invoke(new Action(() => { elemColl = webBrowser.Document.GetElementsByTagName("b"); count = elemColl.Count; }));
                        //webBrowser1.Document.GetElementsByTagName("b");
                        foreach (HtmlElement elem in elemColl)
                        {
                            string className;

                            className = elem.GetAttribute("className");
                            //从元素组中找到审查结果所在的元素，拿到结果是否为通过
                            if ((className == "adopt") || (className == "pass"))
                            {
                                //textBoxB.Invoke(new Action(() => { textBoxB.Text = elem.GetAttribute("InnerHtml"); }));  //InnerHtml = "通过"
                                string elemstr = elem.GetAttribute("InnerHtml");
                                if (elemstr == "通过")
                                {
                                    adopt = 1;
                                    return false;
                                }
                                else
                                {
                                    adopt = 0;
                                    return false;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    { }
                    //返回true表示繁忙，需要下次继续检查，为了更快得到数据这里需要多数检查。为得到正确的数据，这里不能在堵塞线程的情况下处理
                    return true;
                }
            }
            //未传入字符串时，按取结果方式处理
            else
            {
                //反回最终结果
                if (adopt == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }


        public void SetClose()
        {
            KeyBoard.keyPress(KeyBoard.vKeyF5);//按一下后退(back)键
        }
        //设置目标网址
        public void SetUrl(string str)
        {
            webBrowser.Url = new System.Uri(str, System.UriKind.Absolute);
            
        }
    }
}
