//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CherednichenkoKursovoi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zakaz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zakaz()
        {
            this.Passajir = new HashSet<Passajir>();
        }
    
        public int IdZakaz { get; set; }
        public int IdReis { get; set; }
        public int KolichBilet { get; set; }
        public int Sum { get; set; }
    
        public virtual Reis Reis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Passajir> Passajir { get; set; }
    }
}