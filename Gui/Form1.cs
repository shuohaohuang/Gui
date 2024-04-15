namespace Gui
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<County> counties = Csv.ReadCounties().OrderBy(x => x.CountyCode).ToList();

            Dictionary<int, string> CountiesDic = new Dictionary<int, string>();

            for (int i = counties.Select(x => x.Year).Distinct().ToList().Min(); i <= 2050; i++)
                cbbYear.Items.Add(i);

            foreach (var x in counties)
                CountiesDic[x.CountyCode] = x.CountyName;
            Xml.Create(CountiesDic);
            foreach (var x in Xml.Read())
                cbbCounty.Items.Add(x.Value);

            counties = Csv.ReadCounties().OrderBy(x => x.Year).ToList();
            dgvCounties.Columns.Add("year", "Any");
            dgvCounties.Columns.Add("code", "Codi comarca");
            dgvCounties.Columns.Add("name", "Comarca");
            dgvCounties.Columns.Add("population", "Població");
            dgvCounties.Columns.Add("domNet", "Domèstic xarxa");
            dgvCounties.Columns.Add("ecoActs", "Activitats econòmiques i fonts pròpies");
            dgvCounties.Columns.Add("total", "Total");
            dgvCounties.Columns.Add("conDomCap", "Consum domèstic per càpita");
            foreach (var x in counties)
            {
                int index = dgvCounties.Rows.Add();
                dgvCounties.Rows[index].Cells["year"].Value = x.Year;
                dgvCounties.Rows[index].Cells["code"].Value = x.CountyCode;
                dgvCounties.Rows[index].Cells["name"].Value = x.CountyName;
                dgvCounties.Rows[index].Cells["population"].Value = x.Population;
                dgvCounties.Rows[index].Cells["domNet"].Value = x.DomesticNetwork;
                dgvCounties.Rows[index].Cells["ecoActs"].Value = x.EconomicActivities;
                dgvCounties.Rows[index].Cells["total"].Value = x.Total;
                dgvCounties.Rows[index].Cells["conDomCap"].Value = x.DomesticConsumptionPerCapita;
            }
        }

        private void dgvCounties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            List<County> counties = Csv.ReadCounties();
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                float value = counties
                        .Where(x => x.Year == Convert.ToInt32(dgvCounties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                        .Max(x => x.DomesticConsumptionPerCapita);
                lblTest.Text = value.ToString();
                lblGb2_13.Text =
                    counties
                        .Where(x => x.Year == Convert.ToInt32(dgvCounties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                        .Max(x => x.DomesticConsumptionPerCapita)
                    == Convert.ToInt32(dgvCounties.Rows[e.RowIndex].Cells[7].Value)
                        ? "Si"
                        : "No";
                lblGb2_14.Text =
                    counties
                        .Where(x => x.Year == Convert.ToInt32(dgvCounties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
                        .Min(x => x.DomesticConsumptionPerCapita)
                    == Convert.ToInt32(dgvCounties.Rows[e.RowIndex].Cells[7].Value)
                        ? "Sí"
                        : "No";
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 2) 
            {
               
                lblGb2_13.Text =
                    counties
                        .Where(x => x.CountyName == dgvCounties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                        .Max(x => x.DomesticConsumptionPerCapita)
                    == Convert.ToInt32(dgvCounties.Rows[e.RowIndex].Cells[7].Value)
                        ? "No"
                        : "Sí";
                lblGb2_14.Text =
                    counties
                        .Where(x => x.CountyName == dgvCounties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                        .Min(x => x.DomesticConsumptionPerCapita)
                    == Convert.ToInt32(dgvCounties.Rows[e.RowIndex].Cells[7].Value)
                        ? "Sí"
                        : "No";
            }
        }
    }
}
