using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Web;
using System.Text.RegularExpressions;
using Common;
using Web.UI;
using LitJson;
using System.Data;
using System.Text;

namespace Web.tools
{
    /// <summary>
    /// 文件上传处理页
    /// </summary>
    public class upload_ajax : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //取得处事类型
            string action = AXRequest.GetQueryString("action");

            switch (action)
            {
                case "EditorFile": //编辑器文件
                    EditorFile(context);
                    break;
                case "ManagerFile": //管理文件
                    ManagerFile(context);
                    break;
                case "ExcelFile": //管理文件
                    ExcelFile(context);
                    break;
                default: //普通上传
                    UpLoadFile(context); 
                    break;
            }

        }

        #region 上传文件处理===================================
        private void UpLoadFile(HttpContext context)
        {
         //   Common.Log.LogMsg("start", "admin");
            string _delfile = AXRequest.GetString("DelFilePath");
            HttpPostedFile _upfile = context.Request.Files["Filedata"];
            bool _iswater = false; //默认不打水印
            bool _isthumbnail = false; //默认不生成缩略图

            if (AXRequest.GetQueryString("IsWater") == "1")
                _iswater = true;
            if (AXRequest.GetQueryString("IsThumbnail") == "1")
                _isthumbnail = true;
            if (_upfile == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"请选择要上传文件！\"}");
                return;
            }
        //    Common.Log.LogMsg("1", "admin");
            UpLoad upFiles = new UpLoad();
            string newpath = "";
            string msg = upFiles.fileSaveAs(_upfile, _isthumbnail, _iswater,ref newpath);
        //    Common.Log.LogMsg(msg, "admin");
            ////删除已存在的旧文件
            //if (!string.IsNullOrEmpty(_delfile))
            //{
            //    Utils.DeleteUpFile(_delfile);
            //}
            //返回成功信息
            context.Response.Write(msg);
            context.Response.End();
        }
        #endregion
        #region 导入处理===================================
        private void ExcelFile(HttpContext context)
        {
            
            string _delfile = AXRequest.GetString("DelFilePath");
            HttpPostedFile _upfile = context.Request.Files["Filedata"];
            bool _iswater = false; //默认不打水印
            bool _isthumbnail = false; //默认不生成缩略图
            int id = 0;
           
            if (_upfile == null)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"请选择要上传文件！\"}");
                return;
            }
            //    Common.Log.LogMsg("1", "admin");
            StringBuilder sb = new StringBuilder(220000);
            StringBuilder info = new StringBuilder(220000);
          //  Common.Log.LogMsg("start", "super");
            UpLoad upFiles = new UpLoad();
            string newpath = "";
            string msg = upFiles.fileSaveAs(_upfile, _isthumbnail, _iswater,ref newpath);
          //  Common.Log.LogMsg("newpath:" + newpath, "super");
              DataTable dt=   Common.ExcelHelper.ConvertExcelFileToTable(newpath);
              BLL.article bll = new BLL.article();
              BLL.article_category bbc = new BLL.article_category();
         //     Common.Log.LogMsg("count:"+dt.Rows.Count.ToString(), "super");
         //     Common.Log.LogMsg("row:" + dt.Rows[0][0].ToString().Trim(), "super");
            
              for (int i = 1; i < dt.Rows.Count;i++ )
              {
                  int type = 0;
                  string no = "";
                  if (dt.Rows[i]["Name"].ToString().Trim() == "" && dt.Rows[i]["Barcode"].ToString().Trim() == "")
                      continue;
                  
                  if (dt.Rows[i]["Name"].ToString().Trim() == "")
                  {
                      sb.Append("{");
                    sb.Append("\"id\":\"" + i + "\",");
                     sb.Append("\"code\":\"" + dt.Rows[i]["Barcode"].ToString().Trim() + "\",");
                     sb.Append("\"name\":\"" + dt.Rows[i]["Name"].ToString().Trim() + "\",");
                     sb.Append("\"result\":\"失败\",");
                      sb.Append("\"reason\":\"中文名不能为空\"");
                      sb.Append("},");
                      continue;
                  }
                  if (dt.Rows[i]["Barcode"].ToString().Trim() == "")
                  {
                      sb.Append("{");
                      sb.Append("\"id\":\"" + i + "\",");
                     sb.Append("\"code\":\"" + dt.Rows[i]["Barcode"].ToString().Trim() + "\",");
                     sb.Append("\"name\":\"" + dt.Rows[i]["Name"].ToString().Trim() + "\",");
                     sb.Append("\"result\":\"失败\",");
                      sb.Append("\"reason\":\"条形码不能为空\"");
                      sb.Append("},");
                      continue;
                  }
                  else
                  {
                     if( bll.ExistsBarcode(dt.Rows[i]["Barcode"].ToString().Trim())){
                     //       sb.Append("{");
                     // sb.Append("\"id\":\"" + i + "\",");
                     //sb.Append("\"code\":\"" + dt.Rows[i]["Barcode"].ToString().Trim() + "\",");
                     //sb.Append("\"name\":\"" + dt.Rows[i]["Name"].ToString().Trim() + "\",");
                     //sb.Append("\"result\":\"失败\",");
                     // sb.Append("\"reason\":\"此商品已存在\"");
                     // sb.Append("},");
                     // continue;
                         type = 1;
                      }
                  }
                  if (dt.Rows[i]["ProductTypeNo"].ToString().Trim() == "")
                  {
                      sb.Append("{");
                       sb.Append("\"id\":\"" + i + "\",");
                     sb.Append("\"code\":\"" + dt.Rows[i]["Barcode"].ToString().Trim() + "\",");
                     sb.Append("\"name\":\"" + dt.Rows[i]["Name"].ToString().Trim() + "\",");
                     sb.Append("\"result\":\"失败\",");
                      sb.Append("\"reason\":\"商品类型不能为空\"");
                      sb.Append("},");
                      continue;
                  }
                  else
                  {
                      try
                      {
                           no = dt.Rows[i]["ProductTypeNo"].ToString().Trim();
                           if (string.IsNullOrEmpty(no))
                               id = 0;
                           else
                               id=  bbc.GetID(no);
                        if (id == 0)
                        {
                            sb.Append("{");
                             sb.Append("\"id\":\"" + i + "\",");
                     sb.Append("\"code\":\"" + dt.Rows[i]["Barcode"].ToString().Trim() + "\",");
                     sb.Append("\"name\":\"" + dt.Rows[i]["Name"].ToString().Trim() + "\",");
                     sb.Append("\"result\":\"失败\",");
                            sb.Append("\"reason\":\"商品类型不存在\"");
                            sb.Append("},");
                            continue;
                        }

                      }
                      catch (Exception ex)
                      {
                          sb.Append("{");
                      sb.Append("\"id\":\"" + i + "\",");
                     sb.Append("\"code\":\"" + dt.Rows[i]["Barcode"].ToString().Trim() + "\",");
                     sb.Append("\"name\":\"" + dt.Rows[i]["Name"].ToString().Trim() + "\",");
                     sb.Append("\"result\":\"失败\",");
                          sb.Append("\"reason\":\"商品类型:" + ex.Message + "\"");
                          sb.Append("},");
                          continue;
                          
                      }
                     
                  }
                //  Common.Log.LogMsg("1", "super");
                  Model.article model = new Model.article();
                  Dictionary<string, string> dn = new Dictionary<string, string>();
                  if (type == 1)
                  {
                      model = bll.GetModelNew(" where Barcode='" + dt.Rows[i]["Barcode"].ToString().Trim() + "'");
                      dn = model.fields;
                      if (dt.Rows[i]["Quantity"].ToString().Trim() == "")
                      {
                        //  dn.Add("stock_quantity", "0");
                      }
                      else
                      {
                          Decimal d = Convert.ToDecimal(model.fields["stock_quantity"]) + Convert.ToDecimal(dt.Rows[i]["Quantity"].ToString().Trim());                        
                          dn["stock_quantity"] = d.ToString();
                      }
                      if (dt.Rows[i]["PriceMode"].ToString().Trim() == "")
                      {
                          dn["PriceMode"] = "0";
                      }
                      else
                      {
                          dn["PriceMode"] = dt.Rows[i]["PriceMode"].ToString().Trim();
                      }
                      if (dt.Rows[i]["PurchasePrice"].ToString().Trim() == "")
                      {
                          dn["PurchasePrice"] = "0";
                      }
                      else
                      {
                          dn["PurchasePrice"] = dt.Rows[i]["PurchasePrice"].ToString().Trim();
                      }
                      if (dt.Rows[i]["WholesalePrice"].ToString().Trim() == "")
                      {
                          dn["WholesalePrice"] =  "0";
                      }
                      else
                      {
                          dn["WholesalePrice"] =  dt.Rows[i]["WholesalePrice"].ToString().Trim();
                      }
                      if (dt.Rows[i]["SpecialPrice"].ToString().Trim() == "")
                      {
                          dn["SpecialPrice"] = "0";
                      }
                      else
                      {
                          dn["SpecialPrice"] =  dt.Rows[i]["SpecialPrice"].ToString().Trim();
                      }
                     
                      if (dt.Rows[i]["DiscountRate"].ToString().Trim() == "")
                      {
                          dn["DiscountRate"] =  "0";
                      }
                      else
                      {
                          dn["DiscountRate"] =  dt.Rows[i]["DiscountRate"].ToString().Trim();
                      }

                      dn["Barcode"] = dt.Rows[i]["Barcode"].ToString().Trim();
                      dn["goods_no"] =  dt.Rows[i]["No"].ToString().Trim();
                      dn["english_name"] =  dt.Rows[i]["NameP"].ToString().Trim();
                      dn["ProductTypeNo"] =  dt.Rows[i]["ProductTypeNo"].ToString().Trim();
                      dn["sub_title"] = dt.Rows[i]["Name"].ToString().Trim();
                  }
                  else
                  {
                      model.img_url = "/upload/templates/default.jpg";
                      model.sort_id = 99;
                      model.click = 0;
                      model.status = 0;
                      model.is_msg = 0;
                      model.is_top = 0;
                      model.is_red = 0;
                      model.is_hot = 0;
                      model.is_slide = 0;
                      if (dt.Rows[i]["Quantity"].ToString().Trim() == "")
                      {
                          dn.Add("stock_quantity", "0");
                      }
                      else
                      {
                          dn.Add("stock_quantity", dt.Rows[i]["Quantity"].ToString().Trim());
                      }
                      if (dt.Rows[i]["PriceMode"].ToString().Trim() == "")
                      {
                          dn.Add("PriceMode", "0");
                      }
                      else
                      {
                          dn.Add("PriceMode", dt.Rows[i]["PriceMode"].ToString().Trim());
                      }
                      if (dt.Rows[i]["PurchasePrice"].ToString().Trim() == "")
                      {
                          dn.Add("PurchasePrice", "0");
                      }
                      else
                      {
                          dn.Add("PurchasePrice", dt.Rows[i]["PurchasePrice"].ToString().Trim());
                      }
                      if (dt.Rows[i]["WholesalePrice"].ToString().Trim() == "")
                      {
                          dn.Add("WholesalePrice", "0");
                      }
                      else
                      {
                          dn.Add("WholesalePrice", dt.Rows[i]["WholesalePrice"].ToString().Trim());
                      }
                      if (dt.Rows[i]["SpecialPrice"].ToString().Trim() == "")
                      {
                          dn.Add("SpecialPrice", "0");
                      }
                      else
                      {
                          dn.Add("SpecialPrice", dt.Rows[i]["SpecialPrice"].ToString().Trim());
                      }
                      //if (dt.Rows[i]["RetailPrice"].ToString().Trim() == "")
                      //{
                      //    dn.Add("RetailPrice", "0");
                      //}
                      //else
                      //{
                      //    dn.Add("RetailPrice", dt.Rows[i]["RetailPrice"].ToString().Trim());
                      //}
                      //if (dt.Rows[i]["TaxRate"].ToString().Trim() == "")
                      //{
                      //    dn.Add("TaxRate", "0");
                      //}
                      //else
                      //{
                      //    dn.Add("TaxRate", dt.Rows[i]["TaxRate"].ToString().Trim());
                      //}
                      if (dt.Rows[i]["DiscountRate"].ToString().Trim() == "")
                      {
                          dn.Add("DiscountRate", "0");
                      }
                      else
                      {
                          dn.Add("DiscountRate", dt.Rows[i]["DiscountRate"].ToString().Trim());
                      }

                      dn.Add("Barcode", dt.Rows[i]["Barcode"].ToString().Trim());
                      dn.Add("goods_no", dt.Rows[i]["No"].ToString().Trim());
                      dn.Add("english_name", dt.Rows[i]["NameP"].ToString().Trim());
                      dn.Add("ProductTypeNo", dt.Rows[i]["ProductTypeNo"].ToString().Trim());
                      dn.Add("sub_title", dt.Rows[i]["Name"].ToString().Trim());

                      model.fields = dn;
                  }
                  model.channel_id = 2;
                  model.category_id = id;
                  
                  model.title = dt.Rows[i]["Name"].ToString();
                
                 
                  model.zhaiyao = dt.Rows[i]["Remark"].ToString().Trim();
                  model.add_time = DateTime.Now;
                  model.is_sys = 1; //管理员发布
                  model.user_name = "super"; //获得当前登录用户名
               
                 
              //    Common.Log.LogMsg("2", "super");
             
                  model.fields["sell_price"] = GetPrice(model.fields);
                  List<Model.user_group_price> priceList = new List<Model.user_group_price>();
                 decimal _price = Convert.ToDecimal(model.fields["sell_price"]);
                 priceList.Add(new Model.user_group_price { group_id = 1, price = _price });
                 priceList.Add(new Model.user_group_price { group_id = 2, price = _price });
                 model.group_price = priceList;
                 if (type == 1)
                 {
                     if (!bll.Update(model) )
                     {
                         sb.Append("{");
                         sb.Append("\"id\":\"" + i + "\",");
                         sb.Append("\"code\":\"" + dt.Rows[i]["Barcode"].ToString().Trim() + "\",");
                         sb.Append("\"name\":\"" + dt.Rows[i]["Name"].ToString().Trim() + "\",");
                         sb.Append("\"result\":\"更新失败\",");
                         sb.Append("\"reason\":\"请检查数据格式\"");
                         sb.Append("},");
                         continue;
                     }
                     type = 0;
                 }
                 else
                 {
                     if (bll.Add(model) == 0)
                     {
                         sb.Append("{");
                         sb.Append("\"id\":\"" + i + "\",");
                         sb.Append("\"code\":\"" + dt.Rows[i]["Barcode"].ToString().Trim() + "\",");
                         sb.Append("\"name\":\"" + dt.Rows[i]["Name"].ToString().Trim() + "\",");
                         sb.Append("\"result\":\"新增失败\",");
                         sb.Append("\"reason\":\"请检查数据格式\"");
                         sb.Append("},");
                         continue;
                     }
                 }
              }
              string data = sb.ToString();
              if (data.Length > 0)
              {
                  data = data.Substring(0,data.Length-1);
                  msg = "{\"status\": 1, \"msg\": \"导入成功！\",\"data\":[" + data + "]}";
              }else{
                  msg = "{\"status\": 1, \"msg\": \"部分数据导入失败！\",\"data\":[" + data + "]}";
              }
            
            //    Common.Log.LogMsg(msg, "admin");
            ////删除已存在的旧文件
            //if (!string.IsNullOrEmpty(_delfile))
            //{
            //    Utils.DeleteUpFile(_delfile);
            //}
            //返回成功信息
            context.Response.Write(msg);
            context.Response.End();
        }
        #endregion

        private string GetPrice(Dictionary<string, string> dc)
        {
            string price = "";
            if (dc["PriceMode"] == "1")
            {
                if (dc["WholesalePrice"] == null || dc["WholesalePrice"] == "")
                {
                    price = "0";
                }
                else if (dc["DiscountRate"] == null || dc["DiscountRate"] == "")
                {
                    price = "0";
                }
                else
                {
                    price = (Decimal.Parse(dc["WholesalePrice"]) * Decimal.Parse(dc["DiscountRate"]) / 100).ToString();
                }
            }
            else if (dc["PriceMode"] == "2")
            {
                if (dc["SpecialPrice"] == null || dc["SpecialPrice"] == "")
                {
                    price = "0";
                }
                else
                {
                    price = dc["SpecialPrice"];
                }
            }
            else
            {
                if (dc["WholesalePrice"] == null || dc["WholesalePrice"] == "")
                {
                    price = "0";
                }
                else
                {
                    price = dc["WholesalePrice"];
                }
            }
            return price;
        }
        #region 编辑器上传处理===================================
        private void EditorFile(HttpContext context)
        {
            bool _iswater = false; //默认不打水印
            if (context.Request.QueryString["IsWater"] == "1")
                _iswater = true;
            HttpPostedFile imgFile = context.Request.Files["imgFile"];
            if (imgFile == null)
            {
                showError(context, "请选择要上传文件！");
                return;
            }
            UpLoad upFiles = new UpLoad();
            string newpath = "";
            string remsg = upFiles.fileSaveAs(imgFile, false, _iswater, ref newpath);
            JsonData jd = JsonMapper.ToObject(remsg);
            string status = jd["status"].ToString();
            string msg = jd["msg"].ToString();
            if (status == "0")
            {
                showError(context, msg);
                return;
            }
            string filePath = jd["path"].ToString(); //取得上传后的路径
            Hashtable hash = new Hashtable();
            hash["error"] = 0;
            hash["url"] = filePath;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(JsonMapper.ToJson(hash));
            context.Response.End();
        }
        //显示错误
        private void showError(HttpContext context, string message)
        {
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = message;
            context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
            context.Response.Write(JsonMapper.ToJson(hash));
            context.Response.End();
        }
        #endregion

        #region 浏览文件处理=====================================
        private void ManagerFile(HttpContext context)
        {
            Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig();
            //String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);

            //根目录路径，相对路径
            String rootPath = siteConfig.webpath + siteConfig.filepath + "/"; //站点目录+上传目录
            //根目录URL，可以指定绝对路径，比如 http://www.yoursite.com/attached/
            String rootUrl = siteConfig.webpath + siteConfig.filepath + "/";
            //图片扩展名
            String fileTypes = "gif,jpg,jpeg,png,bmp";

            String currentPath = "";
            String currentUrl = "";
            String currentDirPath = "";
            String moveupDirPath = "";

            String dirPath = Utils.GetMapPath(rootPath);
            String dirName = context.Request.QueryString["dir"];

            //根据path参数，设置各路径和URL
            String path = context.Request.QueryString["path"];
            path = String.IsNullOrEmpty(path) ? "" : path;
            if (path == "")
            {
                currentPath = dirPath;
                currentUrl = rootUrl;
                currentDirPath = "";
                moveupDirPath = "";
            }
            else
            {
                currentPath = dirPath + path;
                currentUrl = rootUrl + path;
                currentDirPath = path;
                moveupDirPath = Regex.Replace(currentDirPath, @"(.*?)[^\/]+\/$", "$1");
            }

            //排序形式，name or size or type
            String order = context.Request.QueryString["order"];
            order = String.IsNullOrEmpty(order) ? "" : order.ToLower();

            //不允许使用..移动到上一级目录
            if (Regex.IsMatch(path, @"\.\."))
            {
                context.Response.Write("Access is not allowed.");
                context.Response.End();
            }
            //最后一个字符不是/
            if (path != "" && !path.EndsWith("/"))
            {
                context.Response.Write("Parameter is not valid.");
                context.Response.End();
            }
            //目录不存在或不是目录
            if (!Directory.Exists(currentPath))
            {
                context.Response.Write("Directory does not exist.");
                context.Response.End();
            }

            //遍历目录取得文件信息
            string[] dirList = Directory.GetDirectories(currentPath);
            string[] fileList = Directory.GetFiles(currentPath);

            switch (order)
            {
                case "size":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new SizeSorter());
                    break;
                case "type":
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new TypeSorter());
                    break;
                case "name":
                default:
                    Array.Sort(dirList, new NameSorter());
                    Array.Sort(fileList, new NameSorter());
                    break;
            }

            Hashtable result = new Hashtable();
            result["moveup_dir_path"] = moveupDirPath;
            result["current_dir_path"] = currentDirPath;
            result["current_url"] = currentUrl;
            result["total_count"] = dirList.Length + fileList.Length;
            List<Hashtable> dirFileList = new List<Hashtable>();
            result["file_list"] = dirFileList;
            for (int i = 0; i < dirList.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(dirList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = true;
                hash["has_file"] = (dir.GetFileSystemInfos().Length > 0);
                hash["filesize"] = 0;
                hash["is_photo"] = false;
                hash["filetype"] = "";
                hash["filename"] = dir.Name;
                hash["datetime"] = dir.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }
            for (int i = 0; i < fileList.Length; i++)
            {
                FileInfo file = new FileInfo(fileList[i]);
                Hashtable hash = new Hashtable();
                hash["is_dir"] = false;
                hash["has_file"] = false;
                hash["filesize"] = file.Length;
                hash["is_photo"] = (Array.IndexOf(fileTypes.Split(','), file.Extension.Substring(1).ToLower()) >= 0);
                hash["filetype"] = file.Extension.Substring(1);
                hash["filename"] = file.Name;
                hash["datetime"] = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                dirFileList.Add(hash);
            }
            context.Response.AddHeader("Content-Type", "application/json; charset=UTF-8");
            context.Response.Write(JsonMapper.ToJson(result));
            context.Response.End();
        }

        #region Helper
        public class NameSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }
                FileInfo xInfo = new FileInfo(x.ToString());
                FileInfo yInfo = new FileInfo(y.ToString());

                return xInfo.FullName.CompareTo(yInfo.FullName);
            }
        }

        public class SizeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }
                FileInfo xInfo = new FileInfo(x.ToString());
                FileInfo yInfo = new FileInfo(y.ToString());

                return xInfo.Length.CompareTo(yInfo.Length);
            }
        }

        public class TypeSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                {
                    return 0;
                }
                if (x == null)
                {
                    return -1;
                }
                if (y == null)
                {
                    return 1;
                }
                FileInfo xInfo = new FileInfo(x.ToString());
                FileInfo yInfo = new FileInfo(y.ToString());

                return xInfo.Extension.CompareTo(yInfo.Extension);
            }
        }
        #endregion
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}