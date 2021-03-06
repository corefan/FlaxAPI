﻿// Flax Engine scripting API

namespace FlaxEngine.GUI
{
    /// <summary>
    /// Horizontal scroll bar control.
    /// </summary>
    /// <seealso cref="FlaxEngine.GUI.ScrollBar" />
    public class HScrollBar : ScrollBar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HScrollBar"/> class.
        /// </summary>
        /// <param name="y">The y position.</param>
        /// <param name="width">The width.</param>
        public HScrollBar(float y, float width)
            : base(Orientation.Horizontal, 0, y, width, DefaultSize)
        {
            DockStyle = DockStyle.Bottom;
        }

        /// <inheritdoc />
        protected override float TrackSize => Width;
    }
}
