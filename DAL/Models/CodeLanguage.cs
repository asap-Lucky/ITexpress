﻿using Abstraction.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CodeLanguage : ICodeLanguage
    {
        public int Id { get; set; }
        public string Language { get; set; }
    }
}
