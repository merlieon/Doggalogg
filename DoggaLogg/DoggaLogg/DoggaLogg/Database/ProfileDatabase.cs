using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using DoggaLogg.Model;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;
namespace DoggaLogg.Database
{

    public class ProfileDatabase
    {

        readonly SQLiteAsyncConnection database;

        public ProfileDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ProfileItems>().Wait();
            database.CreateTableAsync<LoggItems>().Wait();
        }
        

        //Profile
        public Task<List<ProfileItems>> GetProfileAsync()
        {
            return database.Table<ProfileItems>().ToListAsync();
        }

        public Task<ProfileItems> GetProfileAsync(int id)
        {
            return database.Table<ProfileItems>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ProfileItems>> GetProfileInclude()
        {
            return await database.Table<ProfileItems>().Include("Loggs").ToListAsync();
        }

        public Task<int> SaveProfileAsync(ProfileItems profileItems)
        {
            if (profileItems.Id != 0)
            {
                return database.UpdateAsync(profileItems);
            }
            else
            {
                return database.InsertAsync(profileItems);
            }
        }

        public  Task<int> DeleteProfileAsync(ProfileItems profileItems)
        {
            return database.DeleteAsync(profileItems);
        }


        //Logg
        public Task<List<LoggItems>> GetLoggAsync()
        {
            return database.Table<LoggItems>().ToListAsync();
        }

        public Task<LoggItems> GetLoggAsync(int id)
        {
           return database.Table<LoggItems>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveLoggAsync(LoggItems loggItems)
        {
            if (loggItems.Id != 0)
            {
                return database.UpdateAsync(loggItems);
                
            }
            else
            {
                return database.InsertAsync(loggItems);
            }
        }

        public Task<int> DeleteLoggAsync(LoggItems loggItems)
        {
            return database.DeleteAsync(loggItems);
        }
    }
}
