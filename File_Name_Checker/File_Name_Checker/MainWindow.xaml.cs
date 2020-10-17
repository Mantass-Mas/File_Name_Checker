using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
                var file_paths = Directory.GetFiles(inputFolder.Text, "*", SearchOption.TopDirectoryOnly);
                var file_names = new string[file_paths.Length];
                for(var i = 0; i < file_names.Length; i++)
                {
                    file_names[i] = System.IO.Path.GetFileName(file_paths[i]);
                }
                var file_text = "";
                using(var reader = new StreamReader(inputFile.Text))
                {
                    file_text = reader.ReadToEnd();
                }
                var file_array = file_text.Split('\n');
                file_array = file_array.Select(x => x.Trim()).Where(x => x != "").ToArray();
                var no_file_list = new List<string>();
                foreach(var file in file_array)
                {
                    if (!file_names.Contains(file))
                    {
                        no_file_list.Add(file);
                    }
                }
                var no_text_list = new List<string>();
                foreach(var file_name in file_names)
                {
                    if (!file_array.Contains(file_name))
                    {
                        no_text_list.Add(file_name);
                    }
                }
                var resultWindow = new ResultWindow();
                resultWindow.DataSet(no_file_list.ToArray(), no_text_list.ToArray());
                resultWindow.Show();
            }
            catch
            {
                var errorDialog = new ErrorWindow();
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
