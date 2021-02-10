using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
namespace second_attempt.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private readonly View_Model.ViewModel viewModel;
        public MainView()
        {
            InitializeComponent();
            viewModel = new View_Model.ViewModel();
            DataContext = viewModel;
            randomName.ItemsSource = viewModel.usersList;
        }

        private void Button_AddOrEditUser(object sender, RoutedEventArgs e)
        {
            viewModel.AddOrEditUser(NewUserButton);
        }

        private void Button_DeleteUsers(object sender, RoutedEventArgs e)
        {
            viewModel.DeleteUsers(randomName.SelectedItems.Cast<Model.User>().ToList());
        }

        private void Button_EditUser(object sender, RoutedEventArgs e)
        {
            viewModel.SetEditedUser(randomName.SelectedItems.Cast<Model.User>().ToList(), NewUserButton);
        }

    }
}
