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
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonTest
{
    public partial class Form1 : Form
    {
       public static string  date = DateTime.Now.ToString("yyyyMMddHHmmss");//24小时制
        
        public Form1()
        {
            InitializeComponent();
            
            // textBox2.Text={n};
        }
        
      

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = GenerateTodo03();
        }
        /// <summary>
        /// 1.	测试连接
        /// </summary>
        /// <returns></returns>
        public  string GenerateTodo03()
        {
            Txml key = new Txml();

            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
            string jsondata = "{\"DateTime\": \"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\",\"KEY\": \""+ key.Key() + "\",\"DB\": \"bwshopsy_01\",\"Parm\": \"测试连接\"}";

            string url = "http://192.168.4.106:5555/bwshop/test";
            string res = HttpResponse.GetResponseData(jsondata, url);
            return res;


        }


        private void TB_XNLJ_Leave(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^/[^\\:*?\"<>|]*$"))
            {
                string dizhi = "http://localhost";
                //linkLabel_dizhi.Text = dizhi + TB_XNLJ.Text;
            }
            else
            {
                MessageBox.Show("输入格式不正确,已重置。\n\n文件夹名称中不能包含：  \\ : * ? \" < > | 这些字符。");
                // TB_XNLJ.Text = "/";
            }
        }

      public static  String NAME;
        private void button2_Click(object sender, EventArgs e)
        {
            NAME = textBox2.Text.Trim();
            textBox1.Text = ConvertJsonString(GenerateTodo04());
        }
        /// <summary>
        /// 2.	会员信息
        /// </summary>
        /// <returns></returns>
        public static string GenerateTodo04()
        {
            // TextBox textBox = new TextBox();
            Txml key = new Txml();
            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
            string jsondata = "{\"DateTime\": \"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\",\"KEY\": \"" + key.Key() + "\",\"DB\": \"bwshopsy_01\",\"Parm\": \""+ Base64Helper.Base64Encode(NAME)+"\",\"JsonData\": true}";
            string url = "http://192.168.4.106:5555/bwshop/GetVipInfo"; 
            string res = HttpResponse.GetResponseData(jsondata, url);
            return res;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            NAME = textBox2.Text.Trim();
            textBox1.Text = GenerateTodo05();



        }
        /// <summary>
        /// 14.	会员积分
        /// </summary>
        /// <returns></returns>
        public  string GenerateTodo05()
        {

            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
            string jsondata = "{\"DateTime\": \"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\",\"KEY\": \"" + Key2() + "\",	\"DB\": \"bwshopsy_01\",\"Parm\": \"" + Base64Helper.Base64Encode(NAME)+"\"}";

            string url = "http://192.168.4.106:5555/bwshop/GetVipIntegral";
            string res = HttpResponse.GetResponseData(jsondata, url);
            
            return res;

            //MD5Encrypt
        }

        public  string GenerateTodo005()
        {
           // Txml xml1 = new Txml();
            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
            string jsondata = "{\"DateTime\": \"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\",\"KEY\": \"" + Key2() + "\",	\"DB\": \"bwshopsy_01\",\"Parm\": \"" + Base64Helper.Base64Encode(NAME) + "\"}";

            string url = "http://192.168.4.106:5555/bwshop/GetVipIntegral";
            string res = HttpResponse.GetResponseData(jsondata, url);
            return Tjson(res);

            //MD5Encrypt
        }

        public  String Key2()
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
            NAME = textBox2.Text.Trim();
            textBox1.Text = GenerateTodo06();
        }
        /// <summary>
        /// 15.	会员余额
        /// </summary>
        /// <returns></returns>
        public  string GenerateTodo06()
        {
            Txml key = new Txml();
            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
            string jsondata = "{\"DateTime\": \"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\",\"KEY\": \"" + key.Key() + "\",\"DB\": \"bwshopsy_01\",\"Parm\": \"" + Base64Helper.Base64Encode(NAME)+"\"}";

            string url = "http://192.168.4.106:5555/bwshop/GetVipSpareCash"; 
            string res = PostUrl( url, jsondata);
            return Tjson(res);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = Key1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Txml key = new Txml();
            textBox1.Text = "{\"DateTime\": \"" + date + "\",\"KEY\": \"" + key.Key() + "\",	\"DB\": \"bwshopsy_01\",\"Parm\": \"MDAwMDI=\"}";
        }


        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = GenerateTodo07();
        }
        public  string GenerateTodo07()
        {

            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
           string jsondata = "{\"DateTime\": \"" + DateTime.Now.ToString("yyyyMMddHHmmss") + "\",\"KEY\": \"" + Key1() + "\",\"DB\": \"bwshopsy_01\",\"Parm\": \"测试连接\"}";

            string url = "http://127.0.0.1:5555/bwshop/test";
            string res = Httpost( url, jsondata);
            return res;

            

        }

        public  String Key1()
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

        public  string PostUrl(string url, string postData)
        {
            string result = "";
            Encoding encoding = Encoding.Default;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Method = "POST";

            req.Timeout = 80000;//设置请求超时时间，单位为毫秒

            req.ContentType = "application/json";
   /*         req.Method = "post";
        //    req.Accept = "text/html, application/xhtml+xml, 
         //   req.ContentType = "application/x-www-form-urlencoded";*/
           // byte[] buffer = encoding.GetBytes(strPostdata);
          //  req.ContentLength = buffer.Length;

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


        public  string Httpost(string url, string postDataStr)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex rg = new Regex("^[0000000000-9999999999]+$");  //正则表达式
            if (!rg.IsMatch(e.KeyChar.ToString()) && e.KeyChar != '\b') //'\b'是退格键
            {

                e.Handled = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txt_url.Text = "http://192.168.4.106:5921/wshopCtxOrderLockDel"; 
            this.txt_data.Text = "{ \"strsing\": \"MDAwMDAwLGdoXzg4NDhlNjllY3R4MSx6YndjdHgsMywxLDAwMDAyLDAwMDMzLG8yOFZ0dDdMRHlyMXdkS1Jqelc0OC1pYy0tcGs=\", \"deskno\": \"0001\"}";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            textBox6.Text=Base64Helper.Base64Encode(textBox2.Text);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox2.Text= Base64Helper.Base64Decode(textBox6.Text);
        }


        private string ConvertJsonString(string str)
        {
            //格式化json字符串
            JsonSerializer serializer = new JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }

        public string Tjson(string str)
        {

            //反序列化JSON字符串
            //JArray ja = (JArray)JsonConvert.DeserializeObject(str);
            var obj = JsonConvert.DeserializeObject(str);
            JArray json = new JArray();
            if (obj is JArray)
            {
                json = JsonConvert.DeserializeObject<JArray>(str);
            }
            else
            {
                json = JsonConvert.DeserializeObject<JArray>("[" + str + "]");
            }
            //  return json;

            //将反序列化的JSON字符串转换成对象
            JObject o = (JObject)json[0];

            //读取对象中的各项值
          //  Console.WriteLine(o["a"]);
          //  Console.WriteLine(json[1]["a"]);

            /*  JObject json = JObject.Parse(str);
              //得到json对应的propertyies，实际是一个<key,value>
              // 对象组成的数组，可以遍历和获得value的值
              IEnumerable<JProperty> properties = json.Properties();
              JObject node=null;
              // 遍历Jproperty对象
              foreach (JProperty item in properties)
              {
                  //得到value并转化为object对象，得到子json
                  node = JObject.Parse(item.Value.ToString());

              }
              JToken children = node["data"];
              foreach (JProperty child in children)
              {
                  // 即可得到字符串"b9185a050d0540fea32cdd6fdf5e0d7d"等
                  string name = (string)child;
              }
              */

            return o["data"].ToString();
        }

        public string Tjson2(string str)
        {

            //反序列化JSON字符串
            //JArray ja = (JArray)JsonConvert.DeserializeObject(str);
            var obj = JsonConvert.DeserializeObject(str);
            JArray json = new JArray();
            if (obj is JArray)
            {
                json = JsonConvert.DeserializeObject<JArray>(str);
            }
            else
            {
                json = JsonConvert.DeserializeObject<JArray>("[" + str + "]");
            }
            //  return json;

            //将反序列化的JSON字符串转换成对象
            JObject o = (JObject)json[0];

            //读取对象中的各项值
            //  Console.WriteLine(o["a"]);
            //  Console.WriteLine(json[1]["a"]);

            /*  JObject json = JObject.Parse(str);
              //得到json对应的propertyies，实际是一个<key,value>
              // 对象组成的数组，可以遍历和获得value的值
              IEnumerable<JProperty> properties = json.Properties();
              JObject node=null;
              // 遍历Jproperty对象
              foreach (JProperty item in properties)
              {
                  //得到value并转化为object对象，得到子json
                  node = JObject.Parse(item.Value.ToString());

              }
              JToken children = node["data"];
              foreach (JProperty child in children)
              {
                  // 即可得到字符串"b9185a050d0540fea32cdd6fdf5e0d7d"等
                  string name = (string)child;
              }
              */

            return o["Table"].ToString();
        }

        public string Tjson3(string str,string sx)
        {

            //反序列化JSON字符串
            //JArray ja = (JArray)JsonConvert.DeserializeObject(str);
            var obj = JsonConvert.DeserializeObject(str);
            JArray json = new JArray();
            if (obj is JArray)
            {
                json = JsonConvert.DeserializeObject<JArray>(str);
            }
            else
            {
                json = JsonConvert.DeserializeObject<JArray>("[" + str + "]");
            }
            //  return json;

            //将反序列化的JSON字符串转换成对象
            JObject o = (JObject)json[0];

            //读取对象中的各项值
            //  Console.WriteLine(o["a"]);
            //  Console.WriteLine(json[1]["a"]);

            /*  JObject json = JObject.Parse(str);
              //得到json对应的propertyies，实际是一个<key,value>
              // 对象组成的数组，可以遍历和获得value的值
              IEnumerable<JProperty> properties = json.Properties();
              JObject node=null;
              // 遍历Jproperty对象
              foreach (JProperty item in properties)
              {
                  //得到value并转化为object对象，得到子json
                  node = JObject.Parse(item.Value.ToString());

              }
              JToken children = node["data"];
              foreach (JProperty child in children)
              {
                  // 即可得到字符串"b9185a050d0540fea32cdd6fdf5e0d7d"等
                  string name = (string)child;
              }
              */

            return o[sx].ToString();
        }

      

        private void button8_Click(object sender, EventArgs e)
        {
            NAME = textBox2.Text.Trim();
            textBox1.Text = GenerateTodo005();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NAME = textBox2.Text.Trim();
            textBox1.Text = GenerateTodo006();
        }

        public string GenerateTodo006()
        {
            Txml key = new Txml();
            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
            string jsondata = "{ \"strsing\":\"MDAwMDAwLGdoXzRhNDRjZDJmOGEzMix6Ync4ODQ4LDMsMywwMDAwMiwwMDAyMCxvMjhWdHQ3TER5cjF3ZEtSanpXNDgtaWMtLXBr\",\"pub_orgid\":\"13100000012\",\"wx_openid\":\"o28Vtt7LDyr1wdKRjzW48-ic--pk\" }";
           // ub_orgid\":\"18122226669\",\"wx_openid\":\"o28Vtt7LDyr1wdKRjzW48-ic--pk\",
            string url = "http://192.168.4.106:5924/dwtGetVipCenterInfo";// dwtGetVipCenterInfo/dwtGetVipCenterInfo
            string res = PostUrl(url, jsondata);
            return res;


        }

        private void button10_Click(object sender, EventArgs e)
        {
            NAME = textBox2.Text.Trim();
            var obj = JsonConvert.DeserializeObject(GenerateTodo007());
            textBox1.Text = Tjson2(obj.ToString());
            
        }

            public string GenerateTodo007()
            {
                Txml key = new Txml();
                //-------------------
                //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
                string jsondata = "{ \"strsing\":\"MDAwMDAwLGdoXzRhNDRjZDJmOGEzMix6Ync4ODQ4LDMsMywwMDAwMiwwMDAyMCxvMjhWdHQ3TER5cjF3ZEtSanpXNDgtaWMtLXBr\" }";

                string url = "http://192.168.4.106:5924/dwtPeopleInfo";
                string res = PostUrl(url, jsondata);
                return res;


            }

        private void button11_Click(object sender, EventArgs e)
        {
            NAME = textBox2.Text.Trim();
            var obj = JsonConvert.DeserializeObject(GenerateTodo007());
            textBox1.Text = Tjson3(obj.ToString(), textBox7.Text);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {


            string url = this.txt_url.Text;
            string data = this.txt_data.Text;
            string res = PostUrl(url, data);
            this.textBox1.Text = ConvertJsonString(res);
         
        }

        public string GenerateTodo008()
        {
            Txml key = new Txml();
            //-------------------
            //JObject jo = (JObject)JsonConvert.DeserializeObject(token);
            string jsondata = txt_data.Text;// "{ \"strsing\":\"MDAwMDAwLGdoXzg4NDhlNjllY3R4MSx6YndjdHgsMywxLDAwMDAyLDAwMDMzLG8yOFZ0dDdMRHlyMXdkS1Jqelc0OC1pYy0tcGs=\" }";

            string url = txt_url.Text;// "http://192.168.4.106:5921/wshopCtxOrderLockDel";
            string res = PostUrl(url, jsondata);
            return res;


        }

        private void button13_Click(object sender, EventArgs e)
        {
            //this.textBox1.Text = ConvertJsonString(res);

           // textBox8.Text = System.Text.RegularExpressions.Regex.Unescape(textBox8.Text); // ConvertJsonString(textBox8.Text);
          //  textBox8.Text = ConvertJsonString(textBox8.Text);
            textBox8.Text = textBox8.Text.TrimStart('\"').TrimEnd('\"');//{ \"TableInfo\":[{ \"errcode\":\"00\",\"errmsg\":\"订单结账锁定成功！\"} ]}
            textBox8.Text = System.Text.RegularExpressions.Regex.Unescape(textBox8.Text);
            textBox8.Text = ConvertJsonString(textBox8.Text);
            textBox8.Text = Tjson4(textBox8.Text, "errcode");
            //  string json = ConvertJsonString(textBox8.Text);
            //textBox8.Text = StringEscapeUtils.unescapeJavaScript(textBox8.Text);
        }

        public string Tjson4(string str, string sx)
        {

            //反序列化JSON字符串
            //JArray ja = (JArray)JsonConvert.DeserializeObject(str);
            var obj = JsonConvert.DeserializeObject(str);
            JArray json = new JArray();
            if (obj is JArray)
            {
                json = JsonConvert.DeserializeObject<JArray>(str);
            }
            else
            {
                json = JsonConvert.DeserializeObject<JArray>("[" + str + "]");
            }


            //将反序列化的JSON字符串转换成对象
            JObject o = (JObject)json[0];
            var obj2 = JsonConvert.DeserializeObject(o["TableInfo"].ToString());
            JArray json2 = new JArray();
            if (obj2 is JArray)
            {
                json = JsonConvert.DeserializeObject<JArray>(o["TableInfo"].ToString());
            }
            else
            {
                json = JsonConvert.DeserializeObject<JArray>("[" + o["TableInfo"].ToString() + "]");
            }
            JObject o2 = (JObject)json[0];
            return o2[sx].ToString();

        }
        /*       public static string Txml2
        (string str)
{
 JToken children = node["data"];
 foreach (JProperty child in children)
 {
     // 即可得到字符串"b9185a050d0540fea32cdd6fdf5e0d7d"等
     string name = (string)child;
 }

 return name;
}*/
    }
}
