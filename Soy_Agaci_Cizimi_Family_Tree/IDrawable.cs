using System.Drawing;

namespace Soy_Agaci_Cizimi_Family_Tree
{
    // Bir TreeNode'un çizebileceği bir şeyi temsil eder.
    interface IDrawable
    {
        // Nesnenin gerekli boyutunu döndürün.
        SizeF GetSize(Graphics gr, Font font);

        // Düğüm bu noktanın üzerindeyse true değerini döndürün.
        bool IsAtPoint(Graphics gr, Font font, PointF center_pt, PointF target_pt);

        // (x, y) merkezli nesneyi çizin.
        void Draw(float x, float y, Graphics gr, Pen pen,
            Brush bg_brush, Brush text_brush, Font font);
    }
}
