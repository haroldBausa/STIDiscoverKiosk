using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace STIDiscover
{
    public partial class scheduleControl : UserControl
    {
        private Guna2Button currentBtn;
        private Guna2CustomGradientPanel leftBorderBtn;
        public scheduleControl()
        {
            InitializeComponent();
            leftBorderBtn = new Guna2CustomGradientPanel();
            leftBorderBtn.Size = new Size(7, 60);  // Adjust size as needed
            leftBorderBtn.Visible = false;  // Initially hidden
            this.Controls.Add(leftBorderBtn);
        }
        private void LoadDataToDataGridView(string tableName)
        {
            string connectionString = "Server=localhost;Database=schedules;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"SELECT course_des, days, time, room FROM {tableName}";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    guna2DataGridView1.DataSource = table;

                    // Optional: Adjust column headers for consistency
                    guna2DataGridView1.Columns[0].HeaderText = "Course Description";
                    guna2DataGridView1.Columns[1].HeaderText = "Days";
                    guna2DataGridView1.Columns[2].HeaderText = "Time";
                    guna2DataGridView1.Columns[3].HeaderText = "Room";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(255, 221, 0);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                //Button
                currentBtn = (Guna2Button)senderBtn;
                currentBtn.BackColor = Color.FromArgb(24, 49, 83);
                currentBtn.ForeColor = color;

                // Left border button (position it at the bottom of the button)
                leftBorderBtn.BackColor = color;

                // Set the leftBorderBtn location to be directly under the button
                leftBorderBtn.Size = new Size(currentBtn.Width, 7);  // Match the width of the button, 7px height
                leftBorderBtn.Location = new Point(currentBtn.Location.X, currentBtn.Location.Y + currentBtn.Height);  // Set at the bottom of the button
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(24, 49, 83);
                currentBtn.ForeColor = Color.Gainsboro;
            }
        }
        private void TogglePanelVisibility(Panel panelToShow, bool hideOthers = true)
        {
            if (hideOthers)
            {
                // Hide all panels
                panelSHS11.Visible = false;
                panelSHS12.Visible = false;
                panelBMMA.Visible = false;
                panelBSA.Visible = false;
                panelBSCPE.Visible = false;
                panelBSCS.Visible = false;
                panelBSHM.Visible = false;
                panelBSIT.Visible = false;
                panelSTEM.Visible = false;
                panelSTEM12.Visible = false;

                panelBMMA1st.Visible = false;
                panelBMMA2.Visible = false;
                panelBMMA3.Visible = false;
                panelBMMA4.Visible = false;

                panelBSA1.Visible = false;
                panelBSA2.Visible = false;
                panelBSA3.Visible = false;
                panelBSA4.Visible = false;

                panelBSCPE1.Visible = false;
                panelBSCPE2.Visible = false;
                panelBSCPE3.Visible = false;
                panelBSCPE4.Visible = false;

                panelBSCS1.Visible = false;
                panelBSCS2.Visible = false;
                panelBSCS3.Visible = false;
                panelBSCS4.Visible = false;

                panelBSHM1.Visible = false;
                panelBSHM2.Visible = false;
                panelBSHM3.Visible = false;
                panelBSHM4.Visible = false;

                panelBSIT1.Visible = false;
                panelBSIT2.Visible = false;
                panelBSIT3.Visible = false;
                panelBSIT4.Visible = false;
            }
            // Show the requested panel
            panelToShow.Visible = true;
        }
        private void ToggleBMMAVisibility(Panel panelToShow)
        {
            // Hide all BMMA submenus
            panelBMMA1st.Visible = false;
            panelBMMA2.Visible = false;
            panelBMMA3.Visible = false;
            panelBMMA4.Visible = false;

            // Show the requested submenu panel
            panelToShow.Visible = true;
        }
        private void ToggleBSAVisibility(Panel panelToShow)
        {
            panelBSA1.Visible = false;
            panelBSA2.Visible = false;
            panelBSA3.Visible = false;
            panelBSA4.Visible = false;

            panelToShow.Visible = true;
        }
        private void ToggleBSCPEVisibility(Panel panelToShow)
        {
            panelBSCPE1.Visible = false;
            panelBSCPE2.Visible = false;
            panelBSCPE3.Visible = false;
            panelBSCPE4.Visible = false;

            panelToShow.Visible = true;
        }
        private void ToggleBSCSVisibility(Panel panelToShow)
        {
            panelBSCS1.Visible = false;
            panelBSCS2.Visible = false;
            panelBSCS3.Visible = false;
            panelBSCS4.Visible = false;

            panelToShow.Visible = true;
        }
        private void ToggleBSHMVisibility(Panel panelToShow)
        {

            panelBSHM1.Visible = false;
            panelBSHM2.Visible = false;
            panelBSHM3.Visible = false;
            panelBSHM4.Visible = false;

            panelToShow.Visible = true;
        }
        private void ToggleBSITVisibility(Panel panelToShow)
        {
            panelBSIT1.Visible = false;
            panelBSIT2.Visible = false;
            panelBSIT3.Visible = false;
            panelBSIT4.Visible = false;

            panelToShow.Visible = true;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            TogglePanelVisibility(panelSHS11);
        }

        private void btnSHS12_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            TogglePanelVisibility(panelSHS12);
        }

        private void btnBMMA_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            TogglePanelVisibility(panelBMMA);
        }

        private void btnBSA_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            TogglePanelVisibility(panelBSA);
        }

        private void btnBSCPE_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            TogglePanelVisibility(panelBSCPE);
        }

        private void btnBSCS_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            TogglePanelVisibility(panelBSCS);
        }

        private void btnBSHM_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            TogglePanelVisibility(panelBSHM);
        }

        private void btnBSIT_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            TogglePanelVisibility(panelBSIT);
        }

        private void btnBSTM_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }

        private void scheduleControl_Load(object sender, EventArgs e)
        {

        }

        
        private void btnShowSTEM_Click(object sender, EventArgs e)
        {
            TogglePanelVisibility(panelSTEM, false);
        }

        private void btnShowSTEM12_Click(object sender, EventArgs e)
        {
            TogglePanelVisibility(panelSTEM12, false);
        }

        private void bmma1stYear_Click(object sender, EventArgs e)
        {
            ToggleBMMAVisibility(panelBMMA1st);

        }

        private void bmma2ndYear_Click(object sender, EventArgs e)
        {
            ToggleBMMAVisibility(panelBMMA2);
        }

        private void bmma3rdYear_Click(object sender, EventArgs e)
        {
            ToggleBMMAVisibility(panelBMMA3);
        }

        private void bmma4thYear_Click(object sender, EventArgs e)
        {
            ToggleBMMAVisibility(panelBMMA4);
        }

        private void bsa1stYear_Click(object sender, EventArgs e)
        {
            ToggleBSAVisibility(panelBSA1);
        }

        private void bsa2ndYear_Click(object sender, EventArgs e)
        {
            ToggleBSAVisibility(panelBSA2);
        }

        private void bsa3rdYear_Click(object sender, EventArgs e)
        {
            ToggleBSAVisibility(panelBSA3);
        }

        private void bsa4thYear_Click(object sender, EventArgs e)
        {
            ToggleBSAVisibility(panelBSA4);
        }

        private void bscpe1stYear_Click(object sender, EventArgs e)
        {
            ToggleBSCPEVisibility(panelBSCPE1);
        }

        private void bscpe2ndYear_Click(object sender, EventArgs e)
        {
            ToggleBSCPEVisibility(panelBSCPE2);
        }

        private void bscpe3rdYear_Click(object sender, EventArgs e)
        {
            ToggleBSCPEVisibility (panelBSCPE3);
        }

        private void bscpe4thYear_Click(object sender, EventArgs e)
        {
            ToggleBSCPEVisibility(panelBSCPE4);
        }

        

        private void bshm1stYear_Click(object sender, EventArgs e)
        {
            ToggleBSHMVisibility(panelBSHM1);
        }

        private void bshm2ndYear_Click(object sender, EventArgs e)
        {
            ToggleBSHMVisibility(panelBSHM2);
        }

        private void bshm3rdYear_Click(object sender, EventArgs e)
        {
            ToggleBSHMVisibility(panelBSHM3);
        }

        private void bshm4thYear_Click(object sender, EventArgs e)
        {
            ToggleBSHMVisibility(panelBSHM4);
        }

        private void bsit1stYear_Click(object sender, EventArgs e)
        {
            ToggleBSITVisibility(panelBSIT1);
        }

        private void bsit2ndYear_Click(object sender, EventArgs e)
        {
            ToggleBSITVisibility(panelBSIT2);
        }

        private void bsit3rdYear_Click(object sender, EventArgs e)
        {
            ToggleBSITVisibility(panelBSIT3);
        }

        private void bsit4thYear_Click(object sender, EventArgs e)
        {
            ToggleBSITVisibility(panelBSIT4);
        }

        private void bscs1stYear_Click(object sender, EventArgs e)
        {
            ToggleBSCSVisibility(panelBSCS1);
        }

        private void bscs2ndYear_Click(object sender, EventArgs e)
        {
            ToggleBSCSVisibility(panelBSCS2);
        }

        private void bscs3rdYear_Click(object sender, EventArgs e)
        {
            ToggleBSCSVisibility(panelBSCS3);
        }

        private void bscs4thYear_Click(object sender, EventArgs e)
        {
            ToggleBSCSVisibility(panelBSCS4);
        }
        private void btnShowABM_Click(object sender, EventArgs e)
        {
            lblshowSelected.Text = "ABM111-1A";
            LoadDataToDataGridView("abm111_1a");
            panelSHS11.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShowHUMMS_Click(object sender, EventArgs e)
        {
            lblshowSelected.Text = "HUMSS111-1A";
            LoadDataToDataGridView("humss111_1a");
            panelSHS11.Visible = false;
        }

        private void btnShowWEB_Click(object sender, EventArgs e)
        {

            lblshowSelected.Text = "WEB111-1A";
            LoadDataToDataGridView("web111_1a");
            panelSHS11.Visible = false;
        }

        private void btnShowTO_Click(object sender, EventArgs e)
        {
            lblshowSelected.Text = "TO111-1A";
            LoadDataToDataGridView("to111_1a");
            panelSHS11.Visible = false;
        }

        private void btnShowCA_Click(object sender, EventArgs e)
        {
            lblshowSelected.Text = "CA111-1A";
            LoadDataToDataGridView("ca111_1a");
            panelSHS11.Visible = false;
        }
        private void btnShowStem11A_Click(object sender, EventArgs e)
        {
            lblshowSelected.Text = "STEM111-1A";
            LoadDataToDataGridView("stem111_1a");
            panelSHS11.Visible = false;
            panelSTEM.Visible = false;
        }

        private void btnShowStem11B_Click(object sender, EventArgs e)
        {
            lblshowSelected.Text = "STEM111-1B";
            LoadDataToDataGridView("stem111_1b");
            panelSHS11.Visible = false;
            panelSTEM.Visible = false;
        }

        private void btnShowABM12_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("abm121_1a");
            panelSHS12.Visible = false;
            lblshowSelected.Text = "ABM121-1A";
        }
        private void btnShowTO12_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("to121_1a");
            panelSHS12.Visible = false;
            lblshowSelected.Text = "TO121-1A";
        }

        private void btnShowGAS12_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("gas121_1a");
            panelSHS12.Visible = false;
            lblshowSelected.Text = "GAS121-1A";
        }

        private void btnShowWEB12_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("web121_1a");
            panelSHS12.Visible = false;
            lblshowSelected.Text = "WEB121-1A";
        }

        private void btnShowHUMS12_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("humss121_1a");
            panelSHS12.Visible = false;
            lblshowSelected.Text = "HUMSS121-1A";
        }

        private void btnShowCA12_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("ca121_1a");
            panelSHS12.Visible = false;
            lblshowSelected.Text = "CA121-1A";
        }
        private void btnShowSTEM12A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("stem121_1a");
            panelSHS12.Visible = false;
            panelSTEM12.Visible = false;
            lblshowSelected.Text = "STEM121-1A";
        }

        private void btnShowSTEM12B_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("stem121_1b");
            panelSHS12.Visible = false;
            panelSTEM12.Visible = false;
            lblshowSelected.Text = "STEM121-1B";
        }

        private void btnBMMA1A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bmma101a");
            panelBMMA1st.Visible = false;
            panelBMMA.Visible = false;
            lblshowSelected.Text = "BMMA101A";
        }

        private void btnBMMA1P_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bmma101p");
            panelBMMA1st.Visible = false;
            panelBMMA.Visible = false;
            lblshowSelected.Text = "BMMA101P";
        }

        private void btnBMMA3A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bmma301a");
            panelBMMA2.Visible = false;
            panelBMMA.Visible = false;
            lblshowSelected.Text = "BMMA301A";
        }

        private void btnBMMA3P_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bmma301p");
            panelBMMA2.Visible = false;
            panelBMMA.Visible = false;
            lblshowSelected.Text = "BMMA301P";
        }

        private void btnBMMA501A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bmma501a");
            panelBMMA3.Visible = false;
            panelBMMA.Visible = false;
            lblshowSelected.Text = "BMMA501A";
        }

        private void btnBMMA501P_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bmma501p");
            panelBMMA3.Visible = false;
            panelBMMA.Visible = false;
            lblshowSelected.Text = "BMMA501P";
        }

        private void btnBMMA701A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bmma701a");
            panelBMMA4.Visible = false;
            panelBMMA.Visible = false;
            lblshowSelected.Text = "BMMA701A";
        }

        private void btnBSA701A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsa701a");
            panelBSA4.Visible = false;
            panelBSA.Visible = false;
            lblshowSelected.Text = "BSA701A";
        }

        private void btnBSA301A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsa301a");
            panelBSA2.Visible = false;
            panelBSA.Visible = false;
            lblshowSelected.Text = "BSA301A";
        }

        private void btnBSA501A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsa501a");
            panelBSA3.Visible = false;
            panelBSA.Visible = false;
            lblshowSelected.Text = "BSA501A";
        }

        private void btnBSA101A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsa101a");
            panelBSA1.Visible = false;
            panelBSA.Visible = false;
            lblshowSelected.Text = "BSA101A";
        }

        private void btnBSCPE101A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bscpe101a");
            panelBSCPE1.Visible = false;
            panelBSCPE.Visible = false;
            lblshowSelected.Text = "BSCPE101A";
        }

        private void btnBSCPE301A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bscpe301a");
            panelBSCPE2.Visible = false;
            panelBSCPE.Visible = false;
            lblshowSelected.Text = "BSCPE301A";
        }

        private void btnBSCPE501A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bscpe501a");
            panelBSCPE3.Visible = false;
            panelBSCPE.Visible = false;
            lblshowSelected.Text = "BSCPE501A";
        }

        private void btnBSCPE701A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bscpe701a");
            panelBSCPE4.Visible = false;
            panelBSCPE.Visible = false;
            lblshowSelected.Text = "BSCPE701A";
        }
        private void btnBSCS101A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bscs101a");
            panelBSCPE1.Visible = false;
            panelBSCS.Visible = false;
            lblshowSelected.Text = "BSCS101A";
        }

        private void btnBSCS301A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bscs301a");
            panelBSCS2.Visible = false;
            panelBSCS.Visible = false;
            lblshowSelected.Text = "BSCS301A";
        }

        private void btnBSCS501A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bscs501a");
            panelBSCS3.Visible = false;
            panelBSCS.Visible = false;
            lblshowSelected.Text = "BSCS501A";
        }
        private void btnBSCS701A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bscs701a");
            panelBSCS4.Visible = false;
            panelBSCS.Visible = false;
            lblshowSelected.Text = "BSCS701A";
        }

        private void btnBSHM101A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bshm101a");
            panelBSHM1.Visible = false;
            panelBSHM.Visible = false;
            lblshowSelected.Text = "BSHM101A";
        }

        private void btnBSHM101P_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bshm101p");
            panelBSHM1.Visible = false;
            panelBSHM.Visible = false;
            lblshowSelected.Text = "BSHM101P";
        }

        private void btnBSHM301A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bshm301a");
            panelBSHM2.Visible = false;
            panelBSHM.Visible = false;
            lblshowSelected.Text = "BSHM301A";
        }

        private void btnBSHM301E_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bshm301e");
            panelBSHM2.Visible = false;
            panelBSHM.Visible = false;
            lblshowSelected.Text = "BSHM301E";
        }
        private void btnBSHM301P_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bshm301p");
            panelBSHM2.Visible = false;
            panelBSHM.Visible = false;
            lblshowSelected.Text = "BSHM301P";
        }

        private void btnBSHM501A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bshm501a");
            panelBSHM3.Visible = false;
            panelBSHM.Visible = false;
            lblshowSelected.Text = "BSHM501A";
        }

        private void btnBSHM501P_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bshm501p");
            panelBSHM3.Visible = false;
            panelBSHM.Visible = false;
            lblshowSelected.Text = "BSHM501P";
        }

        private void btnBSHM701A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bshm701a");
            panelBSHM4.Visible = false;
            panelBSHM.Visible = false;
            lblshowSelected.Text = "BSHM701P";
        }

        private void btnBSHM701P_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bshm701e");
            panelBSHM4.Visible = false;
            panelBSHM.Visible = false;
            lblshowSelected.Text = "BSHM701P";
        }

        private void btnBSIT101A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsit101a");
            panelBSIT1.Visible = false;
            panelBSIT.Visible = false;
            lblshowSelected.Text = "BSIT101A";
        }

        private void btnBSIT101P_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsit101P");
            panelBSIT1.Visible = false;
            panelBSIT.Visible = false;
            lblshowSelected.Text = "BSIT101P";
        }

        private void btnBSIT301A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsit301a");
            panelBSIT2.Visible = false;
            panelBSIT.Visible = false;
            lblshowSelected.Text = "BSIT301A";
        }

        private void btnBSIT301E_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsit301e");
            panelBSIT2.Visible = false;
            panelBSIT.Visible = false;
            lblshowSelected.Text = "BSIT301E";
        }
        private void btnBSIT301P_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsit301p");
            panelBSIT2.Visible = false;
            panelBSIT.Visible = false;
            lblshowSelected.Text = "BSIT301P";
        }
        private void btnBSIT501A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsit501a");
            panelBSIT3.Visible = false;
            panelBSIT.Visible = false;
            lblshowSelected.Text = "BSIT501A";
        }

        private void btnBSIT501P_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsit501p");
            panelBSIT3.Visible = false;
            panelBSIT.Visible = false;
            lblshowSelected.Text = "BSIT501P";
        }

        private void btnBSIT701A_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsit701a");
            panelBSIT4.Visible = false;
            panelBSIT.Visible = false;
            lblshowSelected.Text = "BSIT701A";
        }

        private void btnBSIT701E_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView("bsit701p");
            panelBSIT4.Visible = false;
            panelBSIT.Visible = false;
            lblshowSelected.Text = "BSIT701P";
        }

        
    }

}
