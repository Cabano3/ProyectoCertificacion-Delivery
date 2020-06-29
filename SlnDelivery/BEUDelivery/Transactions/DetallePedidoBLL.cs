using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUDelivery.Transactions
{
	public class DetallePedidoBLL
	{
		public static DetallePedido Get(int? id)
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.DetallePedido.Find(id);
		}

		public static void Create(DetallePedido dpd)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.DetallePedido.Add(dpd);
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

		public static void Update(DetallePedido dpd)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.DetallePedido.Attach(dpd);
						db.Entry(dpd).State = System.Data.Entity.EntityState.Modified;
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
						DetallePedido dpd = db.DetallePedido.Find(id);
						db.Entry(dpd).State = System.Data.Entity.EntityState.Deleted;
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

		public static List<DetallePedido> List()
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.DetallePedido.ToList();
		}
	}
}
