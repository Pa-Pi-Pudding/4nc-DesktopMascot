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

namespace DesktopMascot.SubScreens.Newsviewer
{
    /// <summary>
    /// NewsControl.xaml の相互作用ロジック
    /// </summary>
    public partial class NewsControl : UserControl
    {

        NewsViewerForm newsform;
        TableClass tableObject;
        public NewsControl()
        {
            newsform = new NewsViewerForm();
            InitializeComponent();
            tableObject = new TableClass();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine(newsform.ReceiveData);
            tableObject.colomn1 = "hoge";
            tableObject.colomn2 = "hoge";
            tableObject.colomn3 = "hoge";
            DataContext = tableObject;
        }
       
    }

    public class TableClass
    {
        public string colomn1 { get; set; }
        public string colomn2 { get; set; }
        public string colomn3 { get; set; }
        
    }

}
