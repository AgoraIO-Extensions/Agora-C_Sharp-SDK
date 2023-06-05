
namespace C_Sharp_API_Example
{
    partial class CustomRenderView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.remoteVideoView = new C_Sharp_API_Example.src.Advanced.CustomRender.CustomVideoBox();
            this.localVideoView = new C_Sharp_API_Example.src.Advanced.CustomRender.CustomVideoBox();
            this.comboRenderType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // remoteVideoView
            // 
            this.remoteVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remoteVideoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteVideoView.Location = new System.Drawing.Point(0, 0);
            this.remoteVideoView.Name = "remoteVideoView";
            this.remoteVideoView.Size = new System.Drawing.Size(591, 510);
            this.remoteVideoView.TabIndex = 0;
            // 
            // localVideoView
            // 
            this.localVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.localVideoView.Location = new System.Drawing.Point(3, 3);
            this.localVideoView.Name = "localVideoView";
            this.localVideoView.Size = new System.Drawing.Size(240, 160);
            this.localVideoView.TabIndex = 1;
            // 
            // comboRenderType
            // 
            this.comboRenderType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboRenderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRenderType.FormattingEnabled = true;
            this.comboRenderType.Location = new System.Drawing.Point(467, 482);
            this.comboRenderType.Name = "comboRenderType";
            this.comboRenderType.Size = new System.Drawing.Size(121, 25);
            this.comboRenderType.TabIndex = 2;
            this.comboRenderType.SelectedIndexChanged += new System.EventHandler(this.comboRenderType_SelectedIndexChanged);
            // 
            // CustomRenderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboRenderType);
            this.Controls.Add(this.localVideoView);
            this.Controls.Add(this.remoteVideoView);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CustomRenderView";
            this.Size = new System.Drawing.Size(591, 510);
            this.ResumeLayout(false);

        }

        #endregion

        public src.Advanced.CustomRender.CustomVideoBox remoteVideoView;
        public src.Advanced.CustomRender.CustomVideoBox localVideoView;
        private System.Windows.Forms.ComboBox comboRenderType;
    }
}
