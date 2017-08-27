using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Web;
using System.Net.Mail;

namespace Common
{
    public class AXMail
    {


        #region 发送电子邮件
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="smtpserver">SMTP服务器</param>
        /// <param name="userName">登录帐号</param>
        /// <param name="pwd">登录密码</param>
        /// <param name="nickName">发件人姓名</param>
        /// <param name="strfrom">发件人</param>
        /// <param name="strto">收件人</param>
        /// <param name="subj">主题</param>
        /// <param name="bodys">内容</param>
        public static void sendMail(string smtpserver, string userName, string pwd, string nickName, string strfrom, string strto, string subj, string bodys)
        {
            try
            {

          
            SmtpClient _smtpClient = new SmtpClient();
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = smtpserver;//指定SMTP服务器
            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials = new System.Net.NetworkCredential(userName, pwd);//" + Resources.lang.username+ "和密码
            if (smtpserver.Equals("smtp.qq.com"))
            {
                _smtpClient.Port = 587;
            }
             
            //MailMessage _mailMessage = new MailMessage(strfrom, strto);
            MailAddress _from = new MailAddress(strfrom, nickName);
            MailAddress _to = new MailAddress(strto);
            MailMessage _mailMessage = new MailMessage(_from, _to);
            _mailMessage.Subject = subj;//主题
            _mailMessage.Body = bodys;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.Default;//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = MailPriority.High;//优先级
            _smtpClient.Send(_mailMessage);
            }
            catch (Exception)
            {
                throw new Exception("邮箱设置错误"); 
                //throw;
            }
        }
        #endregion
        public static void sendMail2(string smtpserver, string userName, string pwd, string nickName, string strfrom, string strto, string subj, string bodys)
        {
            try
            {
                bodys = bodys.Replace("&gt;", ">");
                bodys = bodys.Replace("&lt;", "<");
                bodys = bodys.Replace("&nbsp;", " ");
                bodys = bodys.Replace("&quot;", "\"");
                bodys = bodys.Replace("&#39;", "\'");
                bodys = bodys.Replace("<br/>", "\n");

                   System.Net.WebClient wCient = new System.Net.WebClient();
             wCient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
             string data = "content={\"platform\":\"pc\",\"deviceToken\":\"deviceToken\",\"appkey\":\"gdfshgfhdgdf\",\"appCode\":\"1001\",\"language\":\"zh_CN\",'from':'" + strfrom + "','to':'" + strto + "','password':'" + pwd + "','hostName':'" + smtpserver
                 + "','smtpPort':'25','subTitle':'" + subj + "','body':'" + bodys + "','name':'" + nickName + "','maillist':['" + strto 
                 + "']}"  +"&sign='sign'";
               byte[] buffer= Encoding.UTF8.GetBytes(data);
                //data = Encoding.GetEncoding("GB2312").GetString(buffer);
             //   HttpUtility.UrlEncode
            // HttpUtility.UrlDecode("aa", Encoding.GetEncoding("gbk"));  
             byte[] utf8bytes = System.Text.Encoding.Default.GetBytes(data);
byte[] utf8bytes2 = System.Text.Encoding.Convert(System.Text.Encoding.Default, System.Text.Encoding.UTF8, utf8bytes);
//data = System.Text.Encoding.Default.GetString(utf8bytes2);
          //    byte[] postData = System.Text.Encoding.ASCII.GetBytes(data);
           //   string URLEncode = HttpHelper.URLEncode(parameters);
byte[] responseData = wCient.UploadData("http://power_cloud_manager/api/mail/send", "POST", buffer);
 
               string returnStr = System.Text.Encoding.UTF8.GetString(responseData);//返回接受的数据 
 
            }
            catch (Exception)
            {
                throw new Exception("邮箱设置错误");
                //throw;
            }
        }
    }
}
