using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;


namespace RPGInventory.Models
{
    public class InventoryRepository
    {
        public readonly RpgInventoryContext _context;
        public InventoryRepository(RpgInventoryContext context)
        {
            _context = context;
        }

        // Get items by rarity
        public List<Item> GetItemsByRarity(string rarity)
        {
            var result = _context.Items
              .Where(i => i.Rarity != null && i.Rarity.RarityName == rarity)
              .Include(i => i.ItemType)  // To include related item type
              .ToList();

            Console.WriteLine($"Generated SQL: {_context.Database.GetDbConnection().ConnectionString}");  // Outputs the connection string
            Console.WriteLine($"Found {result.Count} items for rarity {rarity}");

            return result;
        }

        public Item GetItemById(int id)
        {
            return _context.Items
                .Include(i => i.ItemType)
                .Include(i => i.Rarity)
                .FirstOrDefault(i => i.Id == id);
        }

        // Update item base value
        public void UpdateItemBaseValue(int id, decimal baseValue)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.BaseValue = baseValue;
                _context.SaveChanges();
            }
        }

        // Delete item by Id
        public void DeleteItem(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        // Get items by item type
        public List<Item> GetItemsByType(string typeName)
        {
            var result = _context.Items
               .Where(i => i.ItemType.TypeName == typeName)
               .Include(i => i.Rarity)
               .ToList();

            Console.WriteLine($"Found {result.Count} items for type {typeName}");

            return result;
        }

        // Get averages for BaseValue, AttValue, and DefValue
        public Averages GetAverages()
        {
            return new Averages
            {
                AverageBaseValue = _context.Items.Average(i => i.BaseValue) ?? 0,
                AverageAttValue = _context.Items.Average(i => i.AttValue) ?? 0,
                AverageDefValue = _context.Items.Average(i => i.DefValue) ?? 0
            };
        }

        // Get items with AttValue greater than specified value
        public List<Item> GetItemsWithHighAttValue(decimal value)
        {
            return _context.Items.Where(i => i.AttValue > value).ToList();
        }

        public List<Item> GetAllItems()
        {
            return _context.Items
                .Include(i => i.ItemType)
                .Include(i => i.Rarity)
                .ToList();
        }

        public DataTable SearchItems(string keyword)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            connection.Open();

            using var command = new SqlCommand("SearchItems", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Keyword", keyword);

            using var reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);

            return dataTable;
        }
    }
}
