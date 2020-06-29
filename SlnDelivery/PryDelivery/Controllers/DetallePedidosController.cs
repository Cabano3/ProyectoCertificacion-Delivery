using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUDelivery;
using BEUDelivery.Transactions;

namespace PryDelivery.Controllers
{
    public class DetallePedidosController : Controller
    {
        // GET: DetallePedidos
        public ActionResult Index()
        {
            return View(DetallePedidoBLL.List());
        }

        // GET: DetallePedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = DetallePedidoBLL.Get(id);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            return View(detallePedido);
        }

        // GET: DetallePedidos/Create
        public ActionResult Create()
        {
            ViewBag.idPedido = new SelectList(PedidoBLL.List(), "idPedido", "estadopedido");
            ViewBag.idProducto = new SelectList(ProductoBLL.List(), "idProducto", "nombre");
            return View();
        }

        // POST: DetallePedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetPedido,cantidad,subtotal,recargaentrega,iva,total,idPedido,idProducto")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                DetallePedidoBLL.Create(detallePedido);
                return RedirectToAction("Index");
            }

            ViewBag.idPedido = new SelectList(PedidoBLL.List(), "idPedido", "estadopedido", detallePedido.idPedido);
            ViewBag.idProducto = new SelectList(ProductoBLL.List(), "idProducto", "nombre", detallePedido.idProducto);
            return View(detallePedido);
        }

        // GET: DetallePedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = DetallePedidoBLL.Get(id);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPedido = new SelectList(PedidoBLL.List(), "idPedido", "estadopedido", detallePedido.idPedido);
            ViewBag.idProducto = new SelectList(ProductoBLL.List(), "idProducto", "nombre", detallePedido.idProducto);
            return View(detallePedido);
        }

        // POST: DetallePedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetPedido,cantidad,subtotal,recargaentrega,iva,total,idPedido,idProducto")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                DetallePedidoBLL.Update(detallePedido);
                return RedirectToAction("Index");
            }
            ViewBag.idPedido = new SelectList(PedidoBLL.List(), "idPedido", "estadopedido", detallePedido.idPedido);
            ViewBag.idProducto = new SelectList(ProductoBLL.List(), "idProducto", "nombre", detallePedido.idProducto);
            return View(detallePedido);
        }

        // GET: DetallePedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetallePedido detallePedido = DetallePedidoBLL.Get(id);
            if (detallePedido == null)
            {
                return HttpNotFound();
            }
            return View(detallePedido);
        }

        // POST: DetallePedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetallePedidoBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
