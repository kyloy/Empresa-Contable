using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Empresa
{
    public partial class diagnosticoConMensual : Form
    {
        public string Empresa;
        public diagnosticoConMensual()
        {
            InitializeComponent();
        }

        private void diagnosticoConMensual_Load(object sender, EventArgs e)
        {
            ParameterField param1 = new ParameterField();

            param1.ParameterFieldName = "Empresa";

            ParameterDiscreteValue discreteValue1 = new ParameterDiscreteValue();
            discreteValue1.Value = Empresa;
            param1.CurrentValues.Add(discreteValue1);
            ParameterFields paramFiels1 = new ParameterFields();
            paramFiels1.Add(param1);
            crystalReportViewer1.ParameterFieldInfo = paramFiels1;

            DiagnosticoConcentrado_Mensual report = new DiagnosticoConcentrado_Mensual();
            crystalReportViewer1.ReportSource = report;
        }
    }
}
