using System;

using Android.App;
using Android.OS;
using Android.Widget;

namespace TicTacToe.Android
{
    using System.Collections.Generic;
    using System.Linq;

    using TicTacToe.Android.Score;

    [Activity(Label = "Tic Tac Toe")]
    public class GameActivity : Activity
    {
        public GameView GameView { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Game);

            GameView = this.FindViewById<GameView>(Resource.Id.GameView);

            Bundle extras = this.Intent.Extras;
            if (extras != null)
            {
                var gameMode = (GameMode)extras.GetInt("GameMode");

                GameView.GameMode = gameMode;
            }

            MapButtonToDelegate(Resource.Id.ScaleInButton, OnScaleIn);

            MapButtonToDelegate(Resource.Id.ScaleOutButton, OnScaleOut);

            MapButtonToDelegate(Resource.Id.MoveLeftButton, OnMoveLeft);

            MapButtonToDelegate(Resource.Id.MoveRightButton, OnMoveRight);

            MapButtonToDelegate(Resource.Id.MoveUpButton, OnMoveUp);

            MapButtonToDelegate(Resource.Id.MoveDownButton, OnMoveDown);

            MapButtonToDelegate(Resource.Id.MoveHomeButton, OnMoveHome);
        }

        private void MapButtonToDelegate(int id, EventHandler eventHandler)
        {
            var button = this.FindViewById<ImageButton>(id);

            if (button != null)
            {
                button.Click += (sender, args) =>
                    {
                        try
                        {
                            eventHandler.Invoke(sender, args);
                        }
                        catch (Exception ex)
                        {
                            GameView.ShowMessage(ex.Message);
                        }
                    };
            }
        }

        private void OnScaleIn(object sender, EventArgs e)
        {
            GameView.Game.Field.cellSize+=5;

            GameView.Invalidate();
        }

        private void OnScaleOut(object sender, EventArgs e)
        {
            GameView.Game.Field.cellSize-=5;

            GameView.Invalidate();
        }

        private void OnMoveLeft(object sender, EventArgs e)
        {
            GameView.Game.Field.Move(-1, 0);

            GameView.Invalidate();
        }

        private void OnMoveRight(object sender, EventArgs e)
        {
            GameView.Game.Field.Move(1, 0);

            GameView.Invalidate();
        }

        private void OnMoveUp(object sender, EventArgs e)
        {
            GameView.Game.Field.Move(0, -1);

            GameView.Invalidate();
        }

        private void OnMoveDown(object sender, EventArgs e)
        {
            GameView.Game.Field.Move(0, 1);

            GameView.Invalidate();
        }

        private void OnMoveHome(object sender, EventArgs e)
        {
            if ((GameView.Game.Field.Origin.X != 0) || 
                (GameView.Game.Field.Origin.Y != 0))
            {
                GameView.Game.MoveGameField(
                    GameView.Game.Field.Origin.X,
                    GameView.Game.Field.Origin.Y);

                GameView.Invalidate();
            }
        }

        public override void OnBackPressed()
        {
            try
            {
                 if (!GameView.Game._gameIsGoing && GameView.GameMode == GameMode.OnePlayer)
                {
                    var lastFigure = (GameView.Game.Field.Figures as IEnumerable<Figure>).LastOrDefault();

                    if (lastFigure != null)
                    {
                        var winner = lastFigure.Type == FigureType.X ? PlayerType.Player : PlayerType.Computer;

                        var repository = new ScoreRepository("score.xml");

                        var score = repository.Load();

                        score.GamesInfo.Add(
                            new GameInfo
                            {
                                GameMode = GameMode.OnePlayer,
                                Winner = winner
                            });

                        repository.Save(score);
                    }
                }

                base.OnBackPressed();
            }
            catch (Exception ex)
            {
                GameView.ShowMessage(ex.Message, this.BaseContext);
            }
        }
    }
}