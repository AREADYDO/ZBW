using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonTest
{
   public class Txml
    {


        public String Key()
        {

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


        public string Txml1  (string str)
        {

            JObject json = JObject.Parse(str);
            //得到json对应的propertyies，实际是一个<key,value>
            // 对象组成的数组，可以遍历和获得value的值
            IEnumerable<JProperty> properties = json.Properties();
            string name = "";
            // 遍历Jproperty对象

            foreach (JProperty item in properties)
            {
                //得到value并转化为object对象，得到子json
                JObject node = JObject.Parse(item.Value.ToString());
                name = node.ToString();
            }
            /*    JToken children = node["datalist"];
               
                foreach (JProperty child in children)
                {
                    // 即可得到字符串"b9185a050d0540fea32cdd6fdf5e0d7d"等
                    name = (string)child;
                }

            }*/


            return name;

        }
    }
}
