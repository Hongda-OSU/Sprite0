using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprite0.Contorllers;
using Sprite0.Sprites;

namespace Sprite0
{
    public class Mario : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // properties used for text 
        private SpriteFont font;
        private string info =
            "Credits: \nProgram Made By: Hongda Lin\nSprites from: http://www.mariouniverse.com \n/nwp-content/img/sprites/nes/smb/luigi.png";

        // properties used for sprite texture, position and animation
        private float marioSpeed;
        private int row = 1;
        private int column = 4;
        public static int screenWidth;
        public static int screenHeight;
        private Vector2 screenCenter;
        private Texture2D standingInPlaceMarioTexture;
        private Vector2 standingInPlaceMarioPosition;
        private Texture2D runningInPlaceMarioTexture;
        private Vector2 runningInPlaceMarioPosition;
        private Texture2D deadMovingUpAndDownMarioTexture;
        private Vector2 deadMovingUpAndDownMarioPosition;
        private Texture2D runningLeftAndRightMarioTexture;
        private Vector2 runningLeftAndRightMarioPosition;

        // properties with their interface type that used in Update and Draw method
        private ISprite currentMarioSprite;
        private List<IController> myController;

        public Mario()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            // set basic properties of MonoGame screen width and height
            screenWidth = _graphics.PreferredBackBufferWidth;
            screenHeight = _graphics.PreferredBackBufferHeight;
            screenCenter = new Vector2((float)screenWidth / 2, (float)screenHeight / 2);
        }

        // Initialize methods for different Sprites. Command classes will use these to set current Mario sprite, which is used in Update and Draw
        public void InitializeStandingInPlaceMario()
        {
            standingInPlaceMarioPosition = new Vector2((float)screenWidth / 4, (float)screenHeight / 4);
            currentMarioSprite = new StandingInPlaceMarioSprite(standingInPlaceMarioTexture, standingInPlaceMarioPosition);
        }

        public void InitializeRunningInPlaceMario()
        {
            runningInPlaceMarioPosition = new Vector2(screenWidth / 4 * 3, (float)screenHeight / 4);
            currentMarioSprite = new RunningInPlaceMarioSprite(runningInPlaceMarioTexture, runningInPlaceMarioPosition, row, column);
        }

        public void InitializeDeadMovingUpAndDownMario()
        {
            deadMovingUpAndDownMarioPosition = new Vector2((float)screenWidth / 4, screenHeight / 4 * 3);
            currentMarioSprite = new DeadMovingUpAndDownMarioSprite(deadMovingUpAndDownMarioTexture, deadMovingUpAndDownMarioPosition, marioSpeed, _graphics.PreferredBackBufferHeight);
        }

        public void InitializeRunningLeftAndRightMario()
        {
            runningLeftAndRightMarioPosition = new Vector2(screenWidth / 4 * 3, screenHeight / 4 * 3);
            currentMarioSprite = new RunningLeftAndRightMarioSprite(runningLeftAndRightMarioTexture, runningLeftAndRightMarioPosition, row, column, marioSpeed, _graphics.PreferredBackBufferWidth);
        }

        protected override void Initialize()
        {
            marioSpeed = 0.8f;
            myController = new List<IController>
            {
                // passing "this", which is current game state to each controller class
                new KeyboardController(this),
                new MouseController(this)
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // load sprite text and textures
            font = Content.Load<SpriteFont>("TextInfo");
            standingInPlaceMarioTexture = Content.Load<Texture2D>("StandingInPlaceMario/StandingInPlaceMarioSprite");
            runningInPlaceMarioTexture = Content.Load<Texture2D>("RunningInPlaceMario/RunningLeftAndRightMarioSprite");
            deadMovingUpAndDownMarioTexture = Content.Load<Texture2D>("DeadMovingUpAndDownMario/DeadMovingUpAndDownMarioSprite");
            runningLeftAndRightMarioTexture = Content.Load<Texture2D>("RunningLeftAndRightMario/RunningLeftAndRightMarioSprite");
            // This will initialize the currentMarioSprite to the center of the screen when the game starts, but may not be the best place to put it...
            currentMarioSprite = new StandingInPlaceMarioSprite(standingInPlaceMarioTexture, screenCenter);
        }
        
        protected override void Update(GameTime gameTime)
        {
            foreach (IController currentController in myController)
            {
                // Update controller base on user action 
                currentController.Update();
            }
            // Update current Mario sprite with a constant frame rate, which is 1/60 * 10 approximately
            currentMarioSprite.Update(gameTime.ElapsedGameTime.TotalSeconds * 10);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            // Draw different state of Mario base on current Mario sprite
            currentMarioSprite.Draw(_spriteBatch);
            // Draw text sprite on the screen
            _spriteBatch.DrawString(font, info, new Vector2((_graphics.PreferredBackBufferWidth - font.MeasureString(info).X)/2, 260), Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
