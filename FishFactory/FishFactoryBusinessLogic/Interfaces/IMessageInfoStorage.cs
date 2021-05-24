using System;
using System.Collections.Generic;
using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.ViewModels;

namespace FishFactoryBusinessLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
        int Count();
        List<MessageInfoViewModel> GetMessagesForPage(MessageInfoBindingModel model);
    }
}
