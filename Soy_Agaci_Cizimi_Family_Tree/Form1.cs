using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Soy_Agaci_Cizimi_Family_Tree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // The root node.
        private TreeNode<PictureNode> root =
            new TreeNode<PictureNode>(
                new PictureNode("Kraliçe II. Elizabeth && Prens Philip Edinburgh Dükü",
                    Properties.Resources.Elizabeth_Philip));

        // Make a tree.
        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode<PictureNode> charles =
                new TreeNode<PictureNode>(
                    new PictureNode("Prens Charles, Galler Prensi",
                        Properties.Resources.Charles));
            TreeNode<PictureNode> anne =
                new TreeNode<PictureNode>(
                    new PictureNode("Prenses Anne",
                        Properties.Resources.Anne));
            TreeNode<PictureNode> andrew =
                new TreeNode<PictureNode>(
                    new PictureNode("Prens Andrew, York Dükü",
                        Properties.Resources.Andrew));
            TreeNode<PictureNode> edward =
                new TreeNode<PictureNode>(
                    new PictureNode("Prens Edward, Wessex Kontu",
                        Properties.Resources.Edward));
            TreeNode<PictureNode> william =
                new TreeNode<PictureNode>(
                    new PictureNode("Prens William",
                        Properties.Resources.William));
            TreeNode<PictureNode> harry =
                new TreeNode<PictureNode>(
                    new PictureNode("Prens Henry (Harry)",
                        Properties.Resources.Harry));
            TreeNode<PictureNode> peter =
                new TreeNode<PictureNode>(
                    new PictureNode("Peter Phillips",
                        Properties.Resources.Peter));
            TreeNode<PictureNode> zara =
                new TreeNode<PictureNode>(
                    new PictureNode("Zara Phillips",
                        Properties.Resources.Zara));
            TreeNode<PictureNode> beatrice =
                new TreeNode<PictureNode>(
                    new PictureNode("Prenses Beatrice",
                        Properties.Resources.Beatrice));
            TreeNode<PictureNode> eugenie =
                new TreeNode<PictureNode>(
                    new PictureNode("Prenses Eugenie",
                        Properties.Resources.Eugenie));
            TreeNode<PictureNode> louise =
                new TreeNode<PictureNode>(
                    new PictureNode("Leydi Louise",
                        Properties.Resources.Louise));
            TreeNode<PictureNode> severn =
                new TreeNode<PictureNode>(
                    new PictureNode("Vikont Severn",
                        Properties.Resources.Severn));

            root.AddChild(charles);
            charles.AddChild(william);
            charles.AddChild(harry);
            root.AddChild(anne);
            anne.AddChild(peter);
            anne.AddChild(zara);
            root.AddChild(andrew);
            andrew.AddChild(beatrice);
            andrew.AddChild(eugenie);
            root.AddChild(edward);
            edward.AddChild(louise);
            edward.AddChild(severn);

            // Arrange the tree.
            ArrangeTree();
        }

        // Draw the tree.
        private void picTree_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            root.DrawTree(e.Graphics);
        }

        // Center the tree on the form.
        private void picTree_Resize(object sender, EventArgs e)
        {
            ArrangeTree();
        }
        private void ArrangeTree()
        {
            using (Graphics gr = picTree.CreateGraphics())
            {
                // Arrange the tree once to see how big it is.
                float xmin = 0, ymin = 0;
                root.Arrange(gr, ref xmin, ref ymin);

                // Arrange the tree again to center it horizontally.
                xmin = (this.ClientSize.Width - xmin) / 2;
                ymin = 10;
                root.Arrange(gr, ref xmin, ref ymin);
            }

            picTree.Refresh();
        }

        // The currently selected node.
        private TreeNode<PictureNode> SelectedNode;

        private void picTree_MouseClick(object sender, MouseEventArgs e)
        {
            FindNodeUnderMouse(e.Location);
        }

        // Set SelectedNode to the node under the mouse.
        private void FindNodeUnderMouse(PointF pt)
        {
            // Deselect the previously selected node.
            if (SelectedNode != null)
            {
                SelectedNode.Data.Selected = false;
                lblNodeText.Text = "";
            }

            // Find the node at this position (if any).
            using (Graphics gr = picTree.CreateGraphics())
            {
                SelectedNode = root.NodeAtPoint(gr, pt);
            }

            // Select the node.
            if (SelectedNode != null)
            {
                SelectedNode.Data.Selected = true;
                lblNodeText.Text = SelectedNode.Data.Description;
            }

            // Redraw.
            picTree.Refresh();
        }
    }
}
