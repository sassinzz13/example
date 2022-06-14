using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using ConsoleApp5.FuruHana;



namespace ConsoleApp5
{
    class Demo : FuruHana.furuhana
    {


        Sprite2D player;
        //Sprite2D player2;

        bool left;
        bool right;
        bool up;
        bool down;
        bool shoot;




        //the level creator
        Vector2 lastPos = Vector2.Zero();
        string[,] Map =
        {
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".","d",".","p",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },
                 {"g",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","g" },

        };

        //this starts our game engine
        //now announce this at main
        public Demo() : base(new Vector2(615, 515), "FuruHana Engine Built In C#")
        {




        }



        //will be used to load our sprites
        public override void OnLoad()
        {
            BackGroundColour = Color.Black;
            CameraZoom = new Vector2(.7f, .7f);
            Sprite2D groundRef = new Sprite2D("Background/bgs/background_0000");
            Sprite2D fire = new Sprite2D("Background/bgs/background_0000");
            Sprite2D bullet = new Sprite2D("bullets/bullet/bullet");


            //left off
            for (int i = 0; i < Map.GetLength(1); i++)
            {
                for (int f = 0; f < Map.GetLength(0); f++)//left off at game design
                {
                    if (Map[f, i] == "g")
                    {
                        new Sprite2D(new Vector2(i * 50, f * 50), new Vector2(50, 50), groundRef, "Ground");
                    }
                    if (Map[f, i] == "h")
                    {
                        new Sprite2D(new Vector2(i * 50, f * 50), new Vector2(25, 25), fire, "Fire");
                    }
                    if (Map[f, i] == "d")
                    {
                        new Sprite2D(new Vector2(i * 50, f * 50), new Vector2(25, 25), bullet, "bullet");
                    }

                    if (Map[f, i] == "p")
                    {
                        player = new Sprite2D(new Vector2(i * 100 + 50, f * 100 + 50), new Vector2(60, 60), "characters/Players/character_0000", "Player");
                    }


                    //player = new Sprite2D(new Vector2(30,30), new Vector2(60, 60), "characters/Players/character_0000", "Player");
                    // player2 = new Sprite2D(new Vector2(30, 30), new Vector2(100, 100), "charlie/circus/Charlie2", "Player2");
                }



                //player  = new shapes2D(new Vector2(10, 10),new Vector2(10,10), "Test");
                // player = new Sprite2D(new Vector2(10, 10),new Vector2(50,50), "characters/Players/character_0000", "Player");
            }

        }


        public override void OnDraw()
        {


        }

        int times = 0;

        public override void OnUpdate()
        {
            if (player == null)
                return;
            times++;
            if (up)
            {
                player.Position.Y -= 3f;
            }

            if (down)
            {
                player.Position.Y += 3f;
            }

            if (left)
            {
                player.Position.X -= 3f;
            }

            if (right)
            {
                player.Position.X += 3f;
            }
            Sprite2D Fire = player.IsColliding("Fire");
            if (Fire != null)
            {
                Fire.DestroySelf();
            }
            if (player.IsColliding("Ground") != null)
            {


                //Log.Info($"Colliding! {times}");
                //times++;
                // player.Position.X = lastPos.X;
                player.Position.Y = lastPos.Y;
            }
            else
            {

                lastPos.X = player.Position.X;
                lastPos.Y = player.Position.Y;
            }


            Sprite2D bullet = player.IsColliding("bullet");
            if (bullet != null)
            {
                bullet.DestroySelf();
            }
            if (player.IsColliding("bullet") != null)
            {


                //Log.Info($"Colliding! {times}");
                //times++;
                // player.Position.X = lastPos.X;
                player.Position.Y = lastPos.Y;
            }
            else
            {

                lastPos.X = player.Position.X;
                lastPos.Y = player.Position.Y;
            }

        }


        public override void GetKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                up = true;
            }

            if (e.KeyCode == Keys.S)
            {
                down = true;
            }

            if (e.KeyCode == Keys.A)
            {
                left = true;
            }

            if (e.KeyCode == Keys.D)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                shoot = true;
            }
        }

        private void GameLoop(KeyEventArgs e)
        {

        }

        public override void GetKeyUp(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.W)
            {
                up = false;
            }

            if (e.KeyCode == Keys.S)
            {
                down = false;
            }

            if (e.KeyCode == Keys.A)
            {
                left = false;
            }

            if (e.KeyCode == Keys.D)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                shoot = true;
            }

        }


    }

    }


