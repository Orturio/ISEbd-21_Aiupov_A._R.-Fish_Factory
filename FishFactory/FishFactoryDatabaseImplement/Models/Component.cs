using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishFactoryDatabaseImplement.Models
{
    public class Component
    {
        public int Id { get; set; }

        [Required]
        public string ComponentName { get; set; }

        [ForeignKey("ComponentId")]
        public virtual List<CannedComponent> CannedComponents { get; set; }

        [ForeignKey("ComponentId")]
        public virtual List<WarehouseComponent> WarehouseComponent { get; set; }
    }
}
