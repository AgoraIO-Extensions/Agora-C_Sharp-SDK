
namespace CSharp_API_Example
{
    partial class JoinChannelAudioView
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
            this.audioLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // audioLabel
            // 
            this.audioLabel.AutoSize = true;
            this.audioLabel.Location = new System.Drawing.Point(188, 12);
            this.audioLabel.Name = "audioLabel";
            this.audioLabel.Size = new System.Drawing.Size(114, 20);
            this.audioLabel.TabIndex = 0;
            this.audioLabel.Text = "一对一语音通话";
            this.audioLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // JoinChannelAudioView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.audioLabel);
            this.Name = "JoinChannelAudioView";
            this.Size = new System.Drawing.Size(502, 367);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label audioLabel;
    }
}
