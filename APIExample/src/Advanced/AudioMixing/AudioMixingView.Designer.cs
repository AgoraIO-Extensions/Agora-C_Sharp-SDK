
namespace CSharp_API_Example
{
    partial class AudioMixingView
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
            this.audioMxingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // audioMxingLabel
            // 
            this.audioMxingLabel.AutoSize = true;
            this.audioMxingLabel.Location = new System.Drawing.Point(165, 21);
            this.audioMxingLabel.Name = "audioMxingLabel";
            this.audioMxingLabel.Size = new System.Drawing.Size(39, 20);
            this.audioMxingLabel.TabIndex = 0;
            this.audioMxingLabel.Text = "Audio Mixing";
            this.audioMxingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AudioMixingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.audioMxingLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AudioMixingView";
            this.Size = new System.Drawing.Size(501, 367);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label audioMxingLabel;
    }
}
