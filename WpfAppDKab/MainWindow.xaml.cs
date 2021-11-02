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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
      
    public partial class MainWindow : Window
    {
        public static RoutedCommand Custom = new RoutedCommand("PathButton", typeof(MainWindow));
        private Property PC;
        private Comp Comp;
        
        public MainWindow()
        {
            InitializeComponent();
            bool tmpflag = !Validation.GetHasError(TBPath);
            PC = new Property();
            Test.DataContext = PC;
            Comp = new Comp();
            DataContext = Comp;
            
        }
        private void CanCustomCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            bool tmpflag = !Validation.GetHasError(TBPath);
            e.CanExecute = tmpflag;
        }
        
        private void CustomCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            
            Comp.TaskAsync(PC.Path);
            
        }

    }
}

