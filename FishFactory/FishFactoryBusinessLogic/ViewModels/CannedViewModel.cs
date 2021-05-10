using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace FishFactoryBusinessLogic.ViewModels
{
    [DataContract]
    public class CannedViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название изделия")]
        public string CannedName { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> CannedComponents { get; set; }
    }
}
