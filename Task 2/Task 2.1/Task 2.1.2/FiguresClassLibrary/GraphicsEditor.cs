using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public class GraphicsEditor
    {
        private static List<Figure> figures = new List<Figure>();

        public static void RunEditor()
        {
            do
            {
                switch (GraphicsEditorHelper.ChooseAction())
                {
                    case 1:
                        Figure newFig = GraphicsEditorHelper.CreateFigure();
                        figures.Add(newFig);
                        Console.WriteLine($"Фигура {newFig.GetType().Name} создана!");
                        break;
                    case 2:
                        if (figures.Count > 0)
                        {
                            foreach (var fig in figures)
                            {
                                Console.WriteLine(fig);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Список фигур пока что пуст.");
                        }
                        break;
                    case 3:
                        if (figures.Count > 0)
                        {
                            figures.Clear();
                            Console.WriteLine("Список фигур очищен!");
                        }
                        else
                        {
                            Console.WriteLine("Список фигур пуст.");
                        }
                        break;
                    case 4:
                        return;
                }
            } while (true);
        }
    }
}
