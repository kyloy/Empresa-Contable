﻿using System;
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
    public partial class Reporte1 : Form
    {
        public string fecha1;
        public string fecha2;
        public string Titulo;
        public Reporte1()
        {
            InitializeComponent();
        }

        private void Reporte1_Load(object sender, EventArgs e)
        {
            //
            // Creo el parametro y asigno el nombre
            //
            ParameterField param1 = new ParameterField();
            ParameterField param2 = new ParameterField();
            ParameterField param3 = new ParameterField();
            param1.ParameterFieldName = "Fecha Inicio";
            param2.ParameterFieldName = "Fecha Final";
            param3.ParameterFieldName = "Titulo";

            //
            // creo el valor que se asignara al parametro
            //
            ParameterDiscreteValue discreteValue1 = new ParameterDiscreteValue();
            ParameterDiscreteValue discreteValue2 = new ParameterDiscreteValue();
            ParameterDiscreteValue discreteValue3 = new ParameterDiscreteValue();
            discreteValue2.Value = fecha1;
            discreteValue1.Value = fecha2;
            discreteValue3.Value = Titulo;
            param1.CurrentValues.Add(discreteValue1);
            param2.CurrentValues.Add(discreteValue2);
            param3.CurrentValues.Add(discreteValue3);

            //
            // Asigno el paramametro a la coleccion
            //
            ParameterFields paramFiels1 = new ParameterFields();
            //ParameterFields paramFiels2 = new ParameterFields();
            //ParameterFields paramFiels3 = new ParameterFields();
            paramFiels1.Add(param1);
            paramFiels1.Add(param2);
            paramFiels1.Add(param3);

            //
            // Asigno la coleccion de parametros al Crystal Viewer
            //
            //crystalReportViewer1.ParameterFieldInfo = paramFiels2;
            crystalReportViewer1.ParameterFieldInfo = paramFiels1;
            //crystalReportViewer1.ParameterFieldInfo = paramFiels3;

            //
            // Creo la instancia del reporte
            //
            Report1 report = new Report1();

            ////
            //// Cambio el path de la base de datos
            ////
            //string rutadb = Path.Combine(Application.StartupPath, "TestDb.mdb");
            //report.DataSourceConnections[0].SetConnection("", rutadb, false);

            ////
            //// Asigno el reporte a visor
            ////
            crystalReportViewer1.ReportSource = report;
        }
    }
}
