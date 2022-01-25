using FileManager.Commander;
using FileManager.Drawing;
using FileManager.Structure.PanelStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Structure
{
    /// <summary>
    /// всплывающее меню
    /// </summary>
    public class Menu : List<Button>, IStructure
    {
        public string Text { get; set; }
        public bool IsActive { get; set; }
        public bool ActiveButton { get; set; }


        /// <summary>
        /// кнопки меню (Yes/No)
        /// </summary>
        public List<Button> MenuButtons { get; set; }
        /// <summary>
        /// ячейки для вывод/ввод 
        /// </summary>

        public IDrawing drawing;

        Settings mySet = Settings.Instance();

        public Menu(string text, IDrawing drawing)
        {
            this.Text = text;
            this.drawing = drawing;
            this.ActiveButton = false;
            ClearMenu();
            AddButtons();
            PrintText();
        }


        public void PrintText()
        {
            //Console.ResetColor();
            CoorditatesCount.CountTextStart()
                .SetCursor();
            Console.WriteLine(Text);
        }

        public void AddButtons()
        {
            //this.Clear();
            this.Add(
                new Button(
                    CoorditatesCount.CountStartButton(0),
                    CoorditatesCount.CountFinishButton(0),
                    "YES",
                    false
                    ));

            this.Add(
                new Button(
                    CoorditatesCount.CountStartButton(1),
                    CoorditatesCount.CountFinishButton(1),
                    "NO",
                    true
                    ));
            Console.ResetColor();
        }



        public void RefreshButtons()
        {
            ClearButtons();
            this.ForEach(b => b.DrawButton());
        }


        public void ClearButtons()
        {
            foreach (var b in this)
            {
                for (int i = b.StartPoint.X; i < b.FinishPoint.X; i++)
                {
                    Console.SetCursorPosition(i, b.StartPoint.Y);
                    Console.Write(" ");
                }
            }
        }


        public void ChangeActiveButton()
        {
            foreach (var b in this)
            {
                b.IsActive = !b.IsActive;
                b.BackColor = b.IsActive ? ConsoleColor.Red : ConsoleColor.Black;
            }
            RefreshButtons();

        }



        /// <summary>
        /// Clear all except borders
        /// </summary>
        public void ClearMenu() => Delete(1);
        /// <summary>
        /// Erase menu
        /// </summary>
        public void DeleteMenu() => Delete(0);
        /// <summary>
        /// Delete data in menu: 1 - leave border,0 - delete border
        /// </summary>
        /// <param name="border"></param>
        public void Delete(int border)
        {
            for (int x = mySet.MenuStartX + border; x <= mySet.MenuStartX + mySet.MenuWidth - border; x++)
                for (int y = mySet.MenuStartY + border; y <= mySet.MenuStartY + mySet.MenuHeight - border; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ");
                }
        }


        public void MakeActive()
        {
            this.IsActive = !this.IsActive;
        }



    }
}