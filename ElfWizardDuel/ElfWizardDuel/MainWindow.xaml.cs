using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ElfWizardDuel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DirectoryInfo> imagesFoldersLocations;
        List<string> dicesSources;
        List<string> elfAttackSources;
        List<string> elfDieSources;
        List<string> elfHurtSources;
        List<string> elfWalkSources;
        List<string> wizardAttackSources;
        List<string> wizardDieSources;
        List<string> wizardHurtSources;
        List<string> wizardWalkSources;
        ScaleTransform flipTrans;
        Image wizardImage;
        Image elfImage;
        int elfLife;
        int wizardLife;
        int currentImageIndex = 0;
        int animationCount = 0;
        int roundNumber;
        string userCharacterChoice;
        ImageBrush brush;
        Storyboard storyBoard;
        DoubleAnimation wizardDoubleAnimation;
        DoubleAnimation elfDoubleAnimation;
        DispatcherTimer timer;
        Random generator;
        bool machineRoundOn;

        public MainWindow()
        {
            InitializeComponent();
            CreateImageSources();
            Start();
        }

        void CreateImageSources()
        {
            string currentDirectory = Environment.CurrentDirectory;
            DirectoryInfo backgroundLocation = new DirectoryInfo(currentDirectory + "\\ElfWizardDuel\\Images");
            List<string> background = Directory.GetFiles(backgroundLocation.FullName).ToList();
            brush = new ImageBrush();
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Source = new BitmapImage(new Uri(background[0], UriKind.Relative));
            brush.ImageSource = image.Source;
            this.Background = brush;

            imagesFoldersLocations = new List<DirectoryInfo>();

            DirectoryInfo dicesLocation = new DirectoryInfo(currentDirectory + "\\Images\\Dices");
            imagesFoldersLocations.Add(dicesLocation);
            DirectoryInfo elfAttackLocation = new DirectoryInfo(currentDirectory + "\\Images\\ElfAttack");
            imagesFoldersLocations.Add(elfAttackLocation);
            DirectoryInfo elfDieLocation = new DirectoryInfo(currentDirectory + "\\Images\\ElfDie");
            imagesFoldersLocations.Add(elfDieLocation);
            DirectoryInfo elfHurtLocation = new DirectoryInfo(currentDirectory + "\\Images\\ElfHurt");
            imagesFoldersLocations.Add(elfHurtLocation);
            DirectoryInfo elfWalkLocation = new DirectoryInfo(currentDirectory + "\\Images\\ElfWalk");
            imagesFoldersLocations.Add(elfWalkLocation);
            DirectoryInfo wizardAttackLocation = new DirectoryInfo(currentDirectory + "\\Images\\WizardAttack");
            imagesFoldersLocations.Add(wizardAttackLocation);
            DirectoryInfo wizardDieLocation = new DirectoryInfo(currentDirectory + "\\Images\\WizardDie");
            imagesFoldersLocations.Add(wizardDieLocation);
            DirectoryInfo wizardHurtLocation = new DirectoryInfo(currentDirectory + "\\Images\\WizardHurt");
            imagesFoldersLocations.Add(wizardHurtLocation);
            DirectoryInfo wizardWalkLocation = new DirectoryInfo(currentDirectory + "\\Images\\WizardWalk");
            imagesFoldersLocations.Add(wizardWalkLocation);

            dicesSources = Directory.GetFiles(imagesFoldersLocations[0].FullName).ToList();
            elfAttackSources = Directory.GetFiles(imagesFoldersLocations[1].FullName).ToList();
            elfDieSources = Directory.GetFiles(imagesFoldersLocations[2].FullName).ToList();
            elfHurtSources = Directory.GetFiles(imagesFoldersLocations[3].FullName).ToList();
            elfWalkSources = Directory.GetFiles(imagesFoldersLocations[4].FullName).ToList();
            wizardAttackSources = Directory.GetFiles(imagesFoldersLocations[5].FullName).ToList();
            wizardDieSources = Directory.GetFiles(imagesFoldersLocations[6].FullName).ToList();
            wizardHurtSources = Directory.GetFiles(imagesFoldersLocations[7].FullName).ToList();
            wizardWalkSources = Directory.GetFiles(imagesFoldersLocations[8].FullName).ToList();
        }

        void Start()
        {
            mainLabel.Content = "MEET YOUR FAITH IN THE ENCHANTED FOREST!";
            mainSecondLabel.Tag = "Starter";
            mainSecondLabel.Content = "CHOOSE YOUR CHARACTER!";

            button1.Tag = "Visible";
            button2.Tag = "Visible";
            diceImage.Tag = "Hidden";
            diceButton.Tag = "Hidden";
            fightAgainButton.Tag = "Hidden";
            exitButton.Tag = "Hidden";
            elfLifePointsLabel.Tag = "Hidden";
            elfLifePoints.Tag = "Hidden";
            wizardLifePointsLabel.Tag = "Hidden";
            wizardLifePoints.Tag = "Hidden";

            CreateBaseElements();
            BaseStateOfCharacters();
            BaseDice();
        }

        void CreateBaseElements()
        {
            wizardImage = new Image();
            wizardImage.Width = 500;
            wizardImage.Height = 500;
            wizardImage.Visibility = Visibility.Visible; 
            wizardImage.Margin = new Thickness(100, 70, 0, 0);
            canvas.Children.Add(wizardImage);

            elfImage = new Image();
            elfImage.Width = 500;
            elfImage.Height = 500;
            elfImage.Visibility = Visibility.Visible;
            elfImage.Margin = new Thickness(270, 70, 0, 0);
            FlipImage(elfImage, -1);
            canvas.Children.Add(elfImage);
        }
      
        void BaseStateOfCharacters()
        {
            wizardImage.Source = new BitmapImage(new Uri(wizardAttackSources[0]));
            brush = new ImageBrush();
            brush.ImageSource = wizardImage.Source;

            elfImage.Source = new BitmapImage(new Uri(elfAttackSources[0]));
            brush = new ImageBrush();
            brush.ImageSource = elfImage.Source;
        }

        void BaseDice()
        {
            DirectoryInfo backgroundLocation = new DirectoryInfo(Environment.CurrentDirectory + "\\ElfWizardDuel\\Images");
            List<string> images = Directory.GetFiles(backgroundLocation.FullName).ToList();
            diceImage.Source = new BitmapImage(new Uri(images[1]));
            brush = new ImageBrush();
            brush.ImageSource = diceImage.Source;
        }

        void FlipImage(Image image, int scaleX)
        {
            flipTrans = new ScaleTransform();
            flipTrans.ScaleX = scaleX;
            image.RenderTransformOrigin = new Point(0.5, 0.5);
            image.RenderTransform = flipTrans;
        }

        void wizardWalkAnimation(Storyboard sb, int FromValue, int ToValue, int FromSeconds)
        {
            wizardDoubleAnimation = new DoubleAnimation(FromValue, ToValue, TimeSpan.FromSeconds(FromSeconds));
            Storyboard.SetTarget(wizardDoubleAnimation, wizardImage);
            Storyboard.SetTargetProperty(wizardDoubleAnimation, new PropertyPath(Canvas.LeftProperty));
            sb.Children.Add(wizardDoubleAnimation);
        }

        void elfWalkAnimation(Storyboard sb, int FromValue, int ToValue, int FromSeconds)
        {
            elfDoubleAnimation = new DoubleAnimation(FromValue, ToValue, TimeSpan.FromSeconds(FromSeconds));
            Storyboard.SetTarget(elfDoubleAnimation, elfImage);
            Storyboard.SetTargetProperty(elfDoubleAnimation, new PropertyPath(Canvas.LeftProperty));
            sb.Children.Add(elfDoubleAnimation);
        }

        private void choiceButton_Click(object sender, System.EventArgs e)
        {
            userCharacterChoice = ((Button)sender).Content.ToString();

            button1.Tag = "Hidden";
            button2.Tag = "Hidden";

            FlipImage(wizardImage, -1);
            FlipImage(elfImage, 1);

            storyBoard = new Storyboard();
            wizardWalkAnimation(storyBoard, 0, -100, 3);
            elfWalkAnimation(storyBoard, 0, 100, 3);
            storyBoard.Completed += walking_Completed;
            storyBoard.Begin();

            AnimationTimer(walkingTimer_Tick);
        }

        void AnimationTimer(System.EventHandler tick)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 70);
            timer.Tick += tick;
            timer.Start();
        }

        void walkingTimer_Tick(object sender, EventArgs e)
        {
            ImagesAnimation(wizardImage, wizardWalkSources);
            ImagesAnimation(elfImage, elfWalkSources);
            timer.Stop();
            timer = null;
            AnimationTimer(walkingTimer_Tick);
        }

        void ImagesAnimation(Image image, List<string> imagesMove)
        {
            if (currentImageIndex + 1 >= imagesMove.Count)
            {
                currentImageIndex = 0;
            }
            else
            {
                currentImageIndex++;
            }

            image.Source = new BitmapImage(new Uri(imagesMove[currentImageIndex]));

            animationCount++;
        }

        private void walking_Completed(object sender, EventArgs e)
        {
            animationCount = 0;

            FlipImage(wizardImage, 1);
            FlipImage(elfImage, -1);

            timer.Stop();
            timer = null;

            BaseStateOfCharacters();
            mainSecondLabel.Content = "";

            FightStart();
        }

        void FightStart()
        {
            elfLifePointsLabel.Tag = "Visible";
            elfLifePoints.Tag = "Visible";
            wizardLifePointsLabel.Tag = "Visible";
            wizardLifePoints.Tag = "Visible";
            diceImage.Tag = "Visible";
            diceButton.Tag = "Visible";
            diceButton.Click += rollDiceButton_Click;

            wizardLife = 100;
            elfLife = 100;

            if (userCharacterChoice == "WIZARD")
            {
                elfLifePointsLabel.Content += "ARCHER LIFE POINTS :";
                elfLifePoints.Content = elfLife.ToString();
                wizardLifePointsLabel.Content += "YOUR LIFE POINTS :";
                wizardLifePoints.Content = wizardLife.ToString();
            }
            else
            {
                elfLifePointsLabel.Content += "YOUR LIFE POINTS :";
                elfLifePoints.Content = elfLife.ToString();
                wizardLifePointsLabel.Content += "WIZARD LIFE POINTS :";
                wizardLifePoints.Content = wizardLife.ToString();
            }
        }

        private void rollDiceButton_Click(object sender, System.EventArgs e)
        {
            diceButton.Click -= rollDiceButton_Click;
            RollTheDice();

            AnimationTimer(attackTimer_Tick);
        }

        void RollTheDice()
        {
            generator = new Random();
            int diceNum = generator.Next(0, dicesSources.Count);
            diceImage.Source = new BitmapImage(new Uri(dicesSources[diceNum]));
            brush = new ImageBrush();
            brush.ImageSource = diceImage.Source;
            
            roundNumber = Convert.ToInt32(diceImage.Source.ToString().Split('/').Last().Split('.').First());
        }

        void UserRound()
        {
            machineRoundOn = false;
            BaseDice();
            currentImageIndex = 0;
            diceButton.Click += rollDiceButton_Click;
        }

        void Attack(string character, List<string> attackSources, List<string> hurtSources, Image userImage, Image enemyImage)
        {
            if (animationCount < (roundNumber * attackSources.Count))
            {
                ImagesAnimation(userImage, attackSources);
                if (roundNumber > 1)
                {
                    ImagesAnimation(enemyImage, hurtSources);
                }
                timer.Stop();
                timer = null;
                AnimationTimer(attackTimer_Tick);
            }
            else
            {
                timer.Stop();
                timer = null;
                animationCount = 0;
                currentImageIndex = 0;
                BaseStateOfCharacters();
                CalculateRoundPoint(character, roundNumber);

                if (elfLife > 0 && wizardLife > 0)
                {
                    if (userCharacterChoice == character)
                    {
                        MachineRound();
                    }
                    else
                    {
                        UserRound();
                    }
                }
                else
                {
                    GameOver();
                }
            }
        }

        void attackTimer_Tick(object sender, EventArgs e)
        {
            if (machineRoundOn == true)
            {
                if(userCharacterChoice == "WIZARD")
                {
                    Attack("ARCHER ELF", elfAttackSources, wizardHurtSources, elfImage, wizardImage);

                }
                else
                {
                    Attack("WIZARD", wizardAttackSources, elfHurtSources, wizardImage, elfImage);
                }
            }
            else
            {
                if (userCharacterChoice == "WIZARD")
                {
                    Attack("WIZARD", wizardAttackSources, elfHurtSources, wizardImage, elfImage);

                }
                else
                {
                    Attack("ARCHER ELF", elfAttackSources, wizardHurtSources, elfImage, wizardImage);
                }
            }
        }

        void CalculateRoundPoint(string characterAttacking, int roundNum)
        {
            if(characterAttacking == "WIZARD")
            {
                if (roundNum > 1 && roundNum < 6)
                {
                    elfLife = elfLife - (roundNum * 5);
                }
                else
                {
                    if (roundNum == 1)
                    {
                        elfLife = elfLife - 0;
                    }
                    else
                    {
                        elfLife = elfLife - (roundNum * 8);
                    }
                }
                elfLifePoints.Content = elfLife.ToString();
            }
            else
            {
                if (roundNum > 1 && roundNum < 6)
                {
                    wizardLife = wizardLife - (roundNum * 5);
                }
                else
                {
                    if (roundNum == 1)
                    {
                        wizardLife = wizardLife - 0;
                    }
                    else
                    {
                        wizardLife = wizardLife - (roundNum * 8);
                    }
                }
                wizardLifePoints.Content = wizardLife.ToString();
            }
        }

        void MachineRound()
        {
            machineRoundOn = true;
            currentImageIndex = 0;
            diceButton.Click -= rollDiceButton_Click;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += macineDiceRoll_Tick;
            timer.Start();
        }

        void macineDiceRoll_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer = null;

            RollTheDice();
            AnimationTimer(attackTimer_Tick);
        }

        void GameOver()
        {
            AnimationTimer(dieTimer_Tick);
        }

        void dieTimer_Tick(object sender, EventArgs e)
        {
            if (elfLife <= 0)
            {
                if (animationCount < elfDieSources.Count - 1)
                {
                    timer.Stop();
                    timer = null;
                    ImagesAnimation(elfImage, elfDieSources);
                    GameOver();
                }
                else
                {
                    timer.Stop();
                    timer = null;
                    FinalResult();
                }
            }
            else if(wizardLife <= 0)
            {
                if (animationCount < wizardDieSources.Count - 1)
                {
                    timer.Stop();
                    timer = null;
                    ImagesAnimation(wizardImage, wizardDieSources);
                    GameOver();
                }
                else
                {
                    timer.Stop();
                    timer = null;
                    FinalResult();
                }
            }
        }

        void FinalResult()
        {
            diceImage.Tag = "Hidden";
            diceButton.Tag = "Hidden";
            fightAgainButton.Tag = "Visible";
            exitButton.Tag = "Visible";

            if (wizardLife > elfLife)
            {
                if(userCharacterChoice == "WIZARD")
                {
                    mainSecondLabel.Tag = "Winner";
                    mainSecondLabel.Content = "CONGRATULATIONS, YOU WON THE FIGHT!";
                }
                else
                {
                    mainSecondLabel.Tag = "Loser";
                    mainSecondLabel.Content = "NOW YOU LOST, BETTER LUCK FOR NEXT TIME!";
                }
            }
            else
            {
                if (userCharacterChoice == "ARCHER ELF")
                {
                    mainSecondLabel.Tag = "Winner";
                    mainSecondLabel.Content = "CONGRATULATIONS, YOU WON THE FIGHT!";
                }
                else
                {
                    mainSecondLabel.Tag = "Loser";
                    mainSecondLabel.Content = "NOW YOU LOST, BETTER LUCK FOR NEXT TIME!";
                }
            }
        }

        private void exitButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void fightAgainButton_Click(object sender, System.EventArgs e)
        {
            canvas.Children.Remove(elfImage);
            canvas.Children.Remove(wizardImage);
            elfLifePointsLabel.Content = "";
            elfLifePoints.Content = "";
            wizardLifePointsLabel.Content = "";
            wizardLifePoints.Content = "";

            elfLife = 0;
            wizardLife = 0;
            currentImageIndex = 0;
            animationCount = 0;
            roundNumber = 0;

            userCharacterChoice = null;
            machineRoundOn = false;

            Start();
        }
    }
}
