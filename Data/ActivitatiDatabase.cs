using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using ActivitatiVoluntariatMOBILE.Models;

namespace ActivitatiVoluntariatMOBILE.Data
{
    public class ActivitatiDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ActivitatiDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ActivitateVoluntari>().Wait();
            _database.CreateTableAsync<Activitate>().Wait();
            _database.CreateTableAsync<ListActivitati>().Wait();

        }
        public Task<int> SaveActivitateAsync(Activitate activitate) { 
            if (activitate.ID != 0) 
            { 
                return _database.UpdateAsync(activitate); 
            } 
            else 
            { 
                return _database.InsertAsync(activitate); 
            } 
        }
        public Task<int> DeleteActivitateAsync(Activitate activitate) 
        { 
            return _database.DeleteAsync(activitate); 
        }
        public Task<List<Activitate>> GetActivitateAsync()
        { 
            return _database.Table<Activitate>().ToListAsync(); 
        }
        public Task<List<ActivitateVoluntari>> GetActivitateVoluntariAsync()
        {
            return _database.Table<ActivitateVoluntari>().ToListAsync();
        }
        public Task<ActivitateVoluntari> GetActivitateVoluntariAsync(int id)
        {
            return _database.Table<ActivitateVoluntari>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }
        public Task<int> SaveActivitateVoluntariAsync(ActivitateVoluntari slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else { return _database.InsertAsync(slist); }
        }
        public Task<int> DeleteActivitateVoluntariAsync(ActivitateVoluntari slist) 
        { 
            return _database.DeleteAsync(slist); 
        }
        public Task<int> SaveListActivitatiAsync(ListActivitati listp) { if (listp.ID != 0) { return _database.UpdateAsync(listp); } else { return _database.InsertAsync(listp); } }
        public Task<List<Activitate>> GetListActivitatiAsync(int shoplistid)
        {
            return _database.QueryAsync<Activitate>("select P.ID, P.Nume from Activitate P" + " inner join ListActivitati LP" + " on P.ID = LP.ActivitatiID where LP.ActivitateVoluntariID = ?", shoplistid);
        }
        public Task<int> DeleteListActivitatiAsync(ListActivitati listp)
        {
            return _database.DeleteAsync(listp);
        }

        public Task<List<ListActivitati>> GetListActivitati()
        {
            return _database.QueryAsync<ListActivitati>("select * from ListActivitati");
        }
    }
}