﻿using System.Collections.Generic;

namespace AdventureTool.Plugin.Navigation.Interfaces
{
    public interface IParameter
    {
        IDictionary<string, string> Parameters { get; set; }
    }
}