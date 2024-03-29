﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace JsonTest
{
    public class HttpResponse
    {
        #region Static Field

        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        #endregion Static Field

        #region public Method

        /// <summary>
        /// Get方法获取Json数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHttpResponseJson(string url, IWebProxy webProxy)
        {
            string json = string.Empty;
            Encoding encoding = Encoding.UTF8;
            HttpWebResponse Response = CreateGetHttpResponse(new HttpGetParametersModel()
            {
                Url = url,
                WebProxy = webProxy
            });
            json = GetStream(Response, encoding);
            return json;
        }

        /// <summary>
        /// Post Url获取Json数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string PostHttpResponseJson(string url, IWebProxy webProxy)
        {
            string json = string.Empty;
            Encoding encoding = Encoding.UTF8;
            HttpWebResponse Response = CreatePostHttpResponse(new HttpPostParametersModel()
            {
                Url = url,
                RequestEncoding = encoding,
                WebProxy = webProxy
            });
            json = GetStream(Response, encoding);
            return json;
        }

        /// <summary>
        ///  Post带参数的 Url获取Json数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postDict"></param>
        /// <returns></returns>
        public static string PostHttpResponseJson(string url, IWebProxy webProxy, IDictionary<string, string> postDict)
        {
            string json = string.Empty;
            Encoding encoding = Encoding.UTF8;
            HttpWebResponse Response = CreatePostHttpResponse(new HttpPostParametersModel()
            {
                Url = url,
                DictParameters = postDict,
                WebProxy = webProxy,
                RequestEncoding = encoding
            });
            json = GetStream(Response, encoding);
            return json;
        }


        /// <summary>
        /// 创建GET方式的HTTP请求
        /// </summary>
        /// <param name="url">请求的URL</param>
        /// <param name="timeout">请求的超时时间</param>
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>
        /// <returns></returns>
        public static HttpWebResponse CreateGetHttpResponse(HttpGetParametersModel getParametersModel)
        {
            if (string.IsNullOrEmpty(getParametersModel.Url))
            {
                throw new ArgumentNullException("getParametersModel.Url");
            }
            HttpWebRequest request = WebRequest.Create(getParametersModel.Url) as HttpWebRequest;
            if (getParametersModel.WebProxy != null)
            {
                request.Proxy = getParametersModel.WebProxy;
            }
            request.Method = "GET";
            request.UserAgent = DefaultUserAgent;
            if (!string.IsNullOrEmpty(getParametersModel.UserAgent))
            {
                request.UserAgent = getParametersModel.UserAgent;
            }
            if (getParametersModel.Timeout.HasValue)
            {
                request.Timeout = getParametersModel.Timeout.Value;
            }
            if (getParametersModel.Cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(getParametersModel.Cookies);
            }
            return request.GetResponse() as HttpWebResponse;
        }

        /// <summary>
        /// 创建POST方式的HTTP请求
        /// </summary>
        /// <param name="url">请求的URL</param>
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>
        /// <param name="timeout">请求的超时时间</param>
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>
        /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>
        /// <returns></returns>
        public static HttpWebResponse CreatePostHttpResponse(HttpPostParametersModel postParametersModel)
        {
            if (string.IsNullOrEmpty(postParametersModel.Url))
            {
                throw new ArgumentNullException("postParametersModel.Url");
            }
            if (postParametersModel.RequestEncoding == null)
            {
                throw new ArgumentNullException("postParametersModel.RequestEncoding");
            }
            HttpWebRequest request = null;
            //如果是发送HTTPS请求
            if (postParametersModel.Url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(postParametersModel.Url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(postParametersModel.Url) as HttpWebRequest;
            }
            if (postParametersModel.WebProxy != null)
            {
                request.Proxy = postParametersModel.WebProxy;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";


            if (!string.IsNullOrEmpty(postParametersModel.UserAgent))
            {
                request.UserAgent = postParametersModel.UserAgent;
            }
            else
            {
                request.UserAgent = DefaultUserAgent;
            }

            if (postParametersModel.Timeout.HasValue)
            {
                request.Timeout = postParametersModel.Timeout.Value;
            }
            if (postParametersModel.Cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(postParametersModel.Cookies);
            }
            //如果需要POST数据
            if (!(postParametersModel.DictParameters == null || postParametersModel.DictParameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in postParametersModel.DictParameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, postParametersModel.DictParameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, postParametersModel.DictParameters[key]);
                    }
                    i++;
                }
                byte[] data = postParametersModel.RequestEncoding.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }


        /// <summary>
        /// 发送Post Json 请求 返回JSon数据
        /// </summary>
        /// <param name="JSONData">要处理的JSON数据</param>
        /// <param name="Url">要提交的URL</param>
        /// <returns>返回的JSON处理字符串</returns>
        public static string GetResponseData(string JSONData, string Url)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(JSONData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "application/json;charset=UTF-8";
            Stream reqstream = request.GetRequestStream();
            reqstream.Write(bytes, 0, bytes.Length);

            //声明一个HttpWebRequest请求
            request.Timeout = 60000;
            //设置连接超时时间
            request.Headers.Set("Pragma", "no-cache");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream streamReceive = response.GetResponseStream();
            Encoding encoding = Encoding.UTF8;

            StreamReader streamReader = new StreamReader(streamReceive, encoding);
            string strResult = streamReader.ReadToEnd();
            streamReceive.Dispose();
            streamReader.Dispose();

            return strResult;
        }
        #endregion public Method

        #region Private Method

        /// <summary>
        /// 设置https证书校验机制,默认返回True,验证通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受
        }

        /// <summary>
        /// 将response转换成文本
        /// </summary>
        /// <param name="response"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private static string GetStream(HttpWebResponse response, Encoding encoding)
        {
            try
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    switch (response.ContentEncoding.ToLower())
                    {
                        case "gzip":
                            {
                                string result = Decompress(response.GetResponseStream(), encoding);
                                response.Close();
                                return result;
                            }
                        default:
                            {
                                using (StreamReader sr = new StreamReader(response.GetResponseStream(), encoding))
                                {
                                    string result = sr.ReadToEnd();
                                    sr.Close();
                                    sr.Dispose();
                                    response.Close();
                                    return result;
                                }
                            }
                    }
                }
                else
                {
                    response.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return "";
        }

        private static string Decompress(Stream stream, Encoding encoding)
        {
            byte[] buffer = new byte[100];
            //int length = 0;

            using (GZipStream gz = new GZipStream(stream, CompressionMode.Decompress))
            {
                //GZipStream gzip = new GZipStream(res.GetResponseStream(), CompressionMode.Decompress);
                using (StreamReader reader = new StreamReader(gz, encoding))
                {
                    return reader.ReadToEnd();
                }
                /*
                using (MemoryStream msTemp = new MemoryStream())
                {
                    //解压时直接使用Read方法读取内容，不能调用GZipStream实例的Length等属性，否则会出错：System.NotSupportedException: 不支持此操作；
                    while ((length = gz.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        msTemp.Write(buffer, 0, length);
                    }
                    return encoding.GetString(msTemp.ToArray());
                }
                 * */
            }
        }

        #endregion Private Method


    }
    #region GET/POST请求参数模型

    /// <summary>
    /// GET请求参数模型
    /// </summary>
    public class HttpGetParametersModel
    {
        /// <summary>
        /// 请求的URL(GET方式就附加参数)
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public int? Timeout { get; set; }

        /// <summary>
        ///浏览器代理类型
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// Web请求代理
        /// </summary>
        public IWebProxy WebProxy { get; set; }

        /// <summary>
        /// Cookies列表
        /// </summary>
        public CookieCollection Cookies { get; set; }
    }

    /// <summary>
    /// POST请求参数模型
    /// </summary>
    public class HttpPostParametersModel : HttpGetParametersModel
    {
        /// <summary>
        /// POST参数字典
        /// </summary>
        public IDictionary<string, string> DictParameters { get; set; }

        /// <summary>
        /// 发送HTTP请求时所用的编码
        /// </summary>
        public Encoding RequestEncoding { get; set; }
    }

    #endregion GET/POST请求参数模型

}
