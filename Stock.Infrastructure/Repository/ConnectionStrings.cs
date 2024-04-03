namespace Stock.Infrastructure.Repository
{
    public class ConnectionStrings
    {
        public ConnectionStrings(string connectionString, string databaseName) 
        {
            this.MongoDb = connectionString;
            this.DatabaseName = databaseName;
        } 
        

        public string MongoDb { get; set; }
        public string DatabaseName { get; set; }
    }
}
