using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public static class FormHelper 
    {   

        public static void ResetearMenuItems(ToolStripItemCollection items, Form frm)
        {
            foreach (ToolStripItem itemChild in items)
            {
                if(itemChild is ToolStripMenuItem menuItem)
                {
                    menuItem.Checked = false;

                    if (menuItem.HasDropDownItems)
                    {
                        ResetearMenuItems(menuItem.DropDownItems, frm);
                    }
                    
                }
            }
        }

        public static void ResaltarMenuItem(ToolStripMenuItem menuItem)
        {
            menuItem.Checked = true;

            if (menuItem.OwnerItem is ToolStripMenuItem parentItem)
            {
                parentItem.Checked = true;
                ResaltarMenuItem(parentItem);
            }
        }

        public static void BorderStyle(Form frm, PaintEventArgs e, Color color, int grosor = 1)
        {
            using (Pen pen = new Pen(color, grosor))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, frm.Width, frm.Height);
            }
        }
    }
}
