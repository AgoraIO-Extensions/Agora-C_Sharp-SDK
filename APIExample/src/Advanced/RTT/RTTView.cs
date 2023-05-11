using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharp_API_Example
{
    public partial class RTTView : UserControl
    {
        Dictionary<uint, Label> instant_labels = new Dictionary<uint, Label>();
        Dictionary<uint, Label> final_labels = new Dictionary<uint, Label>();
        public RTTView()
        {
            InitializeComponent();
        }

        public void SetUIText(ConfigHelper config)
        {

        }

        public Label CreateLabel(string name)
        {
            Label label = new System.Windows.Forms.Label();
            label.Name = name;
            label.AutoSize = true;
            label.BackColor = System.Drawing.Color.Transparent;

            return label;
        }

        public Label CreateOrGetInstantLabel(uint uid)
        {
            Label label = null;
            if (!instant_labels.TryGetValue(uid, out label))
            {
                label = CreateLabel("labelRTT_Instant_" + uid);
                instant_labels.Add(uid, label);
            }

            if (!layoutInstant.Controls.Contains(label))
            {
                layoutInstant.Controls.Add(label);
            }

            layoutInstant.Controls.SetChildIndex(label, 0);

            return label;
        }

        public Label CreateOrGetFinalLabels(uint uid)
        {
            Label label = null;
            if (!final_labels.TryGetValue(uid, out label))
            {
                label = CreateLabel("labelRTT_Final_" + uid);
                final_labels.Add(uid, label);
            }

            if (!layoutFinal.Controls.Contains(label))
            {
                layoutFinal.Controls.Add(label);
            }

            layoutFinal.Controls.SetChildIndex(label, 0);

            return label;
        }

        public void AddInstantRttText(uint uid, string text)
        {
            Invoke(new Action(() =>
            {
                var instantLabel = CreateOrGetInstantLabel(uid);
                instantLabel.Text = uid + ": " + text;
            }));
        }

        public void AddFinalRttText(uint uid, string text)
        {
            Invoke(new Action(() =>
            {
                var finalLabel = CreateOrGetFinalLabels(uid);
                finalLabel.Text = uid + ": " + text;
            }));
        }
    }
}
