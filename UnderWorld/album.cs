//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnderWorld
{
    using System;
    using System.Collections.Generic;
    
    public partial class album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public album()
        {
            this.musica = new HashSet<musica>();
        }
    
        public int id_album { get; set; }
        public int id_artista { get; set; }
        public string titulo { get; set; }
        public int qnt_faixa { get; set; }
        public System.TimeSpan duracao { get; set; }
        public string foto_album { get; set; }
        public System.DateTime lancamento { get; set; }
    
        public virtual artista artista { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<musica> musica { get; set; }
    }
}