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
                CheckBox checkbox = new CheckBox();
                checkbox.Content = TodoTextBox.Text;
                TodoListBox.Items.Add(checkbox);
                TodoTextBox.Text = "";
            }
            
           
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            bool hasChecked = false;
            var removelist = new List<CheckBox>();

            foreach (CheckBox items in TodoListBox.Items)
            {
                if (items.IsChecked==true){
                    
                    hasChecked = true;
                    removelist.Add(items);
                }
            }
            foreach (CheckBox items in removelist)
            {
                TodoListBox.Items.Remove(items);
            }
            
            if (!hasChecked)
            {
                MessageBox.Show("삭제할 항목이 없습니다");
            }
        }
    }
}