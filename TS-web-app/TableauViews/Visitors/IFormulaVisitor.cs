﻿using Ts.IO;

namespace TsWebApp.TableauViews {

    public interface IFormulaVisitor<T> {

        T Visit(Formula formula);
    }
}
