using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBGColor
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      
      Form1 form = new Form1();
      PictureBox pictureBox = new PictureBox();
      pictureBox.Dock = DockStyle.Fill;
      form.Controls.Add(pictureBox);
      form.StartPosition = FormStartPosition.CenterScreen;
      form.FormBorderStyle = FormBorderStyle.None;
      //form.WindowState = FormWindowState.Maximized;
      form.Show();
      
      Thread t = new Thread(() => LoopCool(pictureBox, form));
      t.Priority = ThreadPriority.Highest;
      t.Start();
      Application.Run(form);
    }

    static void LoopCool(PictureBox pictureBox, Form1 form)
    {
      while (true)
      {
        form.DoCoolStuff(pictureBox);
        //Thread.Sleep(10);
      }
    }
  }
}
