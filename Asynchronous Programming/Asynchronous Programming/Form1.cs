using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Asynchronous_Programming.Module;
using System.Threading;
namespace Asynchronous_Programming
{
    public partial class Form1 : Form
    {
        private string apiURL;
        private CancellationTokenSource cancellationTokenSource;
        public Form1()
        {
            InitializeComponent();
            apiURL = "https://localhost:5001/api";
           // cancellationTokenSource = new CancellationTokenSource();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            pictureLoading.Visible = true;
            //Task.WhenAll
            // await new Task_WhenAll(apiURL).btnStart_Click();
            // limit amount concurrency
            // await new SemaphoreExample(apiURL).btnStart_Click();
            // Response Task.WhenAll
            // await new Response_Of_Task_WhenAll(apiURL).btnStart_Click();
            // Report progress
            //  await new Reporting_Progress(pgReport,apiURL).btnStart_Click();
            // Report progress inteval
            //await new Reporting_Progress_Intervals(pgReport, apiURL).btnStart_Click();
            // Cancellation_task
            //await new Cancelling_Tasks(pgReport, apiURL,this.cancellationTokenSource).btnStart_Click();
            // Cancellation loop
            //await new Cancelling_Loops(pgReport, apiURL, this.cancellationTokenSource).btnStart_Click();
            // Cancelation IAsyncEnumerable
             cancellationTokenSource = new CancellationTokenSource(); 
            await new Cancelling_Through_IAsyncEnumerable(cancellationTokenSource).btnStart_Click();
            cancellationTokenSource = null;
            pictureLoading.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}
