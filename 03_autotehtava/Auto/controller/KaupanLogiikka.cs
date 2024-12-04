using Autokauppa.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Autokauppa.controller
{


    public class KaupanLogiikka
    {
        DatabaseHallinta dbModel = new DatabaseHallinta();

        public bool TestDatabaseConnection()
        {
            bool doesItWork = dbModel.connectDatabase();
            return doesItWork;
        }

        public bool saveAuto(model.Auto newAuto)
        {
            bool didItGoIntoDatabase = dbModel.saveAutoIntoDatabase(newAuto);
            return didItGoIntoDatabase;
        }

        public List<Merkki> getAllAutoMakers()
        {
            return dbModel.getAllAutoMakersFromDatabase();
        }

        public List<Malli> getAutoModels(int makerId)
        {
            return dbModel.getAutoModelsByMakerId(makerId);
        }

        public bool deleteAuto(model.Auto deleteRecord)
        {
            bool didItGoIntoDatabase = dbModel.DeleteRecordFromDatabase(deleteRecord);
            return didItGoIntoDatabase;
        }

        public List<Auto> GetCarsByBrand(string brand)
        {
            return dbModel.GetCarsByBrandFromDatabase(brand);
        }

        public List<Auto> GetCarsByPrice(decimal price)
        {
            return dbModel.GetCarsByPriceFromDatabase(price);
        }

    }
}
