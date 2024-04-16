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
                CountiesDic.TryAdd(x.CountyCode, x.CountyName);

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
            if (e.RowIndex >= 0)
            {
                List<County> counties = Csv.ReadCounties();

                lblGb2_11.Text =
                    Convert.ToSingle(dgvCounties.Rows[e.RowIndex].Cells[3].Value) > 200000
                        ? "Si"
                        : "No";
                lblGb2_12.Text = Math.Round(
                        Convert.ToSingle(dgvCounties.Rows[e.RowIndex].Cells[4].Value)
                            / Convert.ToSingle(dgvCounties.Rows[e.RowIndex].Cells[3].Value),
                        2
                    )
                    .ToString();
                if (e.ColumnIndex == 0)
                {
                    float maxValue = counties
                        .Where(x =>
                            x.Year
                            == Convert.ToSingle(
                                dgvCounties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
                            )
                        )
                        .Max(x => x.DomesticConsumptionPerCapita);

                    float minValue = counties
                        .Where(x =>
                            x.Year
                            == Convert.ToSingle(
                                dgvCounties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
                            )
                        )
                        .Min(x => x.DomesticConsumptionPerCapita);

                    float currentValue = Convert.ToSingle(
                        dgvCounties.Rows[e.RowIndex].Cells[7].Value
                    );
                    lblGb2_13.Text = maxValue == currentValue ? "Si" : "No";
                    lblGb2_14.Text = minValue == currentValue ? "Si" : "No";
                }

                if (e.ColumnIndex == 2)
                {
                    float maxValue = counties
                        .Where(x =>
                            x.CountyName
                            == (string)dgvCounties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
                        )
                        .Max(x => x.DomesticConsumptionPerCapita);

                    float minValue = counties
                        .Where(x =>
                            x.CountyName
                            == (string)dgvCounties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
                        )
                        .Min(x => x.DomesticConsumptionPerCapita);

                    float currentValue = Convert.ToSingle(
                        dgvCounties.Rows[e.RowIndex].Cells[7].Value
                    );

                    lblGb2_13.Text = currentValue == maxValue ? "Sí" : "No";
                    lblGb2_14.Text = currentValue == minValue ? "Sí" : "No";
                }
            }
        }

        public void CleanInputs()
        {
            cbbCounty.Text = string.Empty;
            cbbYear.Text = string.Empty;
            txtDX.Text = string.Empty;
            txtCDC.Text = string.Empty;
            txtAE.Text = string.Empty;
            txtPopulation.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }

        private void bttClear_Click(object sender, EventArgs e)
        {
            CleanInputs();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            errPro.Clear();
            List<TextBox> list = new List<TextBox>() { txtDX, txtCDC, txtAE, txtTotal };
            decimal value;
            bool AllCorrector = true;
            List<decimal> values = new List<decimal>();
            foreach (var item in list)
            {
                if (decimal.TryParse(item.Text, out value))
                    values.Add(value);
                else
                {
                    errPro.SetError(item, "Nomes numeros");
                    AllCorrector=false;
                }
            }

            if (
                decimal.TryParse(txtPopulation.Text, out value)
                && txtPopulation.Text.Split(',').Length == 1
            )
                values.Add(Convert.ToInt32(value));
            else
            {
                errPro.SetError(txtTotal, "Nomes numeros enters");
                AllCorrector = false;
            }

            if (AllCorrector)
            {
                
            }

        }
    }
}
