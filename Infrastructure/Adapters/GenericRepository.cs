using System.Linq.Expressions;
using Domain.Entities.Base;
using Domain.Exceptions;
using Domain.Ports;
using Infrastructure.Context;
using MongoDB.Driver;

namespace Infrastructure.Adapters;

public class GenericRepository<E> : IGenericRepository<E> where E : EntityBase<string>
{
    private readonly IMongoCollection<E> _collection;
    

    public GenericRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<E>(typeof(E).Name);
    }

    public async Task<IEnumerable<E>> GetAll()
    {
        return await _collection.Find(e => e.DeletionDate == null).ToListAsync();
    }

    public async Task<IEnumerable<E>> FindAsync(Expression<Func<E, bool>> filter)
    {
        var combinedFilter = Builders<E>.Filter.And(
            filter,
            Builders<E>.Filter.Eq(e => e.DeletionDate, null)
        );
           var u =await _collection.Find(combinedFilter).ToListAsync();
           return u;
    }

    public async Task<E> GetById(string id)
    {
        var filter = Builders<E>.Filter.And(
            Builders<E>.Filter.Eq(e => e.Id, id),
            Builders<E>.Filter.Eq(e => e.DeletionDate, null)
        );
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task Add(E entity)
    {
        entity.SetCreationDate();
        await _collection.InsertOneAsync(entity);
    }

    public async Task Update(E entity)
    {
        var filter = Builders<E>.Filter.Eq(e => e.Id, entity.Id);

        entity.SetModificationDate();
        await _collection.ReplaceOneAsync(filter, entity);
    }

    public async Task Delete(string id)
    {
        var filter = Builders<E>.Filter.And(
            Builders<E>.Filter.Eq(e => e.Id, id)
        );
       
        await _collection.DeleteOneAsync(filter);
    }

    public async Task<bool> Exist(string id)
    {
        var filter = Builders<E>.Filter.Eq("_id", id);
        var result = await _collection.Find(filter).FirstOrDefaultAsync();
        return result != null;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}