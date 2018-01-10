using AgGateway.ADAPT.ApplicationDataModel.ADM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgGateway.ADAPT.Visualizer.UI
{
    public partial class ValidateForm : Form
    {
        public ValidateForm()
        {
            InitializeComponent();
        }

        public void LoadData(IList<IError> errors)
        {
            if (errors == null || errors.Count() == 0)
            {
                _errorsLabel.Text = "No errors found.";
                _validationListView.Visible = false;
            }
            else
            {
                foreach (IError error in errors)
                {
                    _validationListView.Items.Add(new ListViewItem(error.Description));
                }
            }
        }
    }
}
