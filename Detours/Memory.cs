// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Memory.cs" company="xcvd">
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
//   Static memory methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detours
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Static memory methods.
    /// </summary>
    public static class Memory
    {
        #region Public Methods and Operators

        /// <summary>
        /// Reads memory as a byte array.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <param name="length">
        /// The length.
        /// </param>
        /// <returns>
        /// Byte array of memory.
        /// </returns>
        public static byte[] Read(IntPtr address, int length)
        {
            var dest = new byte[length];
            Marshal.Copy(address, dest, 0, length);
            return dest;
        }

        /// <summary>
        /// Write bytes to memory.
        /// </summary>
        /// <param name="address">
        /// The address to write to.
        /// </param>
        /// <param name="value">
        /// The value of bytes to be written.
        /// </param>
        public static void Write(IntPtr address, byte[] value)
        {
            uint oldProtect;
            VirtualProtect(address, (uint)value.Length, 0x40, out oldProtect);
            Marshal.Copy(value, 0, address, value.Length);
            VirtualProtect(address, (uint)value.Length, oldProtect, out oldProtect);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Changes the protection on a region of committed pages in the virtual address space of the calling process.
        /// </summary>
        /// <param name="address">
        /// A pointer an address that describes the starting page of the region of pages whose access protection attributes are to be changed.
        /// All pages in the specified region must be within the same reserved region allocated when calling the VirtualAlloc or VirtualAllocEx 
        /// function using MEM_RESERVE. The pages cannot span adjacent reserved regions that were allocated by separate calls to VirtualAlloc or VirtualAllocEx using MEM_RESERVE.
        /// </param>
        /// <param name="size">
        /// The size of the region whose access protection attributes are to be changed, in bytes. The region of affected pages 
        /// includes all pages containing one or more bytes in the range from the lpAddress parameter to (lpAddress+dwSize). 
        /// This means that a 2-byte range straddling a page boundary causes the protection attributes of both pages to be changed.
        /// </param>
        /// <param name="newProtect">
        /// The memory protection option. This parameter can be one of the memory protection constants.
        /// This value must be compatible with the access protection specified for the pages using VirtualAlloc or VirtualAllocEx.
        /// </param>
        /// <param name="oldProtect">
        /// A pointer to a variable that receives the previous access protection value of the first page in the specified region of pages. 
        /// If this parameter is NULL or does not point to a valid variable, the function fails.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool VirtualProtect(IntPtr address, uint size, uint newProtect, out uint oldProtect);

        #endregion
    }
}