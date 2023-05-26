﻿/*
    Copyright(C) 2023  Altom Consulting

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

package com.alttester.Commands.ObjectCommand;

import com.alttester.AltMessage;
import com.alttester.AltObject;

public class AltGetTextParams extends AltMessage {
    /**
     * @param altObject The application object
     */
    private AltObject altObject;

    public AltGetTextParams(AltObject altObject) {
        this.altObject = altObject;
    }

    public AltObject getAltObject() {
        return altObject;
    }

    public void setAltObject(AltObject altObject) {
        this.altObject = altObject;
    }
}
