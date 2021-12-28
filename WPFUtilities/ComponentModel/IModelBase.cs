﻿using System.ComponentModel;

namespace WPFUtilities.ComponentModel
{
    public interface IModelBase
    {
        event PropertyChangedEventHandler PropertyChanged;

        bool HasChanged { get; }
    }
}
