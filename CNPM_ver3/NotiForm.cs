using BLLL;
using DTOO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNPM_ver3
{
    public partial class NotiForm : Form
    {
        NotiBLL notiAccess = new NotiBLL();

        public NotiForm()
        {
            InitializeComponent();
        }

        private void NotiForm_Load(object sender, EventArgs e)
        {
            GetReceiveNoti();
            GetSendNoti();
        }

        private void GetReceiveNoti()
        {
            DataTable dt = notiAccess.GetNotiOfReceiver(Users.PK);
            if (dt != null)
            {
                dataGridView_receiveNoti.DataSource = dt;
            }
        }

        private void GetSendNoti()
        {
            DataTable dt = notiAccess.GetNotiOfSender(Users.PK);
            if (dt != null)
            {
                dataGridView_sendNoti.DataSource = dt;
            }
        }

        private void loadReceiver()
        {
            DataTable dt = notiAccess.GetNotiOfSender(Users.PK);
            foreach (DataRow receiver in dt.Rows)
            {
                comboBox_receiverOfNoti.Items.Add(receiver["N_R_ID"]);
            }
        }

        private void dataGridView_receiveNoti_Click(object sender, DataGridViewCellEventArgs e)
        {
            textBox_sender.Text = dataGridView_receiveNoti.CurrentRow.Cells["N_S_ID"].Value.ToString();
            dateTimePicker_sendDate.Value = (DateTime)dataGridView_receiveNoti.CurrentRow.Cells["N_DATE"].Value;
            textBox_content.Text = dataGridView_receiveNoti.CurrentRow.Cells["N_DES"].Value.ToString();
            String notiID = dataGridView_receiveNoti.CurrentRow.Cells["N_ID"].Value.ToString();

            // Update read notification
            if (!notiAccess.UpdateNotiRead(notiID, Users.PK))
            {
                MessageBox.Show("Fail to update read notification");
            }

            // Reload
            GetReceiveNoti();
        }
    }
}
