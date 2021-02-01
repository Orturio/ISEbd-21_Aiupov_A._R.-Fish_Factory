using System.ComponentModel;

namespace FishFactoryBusinessLogic.ViewModels
{
    public class ComponentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}
