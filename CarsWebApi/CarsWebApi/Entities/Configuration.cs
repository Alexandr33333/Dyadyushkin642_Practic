//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarsWebApi.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Configuration
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public int RimId { get; set; }
        public int CoverId { get; set; }
        public int TireId { get; set; }
        public string Color { get; set; }
    
        public virtual Cars Cars { get; set; }
        public virtual Clients Clients { get; set; }
        public virtual TypesOfCover TypesOfCover { get; set; }
        public virtual TypesOfRims TypesOfRims { get; set; }
        public virtual TypesOfTires TypesOfTires { get; set; }
    }
}
