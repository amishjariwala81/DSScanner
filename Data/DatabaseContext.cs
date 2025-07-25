﻿using DSScanner.Shared;
using SQLite;
using Syncfusion.Blazor.RichTextEditor.Internal;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using Syncfusion.Blazor.RichTextEditor;

namespace DSScanner.Data
{
    public class DatabaseContext : IAsyncDisposable
    {
        private const string DbName = "DSScanner.db3";
        private static string DbPath => Path.Combine(FileSystem.AppDataDirectory, DbName);

        private SQLiteAsyncConnection _connection;
        private SQLiteAsyncConnection Database =>
            (_connection ??= new SQLiteAsyncConnection(DbPath,
                SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache));

        private async Task CreateTableIfNotExists<TTable>() where TTable : class, new()
        {
            await Database.CreateTableAsync<TTable>();  
        }

        public async Task setProgramSyncronous(bool enable)
        {
            var pragmaValue = enable ? "FULL" : "OFF";
            await Database.ExecuteAsync($"PRAGMA synchronous = {pragmaValue}");
        }
        
        private async Task<AsyncTableQuery<TTable>> GetTableAsync<TTable>() where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return Database.Table<TTable>();
        }

        public async Task<IEnumerable<TTable>> GetAllAsync<TTable>() where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.ToListAsync();
        }

        public async Task<IEnumerable<TTable>> GetFileteredAsync<TTable>(Expression<Func<TTable, bool>> predicate) where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.Where(predicate).ToListAsync();
        }

        private async Task<TResult> Execute<TTable, TResult>(Func<Task<TResult>> action) where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return await action();
        }

        public async Task<TTable> GetItemByKeyAsync<TTable>(object primaryKey) where TTable : class, new()
        {            
            return await Execute<TTable, TTable>(async () => await Database.GetAsync<TTable>(primaryKey));
        }

        public async Task<bool> AddItemAsync<TTable>(TTable item) where TTable : class, new()
        {
            await Database.ExecuteAsync("PRAGMA syncronous = OFF");
            return await Execute<TTable, bool>(async () => await Database.InsertAsync(item) > 0);            
        }
        
        public async Task<bool> UpdateItemAsync<TTable>(TTable item) where TTable : class, new()
        {
            return await Execute<TTable, bool>(async () => await Database.UpdateAsync(item) > 0);
        }

        public async Task<bool> DeleteItemAsync<TTable>(TTable item) where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return await Database.DeleteAsync(item) > 0;
        }
        
        public async Task<bool> DeleteItemByKeyAsync<TTable>(object primaryKey) where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return await Database.DeleteAsync<TTable>(primaryKey) > 0;
        }

        public async Task<bool> DeleteAlllItemsAsync<TTable>() where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return await Database.DeleteAllAsync<TTable>() > 0;
        }       

        public async ValueTask DisposeAsync() => await _connection?.CloseAsync();
    }
}
