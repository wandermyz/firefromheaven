﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FireEngine.FireMLEngine.Expr
{
    [Serializable]
    public class LessExpr : BinaryCmpExpr
    {
        internal override void Accept(IExprVisitor visitor, params object[] args)
        {
            visitor.Visit(this, args);
        }
    }
}
