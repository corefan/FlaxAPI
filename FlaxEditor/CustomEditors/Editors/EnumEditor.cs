////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2018 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using FlaxEditor.CustomEditors.Elements;
using FlaxEngine;

namespace FlaxEditor.CustomEditors.Editors
{
	/// <summary>
	/// Default implementation of the inspector used to edit float value type properties.
	/// </summary>
	[CustomEditor(typeof(Enum)), DefaultEditor]
	public class EnumEditor : CustomEditor
	{
		/// <summary>
		/// The enum element.
		/// </summary>
		protected EnumElement element;

		/// <inheritdoc />
		public override DisplayStyle Style => DisplayStyle.Inline;

		/// <inheritdoc />
		public override void Initialize(LayoutElementsContainer layout)
		{
			if (HasDiffrentTypes)
			{
				// No support for diffrent enum types
			}
			else
			{
				element = layout.Enum(Values[0].GetType());
				element.ValueChanged += OnValueChanged;
			}
		}

		/// <summary>
		/// Called when value get changed. Allows to override default value setter logic.
		/// </summary>
		protected virtual void OnValueChanged()
		{
			SetValue(element.EnumTypeValue);
		}

		/// <inheritdoc />
		public override void Refresh()
		{
			if (HasDiffrentValues)
			{
				// No support for diffrent enum values
			}
			else
			{
				element.EnumTypeValue = Values[0];
			}
		}
	}
}
