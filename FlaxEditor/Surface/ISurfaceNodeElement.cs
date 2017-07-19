////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

namespace FlaxEditor.Surface
{
    /// <summary>
    /// Base interface for elements that can be added to the <see cref="SurfaceNode"/>.
    /// </summary>
    public interface ISurfaceNodeElement
    {
        /// <summary>
        /// Gets the parent node.
        /// </summary>
        /// <value>
        /// The parent node.
        /// </value>
        SurfaceNode ParentNode { get; }
    }
}
