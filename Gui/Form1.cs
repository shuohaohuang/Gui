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
            dgvCounties.Columns.Add("h1", "Any");
            dgvCounties.Columns.Add("h2", "Codi comarca");
            dgvCounties.Columns.Add("h3", "Comarca");
            dgvCounties.Columns.Add("h4", "Població");
            dgvCounties.Columns.Add("h5", "Domèstic xarxa");
            dgvCounties.Columns.Add("h6", "Activitats econòmiques i fonts pròpies");
            dgvCounties.Columns.Add("h7", "Total");
            dgvCounties.Columns.Add("h8", "Consum domèstic per càpita");
            foreach (var x in counties)
            {
                int index = dgvCounties.Rows.Add();
                dgvCounties.Rows[index].Cells["h1"].Value = x.Year;
                dgvCounties.Rows[index].Cells["h2"].Value = x.CountyCode;
                dgvCounties.Rows[index].Cells["h3"].Value = x.CountyName;
                dgvCounties.Rows[index].Cells["h4"].Value = x.Population;
                dgvCounties.Rows[index].Cells["h5"].Value = x.DomesticNetwork;
                dgvCounties.Rows[index].Cells["h6"].Value = x.EconomicActivities;
                dgvCounties.Rows[index].Cells["h7"].Value = x.Total;
                dgvCounties.Rows[index].Cells["h8"].Value = x.DomesticConsumptionPerCapita;

            }
        }

        private void txtPopulation_TextChanged(object sender, EventArgs e)
        {
            lblGb2_11.Text = Convert.ToInt32(txtPopulation.Text) > 200000 ? "Sí" : "No";
        }
    }
}
