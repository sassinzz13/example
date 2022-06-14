using ConsoleApp5.FuruHana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class shapes2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = "";

        public shapes2D(Vector2 Position, Vector2 Scale, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            Log.Info($"[Using FuruHana2D]({Tag})- Complete");

            furuhana.RegisterShape(this);


           
        }
           public void DestroySelf()
        {
            Log.Info($"[Shape2d]({Tag})- has been Destroyed");
            furuhana.OnRegisterShape(this);
        }


    }
}
