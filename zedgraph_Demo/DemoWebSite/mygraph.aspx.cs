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
         this.ZedGraphWeb1.RenderGraph += new ZedGraph.Web.ZedGraphWebControlEventHandler(this.OnRenderGraph);

      }
      #endregion

      /// <summary>
      /// This method is where you generate your graph.
      /// </summary>
      /// <param name="masterPane">You are provided with a MasterPane instance that
      /// contains one GraphPane by default (accessible via masterPane[0]).</param>
      /// <param name="g">A graphics instance so you can easily make the call to AxisChange()</param>
		private void OnRenderGraph( ZedGraphWeb zgw, Graphics g, MasterPane masterPane )
      {
         // Get the GraphPane so we can work with it
         GraphPane myPane = masterPane[0];

         myPane.Title.Text = "Sales By Region";
         myPane.XAxis.Title.Text = "Region";
         myPane.YAxis.Title.Text = "Gross Sales, $Thousands";

         PointPairList list = new PointPairList();
         PointPairList list2 = new PointPairList();
         PointPairList list3 = new PointPairList();
         Random rand = new Random();

         for ( double x=0; x<5; x+=1.0 )
         {
            double y = rand.NextDouble() * 1000;
            double y2 = rand.NextDouble() * 1000;
            double y3 = rand.NextDouble() * 1000;
            list.Add( x, y );
            list2.Add( x, y2 );
            list3.Add( x, y3 );
         }

         BarItem myCurve = myPane.AddBar( "Blue Team", list, Color.Blue );
			myCurve.Bar.Fill = new Fill(Color.Blue, Color.White, Color.Blue);
         BarItem myCurve2 = myPane.AddBar( "Red Team", list2, Color.Red );
			myCurve2.Bar.Fill = new Fill(Color.Red, Color.White, Color.Red );
			BarItem myCurve3 = myPane.AddBar( "Green Team", list3, Color.Green );
			myCurve3.Bar.Fill = new Fill( Color.Green, Color.White, Color.Green );

         myPane.XAxis.MajorTic.IsBetweenLabels = true;
         string[] labels = { "Africa", "Americas", "Asia", "Europe", "Australia" };
         myPane.XAxis.Scale.TextLabels = labels;
         myPane.XAxis.Type = AxisType.Text;
         myPane.Fill = new Fill( Color.White, Color.FromArgb(200, 200, 255), 45.0f );
         myPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45.0f );

         masterPane.AxisChange(g);
      }
   }
}