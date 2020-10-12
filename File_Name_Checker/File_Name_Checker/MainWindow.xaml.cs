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
using System.IO;

namespace File_Name_Checker
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Drag and DropされているものがDataFormats.FileDrop形式になっているかチェック
        /// なっていればマウスカーソルを"Copy"に変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void input_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        /// <summary>
        /// Drag and DropされたFileもしくはFolderのPathを文字列として取得し、TextBoxに表示
        /// 複数選択されている場合は初めの１つのみ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void input_Drop(object sender, DragEventArgs e)
        {
            var dropFiles = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (dropFiles == null) return;
            var textBox = sender as TextBox;
            if(textBox.Name == "inputFolder")
            {
                inputFolder.Text = dropFiles[0];
            }
            else if(textBox.Name == "inputFile")
            {
                inputFile.Text = dropFiles[0];
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// チェックスタート
        /// 結果を別ウィンドウにて表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void check_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var file_names = Directory.GetFiles(inputFolder.Text, "*", SearchOption.TopDirectoryOnly);
                var file_text = "";
                using(var reader = new StreamReader(inputFile.Text))
                {
                    file_text = reader.ReadToEnd();
                }
                var file_array = file_text.Split('\n');
                file_array = file_array.Select(x => x.Trim()).ToArray();
                foreach(var file in file_array)
                {
                    if (!file_names.Contains(file))
                    {

                    }
                }
                foreach(var file_name in file_names)
                {
                    if (!file_array.Contains(file_name))
                    {

                    }
                }
            }
            catch
            {
                var errorDialog = new ErrorWindow();
                errorDialog.error.Text = "指定されたフォルダあるいはファイルのパスが誤っています。";
                errorDialog.ShowDialog();
            }
        }

        /// <summary>
        /// アプリケーションの終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void finish_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
