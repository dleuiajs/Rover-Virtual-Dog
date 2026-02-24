namespace VirtualDog
{
    internal static class Animation
    {
        static Random rnd = new Random();

        private static Image spriteSheet;
        private static int frameWidth = 80;
        private static int frameHeight = 80;
        private static int spacing = 1;

        private static int columns;
        private static int rows;

        private static int currentFrame = 0;
        private static System.Windows.Forms.Timer animationTimer;
        public static int animationSpeed = 120;

        public static event Action FrameChanged;

        private class AnimationPart
        {
            public int SlideStart { get; private set; }
            public int SlideEnd { get; private set; }

            public AnimationPart(int slideStart, int slideEnd)
            {
                SlideStart = slideStart - 1;
                SlideEnd = slideEnd - 1;
            }
        }

        private static Dictionary<string, AnimationPart> anims = new Dictionary<string, AnimationPart>()
        {
            { "idle_book", new AnimationPart(1, 56) },
            { "idle_bone", new AnimationPart(56, 150) },
            { "idle_looksAround1", new AnimationPart(150, 180) },
            { "idle_blinks", new AnimationPart(468, 470) },
            { "idle_looksAround2", new AnimationPart(468, 498) },
            { "idle_looksDown", new AnimationPart(658, 703) },
            { "jump_in", new AnimationPart(181, 303) },
            { "jump_out", new AnimationPart(304, 334) },
            { "shows_ball", new AnimationPart(335, 359) },
            { "shows_box", new AnimationPart(359, 403) },
            { "shows_suitcase", new AnimationPart(403, 423) },
            { "shows_money", new AnimationPart(423, 447) },
            { "shows_cinema", new AnimationPart(448, 467) },
            { "shows_red_box", new AnimationPart(586, 623) },
            { "shows_picture", new AnimationPart(624, 658) },
            { "sleep", new AnimationPart(499, 585) },
            { "sitting", new AnimationPart(1, 1) },
            { "sleeping", new AnimationPart(580, 580) },
            { "none", new AnimationPart(705, 705) },
        };

        private class QueueItem
        {
            public AnimationPart Anim;
            public int DelayAfter;

            public QueueItem(AnimationPart anim, int delayAfter = 0)
            {
                Anim = anim;
                DelayAfter = delayAfter;
            }
        }

        private static Queue<QueueItem> animQueue = new Queue<QueueItem>();
        private static CancellationTokenSource animationCTS;
        private static QueueItem currentQueueItem;

        public static void StartAnimRandomAction()
        {
            switch (rnd.Next(0, 8))
            {
                case 0:
                    StartAnimJump();
                    break;
                case 1:
                    StartAnim(anims["shows_ball"], true);
                    break;
                case 2:
                    StartAnim(anims["shows_box"], true);
                    break;
                case 3:
                    StartAnim(anims["shows_suitcase"], true);
                    break;
                case 4:
                    StartAnim(anims["shows_money"], true);
                    break;
                case 5:
                    StartAnim(anims["shows_cinema"], true);
                    break;
                case 6:
                    StartAnim(anims["shows_red_box"], true);
                    break;
                case 7:
                    StartAnim(anims["shows_picture"], true);
                    break;
            }
            //StartAnimIdleBlinksRnd();
        }

        private static void StartAnimJump()
        {
            StartAnim(anims["jump_out"], true);
            StartAnim(anims["none"], false, rnd.Next(500, 5000));
            StartAnim(anims["jump_in"], false);
        }

        public static void StartAnimIdle()
        {
            switch (rnd.Next(0, 5))
            {
                case 0:
                    StartAnim(anims["idle_book"], false);
                    StartAnimIdleBlinksRnd();
                    break;
                case 1:
                    StartAnim(anims["idle_bone"], false);
                    StartAnimIdleBlinksRnd();
                    break;
                case 2:
                    StartAnim(anims["sleep"], false);
                    StartAnim(anims["sleeping"], false, rnd.Next(30000, 120000));
                    break;
                case 3:
                    StartAnim(anims["idle_looksDown"], false);
                    StartAnimIdleBlinksRnd();
                    break;
                case 4:
                    StartAnim(anims["idle_blinks"], false);
                    StartAnimIdleBlinksRnd();
                    break;
            }
        }

        private static void StartAnimIdleBlinksRnd()
        {
            List<AnimationPart> rndAnims = new List<AnimationPart>() {
                anims["idle_looksAround1"],
                anims["idle_looksAround2"],
                anims["idle_looksDown"]
            };
            int count = rnd.Next(1, 4);
            for (int i = 0; i < count; i++)
            {
                StartAnim(anims["idle_blinks"], false, rnd.Next(animationSpeed * 11, animationSpeed * 13));

                if (rnd.Next(0, 5) == 0)
                {
                    AnimationPart rndAnim = rndAnims[rnd.Next(0, rndAnims.Count)];
                    StartAnim(rndAnim);
                    rndAnims.Remove(rndAnim);
                }
            }
        }

        public static void LoadSpriteSheet(Image sheet)
        {
            spriteSheet = sheet;

            columns = spriteSheet.Width / (frameWidth + spacing);
            rows = spriteSheet.Height / (frameHeight + spacing);
        }

        private static void StartAnim(AnimationPart animPart, bool skipPrev = true, int delayAfter = 0)
        {
            //MessageBox.Show(anims.FirstOrDefault(a => a.Value == animPart).Key);

            // если пропускаем пред. анимации, очищаем очередь и останавливаем анимацию
            if (skipPrev)
            {
                animQueue.Clear();
                if (animationTimer != null && animationTimer.Enabled)
                    animationTimer.Stop();
            }

            // кладем текущую анимацию в очередь
            animQueue.Enqueue(new QueueItem(animPart, delayAfter));

            if (animationTimer == null || !animationTimer.Enabled)
            {
                PlayNextAnim();
            }
        }

        private static void PlayNextAnim()
        {
            animationCTS?.Cancel();
            animationCTS = new CancellationTokenSource();
            if (animQueue.Count == 0)
            {
                StartAnimIdle();
                return;
            }

            var queueItem = animQueue.Dequeue();

            currentQueueItem = queueItem;

            currentFrame = queueItem.Anim.SlideStart;

            if (animationTimer == null || !animationTimer.Enabled)
            {
                animationTimer = new System.Windows.Forms.Timer();
                animationTimer.Interval = animationSpeed;

                animationTimer.Tick += AnimationTick;
            }

            animationTimer.Start();
        }

        private static async void AnimationTick(object sender, EventArgs e)
        {
            if (animationTimer == null || animationCTS == null)
                return;

            var token = animationCTS?.Token ?? CancellationToken.None;

            currentFrame++;
            if (currentFrame > currentQueueItem.Anim.SlideEnd)
            {
                animationTimer.Stop();
                try
                {
                    if (currentQueueItem.DelayAfter > 0)
                    {
                        await Task.Delay(currentQueueItem.DelayAfter, token);
                    }
                }
                catch (TaskCanceledException)
                {
                    return;
                }

                if (token.IsCancellationRequested)
                    return;

                PlayNextAnim();
                return;
            }
            FrameChanged?.Invoke();
        }

        public static void Draw(Graphics g)
        {
            if (spriteSheet == null)
                return;

            //int totalFrames = columns * rows;
            //if (currentFrame >= totalFrames)
            //    currentFrame = 0;

            int col = currentFrame % columns;
            int row = currentFrame / columns;

            int x = col * (frameWidth + spacing);
            int y = row * (frameHeight + spacing);

            Rectangle sourceRect = new Rectangle(
                x, y, frameWidth, frameHeight);

            Rectangle destRect = new Rectangle(0, 0, frameWidth, frameHeight);

            g.DrawImage(spriteSheet, destRect, sourceRect, GraphicsUnit.Pixel);
        }

    }
}
