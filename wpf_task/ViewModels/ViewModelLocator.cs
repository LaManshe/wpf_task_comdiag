﻿using Microsoft.Extensions.DependencyInjection;

namespace wpf_task.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
