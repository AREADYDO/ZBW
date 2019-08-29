using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace JsonTest
{
    public partial class Form1 : Form
    {
       public static string  date = DateTime.Now.ToString("yyyyMMddHHmmss");//24小时制
        public Form1()
        {
            InitializeComponent();
        }

        public static String Key() {

       /*      string md5 = "";
              string key = "";
              //string date= DateTime.Now.ToString("yyyyMMddhhmmss");//12小时制

              Random rd = new Random();
             // Random r4 = new Random();
             // Random l4 = new Random();
              for (int i = 0; i <8; i++)
              {
                 　　//无参即为使用系统时钟为种子
                  key = key+rd.Next(0,9).ToString();
              }
              md5 = key + "|bwsoft|bw8848|" + DateTime.Now.ToString("yyyyMMddHHmmss");
              key = Md5Utils.StrToMD5(md5);
              key = rd.ToString().Substring(0, 4) + key + rd.ToString().Substring(4, 4);
              return key.ToUpper();
            */
          //DateTime
            string CoonTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            //KEY
            //拼接字符串：随机码|密钥|bw8848|调用时间
            Random random = new Random();
            int RanNum = random.Next(10000000, 99999999);
            string password = "bwsoft";

            string str = RanNum.ToString() + "|" + password + "|" + "bw8848" + "|" + CoonTime;
            //KEY =随机码左4位 + MD5码 + 随机码右4位
            string key = RanNum.ToString().Substring(0, 4) + Md5Utils.StrToMD5(str.Trim()) + RanNum.ToString().Substring(4, 4);

            return key;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = GenerateTodo03();
        }
        /// <summary>
        /// 1.	测试连接
        /// </summary>
        /// <returns></returns>
        public static string GenerateTodo03()
        {

            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
            string jsondata = "{\"DateTime\": \"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\",\"KEY\": \""+ Key() + "\",\"DB\": \"bwshopsy_01\",\"Parm\": \"测试连接\"}";

            string url = "http://192.168.4.106:5555/bwshop/test";
            string res = HttpResponse.GetResponseData(jsondata, url);
            return res;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = GenerateTodo04();
        }
        /// <summary>
        /// 2.	会员信息
        /// </summary>
        /// <returns></returns>
        public static string GenerateTodo04()
        {

            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
            string jsondata = "{\"DateTime\": \"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\",\"KEY\": \"" + Key() + "\",\"DB\": \"bwshopsy_01\",\"Parm\": \"MTUwNzMzOTA5MzA=\",\"JsonData\": true}";
            string url = "http://192.168.4.106:5555/bwshop/SearchVip";
            string res = HttpResponse.GetResponseData(jsondata, url);
            return res;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = GenerateTodo05();
        }
        /// <summary>
        /// 14.	会员积分
        /// </summary>
        /// <returns></returns>
        public static string GenerateTodo05()
        {

            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
            string jsondata = "{\"DateTime\": \"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\",\"KEY\": \"" + Key2() + "\",	\"DB\": \"bwshopsy_01\",\"Parm\": \"MDAwMDI=\"}";

            string url = "http://192.168.4.106:5555/bwshop/GetVipIntegral";
            string res = HttpResponse.GetResponseData(jsondata, url);
            return res;

            //MD5Encrypt
        }

        public static String Key2()
        {
            
                 string md5 = "";
                   string key = "";
                   //string date= DateTime.Now.ToString("yyyyMMddhhmmss");//12小时制

                   Random rd = new Random();
                  // Random r4 = new Random();
                  // Random l4 = new Random();
                  
                      　　//无参即为使用系统时钟为种子
                   string    keyy = rd.Next(10000000, 99999999).ToString();
            
                   md5 = keyy + "|bwsoft|bw8848|" + DateTime.Now.ToString("yyyyMMddHHmmss");
                   key = Md5Utils.MD5Encrypt(md5);
                   key = keyy.ToString().Substring(0, 4) + key + keyy.ToString().Substring(4, 4);
                   return key.ToUpper();
                 
          /*  //DateTime
            string CoonTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            //KEY
            //拼接字符串：随机码|密钥|bw8848|调用时间
            Random random = new Random();
            int RanNum = random.Next(10000000, 99999999);
            string password = "bwsoft";

            string str = RanNum.ToString() + "|" + password + "|" + "bw8848" + "|" + CoonTime;
            //KEY =随机码左4位 + MD5码 + 随机码右4位
            string key = RanNum.ToString().Substring(0, 4) + Md5Utils.MD5Encrypt(str.Trim()) + RanNum.ToString().Substring(4, 4);
            
            return key;*/
        }



        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = GenerateTodo06();
        }
        /// <summary>
        /// 15.	会员余额
        /// </summary>
        /// <returns></returns>
        public static string GenerateTodo06()
        {

            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
            string jsondata = "{\"DateTime\": \"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\",\"KEY\": \"" + Key() + "\",\"DB\": \"bwshopsy_01\",\"Parm\": \"MDAwMDI=\"}";

            string url = "http://192.168.4.106:5555/bwshop/GetVipConstAmt";
            string res = PostUrl( url, jsondata);
            return res;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = Key1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "{\"DateTime\": \"" + date + "\",\"KEY\": \"" + Key() + "\",	\"DB\": \"bwshopsy_01\",\"Parm\": \"MDAwMDI=\"}";
        }


        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = GenerateTodo07();
        }
        public static string GenerateTodo07()
        {

            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
           string jsondata = "{\"DateTime\": \"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\",\"KEY\": \"" + Key1() + "\",\"DB\": \"bwshopsy_01\",\"Parm\": \"测试连接\"}";

            string url = "http://127.0.0.1:5555/bwshop/test";
            string res = Httpost( url, jsondata);
            return res;

            

        }

        public static String Key1()
        {

            //DateTime
            string CoonTime = DateTime.Now.ToString("yyyyMMddHHmmss");

            //KEY
            //拼接字符串：随机码|密钥|bw8848|调用时间
            Random random = new Random();
            int RanNum = random.Next(11111111, 99999999);
            string password = "bwsoft";

            string str = RanNum.ToString() + "|" + password + "|" + "bw8848" + "|" + CoonTime;
            //KEY =随机码左4位 + MD5码 + 随机码右4位
            string key = RanNum.ToString().Substring(0, 4) + Md5Utils.GetMD5WithString(str.Trim()) + RanNum.ToString().Substring(4, 4);

          /*  //DateTime
            string CoonTime = DateTime.Now.ToString("yyyyMMddHHmmss");

                   //KEY
                   //拼接字符串：随机码|密钥|bw8848|调用时间
                   Random random = new Random();
                   int RanNum = random.Next(10000000, 99999999);
                   string password = "bwsoft";

                   string str = RanNum.ToString() + "|" + password + "|" + "bw8848" + "|" + CoonTime;
                   //KEY =随机码左4位 + MD5码 + 随机码右4位
                   string key = RanNum.ToString().Substring(0, 4) + Md5Utils.GetMD5WithString(str.Trim()) + RanNum.ToString().Substring(4, 4);*/

            return key;
        }

        /*
    *  url:POST请求地址
    *  postData:json格式的请求报文,例如：{"key1":"value1","key2":"value2"}
    */

        public static string PostUrl(string url, string postData)
        {
            string result = "";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Method = "POST";

            req.Timeout = 800;//设置请求超时时间，单位为毫秒

            req.ContentType = "application/json";

            byte[] data = Encoding.UTF8.GetBytes(postData);

            req.ContentLength = data.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);

                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            Stream stream = resp.GetResponseStream();

            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }


        public static string Httpost(string url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] data = Encoding.UTF8.GetBytes(postDataStr);
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("UTF-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

      

    }
}
