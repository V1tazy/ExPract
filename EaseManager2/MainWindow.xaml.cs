using EaseManager2.Models;
using System.Collections.ObjectModel;
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
using YourNamespace;

namespace EaseManager2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseService dbService;
        private ObservableCollection<Partner> partners;

        public MainWindow()
        {
            InitializeComponent();
            dbService = new DatabaseService();
            LoadPartners();
        }

        private void LoadPartners()
        {
            partners = dbService.GetPartners();
            PartnersDataGrid.ItemsSource = partners;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
 
            PartnerWindow partnerWindow = new PartnerWindow();
            if (partnerWindow.ShowDialog() == true)
            {
                Partner newPartner = partnerWindow.Partner;
                dbService.AddPartner(newPartner);
                LoadPartners();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (PartnersDataGrid.SelectedItem is Partner selectedPartner)
            {

                PartnerWindow partnerWindow = new PartnerWindow(selectedPartner);
                if (partnerWindow.ShowDialog() == true)
                {
                    Partner updatedPartner = partnerWindow.Partner;
                    dbService.UpdatePartner(updatedPartner);
                    LoadPartners();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите партнёра для редактирования.", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (PartnersDataGrid.SelectedItem is Partner selectedPartner)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить партнёра '{selectedPartner.Name}'?",
                                             "Удаление",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    dbService.DeletePartner(selectedPartner.Id);
                    LoadPartners();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите партнёра для удаления.", "Удаление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}