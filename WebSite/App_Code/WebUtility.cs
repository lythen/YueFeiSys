using System;
using System.Text.RegularExpressions;

/// <summary>
///WebUtility 的摘要说明
/// </summary>
public static class WebUtility
{
    /// <summary>
    /// Method to make sure that user's inputs are not malicious
    /// </summary>
    /// <param name="text">User's Input</param>
    /// <param name="maxLength">Maximum length of input</param>
    /// <returns>The cleaned up version of the input</returns>
    public static string InputText(string text, int maxLength)
    {
        text = text.Trim();
        if (String.IsNullOrEmpty(text))
            return string.Empty;
        if (text.Length > maxLength)
            text = text.Substring(0, maxLength);
        text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
        text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");	//<br>
        text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");	//&nbsp;
        text = Regex.Replace(text, "<(.|\\n)*?>", String.Empty);	//any other tags
        text = text.Replace("'", "''");
        return text;
    }
    /// <summary>
    /// 过滤TextArea文本
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string HtmlEncode(string text)
    {
        text = text.Replace("<", "&lt;");
        text = text.Replace(">", "&gt;");
        text = text.Replace("   ", "&nbsp;");
        text = text.Replace("’", "'");
        text = text.Replace("\r", "<br />");
        return text;
    }
    public static string HtmlDecode(string str)
    {
        str = str.Replace("&lt;", "<");
        str = str.Replace("&gt;", ">");
        str = str.Replace("&nbsp;", " ");
        str = str.Replace("'", "’");
        str = str.Replace("<br>", "\r");
        str = str.Replace("<br />", "\r");
        return str;
    }
    /// <summary>
    /// 判断是否是数字
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsNumeric(string str)
    {
        bool isNum = true;
        if (!String.IsNullOrEmpty(str) && Regex.IsMatch(str, @"^\d+$"))
        {
            try { int i = int.Parse(str); }
            catch (OverflowException) { isNum = false; }
        }
        else
            isNum = false;
        return isNum;
    }
    /// <summary>
    /// 过滤整型的ID参数，非法的参数将返回0
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int FilterParam(string s)
    {
        if (String.IsNullOrEmpty(s)) return 0;
        if (WebUtility.IsNumeric(s))
            return int.Parse(s);
        else
            return 0;
    }

    /// <summary>
    /// 截取字符串
    /// </summary>
    /// <param name="s">需要截取的字符串</param>
    /// <param name="i">截取长度</param>
    /// <returns>截取后字符串</returns>
    public static string SubStr(string s, int i)
    {
        if (s.Length <= i)
        {
            return s;
        }
        else {
            return s.Substring(0, i)+"...";
        }
    }
    /// <summary>
    /// 过滤HTML代码
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    public static string FilterHtml(string html)
    {
        System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

        html = regex1.Replace(html, ""); //过滤<script></script>标记
        html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
        html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on事件
        html = regex4.Replace(html, ""); //过滤iframe
        html = regex5.Replace(html, ""); //过滤frameset
        html = regex6.Replace(html, ""); //过滤frameset
        html = regex7.Replace(html, ""); //过滤frameset
        html = regex8.Replace(html, ""); //过滤frameset
        html = html.Replace(" ", "");
        html = html.Replace("</strong>", "");
        html = html.Replace("<strong>", "");
        return html;
    }
}
