using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodChain
{
    class GlobalFunction
    {
        /// <summary>  
        /// 获取当前时间戳  
        /// </summary>  
        /// <param name="bflag">为真时获取10位时间戳,为假时获取13位时间戳.</param>  
        /// <returns></returns>  
        public static string GetTimeStamp(bool bflag = true)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string ret = string.Empty;
            if (bflag)
                ret = Convert.ToInt64(ts.TotalSeconds).ToString();
            else
                ret = Convert.ToInt64(ts.TotalMilliseconds).ToString();

            return ret;
        }

        /// <summary>  
        /// 获取当前时间戳  
        /// </summary>  
        /// <param></param>  
        /// <returns></returns>  
        public static string GetTimeString(bool bflag = true)
        {
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            return currentTime.ToShortDateString();
        }

        /// <summary>  
        /// 获取成长随机数
        /// </summary>  
        /// <param></param>  
        /// <returns></returns>  
        public static double GetRandom()
        {
            double result = 0.0;
            Random random = new Random();
            result = random.Next(85, 105) / 100.0;
            return result;
        }
    }
}
