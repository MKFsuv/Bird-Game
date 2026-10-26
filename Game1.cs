using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq.Expressions;

namespace Bird_Game
{
    public class Game1 : Game
    {
        //Gravity shit
        float gravity = 300;
        float jumpStrength = 150;
        bool isGrounded = false;

        //Sprites
        SpriteBatch spriteBatch;
        Texture2D IslandMap;
        Texture2D PurpleSparrow;
        private SpriteBatch _spriteBatch;


        //Class fetches
        PurpleSparrow sparrow = new PurpleSparrow();
        Island island = new Island();


        private GraphicsDeviceManager _graphics;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1800;
            _graphics.PreferredBackBufferHeight = 1200;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        //This part is used to create the sprites

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            IslandMap = new Texture2D(GraphicsDevice, 1, 1);
            IslandMap.SetData(new[] { Color.LawnGreen });

            PurpleSparrow = new Texture2D(GraphicsDevice, 1, 1);
            PurpleSparrow.SetData(new[] { Color.Purple });


            spriteBatch = new SpriteBatch(GraphicsDevice);
        }


        //Logic of the game goes here 

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Rectangle IslandHitbox = new Rectangle(500, 600, 800, 100);
            Rectangle SparrowHitbox = new Rectangle((int)sparrow.x, (int)sparrow.y, 50, 50);


            KeyboardState keyboard = Keyboard.GetState();


            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (SparrowHitbox.Intersects(IslandHitbox) && sparrow.speed > 0)
            {
                sparrow.y = 550;
                sparrow.speed = 0;
                isGrounded = true;
            }


            sparrow.speed += gravity * deltaTime;

            sparrow.y += sparrow.speed * deltaTime;

            // BirdMovement is the one Bellow (Jump, side to side
            { 
            if (keyboard.IsKeyDown(Keys.W) && isGrounded)
            {
                sparrow.y -= jumpStrength;
                isGrounded = false;

            }

            if (keyboard.IsKeyDown(Keys.D))
            {
                sparrow.x += sparrow.sidespeed;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                sparrow.x -= sparrow.sidespeed;
            }
        }


            base.Update(gameTime);
        }

        //Visual area where I load in the sprites

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            spriteBatch.Draw(IslandMap, new Rectangle(500, 600, 800, 100), Color.LawnGreen);
            spriteBatch.Draw(PurpleSparrow, new Rectangle((int) sparrow.x, (int) sparrow.y, 50, 50), Color.Purple);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
