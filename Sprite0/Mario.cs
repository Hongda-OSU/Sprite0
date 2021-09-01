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

        private float Speed;
        private const int Row = 1;
        private const int Column = 4;
        private SpriteFont font;
        private int CurrentSprite;

        public static Mario self;
        public static int ScreenWidth;
        public static int ScreenHeight;

        private string info =
            "Credits: \nProgram Made By: Hongda Lin\nSprites from:http://www.mariouniverse.com \n/nwp-content/img/sprites/nes/smb/luigi.png";

        private ISprite initialStateMario;
        private Vector2 initialStateMarioPosition;

        private Texture2D standingInPlaceMarioTexture;
        private ISprite standingInPlaceMario;
        private Vector2 standingInPlaceMarioPosition;

        private Texture2D runningInPlaceMarioTexture;
        private ISprite runningInPlaceMario;
        private Vector2 runningInPlaceMarioPosition;

        private Texture2D deadMovingUpAndDownMarioTexture;
        private ISprite deadMovingUpAndDownMario;
        private Vector2 deadMovingUpAndDownMarioPosition;

        private Texture2D runningLeftAndRightMarioTexture;
        private ISprite runningLeftAndRightMario;
        private Vector2 runningLeftAndRightMarioPosition;

        private IController keyboardController;
        private IController mouseController;

        public Mario()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            ScreenWidth = _graphics.PreferredBackBufferWidth;
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            self = this;
        }

        // Initialize methods for different Sprites, used in Command classes
        public void InitializeStandingInPlaceMario()
        {
            standingInPlaceMarioPosition = new Vector2(ScreenWidth / 4, ScreenHeight / 4);
            standingInPlaceMario = new StandingInPlaceMarioSprite(standingInPlaceMarioTexture, standingInPlaceMarioPosition);
        }

        public void InitializeRunningInPlaceMario()
        {
            runningInPlaceMarioPosition = new Vector2(ScreenWidth / 4 * 3, ScreenHeight / 4);
            runningInPlaceMario = new RunningInPlaceMarioSprite(runningInPlaceMarioTexture, runningInPlaceMarioPosition, Row, Column);
        }

        public void InitializeDeadMovingUpAndDownMario()
        {
            deadMovingUpAndDownMarioPosition = new Vector2(ScreenWidth / 4, ScreenHeight / 4 * 3);
            deadMovingUpAndDownMario = new DeadMovingUpAndDownMarioSprite(deadMovingUpAndDownMarioTexture, deadMovingUpAndDownMarioPosition, Speed, _graphics.PreferredBackBufferHeight);
        }

        public void InitializeRunningLeftAndRightMario()
        {
            runningLeftAndRightMarioPosition = new Vector2(ScreenWidth / 4 * 3, ScreenHeight / 4 * 3);
            runningLeftAndRightMario = new RunningLeftAndRightMarioSprite(runningLeftAndRightMarioTexture, runningLeftAndRightMarioPosition, Row, Column, Speed, _graphics.PreferredBackBufferWidth);
        }

        public void SetCurrentSprite(int spriteNumber)
        {
            CurrentSprite = spriteNumber;
        }

        protected override void Initialize()
        {
            Speed = 0.8f;
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


            initialStateMarioPosition = new Vector2(ScreenWidth / 2, ScreenHeight / 2);
            initialStateMario = new StandingInPlaceMarioSprite(standingInPlaceMarioTexture, initialStateMarioPosition);
        }
        
        protected override void Update(GameTime gameTime)
        {
            keyboardController.Update();
            mouseController.Update();
            switch (CurrentSprite)
            {
                case 0:
                    initialStateMario.Update();
                    break;
                case 1:
                    standingInPlaceMario.Update();
                    break;
                case 2:
                    runningInPlaceMario.Update();
                    break;
                case 3:
                    deadMovingUpAndDownMario.Update();
                    break;
                case 4:
                    runningLeftAndRightMario.Update();
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            switch (CurrentSprite)
            {
                case 0:
                    initialStateMario.Draw(_spriteBatch);
                    break;
                case 1:
                    standingInPlaceMario.Draw(_spriteBatch);
                    break;
                case 2:
                    runningInPlaceMario.Draw(_spriteBatch);
                    break;
                case 3:
                    deadMovingUpAndDownMario.Draw(_spriteBatch);
                    break;
                case 4:
                    runningLeftAndRightMario.Draw(_spriteBatch);
                    break;
            }
            _spriteBatch.DrawString(font, info, new Vector2((_graphics.PreferredBackBufferWidth - font.MeasureString(info).X)/2, 260), Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
