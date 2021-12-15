using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MineSweeper
{
    public partial class Form2 : Form
        
    {
        
        private Stopwatch stopWatch;
        public Form2()
        {
            InitializeComponent();
            stopWatch = new Stopwatch();
            stopWatch.Start();

            //     this.label1.Text = stopWatch.Elapsed.ToString();

        }

        int countmine = 0;
        public Form2(String text, int row, int col, int size, int mines, String Name) : this()
        {
            countmine = mines;
            this.label5.Text = "Player: " + Name;
            this.label3.Text = countmine.ToString();
            this.Text = text;
            field = new Field(row, col, mines);
            this.ClientSize = new Size(row * size, 50+col * size); 
            buttons = new Button[row][];
            for (int i = 0; i < row; i++)
                buttons[i] = new Button[col];
            foreach (int i in Enumerable.Range(0, row))
                foreach (int j in Enumerable.Range(0, col))
                {
                    this.label1.Text = stopWatch.Elapsed.ToString();
                    buttons[i][j] = new Button();
                    buttons[i][j].Text = "";
                    buttons[i][j].BackColor = Color.White;
                    buttons[i][j].Name = i + "," + j;
                    buttons[i][j].Size = new Size(size, size);
                    buttons[i][j].Location = new Point(size * i, 50+size * j);
                    buttons[i][j].UseVisualStyleBackColor = false;
                    buttons[i][j].MouseUp += new MouseEventHandler(Button_Click);
                    this.Controls.Add(buttons[i][j]);
                }
        }
        private void Button_Click(object sender, MouseEventArgs e)
        {
            this.label1.Text = stopWatch.Elapsed.ToString();
            Button b = (Button)sender;
            int temp = b.Name.IndexOf(",");
            int click_x = Int16.Parse(b.Name.Substring(0, temp));
            int click_y = Int16.Parse(b.Name.Substring(temp + 1));
            switch (e.Button)
            {
                case MouseButtons.Left:
                    // Left click
                 //   if (done == 1) { this.Close(); }
                    if (!this.field.Started)
                        this.field.Initialize(click_x, click_y);
                    int n = this.field.CountMines(click_x, click_y);
                    if (this.field.IsMine(click_x, click_y))
                    {
                        b.BackColor = Color.Red;
                        MessageBox.Show("Game Over! You clicked on a mine!");
                        this.Close();
                        break;
                    }
                    if (this.field.Discovered.Contains(click_x * buttons[0].Length + click_y))
                        break;
                    foreach (int k in this.field.GetSafeIsland(click_x, click_y))
                    {
                        int i = k / buttons[0].Length;
                        int j = k % buttons[0].Length;
                        buttons[i][j].BackColor = Color.LightGray;
                        int m = this.field.CountMines(i, j);
                        if (m == 1)
                        {
                            buttons[i][j].Text = m + "";
                            buttons[i][j].BackColor = Color.LightBlue;
                            buttons[i][j].ForeColor = Color.DarkBlue;
                            buttons[i][j].Font = new Font(Font.FontFamily, 12);
                        }
                        else if (m ==2)
                        {
                            buttons[i][j].Text = m + "";
                            buttons[i][j].BackColor = Color.LightBlue;
                            buttons[i][j].ForeColor = Color.DarkGreen;
                            buttons[i][j].Font = new Font(Font.FontFamily, 12);
                        }
                        else if (m == 3)
                        {
                            buttons[i][j].Text = m + "";
                            buttons[i][j].BackColor = Color.LightBlue;
                            buttons[i][j].ForeColor = Color.Orange;
                            buttons[i][j].Font = new Font(Font.FontFamily, 12);
                        }
                        else if (m > 3)
                        {
                            buttons[i][j].Text = m + "";
                            buttons[i][j].BackColor = Color.LightBlue;
                            buttons[i][j].ForeColor = Color.DarkRed;
                            buttons[i][j].Font = new Font(Font.FontFamily, 12);
                        }
                        else
                            buttons[i][j].Enabled = false;
                    }
                    if (field.Win())
                    {
                        MessageBox.Show("Congratulations! You won! Your time was: "+stopWatch.Elapsed.ToString()+"  Press ok to exit.");
                        this.Close();
                    }
                    break;
                case MouseButtons.Right:
                    // Right click
                    if (this.field.Discovered.Contains(click_x * buttons[0].Length + click_y))
                        break;
                    if (field.Flagged.Contains(click_x * buttons[0].Length + click_y))
                    {
                        b.BackColor = Color.White;
                        field.Flagged.Remove(click_x * buttons[0].Length + click_y);
                    }
                    else
                    {
                        b.BackColor = Color.LightGray;
                        b.Text = "F";
                        b.Font = new Font(Font.FontFamily, 12);
                        b.ForeColor = Color.Red;
                        field.Flagged.Add(click_x * buttons[0].Length + click_y);
                        countmine = countmine - 1;
                        label3.Text = countmine.ToString();
                    }
                    break;
                case MouseButtons.Middle:
                    if (!this.field.Discovered.Contains(click_x * buttons[0].Length + click_y))
                        break;
                    int Flagged_Count = 0;
                    foreach (int k in this.field.GetNeighbors(click_x, click_y))
                        if (field.Flagged.Contains(k))
                            Flagged_Count++;
                    if (this.field.CountMines(click_x, click_y) != Flagged_Count)
                        break;
                    foreach (int k in this.field.GetNeighbors(click_x, click_y))
                    {
                        if (field.Flagged.Contains(k) || field.Discovered.Contains(k))
                            continue;
                        if (this.field.IsMine(k / buttons[0].Length, k % buttons[0].Length))
                        {
                            b.BackColor = Color.Red;
                            
                            MessageBox.Show("Game Over! You clicked on a mine!");//,
                            this.Close();

                            break;
                        }
                        foreach (int l in this.field.GetSafeIsland(k / buttons[0].Length, k % buttons[0].Length))
                        {
                            int i = l / buttons[0].Length;
                            int j = l % buttons[0].Length;
                            buttons[i][j].BackColor = Color.LightGray;
                            int m = this.field.CountMines(i, j);
                            if (m > 0)
                            {
                                buttons[i][j].Text = m + "";
                                buttons[i][j].BackColor = Color.LightBlue;
                            }
                            
                            else
                                buttons[i][j].Enabled = false;
                        }
                        if (field.Win())
                        { MessageBox.Show("Congratulations! You won! Your time was: "+ stopWatch.Elapsed.ToString()+"  Press ok to exit");
                            this.Close();   
                        }
                    }
                    
                    break;
            }
            


        }
        
            
        
        private Button[][] buttons;
        private Field field;

        
    }
}
