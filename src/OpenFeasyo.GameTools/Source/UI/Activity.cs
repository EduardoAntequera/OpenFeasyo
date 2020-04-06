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
namespace OpenFeasyo.GameTools.UI
{
    public class Activity : ComponentCollection
    {
        protected UIEngine _engine;
        public Activity(UIEngine engine) { _engine = engine; }

        public virtual void OnCreate() { }

        public virtual void OnDestroy() { }

        //public virtual void Update(GameTime gameTime) {
        //    Base
        //}



        protected void StartActivity(Activity a)
        {
            _engine.StartActivity(a);
        }
    }
}
