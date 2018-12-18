using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.BoundaryRepresentation;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using Autodesk.AutoCAD.Colors;

namespace MunicipalEngineering
{
    public partial class MapProcessUserControl : UserControl
    {
        public MapProcessUserControl()
        {
            InitializeComponent();
        }

        private void MPP_button_Click(object sender, EventArgs e)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("MPP\n", true, false, false);
        }

        private void SZCJ_button_Click(object sender, EventArgs e)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("szcj1\n", true, false, false);
        }

        private void ZDZB_button_Click(object sender, EventArgs e)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("ZDZB\n", true, false, false);
        }

        private void CZB_button_Click(object sender, EventArgs e)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("CZB\n", true, false, false);
        }

        private void DXT_button_Click(object sender, EventArgs e)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("DXT\n", true, false, false);
        }

        private void ZT_button_Click(object sender, EventArgs e)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            doc.SendStringToExecute("ZT\n", true, false, false);
        }
    }
}
