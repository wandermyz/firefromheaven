//
//  BinaryLogicExpr.h
//  BolognieTouch-iOS
//
//  Created by  on 11-9-25.
//  Copyright 2011年 __MyCompanyName__. All rights reserved.
//

#ifndef BolognieTouch_iOS_BinaryLogicExpr_h
#define BolognieTouch_iOS_BinaryLogicExpr_h

#include "BinaryExpr.h"

namespace FireMLEngine {
    class BinaryLogicExpr : public BinaryExpr {
    public:
        virtual void accept(IExprVisitor* visitor) = 0;
    };
}

#endif
