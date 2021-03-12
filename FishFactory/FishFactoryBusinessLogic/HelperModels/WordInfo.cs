using FishFactoryBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace FishFactoryBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ComponentViewModel> Components { get; set; }

        public List<CannedViewModel> Canneds { get; set; }
    }
}