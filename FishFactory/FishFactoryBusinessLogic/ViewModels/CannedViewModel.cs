using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using FishFactoryBusinessLogic.Attributes;

namespace FishFactoryBusinessLogic.ViewModels
{
    [DataContract]
    public class CannedViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }

        [DataMember]
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string CannedName { get; set; }

        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> CannedComponents { get; set; }
    }
}
