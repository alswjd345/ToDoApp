using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TO_DO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ToDoItem> ToDolist = new List<ToDoItem>();
        List<string> Searchlist = new List<string>();
        

        public MainWindow()
        {
            InitializeComponent();
        }



        private void add_data(object sender, RoutedEventArgs e)
        {
            string todo = TodoTextBox.Text;

            if (string.IsNullOrEmpty(todo))
            {
                MessageBox.Show("내용을 입력해주세요");
                return;
            }
            else
            {
                ToDoItem item = new ToDoItem { Title = todo };
                ToDolist.Add(item);
                TodoListBox.Items.Add(item);
                TodoTextBox.Text = "";
                UpdateCount();
            }
    

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            bool hasChecked = false;
            var removelist = new List<ToDoItem>();

            foreach (ToDoItem items in ToDolist)
            {
                if (items.Ischecked == true)
                {

                    hasChecked = true;
                    removelist.Add(items);
                    
                }
            }
            foreach(ToDoItem item in removelist)
            {
                ToDolist.Remove(item);
            }
            AllSearchButton_Click(null,null);
            UpdateCount();
            if (!hasChecked)
            {
                MessageBox.Show("삭제할 항목이 없습니다");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string SearchData = TodoTextBox.Text;


            if (string.IsNullOrEmpty(SearchData))
            {
                MessageBox.Show("검색어를 입력해주세요");
                return;
            }
            List<ToDoItem> searchList = new List<ToDoItem>();

            foreach (ToDoItem item in ToDolist)
            {
                //serach데이터 포함되는지 확인하고 리스트 넣기
                string text = item.Title.ToString();
                if (text.Contains(SearchData) == true)
                {
                    searchList.Add(item);
                }
            }
            TodoListBox.Items.Clear();
            //search 데이터 화면에 보여줌
            foreach (ToDoItem item in searchList)
            {
                TodoListBox.Items.Add(item);
            }



        }

        private void AllSearchButton_Click(object sender, RoutedEventArgs e)
        {
            TodoTextBox.Text = "";
            TodoListBox.Items.Clear();
            foreach (ToDoItem items in ToDolist)
            {
                TodoListBox.Items.Add(items);
            }
        }


        private void EditOrSave_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ToDoItem item = btn.DataContext as ToDoItem;
            StackPanel panel = btn.Parent as StackPanel;
            TextBox text = panel.Children[1] as TextBox;

            //수정모드
            if (item.editing== false)
            {
                item.editing = true;
                btn.Content = "저장";
                text.IsReadOnly = false;
                
                text.Focus();
                text.CaretIndex = text.Text.Length;

            }
            else
            {
                item.editing = false;
                btn.Content = "수정";
                text.IsReadOnly = true;
                MessageBox.Show("저장되었습니다");
            }
        }
        public void UpdateCount()
        {
            int countNum=ToDolist.Count;
            alllistCount.Text = $"전체 : {countNum} 개";
            int processNum = ToDolist.Count(x=>!x.Ischecked);
            process.Text = $"진행중 : {processNum}개";
            int completeNum = ToDolist.Count(x =>x.Ischecked);
            complete.Text = $"완료 : {completeNum}개";
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateCount();
        }

        private void CheckBoxUnChecked(object sender, RoutedEventArgs e)
        {
            UpdateCount();
        }
    }

}