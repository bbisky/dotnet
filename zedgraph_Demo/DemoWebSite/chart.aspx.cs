using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.GData.Analytics;
using ZedGraph;
using ZedGraph.Web;
using System.Drawing;

public partial class chart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    #region 访问来源
    IList<ListItem> GetBrowserData()
    {
        string userName = "denghaibo@gmail.com";
        string passWord = "456007";
        string profileId = "ga:4898953";
        const string dataFeedUrl = "https://www.google.com/analytics/feeds/data";

        AnalyticsService service = new AnalyticsService("CUCMdedu.ElearnAnalytics");
        if (!string.IsNullOrEmpty(userName))
        {
            service.setUserCredentials(userName, passWord);
        }

        DataQuery query = new DataQuery(dataFeedUrl);
        query.Ids = profileId;
        query.Metrics = "ga:visits";
        query.Dimensions = "ga:browser";
        query.Sort = "-ga:visits";
        query.GAStartDate = DateTime.Now.AddDays(-22).ToString("yyyy-MM-dd");
        query.GAEndDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

        DataFeed dataFeed = service.Query(query);
        IList<ListItem> list = new List<ListItem>();
        foreach (DataEntry entry in dataFeed.Entries)
        {
            ListItem item = new ListItem(entry.Dimensions[0].Value, entry.Metrics[0].Value);
            list.Add(item);
        }
        //  GridView1.DataSource = list;
        //GridView1.DataBind();

        return list;
    }
    /// <summary>
    /// Here is a completely independent second graph.  In InitializeComponent() above,
    /// ZedGraphWeb1 calls OnRenderGraph1, and ZedGraphWeb2 calls OnRenderGraph2.
    /// </summary>
    protected void OnRenderGraph2(ZedGraphWeb zgw, Graphics g, MasterPane masterPane)
    {
        GraphPane myPane = masterPane[0];

        //colors from google
        IList<Color> colors = new List<Color>();
        colors.Add(Color.FromArgb(5, 141, 199));
        colors.Add(Color.FromArgb(80, 180, 50));
        colors.Add(Color.FromArgb(237, 86, 27));
        colors.Add(Color.FromArgb(237, 239, 0));
        colors.Add(Color.FromArgb(36, 203, 229));
        colors.Add(Color.FromArgb(100, 229, 114));
        colors.Add(Color.FromArgb(255, 150, 85));
        colors.Add(Color.FromArgb(255, 242, 99));
        colors.Add(Color.FromArgb(106, 249, 196));
        colors.Add(Color.FromArgb(178, 222, 255));

        // Set the GraphPane title
        myPane.Title.Text = "浏览器";
        myPane.Title.FontSpec.IsItalic = true;
        myPane.Title.FontSpec.Size = 24f;
        myPane.Title.FontSpec.Family = "Times New Roman";

        // Fill the pane background with a color gradient
        // myPane.Fill = new Fill(Color.White, Color.Goldenrod, 45.0f);
        // No fill for the chart background
        myPane.Chart.Fill.Type = FillType.None;

        // Set the legend to an arbitrary location
        myPane.Legend.Position = LegendPos.Float;
        myPane.Legend.Location = new Location(0.05f, 0.05f, CoordType.PaneFraction,
                       AlignH.Left, AlignV.Top);
        myPane.Legend.FontSpec.Size = 10f;
        myPane.Legend.IsHStack = false;

        IList<ListItem> dataLists = GetBrowserData();
        int c = 0;
        Color sliceColor = colors[colors.Count - 1];
        foreach (ListItem li in dataLists)
        {

            if (c < colors.Count)
                sliceColor = colors[c++];

            PieItem segment = myPane.AddPieSlice(Convert.ToDouble(li.Value), sliceColor, sliceColor, 45f, 0, li.Text);
            segment.Border.IsVisible = false;
            segment.LabelType = PieLabelType.Name_Percent;
        }

        /*
                // Add some pie slices
                PieItem segment1 = myPane.AddPieSlice(20, Color.Navy, Color.White, 45f, 0, "North");
                PieItem segment3 = myPane.AddPieSlice(30, Color.Purple, Color.White, 45f, .0, "East");
                PieItem segment4 = myPane.AddPieSlice(10.21, Color.LimeGreen, Color.White, 45f, 0, "West");
                PieItem segment2 = myPane.AddPieSlice(40, Color.SandyBrown, Color.White, 45f, 0.2, "South");
                PieItem segment6 = myPane.AddPieSlice(250, Color.Red, Color.White, 45f, 0, "Europe");
                PieItem segment7 = myPane.AddPieSlice(1500, Color.Blue, Color.White, 45f, 0.2, "Pac Rim");
                PieItem segment8 = myPane.AddPieSlice(400, Color.Green, Color.White, 45f, 0, "South America");
                PieItem segment9 = myPane.AddPieSlice(50, Color.Yellow, Color.White, 45f, 0.2, "Africa");
        */
        //segment2.LabelDetail.FontSpec.FontColor = Color.Red;

        // Sum up the pie values                                                               
        // CurveList curves = myPane.CurveList;
        // double total = 0;
        // for (int x = 0; x < curves.Count; x++)
        //     total += ((PieItem)curves[x]).Value;

        /**/
       
        // Make a text label to highlight the total value
        TextObj text = new TextObj(DateTime.Now.ToString(),
                       0.18F, 0.40F, CoordType.PaneFraction);
        text.Location.AlignH = AlignH.Center;
        text.Location.AlignV = AlignV.Bottom;
        text.FontSpec.Border.IsVisible = false;
        text.FontSpec.Fill = new Fill(Color.White, Color.FromArgb(255, 100, 100), 45F);
        text.FontSpec.StringAlignment = StringAlignment.Center;
        myPane.GraphObjList.Add(text);

        // Create a drop shadow for the total value text item
        TextObj text2 = new TextObj(text);
        text2.FontSpec.Fill = new Fill(Color.Black);
        text2.Location.X += 0.008f;
        text2.Location.Y += 0.01f;
        myPane.GraphObjList.Add(text2);



        // Calculate the Axis Scale Ranges
        masterPane.AxisChange();
    }
    #endregion
}
