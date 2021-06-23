﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public interface  IBehaviorExecution
    {
           Type[] GetLogicBehaviorExecutions() ;
           Type[] GetDataBehaviorExecutions();
          Type[] GetMsgBehaviorExecutions();
    }
}
