using HubCount.Urna.Core.Repositories.Context;
using HubCount.Urna.Core.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace HubCount.Urna.Core.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
    {
        private readonly MySqlContext _context;
        private bool _disposed = false;


        public BaseRepository(MySqlContext context, IConfiguration config)
        {
            _context = context;
            Conexao = new MySqlConnection(config.GetConnectionString("DB_HUBCOUNT"));
            ParamSymbol = config["DataConnection:ParamSymbol"];
        }

        public async Task<TEntity> GetByIdAsync(int? id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }


        #region Config para utilizar o Dapper

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Conexao?.Dispose();
            }

            _disposed = true;
        }

        protected MySqlConnection Conexao { get; private set; }
        protected string ParamSymbol { get; set; }

        #endregion

    }
}