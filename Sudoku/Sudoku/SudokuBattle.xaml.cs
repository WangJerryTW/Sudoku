using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sudoku
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SudokuBattle : ContentPage
	{
		public SudokuBattle ()
		{
			InitializeComponent ();
            lblClickFunc(); //---load 所有label的事件

            lblFocusClickFunc();//---load focus label事件

            LoadStage(); //---load預設關卡
        }

        public void LoadStage()
        {
            ClearAllGridText(); //---清掉所有數字
            string[] array = {
                "" , "3", "", "8", "4", "2", "", "6", "1",
                "" , "4", "2", "6", "1", "5", "3", "", "",
                "" , "", "6", "7", "9", "3", "8", "", "4",
                "7" , "2", "5", "4", "3", "", "", "", "9",
                "6" , "", "", "1", "", "7", "", "3", "2",
                "" , "1", "4", "", "2", "8", "7", "5", "",
                "2" , "7", "3", "5", "", "1", "9", "", "8",
                "4" , "6", "", "", "8", "", "", "", "5",
                "" , "8", "", "2", "", "4", "6", "1", ""
            };
            ReadGame(array);
        }

        void lblFocusClickFunc()
        {
            lb_Focus1.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    SetFocusAndMarkColor(lb_Focus1);
                })
            });
            lb_Focus2.GestureRecognizers.Add(new TapGestureRecognizer(){Command = new Command(() =>{SetFocusAndMarkColor(lb_Focus2);})});
            lb_Focus3.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { SetFocusAndMarkColor(lb_Focus3); }) });
            lb_Focus4.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { SetFocusAndMarkColor(lb_Focus4); }) });
            lb_Focus5.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { SetFocusAndMarkColor(lb_Focus5); }) });
            lb_Focus6.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { SetFocusAndMarkColor(lb_Focus6); }) });
            lb_Focus7.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { SetFocusAndMarkColor(lb_Focus7); }) });
            lb_Focus8.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { SetFocusAndMarkColor(lb_Focus8); }) });
            lb_Focus9.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { SetFocusAndMarkColor(lb_Focus9); }) });
            lb_Focus_c.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { SetFocusAndMarkColor(lb_Focus_c); }) });
        }


        string FocusText = "";
        bool FocusStates = false;

        void SetFocusAndMarkColor(Label label)
        {
            ClearAllFocusGridColor();

            label.BackgroundColor = Color.Aqua;

            if (label == lb_Focus1) { FocusText = "1"; FocusStates = true; }
            else if (label == lb_Focus2) { FocusText = "2"; FocusStates = true; }
            else if (label == lb_Focus3) { FocusText = "3"; FocusStates = true; }
            else if (label == lb_Focus4) { FocusText = "4"; FocusStates = true; }
            else if (label == lb_Focus5) { FocusText = "5"; FocusStates = true; }
            else if (label == lb_Focus6) { FocusText = "6"; FocusStates = true; }
            else if (label == lb_Focus7) { FocusText = "7"; FocusStates = true; }
            else if (label == lb_Focus8) { FocusText = "8"; FocusStates = true; }
            else if (label == lb_Focus9) { FocusText = "9"; FocusStates = true; }
            else { FocusText = ""; FocusStates = true; }
        }
        void ClearFocusStates()
        {
            FocusText = "";
            FocusStates = false;
            ClearAllFocusGridColor();
        }





        void lblClickFunc()
        {
            lb_1x1.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    ReDrawGridColor(lb_1x1);
                })
            });
            lb_1x2.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    ReDrawGridColor(lb_1x2);
                })
            });
            lb_1x3.GestureRecognizers.Add(new TapGestureRecognizer(){Command = new Command(() =>{ReDrawGridColor(lb_1x3);})});
            lb_1x4.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_1x4); }) });
            lb_1x5.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_1x5); }) });
            lb_1x6.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_1x6); }) });
            lb_1x7.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_1x7); }) });
            lb_1x8.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_1x8); }) });
            lb_1x9.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_1x9); }) });

            lb_2x1.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_2x1); }) });
            lb_2x2.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_2x2); }) });
            lb_2x3.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_2x3); }) });
            lb_2x4.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_2x4); }) });
            lb_2x5.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_2x5); }) });
            lb_2x6.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_2x6); }) });
            lb_2x7.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_2x7); }) });
            lb_2x8.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_2x8); }) });
            lb_2x9.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_2x9); }) });

            lb_3x1.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_3x1); }) });
            lb_3x2.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_3x2); }) });
            lb_3x3.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_3x3); }) });
            lb_3x4.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_3x4); }) });
            lb_3x5.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_3x5); }) });
            lb_3x6.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_3x6); }) });
            lb_3x7.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_3x7); }) });
            lb_3x8.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_3x8); }) });
            lb_3x9.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_3x9); }) });

            lb_4x1.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_4x1); }) });
            lb_4x2.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_4x2); }) });
            lb_4x3.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_4x3); }) });
            lb_4x4.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_4x4); }) });
            lb_4x5.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_4x5); }) });
            lb_4x6.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_4x6); }) });
            lb_4x7.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_4x7); }) });
            lb_4x8.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_4x8); }) });
            lb_4x9.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_4x9); }) });

            lb_5x1.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_5x1); }) });
            lb_5x2.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_5x2); }) });
            lb_5x3.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_5x3); }) });
            lb_5x4.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_5x4); }) });
            lb_5x5.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_5x5); }) });
            lb_5x6.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_5x6); }) });
            lb_5x7.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_5x7); }) });
            lb_5x8.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_5x8); }) });
            lb_5x9.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_5x9); }) });

            lb_6x1.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_6x1); }) });
            lb_6x2.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_6x2); }) });
            lb_6x3.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_6x3); }) });
            lb_6x4.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_6x4); }) });
            lb_6x5.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_6x5); }) });
            lb_6x6.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_6x6); }) });
            lb_6x7.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_6x7); }) });
            lb_6x8.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_6x8); }) });
            lb_6x9.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_6x9); }) });

            lb_7x1.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_7x1); }) });
            lb_7x2.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_7x2); }) });
            lb_7x3.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_7x3); }) });
            lb_7x4.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_7x4); }) });
            lb_7x5.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_7x5); }) });
            lb_7x6.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_7x6); }) });
            lb_7x7.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_7x7); }) });
            lb_7x8.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_7x8); }) });
            lb_7x9.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_7x9); }) });

            lb_8x1.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_8x1); }) });
            lb_8x2.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_8x2); }) });
            lb_8x3.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_8x3); }) });
            lb_8x4.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_8x4); }) });
            lb_8x5.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_8x5); }) });
            lb_8x6.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_8x6); }) });
            lb_8x7.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_8x7); }) });
            lb_8x8.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_8x8); }) });
            lb_8x9.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_8x9); }) });

            lb_9x1.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_9x1); }) });
            lb_9x2.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_9x2); }) });
            lb_9x3.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_9x3); }) });
            lb_9x4.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_9x4); }) });
            lb_9x5.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_9x5); }) });
            lb_9x6.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_9x6); }) });
            lb_9x7.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_9x7); }) });
            lb_9x8.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_9x8); }) });
            lb_9x9.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { ReDrawGridColor(lb_9x9); }) });
        }

        /// <summary>
        /// 當點選其中一個格子，他的鄰近格子有互動事件同一Row同一Column的Color要變成LightYellow, 本身變成Orange.
        /// </summary>
        public void ReDrawGridColor(Label lbl)
        {
            ClearAllGridColor(); //清除所有格子顏色
            LoadBasicPanelColor();  //--設定基礎版面配色


            //----取得那個label在Grid的哪個位置
            int Row = Grid.GetRow(lbl);
            int Column = Grid.GetColumn(lbl);
            
            for (int i = 1; i <= 9; i++)
                for (int j = 0; j <= 8; j++)
                {
                    if (i == Row || j == Column)
                    {
                        //--從那個grid拉出label來用
                        Label label = (Label)MyGrid.Children.Cast<Label>().FirstOrDefault((x) => Grid.GetRow(x) == i && Grid.GetColumn(x) == j);
                        label.BackgroundColor = Color.LightYellow;
                    }
                }
            lbl.BackgroundColor = Color.Orange;

            //---塞入規則，字體藍字不能修改或塞入，不是Focus狀態不得修改
            if (lbl.TextColor == Color.Blue) return;
            else
            {
                if (FocusStates == false) return;
                else
                {
                    lbl.Text = FocusText; //---塞值
                    ClearFocusStates(); //---清除focus狀態
                }
            }
            
            //-----判斷是否已經結束? 比對機制 --把目前值讀成陣列再與解答陣列compare  相等的話，就跳出WIN的字樣
            


        }

        bool Is_Game_End = false;
        bool Is_Game_NotEnd = false;
        bool IsGameEnd()
        {
            if (Is_Game_End == true && Is_Game_NoError == true) return true;

            return false;
        }

        bool Is_Game_Error = false;
        bool Is_Game_NoError = false;
        bool IsGameGetError()
        {
            //if((lb_1x1.Text || lb_1x2.Text) == true)
            return false;
        }


        public void LoadBasicPanelColor()
        {
            Color defaulcolor = Color.Silver;
            #region 左上
            lb_1x1.BackgroundColor =
            lb_1x2.BackgroundColor =
            lb_1x3.BackgroundColor =
            lb_2x1.BackgroundColor =
            lb_2x2.BackgroundColor =
            lb_2x3.BackgroundColor =
            lb_3x1.BackgroundColor =
            lb_3x2.BackgroundColor =
            lb_3x3.BackgroundColor =
            #endregion


            #region 右上
            lb_1x7.BackgroundColor =
            lb_1x8.BackgroundColor =
            lb_1x9.BackgroundColor =
            lb_2x7.BackgroundColor =
            lb_2x8.BackgroundColor =
            lb_2x9.BackgroundColor =
            lb_3x7.BackgroundColor =
            lb_3x8.BackgroundColor =
            lb_3x9.BackgroundColor =
            #endregion

            #region 中間
            lb_4x4.BackgroundColor =
            lb_4x5.BackgroundColor =
            lb_4x6.BackgroundColor =
            lb_5x4.BackgroundColor =
            lb_5x5.BackgroundColor =
            lb_5x6.BackgroundColor =
            lb_6x4.BackgroundColor =
            lb_6x5.BackgroundColor =
            lb_6x6.BackgroundColor =
            #endregion

            #region 左下
            lb_7x1.BackgroundColor =
            lb_7x2.BackgroundColor =
            lb_7x3.BackgroundColor =
            lb_8x1.BackgroundColor =
            lb_8x2.BackgroundColor =
            lb_8x3.BackgroundColor =
            lb_9x1.BackgroundColor =
            lb_9x2.BackgroundColor =
            lb_9x3.BackgroundColor =
            #endregion

            #region 右下
            lb_7x7.BackgroundColor =
            lb_7x8.BackgroundColor =
            lb_7x9.BackgroundColor =
            lb_8x7.BackgroundColor =
            lb_8x8.BackgroundColor =
            lb_8x9.BackgroundColor =
            lb_9x7.BackgroundColor =
            lb_9x8.BackgroundColor =
            lb_9x9.BackgroundColor = defaulcolor;
            #endregion


        }

        public void ClearAllGridColor()
        {
            Color ClearColor = Color.White;

            lb_1x1.BackgroundColor =
            lb_1x2.BackgroundColor =
            lb_1x3.BackgroundColor =
            lb_1x4.BackgroundColor =
            lb_1x5.BackgroundColor =
            lb_1x6.BackgroundColor =
            lb_1x7.BackgroundColor =
            lb_1x8.BackgroundColor =
            lb_1x9.BackgroundColor =
            lb_2x1.BackgroundColor =
            lb_2x2.BackgroundColor =
            lb_2x3.BackgroundColor =
            lb_2x4.BackgroundColor =
            lb_2x5.BackgroundColor =
            lb_2x6.BackgroundColor =
            lb_2x7.BackgroundColor =
            lb_2x8.BackgroundColor =
            lb_2x9.BackgroundColor =
            lb_3x1.BackgroundColor =
            lb_3x2.BackgroundColor =
            lb_3x3.BackgroundColor =
            lb_3x4.BackgroundColor =
            lb_3x5.BackgroundColor =
            lb_3x6.BackgroundColor =
            lb_3x7.BackgroundColor =
            lb_3x8.BackgroundColor =
            lb_3x9.BackgroundColor =
            lb_4x1.BackgroundColor =
            lb_4x2.BackgroundColor =
            lb_4x3.BackgroundColor =
            lb_4x4.BackgroundColor =
            lb_4x5.BackgroundColor =
            lb_4x6.BackgroundColor =
            lb_4x7.BackgroundColor =
            lb_4x8.BackgroundColor =
            lb_4x9.BackgroundColor =
            lb_5x1.BackgroundColor =
            lb_5x2.BackgroundColor =
            lb_5x3.BackgroundColor =
            lb_5x4.BackgroundColor =
            lb_5x5.BackgroundColor =
            lb_5x6.BackgroundColor =
            lb_5x7.BackgroundColor =
            lb_5x8.BackgroundColor =
            lb_5x9.BackgroundColor =
            lb_6x1.BackgroundColor =
            lb_6x2.BackgroundColor =
            lb_6x3.BackgroundColor =
            lb_6x4.BackgroundColor =
            lb_6x5.BackgroundColor =
            lb_6x6.BackgroundColor =
            lb_6x7.BackgroundColor =
            lb_6x8.BackgroundColor =
            lb_6x9.BackgroundColor =
            lb_7x1.BackgroundColor =
            lb_7x2.BackgroundColor =
            lb_7x3.BackgroundColor =
            lb_7x4.BackgroundColor =
            lb_7x5.BackgroundColor =
            lb_7x6.BackgroundColor =
            lb_7x7.BackgroundColor =
            lb_7x8.BackgroundColor =
            lb_7x9.BackgroundColor =
            lb_8x1.BackgroundColor =
            lb_8x2.BackgroundColor =
            lb_8x3.BackgroundColor =
            lb_8x4.BackgroundColor =
            lb_8x5.BackgroundColor =
            lb_8x6.BackgroundColor =
            lb_8x7.BackgroundColor =
            lb_8x8.BackgroundColor =
            lb_8x9.BackgroundColor =
            lb_9x1.BackgroundColor =
            lb_9x2.BackgroundColor =
            lb_9x3.BackgroundColor =
            lb_9x4.BackgroundColor =
            lb_9x5.BackgroundColor =
            lb_9x6.BackgroundColor =
            lb_9x7.BackgroundColor =
            lb_9x8.BackgroundColor =
            lb_9x9.BackgroundColor = ClearColor;
        }

        public void ClearAllFocusGridColor()
        {
            Color ClearColor = Color.White;

            lb_Focus1.BackgroundColor =
            lb_Focus2.BackgroundColor =
            lb_Focus3.BackgroundColor =
            lb_Focus4.BackgroundColor =
            lb_Focus5.BackgroundColor =
            lb_Focus6.BackgroundColor =
            lb_Focus7.BackgroundColor =
            lb_Focus8.BackgroundColor =
            lb_Focus9.BackgroundColor =
            lb_Focus_c.BackgroundColor = ClearColor;
        }



        public void ClearAllGridText()
        {
            lb_1x1.Text = "";
            lb_1x2.Text = "";
            lb_1x3.Text = "";
            lb_1x4.Text = "";
            lb_1x5.Text = "";
            lb_1x6.Text = "";
            lb_1x7.Text = "";
            lb_1x8.Text = "";
            lb_1x9.Text = "";

            lb_2x1.Text = "";
            lb_2x2.Text = "";
            lb_2x3.Text = "";
            lb_2x4.Text = "";
            lb_2x5.Text = "";
            lb_2x6.Text = "";
            lb_2x7.Text = "";
            lb_2x8.Text = "";
            lb_2x9.Text = "";

            lb_3x1.Text = "";
            lb_3x2.Text = "";
            lb_3x3.Text = "";
            lb_3x4.Text = "";
            lb_3x5.Text = "";
            lb_3x6.Text = "";
            lb_3x7.Text = "";
            lb_3x8.Text = "";
            lb_3x9.Text = "";

            lb_4x1.Text = "";
            lb_4x2.Text = "";
            lb_4x3.Text = "";
            lb_4x4.Text = "";
            lb_4x5.Text = "";
            lb_4x6.Text = "";
            lb_4x7.Text = "";
            lb_4x8.Text = "";
            lb_4x9.Text = "";

            lb_5x1.Text = "";
            lb_5x2.Text = "";
            lb_5x3.Text = "";
            lb_5x4.Text = "";
            lb_5x5.Text = "";
            lb_5x6.Text = "";
            lb_5x7.Text = "";
            lb_5x8.Text = "";
            lb_5x9.Text = "";

            lb_6x1.Text = "";
            lb_6x2.Text = "";
            lb_6x3.Text = "";
            lb_6x4.Text = "";
            lb_6x5.Text = "";
            lb_6x6.Text = "";
            lb_6x7.Text = "";
            lb_6x8.Text = "";
            lb_6x9.Text = "";

            lb_7x1.Text = "";
            lb_7x2.Text = "";
            lb_7x3.Text = "";
            lb_7x4.Text = "";
            lb_7x5.Text = "";
            lb_7x6.Text = "";
            lb_7x7.Text = "";
            lb_7x8.Text = "";
            lb_7x9.Text = "";

            lb_8x1.Text = "";
            lb_8x2.Text = "";
            lb_8x3.Text = "";
            lb_8x4.Text = "";
            lb_8x5.Text = "";
            lb_8x6.Text = "";
            lb_8x7.Text = "";
            lb_8x8.Text = "";
            lb_8x9.Text = "";

            lb_9x1.Text = "";
            lb_9x2.Text = "";
            lb_9x3.Text = "";
            lb_9x4.Text = "";
            lb_9x5.Text = "";
            lb_9x6.Text = "";
            lb_9x7.Text = "";
            lb_9x8.Text = "";
            lb_9x9.Text = "";
        }
        
        public void ReadGame(
            string [] array
            )
        {
            lb_1x1.Text = array[0]; if (array[0] != "") lb_1x1.TextColor = Color.Blue;
            lb_1x2.Text = array[1]; if (array[1] != "") lb_1x2.TextColor = Color.Blue;
            lb_1x3.Text = array[2]; if (array[2] != "") lb_1x3.TextColor = Color.Blue;
            lb_1x4.Text = array[3]; if (array[3] != "") lb_1x4.TextColor = Color.Blue;
            lb_1x5.Text = array[4]; if (array[4] != "") lb_1x5.TextColor = Color.Blue;
            lb_1x6.Text = array[5]; if (array[5] != "") lb_1x6.TextColor = Color.Blue;
            lb_1x7.Text = array[6]; if (array[6] != "") lb_1x7.TextColor = Color.Blue;
            lb_1x8.Text = array[7]; if (array[7] != "") lb_1x8.TextColor = Color.Blue;
            lb_1x9.Text = array[8]; if (array[8] != "") lb_1x9.TextColor = Color.Blue;

            lb_2x1.Text = array[9]; if (array[9] != "") lb_2x1.TextColor = Color.Blue;
            lb_2x2.Text = array[10]; if (array[10] != "") lb_2x2.TextColor = Color.Blue;
            lb_2x3.Text = array[11]; if (array[11] != "") lb_2x3.TextColor = Color.Blue;
            lb_2x4.Text = array[12]; if (array[12] != "") lb_2x4.TextColor = Color.Blue;
            lb_2x5.Text = array[13]; if (array[13] != "") lb_2x5.TextColor = Color.Blue;
            lb_2x6.Text = array[14]; if (array[14] != "") lb_2x6.TextColor = Color.Blue;
            lb_2x7.Text = array[15]; if (array[15] != "") lb_2x7.TextColor = Color.Blue;
            lb_2x8.Text = array[16]; if (array[16] != "") lb_2x8.TextColor = Color.Blue;
            lb_2x9.Text = array[17]; if (array[17] != "") lb_2x9.TextColor = Color.Blue;

            lb_3x1.Text = array[18]; if (array[18] != "") lb_3x1.TextColor = Color.Blue;
            lb_3x2.Text = array[19]; if (array[19] != "") lb_3x2.TextColor = Color.Blue;
            lb_3x3.Text = array[20]; if (array[20] != "") lb_3x3.TextColor = Color.Blue;
            lb_3x4.Text = array[21]; if (array[21] != "") lb_3x4.TextColor = Color.Blue;
            lb_3x5.Text = array[22]; if (array[22] != "") lb_3x5.TextColor = Color.Blue;
            lb_3x6.Text = array[23]; if (array[23] != "") lb_3x6.TextColor = Color.Blue;
            lb_3x7.Text = array[24]; if (array[24] != "") lb_3x7.TextColor = Color.Blue;
            lb_3x8.Text = array[25]; if (array[25] != "") lb_3x8.TextColor = Color.Blue;
            lb_3x9.Text = array[26]; if (array[26] != "") lb_3x9.TextColor = Color.Blue;

            lb_4x1.Text = array[27]; if (array[27] != "") lb_4x1.TextColor = Color.Blue;
            lb_4x2.Text = array[28]; if (array[28] != "") lb_4x2.TextColor = Color.Blue;
            lb_4x3.Text = array[29]; if (array[29] != "") lb_4x3.TextColor = Color.Blue;
            lb_4x4.Text = array[30]; if (array[30] != "") lb_4x4.TextColor = Color.Blue;
            lb_4x5.Text = array[31]; if (array[31] != "") lb_4x5.TextColor = Color.Blue;
            lb_4x6.Text = array[32]; if (array[32] != "") lb_4x6.TextColor = Color.Blue;
            lb_4x7.Text = array[33]; if (array[33] != "") lb_4x7.TextColor = Color.Blue;
            lb_4x8.Text = array[34]; if (array[34] != "") lb_4x8.TextColor = Color.Blue;
            lb_4x9.Text = array[35]; if (array[35] != "") lb_4x9.TextColor = Color.Blue;

            lb_5x1.Text = array[36]; if (array[36] != "") lb_5x1.TextColor = Color.Blue;
            lb_5x2.Text = array[37]; if (array[37] != "") lb_5x2.TextColor = Color.Blue;
            lb_5x3.Text = array[38]; if (array[38] != "") lb_5x3.TextColor = Color.Blue;
            lb_5x4.Text = array[39]; if (array[39] != "") lb_5x4.TextColor = Color.Blue;
            lb_5x5.Text = array[40]; if (array[40] != "") lb_5x5.TextColor = Color.Blue;
            lb_5x6.Text = array[41]; if (array[41] != "") lb_5x6.TextColor = Color.Blue;
            lb_5x7.Text = array[42]; if (array[42] != "") lb_5x7.TextColor = Color.Blue;
            lb_5x8.Text = array[43]; if (array[43] != "") lb_5x8.TextColor = Color.Blue;
            lb_5x9.Text = array[44]; if (array[44] != "") lb_5x9.TextColor = Color.Blue;

            lb_6x1.Text = array[45]; if (array[45] != "") lb_6x1.TextColor = Color.Blue;
            lb_6x2.Text = array[46]; if (array[46] != "") lb_6x2.TextColor = Color.Blue;
            lb_6x3.Text = array[47]; if (array[47] != "") lb_6x3.TextColor = Color.Blue;
            lb_6x4.Text = array[48]; if (array[48] != "") lb_6x4.TextColor = Color.Blue;
            lb_6x5.Text = array[49]; if (array[49] != "") lb_6x5.TextColor = Color.Blue;
            lb_6x6.Text = array[50]; if (array[50] != "") lb_6x6.TextColor = Color.Blue;
            lb_6x7.Text = array[51]; if (array[51] != "") lb_6x7.TextColor = Color.Blue;
            lb_6x8.Text = array[52]; if (array[52] != "") lb_6x8.TextColor = Color.Blue;
            lb_6x9.Text = array[53]; if (array[53] != "") lb_6x9.TextColor = Color.Blue;

            lb_7x1.Text = array[54]; if (array[54] != "") lb_7x1.TextColor = Color.Blue;
            lb_7x2.Text = array[55]; if (array[55] != "") lb_7x2.TextColor = Color.Blue;
            lb_7x3.Text = array[56]; if (array[56] != "") lb_7x3.TextColor = Color.Blue;
            lb_7x4.Text = array[57]; if (array[57] != "") lb_7x4.TextColor = Color.Blue;
            lb_7x5.Text = array[58]; if (array[58] != "") lb_7x5.TextColor = Color.Blue;
            lb_7x6.Text = array[59]; if (array[59] != "") lb_7x6.TextColor = Color.Blue;
            lb_7x7.Text = array[60]; if (array[60] != "") lb_7x7.TextColor = Color.Blue;
            lb_7x8.Text = array[61]; if (array[61] != "") lb_7x8.TextColor = Color.Blue;
            lb_7x9.Text = array[62]; if (array[62] != "") lb_7x9.TextColor = Color.Blue;

            lb_8x1.Text = array[63]; if (array[63] != "") lb_8x1.TextColor = Color.Blue;
            lb_8x2.Text = array[64]; if (array[64] != "") lb_8x2.TextColor = Color.Blue;
            lb_8x3.Text = array[65]; if (array[65] != "") lb_8x3.TextColor = Color.Blue;
            lb_8x4.Text = array[66]; if (array[66] != "") lb_8x4.TextColor = Color.Blue;
            lb_8x5.Text = array[67]; if (array[67] != "") lb_8x5.TextColor = Color.Blue;
            lb_8x6.Text = array[68]; if (array[68] != "") lb_8x6.TextColor = Color.Blue;
            lb_8x7.Text = array[69]; if (array[69] != "") lb_8x7.TextColor = Color.Blue;
            lb_8x8.Text = array[70]; if (array[70] != "") lb_8x8.TextColor = Color.Blue;
            lb_8x9.Text = array[71]; if (array[71] != "") lb_8x9.TextColor = Color.Blue;

            lb_9x1.Text = array[72]; if (array[72] != "") lb_9x1.TextColor = Color.Blue;
            lb_9x2.Text = array[73]; if (array[73] != "") lb_9x2.TextColor = Color.Blue;
            lb_9x3.Text = array[74]; if (array[74] != "") lb_9x3.TextColor = Color.Blue;
            lb_9x4.Text = array[75]; if (array[75] != "") lb_9x4.TextColor = Color.Blue;
            lb_9x5.Text = array[76]; if (array[76] != "") lb_9x5.TextColor = Color.Blue;
            lb_9x6.Text = array[77]; if (array[77] != "") lb_9x6.TextColor = Color.Blue;
            lb_9x7.Text = array[78]; if (array[78] != "") lb_9x7.TextColor = Color.Blue;
            lb_9x8.Text = array[79]; if (array[79] != "") lb_9x8.TextColor = Color.Blue;
            lb_9x9.Text = array[80]; if (array[80] != "") lb_9x9.TextColor = Color.Blue;
        }

        
        private void SaveReturn_Clicked(object sender, EventArgs e)
        {
            //---儲存進度切回主頁面
            Application.Current.MainPage = new MainPage();
        }
        private void Label_Clicked(object sender, EventArgs e)
        {
            //---我選到的那個label


        }

        private void RestartGame_Clicked(object sender, EventArgs e)
        {
            if (lb_1x1.TextColor != Color.Blue) lb_1x1.Text = "";
            if (lb_1x2.TextColor != Color.Blue) lb_1x2.Text = "";
            if (lb_1x3.TextColor != Color.Blue) lb_1x3.Text = "";
            if (lb_1x4.TextColor != Color.Blue) lb_1x4.Text = "";
            if (lb_1x5.TextColor != Color.Blue) lb_1x5.Text = "";
            if (lb_1x6.TextColor != Color.Blue) lb_1x6.Text = "";
            if (lb_1x7.TextColor != Color.Blue) lb_1x7.Text = "";
            if (lb_1x8.TextColor != Color.Blue) lb_1x8.Text = "";
            if (lb_1x9.TextColor != Color.Blue) lb_1x9.Text = "";

            if (lb_2x1.TextColor != Color.Blue) lb_2x1.Text = "";
            if (lb_2x2.TextColor != Color.Blue) lb_2x2.Text = "";
            if (lb_2x3.TextColor != Color.Blue) lb_2x3.Text = "";
            if (lb_2x4.TextColor != Color.Blue) lb_2x4.Text = "";
            if (lb_2x5.TextColor != Color.Blue) lb_2x5.Text = "";
            if (lb_2x6.TextColor != Color.Blue) lb_2x6.Text = "";
            if (lb_2x7.TextColor != Color.Blue) lb_2x7.Text = "";
            if (lb_2x8.TextColor != Color.Blue) lb_2x8.Text = "";
            if (lb_2x9.TextColor != Color.Blue) lb_2x9.Text = "";

            if (lb_3x1.TextColor != Color.Blue) lb_3x1.Text = "";
            if (lb_3x2.TextColor != Color.Blue) lb_3x2.Text = "";
            if (lb_3x3.TextColor != Color.Blue) lb_3x3.Text = "";
            if (lb_3x4.TextColor != Color.Blue) lb_3x4.Text = "";
            if (lb_3x5.TextColor != Color.Blue) lb_3x5.Text = "";
            if (lb_3x6.TextColor != Color.Blue) lb_3x6.Text = "";
            if (lb_3x7.TextColor != Color.Blue) lb_3x7.Text = "";
            if (lb_3x8.TextColor != Color.Blue) lb_3x8.Text = "";
            if (lb_3x9.TextColor != Color.Blue) lb_3x9.Text = "";

            if (lb_4x1.TextColor != Color.Blue) lb_4x1.Text = "";
            if (lb_4x2.TextColor != Color.Blue) lb_4x2.Text = "";
            if (lb_4x3.TextColor != Color.Blue) lb_4x3.Text = "";
            if (lb_4x4.TextColor != Color.Blue) lb_4x4.Text = "";
            if (lb_4x5.TextColor != Color.Blue) lb_4x5.Text = "";
            if (lb_4x6.TextColor != Color.Blue) lb_4x6.Text = "";
            if (lb_4x7.TextColor != Color.Blue) lb_4x7.Text = "";
            if (lb_4x8.TextColor != Color.Blue) lb_4x8.Text = "";
            if (lb_4x9.TextColor != Color.Blue) lb_4x9.Text = "";

            if (lb_5x1.TextColor != Color.Blue) lb_5x1.Text = "";
            if (lb_5x2.TextColor != Color.Blue) lb_5x2.Text = "";
            if (lb_5x3.TextColor != Color.Blue) lb_5x3.Text = "";
            if (lb_5x4.TextColor != Color.Blue) lb_5x4.Text = "";
            if (lb_5x5.TextColor != Color.Blue) lb_5x5.Text = "";
            if (lb_5x6.TextColor != Color.Blue) lb_5x6.Text = "";
            if (lb_5x7.TextColor != Color.Blue) lb_5x7.Text = "";
            if (lb_5x8.TextColor != Color.Blue) lb_5x8.Text = "";
            if (lb_5x9.TextColor != Color.Blue) lb_5x9.Text = "";

            if (lb_6x1.TextColor != Color.Blue) lb_6x1.Text = "";
            if (lb_6x2.TextColor != Color.Blue) lb_6x2.Text = "";
            if (lb_6x3.TextColor != Color.Blue) lb_6x3.Text = "";
            if (lb_6x4.TextColor != Color.Blue) lb_6x4.Text = "";
            if (lb_6x5.TextColor != Color.Blue) lb_6x5.Text = "";
            if (lb_6x6.TextColor != Color.Blue) lb_6x6.Text = "";
            if (lb_6x7.TextColor != Color.Blue) lb_6x7.Text = "";
            if (lb_6x8.TextColor != Color.Blue) lb_6x8.Text = "";
            if (lb_6x9.TextColor != Color.Blue) lb_6x9.Text = "";

            if (lb_7x1.TextColor != Color.Blue) lb_7x1.Text = "";
            if (lb_7x2.TextColor != Color.Blue) lb_7x2.Text = "";
            if (lb_7x3.TextColor != Color.Blue) lb_7x3.Text = "";
            if (lb_7x4.TextColor != Color.Blue) lb_7x4.Text = "";
            if (lb_7x5.TextColor != Color.Blue) lb_7x5.Text = "";
            if (lb_7x6.TextColor != Color.Blue) lb_7x6.Text = "";
            if (lb_7x7.TextColor != Color.Blue) lb_7x7.Text = "";
            if (lb_7x8.TextColor != Color.Blue) lb_7x8.Text = "";
            if (lb_7x9.TextColor != Color.Blue) lb_7x9.Text = "";

            if (lb_8x1.TextColor != Color.Blue) lb_8x1.Text = "";
            if (lb_8x2.TextColor != Color.Blue) lb_8x2.Text = "";
            if (lb_8x3.TextColor != Color.Blue) lb_8x3.Text = "";
            if (lb_8x4.TextColor != Color.Blue) lb_8x4.Text = "";
            if (lb_8x5.TextColor != Color.Blue) lb_8x5.Text = "";
            if (lb_8x6.TextColor != Color.Blue) lb_8x6.Text = "";
            if (lb_8x7.TextColor != Color.Blue) lb_8x7.Text = "";
            if (lb_8x8.TextColor != Color.Blue) lb_8x8.Text = "";
            if (lb_8x9.TextColor != Color.Blue) lb_8x9.Text = "";

            if (lb_9x1.TextColor != Color.Blue) lb_9x1.Text = "";
            if (lb_9x2.TextColor != Color.Blue) lb_9x2.Text = "";
            if (lb_9x3.TextColor != Color.Blue) lb_9x3.Text = "";
            if (lb_9x4.TextColor != Color.Blue) lb_9x4.Text = "";
            if (lb_9x5.TextColor != Color.Blue) lb_9x5.Text = "";
            if (lb_9x6.TextColor != Color.Blue) lb_9x6.Text = "";
            if (lb_9x7.TextColor != Color.Blue) lb_9x7.Text = "";
            if (lb_9x8.TextColor != Color.Blue) lb_9x8.Text = "";
            if (lb_9x9.TextColor != Color.Blue) lb_9x9.Text = "";
        }

    }
}