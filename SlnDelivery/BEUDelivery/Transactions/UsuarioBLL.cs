using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUDelivery.Transactions
{
	public class UsuarioBLL
	{
		public static Usuario Get(int? id)
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.Usuario.Find(id);
		}

		public static void Create(Usuario us)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Usuario.Add(us);
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

		public static void Update(Usuario us)
		{
			using (DeliveryEntities db = new DeliveryEntities())
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						db.Usuario.Attach(us);
						db.Entry(us).State = System.Data.Entity.EntityState.Modified;
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
						Usuario us = db.Usuario.Find(id);
						db.Entry(us).State = System.Data.Entity.EntityState.Deleted;
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

		public static List<Usuario> List()
		{
			DeliveryEntities db = new DeliveryEntities();
			return db.Usuario.ToList();
		}
	}
}
