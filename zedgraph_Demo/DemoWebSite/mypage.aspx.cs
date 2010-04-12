using System;
using System.Drawing;
using ZedGraph;
using ZedGraph.Web;

namespace ZG1
{

    /// <summary>
    /// Summary description for graph.
    /// </summary>
    public partial class graph : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ZedGraphWeb1.RenderGraph += new ZedGraph.Web.ZedGraphWebControlEventHandler(this.OnRenderGraph1);
            this.ZedGraphWeb2.RenderGraph += new ZedGraph.Web.ZedGraphWebControlEventHandler(this.OnRenderGraph2);
        }
        #endregion

        /// <summary>
        /// This method is where you generate your graph.
        /// </summary>
        /// <param name="masterPane">You are provided with a MasterPane instance that
        /// contains one GraphPane by default (accessible via masterPane[0]).</param>
        /// <param name="g">A graphics instance so you can easily make the call to AxisChange()</param>
        private void OnRenderGraph1( ZedGraphWeb zgw, Graphics g, MasterPane masterPane )
        {
            // Get the GraphPane so we can work with it
            GraphPane myPane = masterPane[0];

            // Set the title and axis labels
            myPane.Title.Text = "Cat Stats";
				myPane.YAxis.Title.Text = "Big Cats";
				myPane.XAxis.Title.Text = "Population";

            // Make up some data points
            string[] labels = { "Panther", "Lion", "Cheetah", "Cougar", "Tiger", "Leopard" };
            double[] x = { 100, 115, 75, 22, 98, 40 };
            double[] x2 = { 120, 175, 95, 57, 113, 110 };
            double[] x3 = { 204, 192, 119, 80, 134, 156 };

            // Generate a red bar with "Curve 1" in the legend
            BarItem myCurve = myPane.AddBar("Here", x, null, Color.Red);
            // Fill the bar with a red-white-red color gradient for a 3d look
            myCurve.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red, 90f);

            // Generate a blue bar with "Curve 2" in the legend
            myCurve = myPane.AddBar("There", x2, null, Color.Blue);
            // Fill the bar with a Blue-white-Blue color gradient for a 3d look
            myCurve.Bar.Fill = new Fill(Color.Blue, Color.White, Color.Blue, 90f);

            // Generate a green bar with "Curve 3" in the legend
            myCurve = myPane.AddBar("Elsewhere", x3, null, Color.Green);
            // Fill the bar with a Green-white-Green color gradient for a 3d look
            myCurve.Bar.Fill = new Fill(Color.Green, Color.White, Color.Green, 90f);

            // Draw the Y tics between the labels instead of at the labels
            myPane.YAxis.MajorTic.IsBetweenLabels = true;

            // Set the YAxis labels
            myPane.YAxis.Scale.TextLabels = labels;
            // Set the YAxis to Text type
            myPane.YAxis.Type = AxisType.Text;

            // Set the bar type to stack, which stacks the bars by automatically accumulating the values
            myPane.BarSettings.Type = BarType.Stack;

            // Make the bars horizontal by setting the BarBase to "Y"
				myPane.BarSettings.Base = BarBase.Y;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill( Color.White,
                Color.FromArgb(255, 255, 166), 45.0F );

            masterPane.AxisChange( g );
        }

        /// <summary>
        /// Here is a completely independent second graph.  In InitializeComponent() above,
        /// ZedGraphWeb1 calls OnRenderGraph1, and ZedGraphWeb2 calls OnRenderGraph2.
        /// </summary>
        private void OnRenderGraph2( ZedGraphWeb zgw, Graphics g, MasterPane masterPane )
        {
            // Get the GraphPane so we can work with it
            GraphPane myPane = masterPane[0];

            // Set the titles and axis labels
            myPane.Title.Text = "≤‚ ‘Õº±Ì";
            myPane.XAxis.Title.Text = "»’∆⁄";
            myPane.YAxis.Title.Text = "Y÷·";

            // Make up some data points from the Sine function
            PointPairList list = new PointPairList();
            PointPairList list2 = new PointPairList();
            for (int i = 0; i < 36; i++)
            {
                double x = new XDate(1995, i + 1, 1);
                double y = Math.Sin((double)i * Math.PI / 15.0);
                double y2 = 2 * y;

                list.Add(x, y);
                list2.Add(x, y2);
            }

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            LineItem myCurve2 = myPane.AddCurve("My Curve 2", list, Color.Blue,
                                    SymbolType.Circle);
            // Fill the area under the curve with a white-red gradient at 45 degrees
            myCurve2.Line.Fill = new Fill(Color.White, Color.Red, 45F);
            // Make the symbols opaque by filling them with white
            myCurve2.Symbol.Fill = new Fill(Color.White);

            // Generate a red curve with diamond symbols, and "My Curve" in the legend
            LineItem myCurve = myPane.AddCurve("My Curve",
                list2, Color.MediumVioletRed, SymbolType.Diamond);
            // Fill the area under the curve with a white-green gradient
            myCurve.Line.Fill = new Fill(Color.White, Color.Green);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);

            // Set the XAxis to date type
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.CrossAuto = true;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);

            masterPane.AxisChange(g);
        }
    }
}