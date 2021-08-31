using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprite0.Contorllers;
using Sprite0.Sprites;

namespace Sprite0
{
    public class Mario : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private float marioSpeed;
        private int row = 1;
        private int column = 4;
        private SpriteFont font;

        private string info =
            "Credits: \nProgram Made By: Hongda Lin\nSprites from:http://www.mariouniverse.com \n/nwp-content/img/sprites/nes/smb/luigi.png";

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

        public Mario()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void InitializeStandingInPlaceMario()
        {
            standingInPlaceMarioPosition = new Vector2(_graphics.PreferredBackBufferWidth / 4,
                _graphics.PreferredBackBufferHeight / 4);
            standingInPlaceMarioTexture = Content.Load<Texture2D>("StandingInPlaceMario/StandingInPlaceMarioSprite");
            standingInPlaceMario = new StandingInPlaceMarioSprite(standingInPlaceMarioTexture, standingInPlaceMarioPosition);
        }

        public void InitializeRunningInPlaceMario()
        {
            runningInPlaceMarioPosition = new Vector2(_graphics.PreferredBackBufferWidth / 4 * 3,
                _graphics.PreferredBackBufferHeight / 4);
            runningInPlaceMarioTexture = Content.Load<Texture2D>("RunningInPlaceMario/RunningLeftAndRightMarioSprite");
            runningInPlaceMario = new RunningInPlaceMarioSprite(runningInPlaceMarioTexture, runningInPlaceMarioPosition, row, column);
        }

        public void InitializeDeadMovingUpAndDownMario()
        {
            deadMovingUpAndDownMarioPosition = new Vector2(_graphics.PreferredBackBufferWidth / 4,
                _graphics.PreferredBackBufferHeight / 4 * 3);
            deadMovingUpAndDownMarioTexture = Content.Load<Texture2D>("DeadMovingUpAndDownMario/DeadMovingUpAndDownMarioSprite");
            deadMovingUpAndDownMario = new DeadMovingUpAndDownMarioSprite(deadMovingUpAndDownMarioTexture, deadMovingUpAndDownMarioPosition, marioSpeed, _graphics.PreferredBackBufferHeight);
        }

        public void InitializeRunningLeftAndRightMario()
        {
            runningLeftAndRightMarioPosition = new Vector2(_graphics.PreferredBackBufferWidth / 4 * 3,
                _graphics.PreferredBackBufferHeight / 4 * 3);
            runningLeftAndRightMarioTexture = Content.Load<Texture2D>("RunningLeftAndRightMario/RunningLeftAndRightMarioSprite");
            runningLeftAndRightMario = new RunningLeftAndRightMarioSprite(runningLeftAndRightMarioTexture, runningLeftAndRightMarioPosition, row, column, marioSpeed, _graphics.PreferredBackBufferWidth);
        }

        protected override void Initialize()
        {
            marioSpeed = 0.8f;
            keyboardController = new KeyboardController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("TextInfo");
        }
        
        protected override void Update(GameTime gameTime)
        {
         
            keyboardController.Update();

            standingInPlaceMario.Update();
            runningInPlaceMario.Update();
            deadMovingUpAndDownMario.Update();
            runningLeftAndRightMario.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            standingInPlaceMario.Draw(_spriteBatch);
            runningInPlaceMario.Draw(_spriteBatch);
            deadMovingUpAndDownMario.Draw(_spriteBatch);
            runningLeftAndRightMario.Draw(_spriteBatch);

            _spriteBatch.DrawString(font, info, new Vector2((_graphics.PreferredBackBufferWidth - font.MeasureString(info).X)/2, 260), Color.Black);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
