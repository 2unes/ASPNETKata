﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;


namespace SqlIntro
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection conn;

        public DapperProductRepository(IDbConnection conn)
        {
            this.conn = conn;
        }
        public IEnumerable<Product> GetProducts()
        {
            return conn.Query<Product>("Select * from Product");
        }
        public Product GetDetails(int productId)
        {
            return conn.Query<Product>("Select * from Product Where ProductID = @id", new { id = productId }).FirstOrDefault();
        }
        public void DeleteProduct(int productId)
        {
            conn.Execute("Delete from Product Where ProductId = @id", new { id = productId });
        }
        public void UpdateProduct(Product prod)
        {
            conn.Execute("Update Product Set Name = @Name Where ProductId = @id", new { id = prod.ProductId, name = prod.Name });
        }
        public void InsertProduct(Product prod)
        {
            conn.Execute("Insert into Product (Name) values (@Name)", new { name = prod.Name });
        }
        public IEnumerable<Product> FindAllProducts()
        {
            return conn.Query<Product>("Select * From Product p left join productreview pr on p.ProductId = pr.ProductId");
        }
        public IEnumerable<Product> FindAllProdcutsWithReviews()
        {
            return conn.Query<Product>("Select*From Product p inner join productreview pr on p.ProductId = pr.ProductId");
        }
    }
}
