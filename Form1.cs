using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
//using "\\buffalo.cs.fiu.edu\homes\Downloads\mixkit - arcade - retro - game - over - 213.wav";

namespace PA5_Draft
{
    public partial class MainForm : Form
    {
        private int Step = 1;
        private readonly SnakeGame Game;
        private int NumberOfApples = -1;
        Timer time1 = new Timer();
        public MainForm()
        {
            
            InitializeComponent();

            this.open2();
            Game = new SnakeGame(new System.Drawing.Point((Field.Width - 20) / 2, Field.Height / 2), 40, NumberOfApples, Field.Size);
            
            Field.Image = new Bitmap(Field.Width, Field.Height);
           
            Game.EatAndGrow += Game_EatAndGrow;
            Game.HitWallAndLose += Game_HitWallAndLose;
            Game.HitSnakeAndLose += Game_HitSnakeAndLose;
            
            time1.Enabled = true;
        }
        private void open2() {
            using (Form2 f2 = new Form2())
            {

                if (f2.ShowDialog() == DialogResult.OK)
                {
                    if (f2.numapples < 2) { NumberOfApples = 1; }
                    else
                    NumberOfApples = f2.numapples;
                }
            }
            
        }
        private void Game_HitWallAndLose()
        {
            System.Media.SoundPlayer player = new SoundPlayer(PA5_Draft.Properties.Resources.GameOver);
            player.Play();
            mainTimer.Stop();
            Field.Refresh();
            string message = "You ate " + size + " apples.";
            string title = "Game Over";
            MessageBox.Show(message, title);
        }
        private void Game_HitSnakeAndLose()
        { 
            System.Media.SoundPlayer player = new SoundPlayer(PA5_Draft.Properties.Resources.GameOver);
            player.Play();
            mainTimer.Stop();
            Field.Refresh();
            string message = "You ate "+size+" apples.";
            string title = "Game Over";
            MessageBox.Show(message, title);
        }
        
        private int size=0;
        private void Game_EatAndGrow()
        {
            System.Media.SoundPlayer player = new SoundPlayer(PA5_Draft.Properties.Resources.AppleAte);
            player.Play();
            size++;
            if (size % 10 == 0 && Step < 10) {Step++;
            progressBar1.Value = progressBar1.Value+10;
        }
          
        }
        int counter = 0;
     
     
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            

            if (NumberOfApples != -1)
            {
                Game.Move(Step);
                Field.Invalidate();
            }
            
        }

        private void Field_Paint(object sender, PaintEventArgs e)
        {
            if (time1.Interval % 100 < 50)
                counter++;
            Pen PenForObstacles = new Pen(Color.FromArgb(40,40,40),2);
            Pen PenForSnake = new Pen(Color.FromArgb(100, 100, 100), 2);
            Brush BackGroundBrush = new SolidBrush(Color.FromArgb(150, 250, 150));
            Brush AppleBrush = new SolidBrush(Color.FromArgb(250, 50, 50));
            using (Graphics g = Graphics.FromImage(Field.Image))
            {
                g.FillRectangle(BackGroundBrush,new Rectangle(0,0,Field.Width,Field.Height));
                // double Radius = (MaxRadius - MinRadius) * (Math.Sin(Counter * Math.PI / 40.0) + 1) / 2.0 + MinRadius;
                if (counter % 2 == 0)
                {
                    foreach (Point Apple in Game.Apples)
                        //  g.FillEllipse(AppleBrush, new Rectangle(Apple.X - (int)Math.Round(Radius),
                        //             Apple.Y - (int)Math.Round(Radius), 2 * (int)Math.Round(Radius), 2 * (int)Math.Round(Radius)));
                        g.FillEllipse(AppleBrush, new Rectangle(Apple.X - SnakeGame.AppleSize / 2, Apple.Y - SnakeGame.AppleSize / 2,
                         SnakeGame.AppleSize*2, SnakeGame.AppleSize*2));
                }
                else {
                    foreach (Point Apple in Game.Apples)
                        //  g.FillEllipse(AppleBrush, new Rectangle(Apple.X - (int)Math.Round(Radius),
                        //             Apple.Y - (int)Math.Round(Radius), 2 * (int)Math.Round(Radius), 2 * (int)Math.Round(Radius)));
                        g.FillEllipse(AppleBrush, new Rectangle(Apple.X - SnakeGame.AppleSize / 2, Apple.Y - SnakeGame.AppleSize / 2,
                         SnakeGame.AppleSize, SnakeGame.AppleSize));
                }
                foreach (LineSeg Obstacle in Game.Obstacles)
                    g.DrawLine(PenForObstacles, new System.Drawing.Point(Obstacle.Start.X, Obstacle.Start.Y)
                        , new System.Drawing.Point(Obstacle.End.X, Obstacle.End.Y));
                foreach (LineSeg Body in Game.SnakeBody)
                    g.DrawLine(PenForSnake, new System.Drawing.Point((int)Body.Start.X, (int)Body.Start.Y)
                        , new System.Drawing.Point((int)Body.End.X, (int)Body.End.Y));
            }

        }



        private void Snakes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Game.Move(Step, Direction.UP);
                    break;
                case Keys.Down:
                    Game.Move(Step, Direction.DOWN);
                    break;
                case Keys.Left:
                    Game.Move(Step, Direction.LEFT);
                    break;
                case Keys.Right:
                    Game.Move(Step, Direction.RIGHT);
                    break;
            }
        }

        private void Field_Click(object sender, EventArgs e)
        {
            if (NumberOfApples != -1)
                NumberOfApples = -1;
            else NumberOfApples = 1;
        }
    }
}
