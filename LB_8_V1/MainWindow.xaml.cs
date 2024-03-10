using LB_8_V1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
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

namespace LB_8_V1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EntityContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = new EntityContext();
            context.Students.Load();
            dGrid.ItemsSource = context.Students.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            EditWindow editWindow = new EditWindow(student);
            if(editWindow.ShowDialog() == true)
            {
                context.Students.Add(student);
                context.SaveChanges();
                editWindow.Close();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dGrid.SelectedItems.Count == 0)
                return;
            if (MessageBox.Show("Вы уверены?", "Удалить запись", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;
            for (int i = dGrid.SelectedItems.Count - 1; i>= 0; i--)
            {
                context.Students.Remove(dGrid.SelectedItems[i] as Student);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dGrid.SelectedItems.Count == 0)
                return;
            EditWindow editWindow = new EditWindow(dGrid.SelectedItem as Student);
            if (editWindow.ShowDialog() == true)
                context.SaveChanges();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            context.Dispose();
        }
    }
}
