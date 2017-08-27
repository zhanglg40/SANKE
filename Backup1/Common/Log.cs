using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace Common
{
    public static class Log
    {
        public static void LogMsg(string msg)
        {
            
            string date = DateTime.Now.ToString("yyyyMMdd");
            string path = HttpContext.Current.Server.MapPath("./log/");
            //判断Log目录是否存在，不存在则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = path + date + ".log";
            //使用StreamWriter写日志，包含时间，错误路径，错误信息
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("-----------------" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-----------------");
                sw.WriteLine(HttpContext.Current.Request.Url.ToString());
                sw.WriteLine(msg);
                sw.WriteLine("\r\n");
            }
        }
        public static void LogMsg(string msg,string userid)
        {
           
            string date = DateTime.Now.ToString("yyyyMMdd");
            string path = "C:\\errLog\\" + userid;
            //判断Log目录是否存在，不存在则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = path+"\\"+ date + ".log";
            //使用StreamWriter写日志，包含时间，错误路径，错误信息
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("-----------------" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-----------------");
                sw.WriteLine(HttpContext.Current.Request.Url.ToString());
                sw.WriteLine(msg);
                sw.WriteLine("\r\n");
            }
        }
      
    }
}