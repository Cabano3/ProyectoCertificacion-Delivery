//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUDelivery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class DetallePedido
    {

        [ScaffoldColumn(false)]
        public int idDetPedido { get; set; }

        [Display(Name = "Cantidad")]
        public Nullable<int> cantidad { get; set; }
        [Display(Name ="Subtotal")]
        public Nullable<decimal> subtotal { get; set; }
        [Display(Name ="Recarga por Entrega")]
        public Nullable<decimal> recargaentrega { get; set; }
        [Display(Name ="Iva")]
        public Nullable<decimal> iva { get; set; }
        [Display(Name ="Total")]
        public Nullable<decimal> total { get; set; }
  
        public Nullable<int> idPedido { get; set; }
        public Nullable<int> idProducto { get; set; }
    
        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
