// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HookUninstallFailedException.cs" company="xcvd">
//   Copyright 2012 - xcvd
//   
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
// 
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
// 
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see http://www.gnu.org/licenses/.
// </copyright>
// <summary>
//   Thrown if a hook cannot be removed.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detours
{
    using System;

    /// <summary>
    /// Thrown if a hook cannot be removed.
    /// </summary>
    public class HookUninstallFailedException : SystemException
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HookUninstallFailedException"/> class.         
        /// </summary>
        /// <param name="errorMessage">
        /// The error message.
        /// </param>
        public HookUninstallFailedException(string errorMessage)
            : base(errorMessage)
        {
        }

        #endregion
    }
}