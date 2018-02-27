using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Xunit;

namespace ManagingLongRequestBatch
{
    public class UnitTest1
    {
        [Fact]
        public void TestBatchSqlProvider()
        {
            var builder = new DbContextOptionsBuilder<CookBookContext>();
            builder.UseSqlServer("Data Source=.")
                   .MaxBatchSize(10)
                   .CommandTimeout(10);

            using(var context = new CookBookContext(builder.Options))
            {
                var bookAzureSql = new Book() { Name = "Azure Sql", Recipes = new List<Recipe>() };
                var bookAzureRedis = new Book() { Name = "Azure Redis", Recipes = new List<Recipe>() };
                var bookSqlBatch1 = new Book() { Name = "Sql Batch 1", Recipes = new List<Recipe>() };
                var bookSqlBatch2 = new Book() { Name = "Sql Batch 2", Recipes = new List<Recipe>() };
                var bookSqlBatch3 = new Book() { Name = "Sql Batch 3", Recipes = new List<Recipe>() };
                var bookSqlBatch4 = new Book() { Name = "Sql Batch 4", Recipes = new List<Recipe>() };

                context.Book.AddRange(bookAzureSql, bookAzureRedis, bookSqlBatch1, bookSqlBatch2, bookSqlBatch3, bookSqlBatch4);

                context.SaveChanges();
            }
        }

        [Fact]
        public void TestUpdateBatchSqlProvider()
        {
            var builder = new DbContextOptionsBuilder<CookBookContext>();
            builder.UseSqlServer("Data Source=.")
                   .MaxBatchSize(10)
                   .CommandTimeout(10);

            using(var context = new CookBookContext(builder.Options))
            {
                var bookAzureSql = context.Book.Where(e => e.Name == "Azure Sql").FirstOrDefault();
                bookAzureSql.Name = "Azure Sql (Updated)";

                var bookAzureRedis = context.Book.Where(e => e.Name == "Azure Redis").FirstOrDefault();
                bookAzureRedis.Name = "Azure Redis (Updated)";

                context.Update(bookAzureSql);
                context.Update(bookAzureRedis);

                context.SaveChanges();
            }
        }

        [Fact]
        public void TestRemoveBatchSqlProvider()
        {
            var builder = new DbContextOptionsBuilder<CookBookContext>();
            builder.UseSqlServer("Data Source=.")
                   .MaxBatchSize(10)
                   .CommandTimeout(10);

            using(var context = new CookBookContext(builder.Options))
            {
                var books = context.Book.ToList();

                context.RemoveRange(books.Where(e => e.Name == "Sql Batch").ToArray());

                context.SaveChanges();
            }
        }
    }
}
