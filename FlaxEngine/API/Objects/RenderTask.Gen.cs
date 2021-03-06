////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2018 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine.Rendering
{
	/// <summary>
	/// Allows to perform custom rendering using graphics pipeline.
	/// </summary>
	public partial class RenderTask : Object
	{
		/// <summary>
		/// Creates new <see cref="RenderTask"/> object.
		/// </summary>
		protected RenderTask() : base()
		{
		}

		/// <summary>
		/// Gets or sets a value indicating whether task is enabled.
		/// </summary>
		[UnmanagedCall]
		public bool Enabled
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetEnabled(unmanagedPtr); }
			set { Internal_SetEnabled(unmanagedPtr, value); }
#endif
		}

		/// <summary>
		/// Gets or sets task order. Tasks with lower order are rendered first.
		/// </summary>
		[UnmanagedCall]
		public int Order
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetOrder(unmanagedPtr); }
			set { Internal_SetOrder(unmanagedPtr, value); }
#endif
		}

		/// <summary>
		/// Creates the new task object.
		/// </summary>
		/// <typeparam name="T">Type of the render task to create. Includes any task derived from the type.</typeparam>
		/// <returns>Created task object or null if cannot do it.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public static T Create<T>() where T : RenderTask
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return (T)Internal_CreateTask(typeof(T));
#endif
		}

#region Internal Calls
#if !UNIT_TEST_COMPILANT
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetEnabled(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetEnabled(IntPtr obj, bool val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int Internal_GetOrder(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetOrder(IntPtr obj, int val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern RenderTask Internal_CreateTask(Type type);
#endif
#endregion
	}
}

