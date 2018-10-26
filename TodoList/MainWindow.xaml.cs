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

using System.Data.Entity;
using System.ComponentModel;

namespace TodoList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TodoModelContainer db = new TodoModelContainer();
        public MainWindow()
        {
            InitializeComponent();
            Populate();
            //todoList.DataContext = new TodoModelContainer();
        }
        private void Populate()
        {
            //using (var db = new TodoModelContainer()) {
            //db.Notes.Add(new Note { Name = "n1", DateAdd = DateTime.Now, Done = false });
            //db.SaveChanges();
            //}
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            //using (var db = new TodoModelContainer())
            {
                db.Notes.Add(new Note { Name = "n1", DateAdd = DateTime.Now, Done = false });
                //db.SaveChanges();
            }

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            //using (var db = new TodoModelContainer())
            //{
            //todoList.Items.Clear();
            //foreach (var n in /*new List<int> { 1, 2, 4, 7 }*/ db.Notes)
            //{
            //    todoList.Items.Add(n);
            //}
            //MessageBox.Show(todoList.Items.IsEmpty ? "empty" : "NOTEMPTY");
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource noteViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("noteViewSource")));
            db.Notes.Load();
            // Загрузите данные, установив свойство CollectionViewSource.Source:
            noteViewSource.Source = db.Notes.Local;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            db.SaveChanges();
            db.Dispose();
        }
    }
}
