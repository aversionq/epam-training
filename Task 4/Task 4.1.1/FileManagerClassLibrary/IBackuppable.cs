﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerClassLibrary
{
    interface IBackuppable
    {
        void StartBackup(string workDir);
    }
}
