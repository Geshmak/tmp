using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using YOLOv4MLNet;
using YOLOv4MLNet.DataStructures;


namespace WpfAppDKab
{
    class Comp
    {
        static private List<string> list;
        public Comp()
        {
            list = new List<string>();
        }
        
        public List<string> Olist
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxMagnF"));
            }
        }
        static public ConcurrentQueue<YoloV4Result> queueeue = new ConcurrentQueue<YoloV4Result>();

        public static async Task TaskAsync(string s )
        {
            var cst = new CancellationTokenSource();
            var ct = cst.Token;

            MessageBox.Show(s);
            YoloV4Result result;
            //string s = @"C:\Users\Asus\source\repos\YOLOv4MLNet\YOLOv4MLNet\Assets\Images";
            _ = Task.Factory.StartNew(() =>
            {
                string cancel = Console.ReadLine();
                if (cancel == "c" || cancel == "с")
                    cst.Cancel();
            }, TaskCreationOptions.LongRunning);
            var task1 = Yolo.FunAsync(s, queueeue, ct);


            var task2 = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    while (queueeue.TryDequeue(out result))
                    {
                    // печать
                        var lab = result.Label;
                        var x1 = result.BBox[0];
                        var y1 = result.BBox[1];
                        var x2 = result.BBox[2];
                        var y2 = result.BBox[3];
                        list.Add($"_____{lab},   ({x1}  ,  {y1}) ; ({x2}  ,  {y2}) ");
                        /*lb.Items.Add($"_____{lab},   ({x1}  ,  {y1}) ; ({x2}  ,  {y2}) ");*/
                        //Console.WriteLine($"_____{lab},   ({x1}  ,  {y1}) ; ({x2}  ,  {y2}) ");

                    }
                }

            }, TaskCreationOptions.LongRunning);
            await Task.WhenAll(task1);
        }
        /*public override string ToString()
        {
            return "\n\nV4DataCollection: \nInfo) " + Info.ToString() + "\nFrequency) " + Frequency.ToString() +
                "\nDictsize: " + Dict.Count.ToString() + "\n\n";
        }*/
    }
}
