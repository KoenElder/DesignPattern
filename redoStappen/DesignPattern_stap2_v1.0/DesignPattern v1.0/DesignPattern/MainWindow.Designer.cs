namespace DesignPattern
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tools = new System.Windows.Forms.ToolStrip();
            this.ButtonSelect = new System.Windows.Forms.ToolStripButton();
            this.ButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.Seperator01 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonRectangle = new System.Windows.Forms.ToolStripButton();
            this.ButtonEllipse = new System.Windows.Forms.ToolStripButton();
            this.Commands = new System.Windows.Forms.ToolStrip();
            this.ButtonNew = new System.Windows.Forms.ToolStripButton();
            this.ButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.ButtonSave = new System.Windows.Forms.ToolStripButton();
            this.Seperator02 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.ButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.Tools.SuspendLayout();
            this.Commands.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.Tools.AllowDrop = true;
            this.Tools.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Tools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Tools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonSelect,
            this.ButtonDelete,
            this.Seperator01,
            this.ButtonRectangle,
            this.ButtonEllipse});
            this.Tools.Location = new System.Drawing.Point(0, 447);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(780, 27);
            this.Tools.TabIndex = 1;
            this.Tools.Text = "Tools";
            // 
            // toolStripButtonPointer
            // 
            this.ButtonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonSelect.Image = global::DesignPattern.Properties.Resources.pointer;
            this.ButtonSelect.ImageTransparentColor = System.Drawing.Color.Silver;
            this.ButtonSelect.Name = "Select";
            this.ButtonSelect.Size = new System.Drawing.Size(24, 24);
            this.ButtonSelect.Text = "Select";
            this.ButtonSelect.Click += new System.EventHandler(this.tools_Select_Click);
            // 
            // toolStripButton6
            // 
            this.ButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonDelete.Enabled = false;
            this.ButtonDelete.Image = global::DesignPattern.Properties.Resources.delete;
            this.ButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonDelete.Name = "Delete";
            this.ButtonDelete.Size = new System.Drawing.Size(24, 24);
            this.ButtonDelete.Text = "Delete";
            this.ButtonDelete.Click += new System.EventHandler(this.tools_Delete_Click);
            // 
            // toolStripSeparator1
            // 
            this.Seperator01.Name = "toolStripSeparator1";
            this.Seperator01.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButtonRectangle
            // 
            this.ButtonRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonRectangle.Image = global::DesignPattern.Properties.Resources.rectangle;
            this.ButtonRectangle.ImageTransparentColor = System.Drawing.Color.Silver;
            this.ButtonRectangle.Name = "Rectangle";
            this.ButtonRectangle.Size = new System.Drawing.Size(24, 24);
            this.ButtonRectangle.Text = "Rectangle";
            this.ButtonRectangle.Click += new System.EventHandler(this.tools_Rectangle_Click);
            // 
            // toolStripButtonEllipse
            // 
            this.ButtonEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonEllipse.Image = global::DesignPattern.Properties.Resources.ellipse;
            this.ButtonEllipse.ImageTransparentColor = System.Drawing.Color.Silver;
            this.ButtonEllipse.Name = "Ellipse";
            this.ButtonEllipse.Size = new System.Drawing.Size(24, 24);
            this.ButtonEllipse.Text = "Ellipse";
            this.ButtonEllipse.Click += new System.EventHandler(this.tools_Ellipse_Click);
            // 
            // command
            // 
            this.Commands.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Commands.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Commands.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonNew,
            this.ButtonOpen,
            this.ButtonSave,
            this.Seperator02,
            this.ButtonUndo,
            this.ButtonRedo});
            this.Commands.Location = new System.Drawing.Point(0, 0);
            this.Commands.Name = "Commands";
            this.Commands.Size = new System.Drawing.Size(780, 25);
            this.Commands.TabIndex = 2;
            this.Commands.Text = "Commands";
            // 
            // toolStripButton1
            // 
            this.ButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonNew.Image = global::DesignPattern.Properties.Resources._new;
            this.ButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonNew.Name = "New";
            this.ButtonNew.Size = new System.Drawing.Size(23, 22);
            this.ButtonNew.Text = "New";
            this.ButtonNew.Click += new System.EventHandler(this.command_New_Click);
            // 
            // toolStripButton2
            // 
            this.ButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonOpen.Image = global::DesignPattern.Properties.Resources.open;
            this.ButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonOpen.Name = "Open";
            this.ButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.ButtonOpen.Text = "Open";
            this.ButtonOpen.Click += new System.EventHandler(this.command_Open_Click);
            // 
            // toolStripButton3
            // 
            this.ButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Image = global::DesignPattern.Properties.Resources.save;
            this.ButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSave.Name = "Save";
            this.ButtonSave.Size = new System.Drawing.Size(23, 22);
            this.ButtonSave.Text = "Save";
            this.ButtonSave.Click += new System.EventHandler(this.command_Save_Click);
            // 
            // toolStripSeparator2
            // 
            this.Seperator02.Name = "toolStripSeparator2";
            this.Seperator02.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.ButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonUndo.Enabled = false;
            this.ButtonUndo.Image = global::DesignPattern.Properties.Resources.undo;
            this.ButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonUndo.Name = "Undo";
            this.ButtonUndo.Size = new System.Drawing.Size(23, 22);
            this.ButtonUndo.Text = "Undo";
            this.ButtonUndo.Click += new System.EventHandler(this.command_Undo_Click);
            // 
            // toolStripButton5
            // 
            this.ButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonRedo.Enabled = false;
            this.ButtonRedo.Image = global::DesignPattern.Properties.Resources.redo;
            this.ButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonRedo.Name = "Redo";
            this.ButtonRedo.Size = new System.Drawing.Size(23, 22);
            this.ButtonRedo.Text = "Redo";
            this.ButtonRedo.Click += new System.EventHandler(this.command_Redo_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(780, 474);
            this.Controls.Add(this.Commands);
            this.Controls.Add(this.Tools);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "DesignPattern";
            this.Text = "DesignPattern";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.Commands.ResumeLayout(false);
            this.Commands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStrip Tools;
        private System.Windows.Forms.ToolStripButton ButtonSelect;
        private System.Windows.Forms.ToolStripButton ButtonRectangle;
        private System.Windows.Forms.ToolStripButton ButtonEllipse;
        private System.Windows.Forms.ToolStripSeparator Seperator01;
        private System.Windows.Forms.ToolStrip Commands;
        private System.Windows.Forms.ToolStripButton ButtonDelete;
        private System.Windows.Forms.ToolStripButton ButtonNew;
        private System.Windows.Forms.ToolStripButton ButtonOpen;
        private System.Windows.Forms.ToolStripButton ButtonSave;
        private System.Windows.Forms.ToolStripSeparator Seperator02;
        private System.Windows.Forms.ToolStripButton ButtonUndo;
        private System.Windows.Forms.ToolStripButton ButtonRedo;
    }
}

