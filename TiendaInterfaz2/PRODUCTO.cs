//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TiendaInterfaz2
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            this.TICKETDETALLEs = new HashSet<TICKETDETALLE>();
        }
    
        public int ProductoId { get; set; }
        public Nullable<int> MarcaId { get; set; }
        public Nullable<int> TipoProductoId { get; set; }
        public string Descripcion { get; set; }
        public string Talle { get; set; }
        public string Color { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<int> Stock { get; set; }
    
        public virtual MARCA MARCA { get; set; }
        public virtual TIPOPRODUCTO TIPOPRODUCTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKETDETALLE> TICKETDETALLEs { get; set; }
    }
}