﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public  interface IDataBehaviour
    {
        void OnCreate();

        void OnDestroy();
    }
}
