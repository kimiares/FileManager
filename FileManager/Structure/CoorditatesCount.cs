using FileManager.Commander;
using FileManager.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    public static class CoorditatesCount
    {
        public static void SetColumn(this Panel panel)
        {
            Settings mySet = Settings.Instance();
            for (int i = 0; i < mySet.ColumnCountLeft; i++)
            {
                panel.Add(
                    new Column(
                        new Point(mySet.Sets.ALX + 1 - i + i * mySet.ColumnWidthLeft + this.Index * (mySet.Sets.PanelWidth + 1), mySet.Sets.ALY + 1),
                            new Point(mySet.Sets.ALX + 1 - i + (i + 1) * mySet.ColumnWidthLeft + this.Index * (mySet.Sets.PanelWidth + 1), mySet.Sets.ALY + 1 + mySet.MaxElementsColumn)
                       ));
            }

        }

    }
}
