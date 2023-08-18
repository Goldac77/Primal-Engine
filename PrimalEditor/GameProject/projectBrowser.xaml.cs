﻿using System;
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

namespace PrimalEditor.GameProject
{
    /// <summary>
    /// Interaction logic for projectBrowser.xaml
    /// </summary>
    public partial class projectBrowser : Window
    {
        public projectBrowser()
        {
            InitializeComponent();
        }

        private void openProjectButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void onToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if(sender == openProjectButton)
            {
                if(createProjectButton.IsChecked == true)
                {
                    createProjectButton.IsChecked = false;
                    browserContent.Margin = new Thickness(0);
                }
                openProjectButton.IsChecked = true;
            } else
            {
                if(openProjectButton.IsChecked == true)
                {
                    openProjectButton.IsChecked= false;
                    browserContent.Margin = new Thickness(-1000, 0, 0, 0);
                }
                createProjectButton.IsChecked = true;
            }
        }

        private void createProjectButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
