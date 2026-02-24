namespace VirtualDog
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dog_picture = new PictureBox();
            menu = new ContextMenuStrip(components);
            changeSizeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dog_picture).BeginInit();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // dog_picture
            // 
            dog_picture.Cursor = Cursors.Hand;
            dog_picture.Location = new Point(0, 0);
            dog_picture.Name = "dog_picture";
            dog_picture.Size = new Size(80, 80);
            dog_picture.SizeMode = PictureBoxSizeMode.StretchImage;
            dog_picture.TabIndex = 0;
            dog_picture.TabStop = false;
            // 
            // menu
            // 
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { changeSizeToolStripMenuItem, closeToolStripMenuItem });
            menu.Name = "contextMenuStrip1";
            menu.Size = new Size(158, 52);
            // 
            // changeSizeToolStripMenuItem
            // 
            changeSizeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem6, toolStripMenuItem7, toolStripMenuItem8, toolStripMenuItem9, toolStripMenuItem10 });
            changeSizeToolStripMenuItem.Name = "changeSizeToolStripMenuItem";
            changeSizeToolStripMenuItem.Size = new Size(157, 24);
            changeSizeToolStripMenuItem.Text = "Change size";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(136, 26);
            toolStripMenuItem2.Tag = 1F;
            toolStripMenuItem2.Text = "100%";
            toolStripMenuItem2.Click += ChangeSize_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(136, 26);
            toolStripMenuItem3.Tag = 1.25F;
            toolStripMenuItem3.Text = "125%";
            toolStripMenuItem3.Click += ChangeSize_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(136, 26);
            toolStripMenuItem4.Tag = 1.5F;
            toolStripMenuItem4.Text = "150%";
            toolStripMenuItem4.Click += ChangeSize_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(136, 26);
            toolStripMenuItem5.Tag = 1.75F;
            toolStripMenuItem5.Text = "175%";
            toolStripMenuItem5.Click += ChangeSize_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(136, 26);
            toolStripMenuItem6.Tag = 2F;
            toolStripMenuItem6.Text = "200%";
            toolStripMenuItem6.Click += ChangeSize_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(136, 26);
            toolStripMenuItem7.Tag = 2.5F;
            toolStripMenuItem7.Text = "250%";
            toolStripMenuItem7.Click += ChangeSize_Click;
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(136, 26);
            toolStripMenuItem8.Tag = 3F;
            toolStripMenuItem8.Text = "300%";
            toolStripMenuItem8.Click += ChangeSize_Click;
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(136, 26);
            toolStripMenuItem9.Tag = 5F;
            toolStripMenuItem9.Text = "500%";
            toolStripMenuItem9.Click += ChangeSize_Click;
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new Size(136, 26);
            toolStripMenuItem10.Tag = 10F;
            toolStripMenuItem10.Text = "1000%";
            toolStripMenuItem10.Click += ChangeSize_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(157, 24);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(80, 80);
            Controls.Add(dog_picture);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            ShowInTaskbar = false;
            Text = "VirtualDog";
            TopMost = true;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dog_picture).EndInit();
            menu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox dog_picture;
        private ContextMenuStrip menu;
        private ToolStripMenuItem changeSizeToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem closeToolStripMenuItem;
    }
}
