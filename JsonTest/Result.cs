using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonTest
{
    class Result
    {

        /*返回码*/
        private int code;
        /*返回信息提示*/
        private String message;
        /*返回的数据*/
        private Object data;

        public Result() { }

        public Result(int code, String message, Object data)
        {
            this.code = code;
            this.message = message;
            this.data = data;
        }

      
         public String toString()
        {
            return "Result [code=" + code + ", message=" + message + ", data=" + data + "]";
        }

        public int getCode()
        {
            return code;
        }
        public void setCode(int code)
        {
            this.code = code;
        }
        public String getMessage()
        {
            return message;
        }
        public void setMessage(String message)
        {
            this.message = message;
        }
        public Object getData()
        {
            return data;
        }
        public void setData(Object data)
        {
            this.data = data;
        }


    }



    }

