// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Hook.cs" company="xcvd">
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
//   Handles unmanaged API hooking.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detours
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Handles unmanaged API hooking.
    /// </summary>
    public class Hook
    {        
        #region Constants and Fields

        /// <summary>
        /// The pointer to the hook.
        /// </summary>
        private readonly IntPtr hook;

        /// <summary>
        /// The six new bytes to be written to the target.
        /// </summary>
        private readonly byte[] newBytes;

        /// <summary>
        /// The original six bytes read from the target.
        /// </summary>
        private readonly byte[] originalBytes;

        /// <summary>
        /// The pointer to the target.
        /// </summary>
        private readonly IntPtr target;        

        /// <summary>
        /// The delegate method of the target.
        /// </summary>
        private readonly Delegate targetDelegate;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Hook"/> class.
        /// </summary>
        /// <param name="target">
        ///   The target.
        /// </param>
        /// <param name="hook">
        ///   The hook.
        /// </param>
        internal Hook(Delegate target, Delegate hook)
        {            
            this.target = Marshal.GetFunctionPointerForDelegate(target);
            this.targetDelegate = target;
            this.hook = Marshal.GetFunctionPointerForDelegate(hook);

            this.originalBytes = new byte[6];
            Marshal.Copy(this.target, this.originalBytes, 0, 6);

            var hookPointerBytes = BitConverter.GetBytes(this.hook.ToInt32());
            this.newBytes = new byte[]
                {
                   0x68, hookPointerBytes[0], hookPointerBytes[1], hookPointerBytes[2], hookPointerBytes[3], 0xC3 
                };                                 
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the hook is installed.
        /// </summary>
        public bool IsInstalled { get; private set; }        

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Calls the original function, and returns a return value.
        /// </summary>
        /// <param name="args">
        ///   The arguments to pass. If it is a 'void' argument list,
        ///   you must pass 'null'.
        /// </param>
        /// <returns>
        /// An object containing the original functions return value.
        /// </returns>
        internal object CallOriginal(params object[] args)
        {
            this.Uninstall();
            var ret = this.targetDelegate.DynamicInvoke(args);
            this.Install();
            return ret;
        }

        /// <summary>
        /// Installs the hook.
        /// </summary>
        /// <returns>
        /// Whether the operation was successful.
        /// </returns>
        internal bool Install()
        {
            try
            {
                Memory.Write(this.target, this.newBytes);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Removes the hook.
        /// </summary>
        /// <returns>
        /// Whether the operation was successful.
        /// </returns>
        internal bool Uninstall()
        {
            try
            {
                Memory.Write(this.target, this.originalBytes);                
                this.IsInstalled = false;                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}