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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



using WpfApplication3.View;
namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<strctGameLog> LogGameLog = new List<strctGameLog>();
        System.Timers.Timer timerRollDice = new System.Timers.Timer();
        System.Timers.Timer timeStopTimer = new System.Timers.Timer();
        Button[] arrbutton = new Button[100];
        int currentPlayer = 0, playerscount=0;
        int currentdicenuumber = 0 , dicetimeout=10;
        Label[] lblPlayerList;
        Label[] lblPlayerDisplayinformation;
        int[] playerstandings;
        bool isdicerolling = false;
        Color[] arrColor = {Colors.Blue , Colors.Magenta , Colors.Chocolate , Colors.YellowGreen  , Colors.GreenYellow };
        public MainWindow()
        {
            InitializeComponent();
            timerRollDice.Elapsed +=new System.Timers.ElapsedEventHandler(this.TimerRollDice_Elapsed);
            timerRollDice.Interval = dicetimeout;

            timeStopTimer.Elapsed += TimeStopTimer_Elapsed;
            timeStopTimer.Interval = 1000;
            drawboard();
    
        }

        private void TimeStopTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            timerRollDice.Stop();
             System.Threading.Thread.Sleep(1);
            this.Dispatcher.Invoke(new Action(()
            =>
                {
                    btnRollDice_Click(sender, new RoutedEventArgs());

                }));
            timeStopTimer.Stop();

        }

        private void TimerRollDice_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>{
            currentdicenuumber = (currentdicenuumber < 6) ? currentdicenuumber + 1 : 1;
            lblDice.Content = Convert.ToString(currentdicenuumber);
               

        }));
      
                //   System.Threading.Thread.Sleep(dicetimeout);
             
        }

        void drawboard()
        {

        //    StackPanel gridBoard = new StackPanel();
       //     gridBoard.Orientation= Orientation.Vertical;
       //
       //     Table tabBoard = new Table();
            int btnIndex = 100;

            int singlecellheight = 50,singlecellwidth = 50;
            int boardleft = 10, boardright = boardleft + (singlecellwidth * 10),  boardheight =singlecellheight*10, boardwidth = singlecellwidth*10;
            int bottomleft = boardleft + boardheight;
            int nextpiecetop, nextpirecright;

                 grdwhole.Height = boardheight;
                  grdwhole.Width = boardwidth;

            for (int i = 0; i < 10; i++)
            {
                RowDefinition newgridrow = new RowDefinition();
                grdwhole.RowDefinitions.Add(newgridrow);

                ColumnDefinition newColDef = new ColumnDefinition();
                grdwhole.ColumnDefinitions.Add(newColDef);
                

            }

            for (int i = 0; i < 10; i++)
            {
              //  
               
                nextpiecetop = boardheight - singlecellheight;
              

        //        StackPanel spHorizantal = new StackPanel();
        //        spHorizantal.Orientation = Orientation.Horizontal;
                RowDefinition rd = new RowDefinition();

               TableRow tbatro = new TableRow();

                if ((i % 2) == 0)
                {
                    //           spHorizantal.FlowDirection = FlowDirection.LeftToRight;
                    for (int j = 0; j < 10; j++)
                    {
                        nextpirecright = boardleft + singlecellwidth * j;
                        Button btnx = new Button();
                        btnx.Width = singlecellwidth;
                        btnx.Height = singlecellheight;
                        btnIndex--;
                        btnx.Opacity = 0.5;
                    //    btnx.Content = btnIndex + 1;
                        arrbutton[btnIndex] = btnx;

                        Grid.SetRow(btnx, i);
                        Grid.SetColumn(btnx, j);
                        grdwhole.Children.Add(btnx);
                    }
                }
                else
                {
                    //          spHorizantal.FlowDirection =FlowDirection.RightToLeft;

                    for (int j = 9; j >= 0; j--)
                    {
                        nextpirecright = boardleft + singlecellwidth * j;
                        Button btnx = new Button();
                        btnx.Width = singlecellwidth;
                        btnx.Height = singlecellheight;
                        btnIndex--;
                        btnx.Opacity = 0.5;
                 //       btnx.Content = btnIndex + 1;
                        arrbutton[btnIndex] = btnx;

                        Grid.SetRow(btnx, i);
                        Grid.SetColumn(btnx, j);
                        grdwhole.Children.Add(btnx);
                    }
                }
                
             
                
             
////
       //         gridBoard.Children.Add(spHorizantal);
                
            }
            //     grdwhole.Children.Add(gridBoard);


        

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
         
        }

        private void setNextPlayer(int currentPlayerNumber)
        {
        
        }
        private void rolldice()
        {

           
        }

        private void stopdice()
        {
            isdicerolling = false;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void txtnop_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSetPlayer.Visibility = Visibility.Visible;
        }

        private void btnRollDice_Click(object sender, RoutedEventArgs e)
        {
            if (isdicerolling)
            {
                isdicerolling = false;
                // stopdice();+-

              //  timerRollDice.Stop();

                //     System.Threading.Thread.Sleep(1);
                dataGridScopre.ItemsSource = null;

                //     lblDice.Content = Convert.ToString(currentdicenuumber);

                currentdicenuumber = Convert.ToInt32(lblDice.Content);
                movePiece(currentPlayer, currentdicenuumber);
                currentPlayer = (currentPlayer < playerscount - 1) ? currentPlayer + 1 : 0;
                lblPlayerText.Content = "Player " + Convert.ToString(currentPlayer + 1) + "\'s turn";
                btnRollDice.Content = "Roll Dice";
                btnRollDice.Visibility = Visibility.Visible;
                dataGridScopre.ItemsSource = clsGV.lstGameLog;
                //   lblDice.Content = currentdicenuumber.ToString();
            }
            else
            {
                lblPlayerList[currentPlayer].Visibility = Visibility.Visible;

                currentdicenuumber = 0;
                lblDice.Visibility = Visibility.Visible;
                isdicerolling = true;
                btnRollDice.Content = "Stop Dice";
                timerRollDice.Start();
                timeStopTimer.Start();
                btnRollDice.Visibility = Visibility.Hidden;
                //     rolldice();
            }
        }


        private void movePiece(int PlayerNumber, int dicevalue)
        {
            strctGameLog singlelog = new strctGameLog();

            singlelog.PlayerNumber = PlayerNumber;
            singlelog.PlayerStartNumber = playerstandings[PlayerNumber];

            singlelog.DiceNumer = dicevalue;

            int targetdicenum = getTargetnumber(playerstandings[PlayerNumber] + dicevalue);
            playerstandings[PlayerNumber] = targetdicenum;
            singlelog.TargetNumber = targetdicenum;
             lblPlayerDisplayinformation[PlayerNumber].Content = "Player " + Convert.ToString(PlayerNumber+1) + " at " + targetdicenum;
            //   lblPlayerList[PlayerNumber].Margin = arrbutton[targetdicenum].Margin;
            Grid.SetColumn(lblPlayerList[PlayerNumber], Grid.GetColumn(arrbutton[targetdicenum-1]));
            Grid.SetRow(lblPlayerList[PlayerNumber], Grid.GetRow(arrbutton[targetdicenum-1]));

            LogGameLog.Add(singlelog);
            clsGV.lstGameLog.Add(singlelog);
            
        }

        private int getTargetnumber(int sourceNumber)
        {
            int retutnnumber = 0;
            switch (sourceNumber)
            {

                case 73:
                    {
                        retutnnumber = 1;
                        break;
                    }
                case 46:
                    {
                        retutnnumber = 5;
                        break;
                    }
                case 55:
                    {
                        retutnnumber = 7;
                        break;
                    }
                case 48:
                    {
                        retutnnumber = 9;
                        break;
                    }
                case 52:
                    {
                        retutnnumber = 11;
                        break;
                    }
                case 59:
                    {
                        retutnnumber = 17;
                        break;
                    }
                case 83:
                    {
                        retutnnumber = 19;
                        break;
                    }
                case 44:
                    {
                        retutnnumber = 22;
                        break;
                    }
                case 95:
                    {
                        retutnnumber = 24;
                        break;
                    }
                case 69:
                    {
                        retutnnumber = 33;
                        break;
                    }
                case 64:
                    {
                        retutnnumber = 36;
                        break;
                    }
                case 92:
                    {
                        retutnnumber = 51;
                        break;
                    }
                case 8:
                    {
                        retutnnumber = 26;
                        break;
                    }
                case 21:
                    {
                        retutnnumber = 82;
                        break;
                    }
                case 43:
                    {
                        retutnnumber = 77;
                        break;
                    }
                case 50:
                    {
                        retutnnumber = 91;
                        break;
                    }
                case 54:
                    {
                        retutnnumber = 93;
                        break;
                    }
                case 62:
                    {
                        retutnnumber = 96;
                        break;
                    }
                case 66:
                    {
                        retutnnumber = 87;
                        break;
                    }
                case 80:
                    {
                        retutnnumber = 100;
                        break;
                    }
                default:
                    {
                        retutnnumber = sourceNumber;
                        break;
                    }                  
            }
            if ((retutnnumber > 100 )|| (retutnnumber<=0))
                retutnnumber = sourceNumber;

            



            return retutnnumber;
        }

        private void btnDisplayLog_Click(object sender, RoutedEventArgs e)
        {
            DisplayLog cwDisplayLog = new DisplayLog( );
            cwDisplayLog.ShowDialog();
            

        }

        private void btnResetGame_Click(object sender, RoutedEventArgs e)
        {
            currentPlayer = 0;
            playerscount = 0;
            currentdicenuumber = 0;
            dicetimeout = 100;

            for (int i=0; i< lblPlayerList.Count(); i++ )
            grdwhole.Children.Remove(lblPlayerList[i]);
           
            lblPlayerList = null;
            stkPnlPlayerList.Children.Clear();

            btnSetPlayer.Visibility = Visibility.Visible;
            btnResetGame.Visibility = Visibility.Hidden;
            btnRollDice.Visibility = Visibility.Hidden;
            //   lblPlayerList.
            //       lblPlayerDisplayinformation
            //       playerstandings
        }

        private void btnSetPlayer_Click(object sender, RoutedEventArgs e)
        {


            int intNop = ((0< Convert.ToInt32(txtnop.Text)) && (Convert.ToInt32(txtnop.Text)>5)?5: Convert.ToInt32(txtnop.Text));
            lblPlayerList = new Label[intNop];
            lblPlayerDisplayinformation = new Label[intNop];
            playerstandings = new int[intNop];
            for (int intSingleplay = 0; intSingleplay < intNop; intSingleplay++)
            {
                  Label lbloneP = new Label();
              
                lbloneP.Width = 50;
                lbloneP.Height = 50;
                lbloneP.Content = Convert.ToString(intSingleplay+1);
                lbloneP.Opacity = 0.5;
                lbloneP.Background = new SolidColorBrush(arrColor[intSingleplay]);   ;
                lbloneP.Visibility = Visibility.Hidden;
                lblPlayerList[intSingleplay] = lbloneP;
                playerstandings[intSingleplay] = 0;
                grdwhole.Children.Add(lbloneP);
                Grid.SetRow(lbloneP, 9);
                Grid.SetColumn(lbloneP, 0);
                Label lblSinglePlayerInfo = new Label();
                lblSinglePlayerInfo.Background = new SolidColorBrush(arrColor[intSingleplay]); ;
                lblSinglePlayerInfo.Content = "Player " + Convert.ToString(intSingleplay + 1) + " at 0" ;
                lblSinglePlayerInfo.Height = 50;
                lblSinglePlayerInfo.Visibility = Visibility.Visible;
                stkPnlPlayerList.Children.Add(lblSinglePlayerInfo);
                lblPlayerDisplayinformation[intSingleplay] = lblSinglePlayerInfo;
            }
            playerscount = intNop;
          //  lblNoofPlayers.Content = playerscount;
            currentPlayer = 0;
            btnRollDice.Visibility = Visibility.Visible;
            lblPlayerText.Content = "Player " + Convert.ToString(currentPlayer + 1) + "\'s turn";
            btnResetGame.Visibility = Visibility.Visible;
            btnSetPlayer.Visibility = Visibility.Hidden;
        }

       
        
    }

   public struct strctGameLog
    {

        public int PlayerNumber { get; set; }

        public int PlayerStartNumber { get; set; }

        public int DiceNumer { get; set; }

        public int TargetNumber { get; set; }

       
    }

 
}
