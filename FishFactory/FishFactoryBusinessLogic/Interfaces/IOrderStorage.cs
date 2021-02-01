using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace FishFactoryBusinessLogic.Interfaces
{
    public interface IOrderStorage
    {
        List<OrderViewModel> GetFullList();

        List<OrderViewModel> GetFilteredList(OrderBindingModel model);

        OrderViewModel GetElement(OrderBindingModel model);

        void Insert(OrderBindingModel model);

        void Update(OrderBindingModel model);

        void Delete(OrderBindingModel model);
    }
}
