using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ConsoleApp5.FuruHana
{
    public class Sprite2D
    {

        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Directory = "";
        public string Tag = "";
        public Bitmap Sprite = null;
        public bool IsReference = false;


        public Sprite2D(Vector2 Position, Vector2 Scale, String Directory, string Tag)
        {


            this.Position = Position;
            this.Scale = Scale;
            this.Directory = Directory;
            this.Tag = Tag;

            Image tmp = Image.FromFile($"assets/sprites/{Directory}.png");

            Bitmap sprite = new Bitmap(tmp);
            Sprite = sprite;


            Log.Info($"[Using FuruHana2D]({Tag})- Complete");

            furuhana.RegisterSprite(this);
        }
        public Sprite2D(bool IsReference, String Directory)
        {


            this.IsReference = IsReference;
            this.Directory = Directory;

            Image tmp = Image.FromFile($"assets/sprites/{Directory}.png");

            Bitmap sprite = new Bitmap(tmp);
            Sprite = sprite;


            Log.Info($"[Using FuruHana2D]({Tag})- Complete");

            furuhana.RegisterSprite(this);
        }



        public Sprite2D(Vector2 Position, Vector2 Scale, Sprite2D reference, string Tag)
        {


            this.Position = Position;
            this.Scale = Scale;
           
            this.Tag = Tag;

            Sprite = reference.Sprite;



            Log.Info($"[Using FuruHana2D]({Tag})- Complete");

            furuhana.RegisterSprite(this);
        }

        public Sprite2D(string Directory)
        {


            this.IsReference = true;
            this.Directory = Directory;
           

            Image tmp = Image.FromFile($"assets/sprites/{Directory}.png");

            Bitmap sprite = new Bitmap(tmp);
            Sprite = sprite;


            Log.Info($"[Using FuruHana2D]({Tag})- Complete");

            furuhana.RegisterSprite(this);
        }


        public bool IsColliding(Sprite2D a, Sprite2D b) 
            {
                if (a.Position.X < b.Position.X + b.Scale.X &&
               a.Position.X + a.Scale.X > b.Position.X &&
               a.Position.Y < b.Position.Y + b.Scale.Y &&
               a.Position.Y + a.Scale.Y > b.Position.Y)
                {
                    return true;
                }
                return false;
            }
        

        public Sprite2D IsColliding(string tag)
        {
            foreach(Sprite2D b in furuhana.AllSprites)
            {
                if(b.Tag == tag)
                {
                    if (Position.X < b.Position.X + b.Scale.X &&
                    Position.X + Scale.X > b.Position.X &&
                    Position.Y < b.Position.Y + b.Scale.Y &&
                    Position.Y + Scale.Y > b.Position.Y)
                    {
                        return b ;
                    }


                }
               

                    }

            return null;
        }

       




                public void DestroySelf()
        {
            furuhana.OnRegisterSprite(this);
        }
    }
}

