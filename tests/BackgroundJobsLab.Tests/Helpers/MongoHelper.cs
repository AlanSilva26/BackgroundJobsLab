using BackgroundJobsLab.Api.Persistence.Mongo;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Search;

namespace BackgroundJobsLab.Tests.Helpers;

public static class MongoHelper
{
    public static MongoCollections CreateFake()
    {
        return new FakeMongoCollections();
    }

    private class FakeMongoCollections : MongoCollections
    {
        public FakeMongoCollections() : base(GetFakeOptions())
        {
            IngestionLogs = new FakeIngestionLogCollection();
        }

        public override IMongoCollection<IngestionLog> IngestionLogs { get; }

        /// <summary>
        /// Implementação completa de IMongoCollection, usada apenas para testes.
        /// Apenas InsertOneAsync é funcional (noop); o restante lança NotSupportedException.
        /// </summary>
        private class FakeIngestionLogCollection : IMongoCollection<IngestionLog>
        {
            public CollectionNamespace CollectionNamespace
                => throw new NotImplementedException();

            public IMongoDatabase Database
                => throw new NotImplementedException();

            public IBsonSerializer<IngestionLog> DocumentSerializer
                => throw new NotImplementedException();

            public IMongoIndexManager<IngestionLog> Indexes
                => throw new NotImplementedException();

            public IMongoSearchIndexManager SearchIndexes
                => throw new NotImplementedException();

            public MongoCollectionSettings Settings
                => throw new NotImplementedException();

            public IAsyncCursor<TResult> Aggregate<TResult>(PipelineDefinition<IngestionLog, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IAsyncCursor<TResult> Aggregate<TResult>(IClientSessionHandle session, PipelineDefinition<IngestionLog, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<IAsyncCursor<TResult>> AggregateAsync<TResult>(PipelineDefinition<IngestionLog, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<IAsyncCursor<TResult>> AggregateAsync<TResult>(IClientSessionHandle session, PipelineDefinition<IngestionLog, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public void AggregateToCollection<TResult>(PipelineDefinition<IngestionLog, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public void AggregateToCollection<TResult>(IClientSessionHandle session, PipelineDefinition<IngestionLog, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task AggregateToCollectionAsync<TResult>(PipelineDefinition<IngestionLog, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task AggregateToCollectionAsync<TResult>(IClientSessionHandle session, PipelineDefinition<IngestionLog, TResult> pipeline, AggregateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public BulkWriteResult<IngestionLog> BulkWrite(IEnumerable<WriteModel<IngestionLog>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public BulkWriteResult<IngestionLog> BulkWrite(IClientSessionHandle session, IEnumerable<WriteModel<IngestionLog>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<BulkWriteResult<IngestionLog>> BulkWriteAsync(IEnumerable<WriteModel<IngestionLog>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<BulkWriteResult<IngestionLog>> BulkWriteAsync(IClientSessionHandle session, IEnumerable<WriteModel<IngestionLog>> requests, BulkWriteOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public long Count(FilterDefinition<IngestionLog> filter, CountOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public long Count(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, CountOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<long> CountAsync(FilterDefinition<IngestionLog> filter, CountOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<long> CountAsync(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, CountOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public long CountDocuments(FilterDefinition<IngestionLog> filter, CountOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public long CountDocuments(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, CountOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<long> CountDocumentsAsync(FilterDefinition<IngestionLog> filter, CountOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<long> CountDocumentsAsync(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, CountOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public DeleteResult DeleteMany(FilterDefinition<IngestionLog> filter, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public DeleteResult DeleteMany(FilterDefinition<IngestionLog> filter, DeleteOptions options, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public DeleteResult DeleteMany(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, DeleteOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<DeleteResult> DeleteManyAsync(FilterDefinition<IngestionLog> filter, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<DeleteResult> DeleteManyAsync(FilterDefinition<IngestionLog> filter, DeleteOptions options, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<DeleteResult> DeleteManyAsync(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, DeleteOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public DeleteResult DeleteOne(FilterDefinition<IngestionLog> filter, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public DeleteResult DeleteOne(FilterDefinition<IngestionLog> filter, DeleteOptions options, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public DeleteResult DeleteOne(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, DeleteOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<DeleteResult> DeleteOneAsync(FilterDefinition<IngestionLog> filter, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<DeleteResult> DeleteOneAsync(FilterDefinition<IngestionLog> filter, DeleteOptions options, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<DeleteResult> DeleteOneAsync(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, DeleteOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IAsyncCursor<TField> Distinct<TField>(FieldDefinition<IngestionLog, TField> field, FilterDefinition<IngestionLog> filter, DistinctOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IAsyncCursor<TField> Distinct<TField>(IClientSessionHandle session, FieldDefinition<IngestionLog, TField> field, FilterDefinition<IngestionLog> filter, DistinctOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<IAsyncCursor<TField>> DistinctAsync<TField>(FieldDefinition<IngestionLog, TField> field, FilterDefinition<IngestionLog> filter, DistinctOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<IAsyncCursor<TField>> DistinctAsync<TField>(IClientSessionHandle session, FieldDefinition<IngestionLog, TField> field, FilterDefinition<IngestionLog> filter, DistinctOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IAsyncCursor<TItem> DistinctMany<TItem>(FieldDefinition<IngestionLog, IEnumerable<TItem>> field, FilterDefinition<IngestionLog> filter, DistinctOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IAsyncCursor<TItem> DistinctMany<TItem>(IClientSessionHandle session, FieldDefinition<IngestionLog, IEnumerable<TItem>> field, FilterDefinition<IngestionLog> filter, DistinctOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<IAsyncCursor<TItem>> DistinctManyAsync<TItem>(FieldDefinition<IngestionLog, IEnumerable<TItem>> field, FilterDefinition<IngestionLog> filter, DistinctOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<IAsyncCursor<TItem>> DistinctManyAsync<TItem>(IClientSessionHandle session, FieldDefinition<IngestionLog, IEnumerable<TItem>> field, FilterDefinition<IngestionLog> filter, DistinctOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public long EstimatedDocumentCount(EstimatedDocumentCountOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<long> EstimatedDocumentCountAsync(EstimatedDocumentCountOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<IAsyncCursor<TProjection>> FindAsync<TProjection>(FilterDefinition<IngestionLog> filter, FindOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<IAsyncCursor<TProjection>> FindAsync<TProjection>(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, FindOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public TProjection FindOneAndDelete<TProjection>(FilterDefinition<IngestionLog> filter, FindOneAndDeleteOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public TProjection FindOneAndDelete<TProjection>(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, FindOneAndDeleteOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<TProjection> FindOneAndDeleteAsync<TProjection>(FilterDefinition<IngestionLog> filter, FindOneAndDeleteOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<TProjection> FindOneAndDeleteAsync<TProjection>(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, FindOneAndDeleteOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public TProjection FindOneAndReplace<TProjection>(FilterDefinition<IngestionLog> filter, IngestionLog replacement, FindOneAndReplaceOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public TProjection FindOneAndReplace<TProjection>(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, IngestionLog replacement, FindOneAndReplaceOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<TProjection> FindOneAndReplaceAsync<TProjection>(FilterDefinition<IngestionLog> filter, IngestionLog replacement, FindOneAndReplaceOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<TProjection> FindOneAndReplaceAsync<TProjection>(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, IngestionLog replacement, FindOneAndReplaceOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public TProjection FindOneAndUpdate<TProjection>(FilterDefinition<IngestionLog> filter, UpdateDefinition<IngestionLog> update, FindOneAndUpdateOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public TProjection FindOneAndUpdate<TProjection>(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, UpdateDefinition<IngestionLog> update, FindOneAndUpdateOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<TProjection> FindOneAndUpdateAsync<TProjection>(FilterDefinition<IngestionLog> filter, UpdateDefinition<IngestionLog> update, FindOneAndUpdateOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<TProjection> FindOneAndUpdateAsync<TProjection>(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, UpdateDefinition<IngestionLog> update, FindOneAndUpdateOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IAsyncCursor<TProjection> FindSync<TProjection>(FilterDefinition<IngestionLog> filter, FindOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IAsyncCursor<TProjection> FindSync<TProjection>(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, FindOptions<IngestionLog, TProjection> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public void InsertMany(IEnumerable<IngestionLog> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public void InsertMany(IClientSessionHandle session, IEnumerable<IngestionLog> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task InsertManyAsync(IEnumerable<IngestionLog> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task InsertManyAsync(IClientSessionHandle session, IEnumerable<IngestionLog> documents, InsertManyOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public void InsertOne(IngestionLog document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public void InsertOne(IClientSessionHandle session, IngestionLog document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task InsertOneAsync(IngestionLog document, InsertOneOptions? options = null, CancellationToken cancellationToken = default)
                => Task.CompletedTask;

            public Task InsertOneAsync(IngestionLog document, CancellationToken _cancellationToken)
                => throw new NotImplementedException();

            public Task InsertOneAsync(IClientSessionHandle session, IngestionLog document, InsertOneOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IAsyncCursor<TResult> MapReduce<TResult>(BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<IngestionLog, TResult> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IAsyncCursor<TResult> MapReduce<TResult>(IClientSessionHandle session, BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<IngestionLog, TResult> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<IAsyncCursor<TResult>> MapReduceAsync<TResult>(BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<IngestionLog, TResult> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<IAsyncCursor<TResult>> MapReduceAsync<TResult>(IClientSessionHandle session, BsonJavaScript map, BsonJavaScript reduce, MapReduceOptions<IngestionLog, TResult> options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IFilteredMongoCollection<TDerivedDocument> OfType<TDerivedDocument>() where TDerivedDocument : IngestionLog
                => throw new NotImplementedException();

            public ReplaceOneResult ReplaceOne(FilterDefinition<IngestionLog> filter, IngestionLog replacement, ReplaceOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public ReplaceOneResult ReplaceOne(FilterDefinition<IngestionLog> filter, IngestionLog replacement, UpdateOptions options, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public ReplaceOneResult ReplaceOne(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, IngestionLog replacement, ReplaceOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public ReplaceOneResult ReplaceOne(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, IngestionLog replacement, UpdateOptions options, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<ReplaceOneResult> ReplaceOneAsync(FilterDefinition<IngestionLog> filter, IngestionLog replacement, ReplaceOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<ReplaceOneResult> ReplaceOneAsync(FilterDefinition<IngestionLog> filter, IngestionLog replacement, UpdateOptions options, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<ReplaceOneResult> ReplaceOneAsync(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, IngestionLog replacement, ReplaceOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<ReplaceOneResult> ReplaceOneAsync(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, IngestionLog replacement, UpdateOptions options, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public UpdateResult UpdateMany(FilterDefinition<IngestionLog> filter, UpdateDefinition<IngestionLog> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public UpdateResult UpdateMany(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, UpdateDefinition<IngestionLog> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<UpdateResult> UpdateManyAsync(FilterDefinition<IngestionLog> filter, UpdateDefinition<IngestionLog> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<UpdateResult> UpdateManyAsync(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, UpdateDefinition<IngestionLog> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public UpdateResult UpdateOne(FilterDefinition<IngestionLog> filter, UpdateDefinition<IngestionLog> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public UpdateResult UpdateOne(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, UpdateDefinition<IngestionLog> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<UpdateResult> UpdateOneAsync(FilterDefinition<IngestionLog> filter, UpdateDefinition<IngestionLog> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<UpdateResult> UpdateOneAsync(IClientSessionHandle session, FilterDefinition<IngestionLog> filter, UpdateDefinition<IngestionLog> update, UpdateOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IChangeStreamCursor<TResult> Watch<TResult>(PipelineDefinition<ChangeStreamDocument<IngestionLog>, TResult> pipeline, ChangeStreamOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IChangeStreamCursor<TResult> Watch<TResult>(IClientSessionHandle session, PipelineDefinition<ChangeStreamDocument<IngestionLog>, TResult> pipeline, ChangeStreamOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<IChangeStreamCursor<TResult>> WatchAsync<TResult>(PipelineDefinition<ChangeStreamDocument<IngestionLog>, TResult> pipeline, ChangeStreamOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public Task<IChangeStreamCursor<TResult>> WatchAsync<TResult>(IClientSessionHandle session, PipelineDefinition<ChangeStreamDocument<IngestionLog>, TResult> pipeline, ChangeStreamOptions options = null, CancellationToken cancellationToken = default)
                => throw new NotImplementedException();

            public IMongoCollection<IngestionLog> WithReadConcern(ReadConcern readConcern)
                => throw new NotImplementedException();

            public IMongoCollection<IngestionLog> WithReadPreference(ReadPreference readPreference)
                => throw new NotImplementedException();

            public IMongoCollection<IngestionLog> WithWriteConcern(WriteConcern writeConcern)
                => throw new NotImplementedException();
        }

        private static IOptions<MongoSettings> GetFakeOptions()
        {
            var fake = new MongoSettings
            {
                ConnectionString = "mongodb://fakehost:27017",
                Database = "fake-db"
            };
            return Options.Create(fake);
        }
    }
}