﻿using LB_8_V1.Models;
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

namespace LB_8_V1
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow(Student student)
        {
            InitializeComponent();
        }

        private void dGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void ButtonOK_Clic(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void ButtonCancel_Clic(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
    }
}
