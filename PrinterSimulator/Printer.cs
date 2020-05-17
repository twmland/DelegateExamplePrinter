using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PrinterSimulator
{
    public delegate void PrintCompleteCallback(string callBackMessage);
    public class Printer
    {
        /// <summary>建構式</summary>
        public Printer()
        {

        }

        /// <summary> 
        /// </summary>
        /// <param name="callBackFunction">列印完畢後回呼的Function</param>
        /// <param name="callBackMessage">送回呼叫端的訊息</param>
        public void Print(PrintCompleteCallback callBackFunction,string callBackMessage)
        {
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(ToPrint);
            Thread printThread = new Thread(threadStart);
            printThread.Start(new object[]{ callBackFunction,callBackMessage});
        }

        /// <summary>列印</summary>
        /// <param name="obj"></param>
        public void ToPrint(object obj)
        {
            var param= (object[])obj;

            // 模擬列印2秒鐘
            Thread.Sleep(2000);
            
            // 列印完畢回呼
            var printCompleteCallback = (PrintCompleteCallback)param[0];
            var callbackMessage = (string)param[1];
            printCompleteCallback.Invoke(callbackMessage);
        }

    }
}
