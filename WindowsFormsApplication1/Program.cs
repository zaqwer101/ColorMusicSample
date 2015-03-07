using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Form myform = new Form();
            Button btn1 = new Button();
            FlowLayoutPanel panel = new FlowLayoutPanel();
            List<Button> btnlist = new List<Button>();
            int i = 0;
            Random rnd = new Random();
            for (int j=0;j<100;j++)
            {
                btnlist.Add(new Button());
                btnlist[j].Text = j + "";
                btnlist[j].MouseMove += new MouseEventHandler((object sender, MouseEventArgs e) =>
                {
                    //((Button)sender).Text = Convert.ToInt32(((Button)sender).Text) + 1 + "";
                    new Thread(() =>
                    {
                        while (true)
                        {
                            ((Button)sender).BackColor = System.Drawing.Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                            Thread.Sleep(1000);
                        }
                    }).Start();
                });
                panel.Controls.Add(btnlist[j]);

            }

            myform.Text = "My Window";
            //btn1.Text = "click me";
            //btn1.Width = 100;
            
            
            btn1.Click += new EventHandler((object sender, EventArgs e) =>
            {
                btn1.Text = "ты нажал " + (i++) + "раз";
            });

            //btn1.ForeColor = System.Drawing.
            myform.Size = new System.Drawing.Size(800, 600);
            panel.Size = myform.Size;

            //btn1.Left = myform.Width / 2;
            //btn1.Top = myform.Height / 2;
            //panel.FlowDirection = FlowDirection.BottomUp;
            //panel.Controls.Add(new Label());
            //panel.Controls.Add(btn1);
            //panel.Controls.Add(new Label());
            //panel.Controls.Add(new TextBox());
            //panel.Controls.Add(new Label());
            //panel.Controls.Add(new TrackBar());
            //panel.Controls.Add(new Label());
            //panel.Controls.Add(new NumericUpDown());
            myform.Controls.Add(panel);
            myform.ShowDialog();
        }
    }
}
