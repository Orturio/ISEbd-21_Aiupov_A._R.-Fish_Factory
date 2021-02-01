using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace FishFactoryBusinessLogic.Interfaces
{
    public interface ICannedStorage
    {
        List<CannedViewModel> GetFullList();

        List<CannedViewModel> GetFilteredList(CannedBindingModel model);

        CannedViewModel GetElement(CannedBindingModel model);

        void Insert(CannedBindingModel model);

        void Update(CannedBindingModel model);

        void Delete(CannedBindingModel model);
    }
}
