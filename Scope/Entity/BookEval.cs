﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scope.Entity
{
    public class BookEval
    {
        private String id;
        private String eval;

        public String Id
        {
            set { this.id = value; }
            get { return id; }
        }

        public String Eval
        {
            set { this.eval = value; }
            get { return eval; }
        }
    }
}