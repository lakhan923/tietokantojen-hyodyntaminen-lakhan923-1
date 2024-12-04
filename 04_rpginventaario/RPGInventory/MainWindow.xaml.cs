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
using System.Linq;
using RPGInventory.Models;


namespace RPGInventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly InventoryRepository _repository;
        public MainWindow()
        {
            InitializeComponent();
            _repository = new InventoryRepository(new RpgInventoryContext());
        }

        // Load items by rarity
        private void OnLoadItemsByRarity(object sender, RoutedEventArgs e)
        {
            string rarity = rarityComboBox.Text;

            if (string.IsNullOrEmpty(rarity))
            {
                MessageBox.Show("Please select a valid rarity.");
                return;
            }

            var items = _repository.GetItemsByRarity(rarity);

            // Display results in DataGrid
            dataGridItems.ItemsSource = items;
            MessageBox.Show($"Found {items.Count} items for rarity: {rarity}");
        }

        // Load items by type
        private void OnLoadItemsByType(object sender, RoutedEventArgs e)
        {
            string itemType = itemTypeComboBox.Text; 

            if (string.IsNullOrEmpty(itemType))
            {
                MessageBox.Show("Please select a valid item type.");
                return;
            }

            var items = _repository.GetItemsByType(itemType);

            // Display results in DataGrid
            dataGridItems.ItemsSource = items;
            MessageBox.Show($"Found {items.Count} items for type: {itemType}");
        }

        private void OnUpdateItemBaseValue(object sender, RoutedEventArgs e)
        {
            try
            {
                int itemId = Convert.ToInt32(textBoxItemId.Text); // Get the Item ID from the TextBox
                decimal baseValue = decimal.Parse(textBoxBaseValue.Text); // Get the Base Value from the TextBox

                _repository.UpdateItemBaseValue(itemId, baseValue);

                // Refresh the DataGrid
                var updatedItem = _repository.GetItemById(itemId);
                MessageBox.Show($"Updated Item ID {itemId} with new Base Value {baseValue}");

                dataGridItems.ItemsSource = _repository.GetAllItems(); // Reload all items
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating item: {ex.Message}");
            }
        }

        private void OnRemoveItem(object sender, RoutedEventArgs e)
        {
            try
            {
                int itemId = Convert.ToInt32(textBoxItemId.Text); // Get the Item ID from the TextBox

                _repository.DeleteItem(itemId);

                // Refresh the DataGrid
                MessageBox.Show($"Removed Item ID {itemId}");
                dataGridItems.ItemsSource = _repository.GetAllItems(); // Reload all items
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing item: {ex.Message}");
            }
        }

        private void OnGetAverages(object sender, RoutedEventArgs e)
        {
            try
            {
                // Call the repository method to get the averages
                var averages = _repository.GetAverages();
                MessageBox.Show($"Average Base Value: {averages.AverageBaseValue}\n" +
                                   $"Average Attack Value: {averages.AverageAttValue}\n" +
                                   $"Average Defense Value: {averages.AverageDefValue}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating averages: {ex.Message}");
            }
        }

        private void OnGetItemsWithHighAttValue(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal thresholdValue = decimal.Parse(textBoxAttValue.Text); // Get the threshold value from the TextBox
                var items = _repository.GetItemsWithHighAttValue(thresholdValue);

                if (items.Any())
                {
                    dataGridItems.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show("No items found with Attack Value higher than the threshold.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching items: {ex.Message}");
            }
        }
    }
}