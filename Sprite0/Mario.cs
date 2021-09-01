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

        private SpriteFont font;
        public static Mario self;

        private float marioSpeed;
        private const int row = 1;
        private const int column = 4;
        public static int screenWidth;
        public static int screenHeight;
        private Vector2 screenCenter;

        private string info =
            "Credits: \nProgram Made By: Hongda Lin\nSprites from:http://www.mariouniverse.com \n/nwp-content/img/sprites/nes/smb/luigi.png";

        private Texture2D standingInPlaceMarioTexture;
        private Vector2 standingInPlaceMarioPosition;
        private Texture2D runningInPlaceMarioTexture;
        private Vector2 runningInPlaceMarioPosition;
        private Texture2D deadMovingUpAndDownMarioTexture;
        private Vector2 deadMovingUpAndDownMarioPosition;
        private Texture2D runningLeftAndRightMarioTexture;
        private Vector2 runningLeftAndRightMarioPosition;

        private ISprite currentMarioSprite;
        private IController keyboardController;
        private IController mouseController;

        public Mario()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            screenWidth = _graphics.PreferredBackBufferWidth;
            screenHeight = _graphics.PreferredBackBufferHeight;
            screenCenter = new Vector2((float)screenWidth / 2, (float)screenHeight / 2);
            self = this;
        }

        // Initialize methods for different Sprites, used in Command classes
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
            keyboardController = new KeyboardController();
            mouseController = new MouseController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("TextInfo");

            standingInPlaceMarioTexture = Content.Load<Texture2D>("StandingInPlaceMario/StandingInPlaceMarioSprite");
            runningInPlaceMarioTexture = Content.Load<Texture2D>("RunningInPlaceMario/RunningLeftAndRightMarioSprite");
            deadMovingUpAndDownMarioTexture = Content.Load<Texture2D>("DeadMovingUpAndDownMario/DeadMovingUpAndDownMarioSprite");
            runningLeftAndRightMarioTexture = Content.Load<Texture2D>("RunningLeftAndRightMario/RunningLeftAndRightMarioSprite");

            currentMarioSprite = new StandingInPlaceMarioSprite(standingInPlaceMarioTexture, screenCenter);
        }
        
        protected override void Update(GameTime gameTime)
        {
            keyboardController.Update();
            mouseController.Update();
            currentMarioSprite.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            currentMarioSprite.Draw(_spriteBatch);
            _spriteBatch.DrawString(font, info, new Vector2((_graphics.PreferredBackBufferWidth - font.MeasureString(info).X)/2, 260), Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
