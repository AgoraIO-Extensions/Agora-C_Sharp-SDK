
namespace CSharp_API_Example
{
    partial class RTTView
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
            this.localVideoView = new System.Windows.Forms.PictureBox();
            this.remoteVideoView = new System.Windows.Forms.PictureBox();
            this.layoutFinal = new System.Windows.Forms.FlowLayoutPanel();
            this.layoutInstant = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideoView)).BeginInit();
            this.SuspendLayout();
            // 
            // localVideoView
            // 
            this.localVideoView.Location = new System.Drawing.Point(2, 3);
            this.localVideoView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.localVideoView.Name = "localVideoView";
            this.localVideoView.Size = new System.Drawing.Size(95, 95);
            this.localVideoView.TabIndex = 2;
            this.localVideoView.TabStop = false;
            // 
            // remoteVideoView
            // 
            this.remoteVideoView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remoteVideoView.Cursor = System.Windows.Forms.Cursors.Default;
            this.remoteVideoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteVideoView.Location = new System.Drawing.Point(0, 0);
            this.remoteVideoView.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.remoteVideoView.Name = "remoteVideoView";
            this.remoteVideoView.Size = new System.Drawing.Size(591, 510);
            this.remoteVideoView.TabIndex = 4;
            this.remoteVideoView.TabStop = false;
            // 
            // layoutFinal
            // 
            this.layoutFinal.BackColor = System.Drawing.Color.Transparent;
            this.layoutFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.layoutFinal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.layoutFinal.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.layoutFinal.Location = new System.Drawing.Point(0, 451);
            this.layoutFinal.Name = "layoutFinal";
            this.layoutFinal.Size = new System.Drawing.Size(591, 59);
            this.layoutFinal.TabIndex = 16;
            // 
            // layoutInstant
            // 
            this.layoutInstant.BackColor = System.Drawing.Color.Transparent;
            this.layoutInstant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.layoutInstant.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.layoutInstant.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.layoutInstant.Location = new System.Drawing.Point(0, 392);
            this.layoutInstant.Name = "layoutInstant";
            this.layoutInstant.Size = new System.Drawing.Size(591, 59);
            this.layoutInstant.TabIndex = 17;
            // 
            // RTTView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutInstant);
            this.Controls.Add(this.layoutFinal);
            this.Controls.Add(this.localVideoView);
            this.Controls.Add(this.remoteVideoView);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "RTTView";
            this.Size = new System.Drawing.Size(591, 510);
            ((System.ComponentModel.ISupportInitialize)(this.localVideoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideoView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox localVideoView;
        public System.Windows.Forms.PictureBox remoteVideoView;
        private System.Windows.Forms.FlowLayoutPanel layoutFinal;
        private System.Windows.Forms.FlowLayoutPanel layoutInstant;
    }
}
