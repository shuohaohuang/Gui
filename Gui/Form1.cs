namespace Gui
{
    public partial class Form1 : Form
    {
        IReadOnlyList<string> HeadersName =
                ["year", "code", "name", "population", "domNet", "ecoActs", "total", "conDomCap"],
            HeadersTitle =

                [
                    "Any",
                    "Codi comarca",
                    "Comarca",
                    "Població",
                    "Domèstic xarxa",
                    "Activitats econòmiques i fonts pròpies",
                    "Total",
                    "Consum domèstic per càpita"
                ];
        const string Yes = "Sí",
            No = "No",
            ConstraindNumers = "Només nombres",
            ConstrintWhole = "Només Enters";

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

            for (int i = 0; i < HeadersTitle.Count; i++)
                dgvCounties.Columns.Add(HeadersName[i], HeadersTitle[i]);

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
                        .Where(
                            x =>
                                x.Year
                                == Convert.ToSingle(
                                    dgvCounties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
                                )
                        )
                        .Max(x => x.DomesticConsumptionPerCapita);

                    float minValue = counties
                        .Where(
                            x =>
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
                        .Where(
                            x =>
                                x.CountyName
                                == (string)dgvCounties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
                        )
                        .Max(x => x.DomesticConsumptionPerCapita);

                    float minValue = counties
                        .Where(
                            x =>
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
            List<TextBox> list = new List<TextBox>() { txtDX, txtCDC, txtAE, txtTotal };
            List<ComboBox> comboBoxes = new List<ComboBox>() { cbbYear, cbbCounty };
            errPro.Clear();

            bool AllCorrector = true;

            foreach (var item in list)
            {
                if (item.Text == string.Empty || !int.TryParse(item.Text, out int useless))
                {
                    errPro.SetError(item, "Només numeros");
                    AllCorrector = false;
                }
            }
            foreach (var item in comboBoxes)
            {
                if (item.Text == string.Empty)
                {
                    errPro.SetError(item, "Selecciona un valor");
                    AllCorrector = false;
                }
            }
            if (
                txtPopulation.Text == string.Empty
                || !int.TryParse(txtPopulation.Text, out int value)
                || txtPopulation.Text.Split(',').Length != 1
            )
            {
                errPro.SetError(txtPopulation, "Nomes numeros enters");
                AllCorrector = false;
            }

            if (AllCorrector)
            {
                Csv.Write(
                    new List<County>()
                    {
                        new County(
                            Convert.ToInt32(cbbYear.Text),
                            cbbCounty.SelectedIndex + 1,
                            cbbCounty.Text,
                            Convert.ToInt32(txtPopulation),
                            Convert.ToInt32(txtDX.Text),
                            Convert.ToInt32(txtAE),
                            Convert.ToInt32(txtTotal),
                            Convert.ToSingle(txtCDC)
                        )
                    }
                );
            }
            CleanInputs();
        }

        private void cbbCounty_SelectedValueChanged(object sender, EventArgs e) { }
    }
}
