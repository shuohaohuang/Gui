namespace Gui
{
    public partial class Form1 : Form
    {
        public const string Year = "year",
            Code = "code",
            Name = "name",
            Population = "population",
            DomNet = "domNet",
            EcoActs = "ecoActs",
            Total = "total",
            ConDomCap = "conDomCap",
            YearCA = "Any",
            CountyCodeCA = "Codi comarca",
            CountyCA = "Comarca",
            PopulationCA = "Població",
            DomesticNetworkCA = "Domèstic xarxa",
            EconomicActivitiesCA = "Activitats econòmiques i fonts pròpies",
            TotalCA = "Total",
            DomesticConsumptionPerCapitaCA = "Consum domèstic per càpita",
            Yes = "Sí",
            No = "No",
            ConstraindNumers = "Només nombres",
            ConstraindEmpty = "SeleccionaValor",
            ConstrintWhole = "Només Enters",
            Spliter = ",";
        const int AvoidNegative = 0,
            Two = 2,
            One = 1,
            DomConCapCollunm = 7,
            YearColunm = 0,
            CountyColunm = 2,
            PopulationColunm = 3,
            DomConColunm = 4,
            MinPopulation = 200000,
            MaxYear = 2050;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<County> counties = Csv.ReadCounties().OrderBy(x => x.CountyCode).ToList();

            Dictionary<int, string> CountiesDic = new Dictionary<int, string>();

            for (int i = counties.Select(x => x.Year).Distinct().ToList().Min(); i <= MaxYear; i++)
                cbbYear.Items.Add(i);

            foreach (var x in counties)
                CountiesDic.TryAdd(x.CountyCode, x.CountyName);

            Xml.Create(CountiesDic);

            foreach (var x in Xml.Read())
                cbbCounty.Items.Add(x.Value);

            counties = Csv.ReadCounties().OrderBy(x => x.Year).ToList();

            dgvCounties.Columns.Add(Year, YearCA);
            dgvCounties.Columns.Add(Code, CountyCodeCA);
            dgvCounties.Columns.Add(Name, CountyCA);
            dgvCounties.Columns.Add(Population, PopulationCA);
            dgvCounties.Columns.Add(DomNet, DomesticNetworkCA);
            dgvCounties.Columns.Add(EcoActs, EconomicActivitiesCA);
            dgvCounties.Columns.Add(Total, TotalCA);
            dgvCounties.Columns.Add(ConDomCap, DomesticConsumptionPerCapitaCA);

            foreach (var x in counties)
            {
                int index = dgvCounties.Rows.Add();
                dgvCounties.Rows[index].Cells[Year].Value = x.Year;
                dgvCounties.Rows[index].Cells[Code].Value = x.CountyCode;
                dgvCounties.Rows[index].Cells[Name].Value = x.CountyName;
                dgvCounties.Rows[index].Cells[Population].Value = x.Population;
                dgvCounties.Rows[index].Cells[DomNet].Value = x.DomesticNetwork;
                dgvCounties.Rows[index].Cells[EcoActs].Value = x.EconomicActivities;
                dgvCounties.Rows[index].Cells[Total].Value = x.Total;
                dgvCounties.Rows[index].Cells[ConDomCap].Value = x.DomesticConsumptionPerCapita;
            }
        }

        private void dgvCounties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= AvoidNegative)
            {
                List<County> counties = Csv.ReadCounties();

                lblGb2_11.Text =
                    Convert.ToSingle(dgvCounties.Rows[e.RowIndex].Cells[PopulationColunm].Value)
                    > MinPopulation
                        ? Yes
                        : No;
                lblGb2_12.Text = Math.Round(
                        Convert.ToSingle(dgvCounties.Rows[e.RowIndex].Cells[DomConColunm].Value)
                            / Convert.ToSingle(
                                dgvCounties.Rows[e.RowIndex].Cells[PopulationColunm].Value
                            ),
                        Two
                    )
                    .ToString();
                if (e.ColumnIndex == YearColunm)
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
                        dgvCounties.Rows[e.RowIndex].Cells[DomConCapCollunm].Value
                    );
                    lblGb2_13.Text = maxValue == currentValue ? Yes : No;
                    lblGb2_14.Text = minValue == currentValue ? Yes : No;
                }

                if (e.ColumnIndex == CountyColunm)
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
                        dgvCounties.Rows[e.RowIndex].Cells[DomConCapCollunm].Value
                    );

                    lblGb2_13.Text = currentValue == maxValue ? Yes : No;
                    lblGb2_14.Text = currentValue == minValue ? Yes : No;
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
                    item.Text = string.Empty;
                    errPro.SetError(item, ConstraindNumers);
                    AllCorrector = false;
                }
            }
            foreach (var item in comboBoxes)
            {
                if (item.Text == string.Empty)
                {
                    errPro.SetError(item, ConstraindEmpty);
                    AllCorrector = false;
                }
            }
            if (
                txtPopulation.Text == string.Empty
                || !int.TryParse(txtPopulation.Text, out int value)
                || txtPopulation.Text.Split(Spliter).Length != One
            )
            {
                txtPopulation.Text = string.Empty;
                errPro.SetError(txtPopulation, ConstrintWhole);
                AllCorrector = false;
            }

            if (AllCorrector)
            {
                int year = Convert.ToInt32(cbbYear.Text),
                    population = Convert.ToInt32(txtPopulation.Text),
                    dX = Convert.ToInt32(txtDX.Text),
                    aE = Convert.ToInt32(txtAE.Text),
                    total = Convert.ToInt32(txtTotal.Text),
                    cDC = Convert.ToInt32(txtCDC.Text),
                    code = cbbCounty.SelectedIndex + One;
                string county = cbbCounty.Text.ToString();

                int index = dgvCounties.Rows.Add();
                dgvCounties.Rows[index].Cells[Year].Value = year;
                dgvCounties.Rows[index].Cells[Code].Value = code;
                dgvCounties.Rows[index].Cells[Name].Value = county;
                dgvCounties.Rows[index].Cells[Population].Value = population;
                dgvCounties.Rows[index].Cells[DomNet].Value = dX;
                dgvCounties.Rows[index].Cells[EcoActs].Value = aE;
                dgvCounties.Rows[index].Cells[Total].Value = total;
                dgvCounties.Rows[index].Cells[ConDomCap].Value = cDC;
                Csv.Write(
                    new List<County>()
                    {
                        new County(year, code, county, population, dX, aE, total, cDC)
                    }
                );
                CleanInputs();
            }
        }

        private void cbbCounty_SelectedValueChanged(object sender, EventArgs e) { }
    }
}
