using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


//build the engine
namespace ConsoleApp5.FuruHana
{
    public class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }
    public abstract class furuhana
    {
        private Vector2 ScreenSize = new Vector2(500, 500);
        private string Title = "Welcome";
        private Canvas Window = null;
        private Thread GameloopThread = null;


        public static List<shapes2D> AllShapes = new List<shapes2D>();
        public static List<Sprite2D> AllSprites = new List<Sprite2D>();

        public Color BackGroundColour = Color.Black;

        public Vector2 CameraZoom = new Vector2(1,1);
        public Vector2 CameraPosition = Vector2.Zero();
        public float CameraAngle = 0f;
        public furuhana(Vector2 ScreenSize, String Title)
        {
            Log.Info("Game is starting");


            this.ScreenSize = ScreenSize;
            this.Title = Title;

            Window = new Canvas();
            Window.Size = new Size((int)this.ScreenSize.X, (int)this.ScreenSize.Y);
            Window.Text = this.Title;
            Window.Paint += Renderer;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;
            Window.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Window.FormClosing += Window_FormClosing;



            GameloopThread = new Thread(GameLoop);
            GameloopThread.Start();

            Application.Run(Window);
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameloopThread.Abort();
        }
        private void Window_KeyDown(object sender,KeyEventArgs e)
        {
                 GetKeyDown(e);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }
        public static void RegisterShape(shapes2D shape)
        {
            AllShapes.Add(shape);
        }

        public static void RegisterSprite(Sprite2D sprite)
        {
            AllSprites.Add(sprite);
        }

        public static void OnRegisterShape(shapes2D shape)
        {
            AllShapes.Remove(shape);
        }

        public static void OnRegisterSprite(Sprite2D sprite)
        {
            AllSprites.Remove(sprite);
        }

        void GameLoop()
        {
            OnLoad();
            while (GameloopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }
                catch
                {
                    Log.Error("No Game Loaded Waiting for Game");
                }
            }
        }

                //our renderer
                private void Renderer(object sender, PaintEventArgs e)
                {
                    Graphics g = e.Graphics;
            g.Clear(BackGroundColour);

            g.TranslateTransform(CameraPosition.X, CameraPosition.Y);
            g.RotateTransform(CameraAngle);
            g.ScaleTransform(CameraZoom.X, CameraZoom.Y);

            try
            { 

            foreach (shapes2D shape in AllShapes) 
            {
                g.FillRectangle(new SolidBrush(Color.Blue), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
            }
            foreach (Sprite2D sprite in AllSprites)
            {
                    if(!sprite.IsReference)
                    {

                    
                g.DrawImage(sprite.Sprite, sprite.Position.X, sprite.Position.Y, sprite.Scale.X, sprite.Scale.Y);
            }
                    //left off
            }

            }
            catch
            {
 
            }
            



                }
        public abstract void OnLoad();//create sprites
        public abstract void OnUpdate();
        public abstract void OnDraw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);
      

    }
    

}
