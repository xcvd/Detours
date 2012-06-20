#region Usings

using System;
using System.Runtime.InteropServices;

#endregion

namespace RGiesecke.DllExport
{
   /// <summary>
   /// Used to control how to create an unmanaged export for a static method.
   /// </summary>
   /// <remarks>
   /// You are not bound to using this class in this assembly.
   /// By default, any attribute named "RGiesecke.DllExport.DllExportAttribute.DllExportAttribute" will do the trick.
   /// Even if it is declared to be only visible inside the assembly with the static methods you want to export.
   /// In such a case the naming and typing of the fileds/properties is critical or otherwise the provided values will not be used.
   /// </remarks>
   [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
   partial class DllExportAttribute : Attribute
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="DllExportAttribute"/> class.
      /// </summary>
      public DllExportAttribute()
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DllExportAttribute"/> class.
      /// </summary>
      /// <param name="exportName">Name of the unmanaged export.
      /// <seealso cref="ExportName"/></param>
      public DllExportAttribute(string exportName)
         : this(exportName, CallingConvention.StdCall)
      {
      }


      /// <summary>
      /// Initializes a new instance of the <see cref="DllExportAttribute"/> class.
      /// </summary>
      /// <param name="exportName">Name of the unmanaged export.
      /// <seealso cref="ExportName"/></param>
      /// <param name="callingConvention">The calling convention of the unmanaged .
      /// <seealso cref="CallingConvention"/></param>
      public DllExportAttribute(string exportName, CallingConvention callingConvention)
      {
         ExportName = exportName;
         CallingConvention = callingConvention;
      }

      /// <summary>
      /// Gets or sets the calling convention that will be used by the unmanaged export.
      /// </summary>
      /// <value>The calling convention.</value>
      public CallingConvention CallingConvention { get; set; }

      /// <summary>
      /// Gets or sets the name of the unmanaged export.
      /// </summary>
      /// <value>The name of the export.</value>
      public string ExportName { get; set; }
   }
}