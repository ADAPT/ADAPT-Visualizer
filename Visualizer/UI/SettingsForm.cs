/*******************************************************************************
 * Copyright (c) 2015 AgGateway and ADAPT Contributors
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html
 *
 * Contributors:
 *    Andrew Vardeman - Settings for added UI features
 *******************************************************************************/
using System.Windows.Forms.VisualStyles;
using AgGateway.ADAPT.Visualizer.Properties;

namespace AgGateway.ADAPT.Visualizer.UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            _showLimitDataUICheckBox.Checked = Settings.Default.ShowLimitDataUI;
            _rememberWindowSettingsCheckBox.Checked = Settings.Default.RememberWindowSettings;
            _propsFileExtensionTextBox.Text = Settings.Default.PropertyFileExtension;
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                bool showLimitData = _showLimitDataUICheckBox.Checked;

                Settings.Default.ShowLimitDataUI = showLimitData;
                if (!showLimitData)
                {
                    Settings.Default.LimitData = false;
                }

                Settings.Default.RememberWindowSettings = _rememberWindowSettingsCheckBox.Checked;
                Settings.Default.PropertyFileExtension = _propsFileExtensionTextBox.Text;
            }
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
