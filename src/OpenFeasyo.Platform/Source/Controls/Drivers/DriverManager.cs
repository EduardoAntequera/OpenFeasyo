﻿/*
 * The program is developed as a data collection tool in the fields of motion 
 * analysis and physical condition.The user of the software is motivated to 
 * complete exercises through the use of Games. This program is available as
 * a part of the open source project OpenFeasyo found at
 * https://github.com/openfeasyo/OpenFeasyo>.
 * 
 * Copyright (c) 2020 - Lubos Omelina
 * 
 * This program is free software: you can redistribute it and/or modify it 
 * under the terms of the GNU General Public License version 3 as published 
 * by the Free Software Foundation. The Software Source Code is submitted 
 * within i-DEPOT holding reference number: 122388.
 */
using System.Collections.ObjectModel;

namespace OpenFeasyo.Platform.Controls.Drivers
{
    public class DriverManager : IDriverManager
    {
        private LibraryLoader<IDevice> _inputDevices = new LibraryLoader<IDevice>();

        public static string DRIVERS_PATH = "InputDrivers";

        public ObservableCollection<IDevice> Drivers {
            get 
            {
                _inputDevices.UpdateModules(DriverManager.DRIVERS_PATH);
                return _inputDevices.LoadedModules; 
            }
        }

        public void UnloadAll()
        {
            foreach(IDevice d in Drivers){
                if (d.IsLoaded) {
                    d.UnloadDriver();
                }
            }

        }

    }
}
