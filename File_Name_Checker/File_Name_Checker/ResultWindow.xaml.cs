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
using System.Windows.Shapes;

namespace File_Name_Checker
{
    /// <summary>
    /// ResultWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow()
        {
            InitializeComponent();
        }
        public void DataSet(string[] no_file_list, string[] no_text_list)
        {
            var unmatch = new UnmatchClass();
            unmatch.NoFile = String.Join("\n", no_file_list);
            unmatch.NoText = String.Join("\n", no_text_list);
            DataContext = unmatch;
        }
    }
}
