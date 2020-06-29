using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUDelivery.Transactions
{
	public class ProductoBLL
	{
		public static Producto Get(int? id)
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.Producto.Find(id);
		}

		public static void Create(Producto pr)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Producto.Add(pr);
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception)
					{
						transaction.Rollback();
						throw;
					}
				}
			}
		}

		public static void Update(Producto pr)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Producto.Attach(pr);
						db.Entry(pr).State = System.Data.Entity.EntityState.Modified;
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw ex;
					}
				}
			}
		}

		public static void Delete(int? id)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						Producto pr = db.Producto.Find(id);
						db.Entry(pr).State = System.Data.Entity.EntityState.Deleted;
						db.SaveChanges();
						transaction.Commit();
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						throw ex;
					}
				}
			}
		}

		public static List<Producto> List()
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.Producto.ToList();
		}
	}
}
