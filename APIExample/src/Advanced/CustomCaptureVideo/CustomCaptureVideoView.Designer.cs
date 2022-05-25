
namespace CSharp_API_Example
{
    partial class CustomCaptureVideoView
    {
        /// <summary> 
        /// 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 
        /// </summary>
        /// <param name="disposing">If release delegate resource, true; or fals</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Componet Designer Generated Code

        /// <summary> 
        /// The method designer supported - don't modify
        /// Modify the code by designer
        /// </summary>
        private void InitializeComponent()
        {
            this.remoteVideoView = new System.Windows.Forms.PictureBox();
            this.localVideoView = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // remoteVideoView
            // 
            this.remoteVideoView.Location = new System.Drawing.Point(3, 4);
            this.remoteVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.remoteVideoView.Name = "remoteVideoView";
            this.remoteVideoView.Size = new System.Drawing.Size(122, 112);
            this.remoteVideoView.TabIndex = 2;
            this.remoteVideoView.TabStop = false;
            // 
            // localVideoView
            // 
            this.localVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.localVideoView.Cursor = System.Windows.Forms.Cursors.Default;
            this.localVideoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localVideoView.Location = new System.Drawing.Point(0, 0);
            this.localVideoView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.localVideoView.Name = "localVideoView";
            this.localVideoView.Size = new System.Drawing.Size(760, 600);
            this.localVideoView.TabIndex = 4;
            this.localVideoView.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "自采集自渲染";
            // 
            // CustomCaptureVideoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.remoteVideoView);
            this.Controls.Add(this.localVideoView);
            this.Name = "CustomCaptureVideoView";
            this.Size = new System.Drawing.Size(760, 600);
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox remoteVideoView;
        public System.Windows.Forms.PictureBox localVideoView;
        private System.Windows.Forms.Label label1;
    }
}
