using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FlyWeight_Pattern_Homework;


interface IDatabase {
    void ExecuteQuery(string query);
}


class SQLDatabase : IDatabase {
    public void ExecuteQuery(string query) {
        MessageBox.Show($"Executing query in SQL database: {query}");
    }
}


// This class for managing sqldatabase in executequery class we can do all checkups and  assigns

class Proxy : IDatabase {
    private SQLDatabase? realDatabase;

    public void ExecuteQuery(string query) {
        if (realDatabase == null) {
            realDatabase = new SQLDatabase();
        }

        realDatabase.ExecuteQuery(query);
    }
}