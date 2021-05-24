using System.ComponentModel;
using FishFactoryBusinessLogic.Attributes;

namespace FishFactoryBusinessLogic.ViewModels
{
    public class ComponentViewModel
    {
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }

        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}
