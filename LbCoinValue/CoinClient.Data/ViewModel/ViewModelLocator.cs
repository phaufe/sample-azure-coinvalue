﻿using CoinClient.Design;
using CoinClient.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace CoinClient.ViewModel
{
    public class ViewModelLocator
    {
        private const bool ForceDesignData = false;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }

        static ViewModelLocator()
        {
            if (ForceDesignData
                || ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<ICoinService, DesignCoinService>();
            }
            else
            {
                SimpleIoc.Default.Register<ICoinService, CoinService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }
    }
}