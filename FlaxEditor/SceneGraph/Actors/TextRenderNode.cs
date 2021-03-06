////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2018 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using FlaxEngine;

namespace FlaxEditor.SceneGraph.Actors
{
	/// <summary>
	/// Scene tree node for <see cref="TextRender"/> actor type.
	/// </summary>
	/// <seealso cref="ActorNode" />
	public sealed class TextRenderNode : ActorNode
	{
		/// <inheritdoc />
		public TextRenderNode(Actor actor)
			: base(actor)
		{
		}

		/// <inheritdoc />
		public override void PostSpawn()
		{
			base.PostSpawn();

			// Setup for default values
			var text = (TextRender)Actor;
			text.Text = "My Text";
			text.Font = FlaxEngine.Content.LoadInternal<FontAsset>(EditorAssets.PrimaryFont);
			text.Material = FlaxEngine.Content.LoadInternal<MaterialBase>(EditorAssets.DefaultFontMaterial);
		}
	}
}
