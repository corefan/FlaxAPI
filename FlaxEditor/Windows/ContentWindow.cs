﻿////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaxEditor.Content;
using FlaxEditor.Content.GUI;
using FlaxEditor.GUI;
using FlaxEngine.GUI;

namespace FlaxEditor.Windows
{
    /// <summary>
    /// One of the main editor windows used to present workspace content and user scripts.
    /// Provides various functionalities for asset operations.
    /// </summary>
    /// <seealso cref="FlaxEditor.Windows.EditorWindow" />
    public sealed partial class ContentWindow : EditorWindow
    {
        private bool _isReady;
        private SplitPanel _split;
        private ContentView _view;

        private ToolStrip _toolStrip;

        //private NavigationBar _navigationBar;
        private Tree _tree;

        private ContentTreeNode _root;

        private bool _navigationUnlocked;
        private readonly List<ContentTreeNode> _navigationUndo = new List<ContentTreeNode>(32);
        private readonly List<ContentTreeNode> _navigationRedo = new List<ContentTreeNode>(32);

        private NewItem _newElement;
        //private AssetsPreviewManager _previewManager;

        internal ContentWindow(Editor editor)
            : base(editor, true, ScrollBars.None)
        {
            Title = "Content";

            // Tool strip
            _toolStrip = new ToolStrip();
            _toolStrip.AddButton(0, Editor.UI.GetIcon("Import32"));//.LinkTooltip(GetSharedTooltip(), "Import content");// Import
            _toolStrip.AddSeparator();
            _toolStrip.AddButton(1, Editor.UI.GetIcon("ArrowLeft32"));//.LinkTooltip(GetSharedTooltip(), "Navigate backward");// Backward
            _toolStrip.AddButton(2, Editor.UI.GetIcon("ArrowRight32"));//.LinkTooltip(GetSharedTooltip(), "Navigate forward");// Forward
            _toolStrip.AddButton(3, Editor.UI.GetIcon("ArrowUp32"));//.LinkTooltip(GetSharedTooltip(), "Navigate up");// Up
            _toolStrip.OnButtonClicked += toolstripButtonClicked;
            _toolStrip.Parent = this;

            // Navigation bar
            //_navigationBar = new CNavigationBar();
            //_navigationBar.SetHeight(32);
            //_navigationBar.Parent = this;

            // Split panel
            _split = new SplitPanel(Orientation.Horizontal, ScrollBars.Both, ScrollBars.Vertical);
            _split.DockStyle = DockStyle.Fill;
            _split.SplitterValue = 0.2f;
            _split.Parent = this;

            // Content structure tree
            _tree = new Tree(false);
            _tree.OnSelectedChanged += treeOnSelectedChanged;
            _tree.Parent = _split.Panel1;

            // Content View
            _view = new ContentView();
            //_view.OnOpen.Bind < ContentWindow, &ContentWindow::view_OnOpen > (this);
            //_view.OnRename.Bind < ContentWindow, &ContentWindow::Rename > (this);
            //_view.OnDelete.Bind < ContentWindow, &ContentWindow::view_OnDelete > (this);
            //_view.OnDuplicate.Bind < ContentWindow, &ContentWindow::CloneSelection > (this);
            //_view.OnNavigateBack.Bind < ContentWindow, &ContentWindow::navigateBackward > (this);
            _view.Parent = _split.Panel2;
        }

        private void toolstripButtonClicked(int id)
        {
            /*switch (id)
            {
                // Import
		        case 0: import(); break;

                // Backward
                case 1: navigateBackward(); break;

                // Forward
                case 2: navigateForward(); break;

                // Up
                case 3: navigateUp(); break;
            }*/
        }

        private void viewOnOpen(ContentItem item)
        {
            //Open(item);
        }

        private void viewOnDelete()
        {
            // Check if has any selected items
            //Delete(_view.Selection);
        }

        private void updateToolstrip()
        {
            if (_toolStrip == null)
                return;

            // Update buttons
            var folder = CurrentViewFolder;
            _toolStrip.GetButton(0).Enabled = folder != null && folder.CanHaveAssets;
            _toolStrip.GetButton(1).Enabled = _navigationUndo.Count > 0;
            _toolStrip.GetButton(2).Enabled = _navigationRedo.Count > 0;
            _toolStrip.GetButton(3).Enabled = folder != null && _tree.SelectedNode != _root;

            // Update navigation path
            navigationBarUpdate();
        }
    }
}
