using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUDelivery.Transactions
{
	public class PedidoBLL
	{
		public static Pedido Get(int? id)
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.Pedido.Find(id);
		}

		public static void Create(Pedido pd)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Pedido.Add(pd);
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

		public static void Update(Pedido pd)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Pedido.Attach(pd);
						db.Entry(pd).State = System.Data.Entity.EntityState.Modified;
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
						Pedido pd = db.Pedido.Find(id);
						db.Entry(pd).State = System.Data.Entity.EntityState.Deleted;
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

		public static List<Pedido> List()
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.Pedido.ToList();
		}
	}
}
