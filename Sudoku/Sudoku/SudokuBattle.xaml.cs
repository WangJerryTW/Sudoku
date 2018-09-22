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

            LoadStage(new Random().Next(1, 4)); //---load預設關卡
        }

        public void LoadStage(int stageNumber)
        {
            //stageNumber = 4;
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
            string[] array2 =
            {
                "" , "4", "1", "5", "7", "", "", "", "2",
                "" , "7", "", "", "8", "", "", "1", "4",
                "6" , "", "", "", "", "1", "", "9", "",
                "2" , "", "3", "8", "", "7", "5", "", "",
                "" , "", "8", "3", "", "", "6", "", "",
                "" , "", "5", "", "6", "", "9", "", "3",
                "" , "2", "", "9", "", "", "", "", "8",
                "8" , "5", "", "", "4", "", "", "3", "",
                "9" , "", "", "", "2", "8", "1", "5", ""
            };
            string[] array3 =
            {
                "3" , "7", "2", "4", "", "9", "", "1", "",
                "" , "", "", "3", "", "5", "", "", "",
                "6" , "", "", "8", "1", "2", "", "", "3",
                "" , "6", "7", "", "8", "", "9", "4", "",
                "" , "", "", "5", "4", "6", "", "", "",
                "1" , "4", "3", "", "", "", "5", "6", "8",
                "" , "", "5", "", "", "", "4", "", "",
                "8" , "3", "", "7", "2", "4", "", "5", "9",
                "4" , "1", "9", "", "", "", "2", "3", "7"
            };
            string[] array4 =
            {
                "4" , "", "3", "7", "", "1", "9", "5", "",
                "2" , "1", "", "", "9", "", "4", "", "3",
                "" , "", "9", "4", "", "3", "", "7", "1",
                "6" , "8", "", "9", "7", "", "1", "", "4",
                "" , "4", "5", "", "1", "8", "", "9", "",
                "9" , "", "1", "3", "6", "", "8", "2", "",
                "7" , "9", "", "1", "", "2", "", "6", "",
                "" , "3", "6", "", "4", "", "2", "1", "9",
                "1" , "", "8", "", "5", "", "3", "", "7"
            };
            switch (stageNumber)
            {
                case 1:
                    StageLabel.Text = "關卡代號: 1 ";
                    ReadGame(array);
                    break;
                case 2:
                    StageLabel.Text = "關卡代號: 2 ";
                    ReadGame(array2);
                    break;
                case 3:
                    StageLabel.Text = "關卡代號: 3 ";
                    ReadGame(array3);
                    break;
                case 4:
                    StageLabel.Text = "關卡代號: 4 ";
                    ReadGame(array4);
                    break;
            }

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

            //-----判斷是否已經結束? 比對機制 --把目前值讀成陣列再與解答陣列compare  相等的話，就跳出WIN的字樣
            IsRuleCorrect();
            SetErrorColor();



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
            IsRuleCorrect();
            SetErrorColor();

            if (IsGameEnd() == true) GoVictoryPage();


        }
        bool Is_All_TextFilled()
        {
            if (lb_1x1.Text != "" && lb_1x2.Text != "" && lb_1x3.Text != "" && lb_1x4.Text != "" &&
                lb_1x5.Text != "" && lb_1x6.Text != "" && lb_1x7.Text != "" && lb_1x8.Text != "" && lb_1x9.Text != "" &&
                lb_2x1.Text != "" && lb_2x2.Text != "" && lb_2x3.Text != "" && lb_2x4.Text != "" &&
                lb_2x5.Text != "" && lb_2x6.Text != "" && lb_2x7.Text != "" && lb_2x8.Text != "" && lb_2x9.Text != "" &&
                lb_3x1.Text != "" && lb_3x2.Text != "" && lb_3x3.Text != "" && lb_3x4.Text != "" &&
                lb_3x5.Text != "" && lb_3x6.Text != "" && lb_3x7.Text != "" && lb_3x8.Text != "" && lb_3x9.Text != "" &&
                lb_4x1.Text != "" && lb_4x2.Text != "" && lb_4x3.Text != "" && lb_4x4.Text != "" &&
                lb_4x5.Text != "" && lb_4x6.Text != "" && lb_4x7.Text != "" && lb_4x8.Text != "" && lb_4x9.Text != "" &&
                lb_5x1.Text != "" && lb_5x2.Text != "" && lb_5x3.Text != "" && lb_5x4.Text != "" &&
                lb_5x5.Text != "" && lb_5x6.Text != "" && lb_5x7.Text != "" && lb_5x8.Text != "" && lb_5x9.Text != "" &&
                lb_6x1.Text != "" && lb_6x2.Text != "" && lb_6x3.Text != "" && lb_6x4.Text != "" &&
                lb_6x5.Text != "" && lb_6x6.Text != "" && lb_6x7.Text != "" && lb_6x8.Text != "" && lb_6x9.Text != "" &&
                lb_7x1.Text != "" && lb_7x2.Text != "" && lb_7x3.Text != "" && lb_7x4.Text != "" &&
                lb_7x5.Text != "" && lb_7x6.Text != "" && lb_7x7.Text != "" && lb_7x8.Text != "" && lb_7x9.Text != "" &&
                lb_8x1.Text != "" && lb_8x2.Text != "" && lb_8x3.Text != "" && lb_8x4.Text != "" &&
                lb_8x5.Text != "" && lb_8x6.Text != "" && lb_8x7.Text != "" && lb_8x8.Text != "" && lb_8x9.Text != "" &&
                lb_9x1.Text != "" && lb_9x2.Text != "" && lb_9x3.Text != "" && lb_9x4.Text != "" &&
                lb_9x5.Text != "" && lb_9x6.Text != "" && lb_9x7.Text != "" && lb_9x8.Text != "" && lb_9x9.Text != "")
                return true;
            else
                return false;
        }

        bool IsRuleCorrect()
        {
            for (int i = 0; i < 81; i++) ResultArray[i] = false;
            GetNowArray();
            bool[] array = new bool[9];
            //--0~8數字不能有一樣
            //--rule1: row1
            IsNumHaveRepeat(NowArray[0], NowArray[1], NowArray[2], NowArray[3], NowArray[4], NowArray[5], NowArray[6], NowArray[7], NowArray[8], ref array);
            SetIndexError(0, 1, 2, 3, 4, 5, 6, 7, 8, array);
            //--rule2: row2
            IsNumHaveRepeat(NowArray[9], NowArray[10], NowArray[11], NowArray[12], NowArray[13], NowArray[14], NowArray[15], NowArray[16], NowArray[17], ref array);
            SetIndexError(9, 10, 11, 12, 13, 14, 15, 16, 17, array);
            //--rule3: row3
            IsNumHaveRepeat(NowArray[18], NowArray[19], NowArray[20], NowArray[21], NowArray[22], NowArray[23], NowArray[24], NowArray[25], NowArray[26], ref array);
            SetIndexError(18, 19, 20, 21, 22, 23, 24, 25, 26, array);
            //--rule4: row4
            IsNumHaveRepeat(NowArray[27], NowArray[28], NowArray[29], NowArray[30], NowArray[31], NowArray[32], NowArray[33], NowArray[34], NowArray[35], ref array);
            SetIndexError(27, 28, 29, 30, 31, 32, 33, 34, 35, array);
            //--rule5: row5
            IsNumHaveRepeat(NowArray[36], NowArray[37], NowArray[38], NowArray[39], NowArray[40], NowArray[41], NowArray[42], NowArray[43], NowArray[44], ref array);
            SetIndexError(36, 37, 38, 39, 40, 41, 42, 43, 44, array);
            //--rule6: row6
            IsNumHaveRepeat(NowArray[45], NowArray[46], NowArray[47], NowArray[48], NowArray[49], NowArray[50], NowArray[51], NowArray[52], NowArray[53], ref array);
            SetIndexError(45, 46, 47, 48, 49, 50, 51, 52, 53, array);
            //--rule7: row7
            IsNumHaveRepeat(NowArray[54], NowArray[55], NowArray[56], NowArray[57], NowArray[58], NowArray[59], NowArray[60], NowArray[61], NowArray[62], ref array);
            SetIndexError(54, 55, 56, 57, 58, 59, 60, 61, 62, array);
            //--rule8: row8
            IsNumHaveRepeat(NowArray[63], NowArray[64], NowArray[65], NowArray[66], NowArray[67], NowArray[68], NowArray[69], NowArray[70], NowArray[71], ref array);
            SetIndexError(63, 64, 65, 66, 67, 68, 69, 70, 71, array);
            //--rule9: row9
            IsNumHaveRepeat(NowArray[72], NowArray[73], NowArray[74], NowArray[75], NowArray[76], NowArray[77], NowArray[78], NowArray[79], NowArray[80], ref array);
            SetIndexError(72, 73, 74, 75, 76, 77, 78, 79, 80, array);

            //--rule10: column1
            IsNumHaveRepeat(NowArray[0], NowArray[9], NowArray[18], NowArray[27], NowArray[36], NowArray[45], NowArray[54], NowArray[63], NowArray[72], ref array);
            SetIndexError(0, 9, 18, 27, 36, 45, 54, 63, 72, array);
            //--rule11: column2
            IsNumHaveRepeat(NowArray[1], NowArray[10], NowArray[19], NowArray[28], NowArray[37], NowArray[46], NowArray[55], NowArray[64], NowArray[73], ref array);
            SetIndexError(1, 10, 19, 28, 37, 46, 55, 64, 73, array);
            //--rule12: column3
            IsNumHaveRepeat(NowArray[2], NowArray[11], NowArray[20], NowArray[29], NowArray[38], NowArray[47], NowArray[56], NowArray[65], NowArray[74], ref array);
            SetIndexError(2, 11, 20, 29, 38, 47, 56, 65, 74, array);
            //--rule13: column4
            IsNumHaveRepeat(NowArray[3], NowArray[12], NowArray[21], NowArray[30], NowArray[39], NowArray[48], NowArray[57], NowArray[66], NowArray[75], ref array);
            SetIndexError(3, 12, 21, 30, 39, 48, 57, 66, 75, array);
            //--rule14: column5
            IsNumHaveRepeat(NowArray[4], NowArray[13], NowArray[22], NowArray[31], NowArray[40], NowArray[49], NowArray[58], NowArray[67], NowArray[76], ref array);
            SetIndexError(4, 13, 22, 31, 40, 49, 58, 67, 76, array);
            //--rule15: column6
            IsNumHaveRepeat(NowArray[5], NowArray[14], NowArray[23], NowArray[32], NowArray[41], NowArray[50], NowArray[59], NowArray[68], NowArray[77], ref array);
            SetIndexError(5, 14, 23, 32, 41, 50, 59, 68, 77, array);
            //--rule16: column7
            IsNumHaveRepeat(NowArray[6], NowArray[15], NowArray[24], NowArray[33], NowArray[42], NowArray[51], NowArray[60], NowArray[69], NowArray[78], ref array);
            SetIndexError(6, 15, 24, 33, 42, 51, 60, 69, 78, array);
            //--rule17: column8
            IsNumHaveRepeat(NowArray[7], NowArray[16], NowArray[25], NowArray[34], NowArray[43], NowArray[52], NowArray[61], NowArray[70], NowArray[79], ref array);
            SetIndexError(7, 16, 25, 34, 43, 52, 61, 70, 79, array);
            //--rule18: column9
            IsNumHaveRepeat(NowArray[8], NowArray[17], NowArray[26], NowArray[35], NowArray[44], NowArray[53], NowArray[62], NowArray[71], NowArray[80], ref array);
            SetIndexError(8, 17, 26, 35, 44, 53, 62, 71, 80, array);

            //--rule19: square1
            IsNumHaveRepeat(NowArray[0], NowArray[1], NowArray[2], NowArray[9], NowArray[10], NowArray[11], NowArray[18], NowArray[19], NowArray[20], ref array);
            SetIndexError(0, 1, 2, 9, 10, 11, 18, 19, 20, array);
            //--rule20: square2
            IsNumHaveRepeat(NowArray[3], NowArray[4], NowArray[5], NowArray[12], NowArray[13], NowArray[14], NowArray[21], NowArray[22], NowArray[23], ref array);
            SetIndexError(3, 4, 5, 12, 13, 14, 21, 22, 23, array);
            //--rule21: square3
            IsNumHaveRepeat(NowArray[6], NowArray[7], NowArray[8], NowArray[15], NowArray[16], NowArray[17], NowArray[24], NowArray[25], NowArray[26], ref array);
            SetIndexError(6, 7, 8, 15, 16, 17, 24, 25, 26, array);

            //--rule22: square4
            IsNumHaveRepeat(NowArray[27], NowArray[28], NowArray[29], NowArray[36], NowArray[37], NowArray[38], NowArray[45], NowArray[46], NowArray[47], ref array);
            SetIndexError(27, 28, 29, 36, 37, 38, 45, 46, 47, array);
            //--rule23: square5
            IsNumHaveRepeat(NowArray[30], NowArray[31], NowArray[32], NowArray[39], NowArray[40], NowArray[41], NowArray[48], NowArray[49], NowArray[50], ref array);
            SetIndexError(30, 31, 32, 39, 40, 41, 48, 49, 50, array);
            //--rule24: square6
            IsNumHaveRepeat(NowArray[33], NowArray[34], NowArray[35], NowArray[42], NowArray[43], NowArray[44], NowArray[51], NowArray[52], NowArray[53], ref array);
            SetIndexError(33, 34, 35, 42, 43, 44, 51, 52, 53, array);

            //--rule25: square7
            IsNumHaveRepeat(NowArray[54], NowArray[55], NowArray[56], NowArray[63], NowArray[64], NowArray[65], NowArray[72], NowArray[73], NowArray[74], ref array);
            SetIndexError(54, 55, 56, 63, 64, 65, 72, 73, 74, array);
            //--rule26: square8
            IsNumHaveRepeat(NowArray[57], NowArray[58], NowArray[59], NowArray[66], NowArray[67], NowArray[68], NowArray[75], NowArray[76], NowArray[77], ref array);
            SetIndexError(57, 58, 59, 66, 67, 68, 75, 76, 77, array);
            //--rule27: square9
            IsNumHaveRepeat(NowArray[60], NowArray[61], NowArray[62], NowArray[69], NowArray[70], NowArray[71], NowArray[78], NowArray[79], NowArray[80], ref array);
            SetIndexError(60, 61, 62, 69, 70, 71, 78, 79, 80, array);


            return false;
        }
        
        void SetErrorColor()
        {
            if (ResultArray[0] == true)  lb_1x1.BackgroundColor = Color.Red; 
            if (ResultArray[1] == true) lb_1x2.BackgroundColor = Color.Red;
            if (ResultArray[2] == true)  lb_1x3.BackgroundColor = Color.Red;
            if (ResultArray[3] == true)  lb_1x4.BackgroundColor = Color.Red; 
            if (ResultArray[4] == true) lb_1x5.BackgroundColor = Color.Red;
            if (ResultArray[5] == true) lb_1x6.BackgroundColor = Color.Red;
            if (ResultArray[6] == true) lb_1x7.BackgroundColor = Color.Red;
            if (ResultArray[7] == true) lb_1x8.BackgroundColor = Color.Red;
            if (ResultArray[8] == true) lb_1x9.BackgroundColor = Color.Red;

            if (ResultArray[9] == true) lb_2x1.BackgroundColor = Color.Red;
            if (ResultArray[10] == true) lb_2x2.BackgroundColor = Color.Red;
            if (ResultArray[11] == true) lb_2x3.BackgroundColor = Color.Red;
            if (ResultArray[12] == true) lb_2x4.BackgroundColor = Color.Red;
            if (ResultArray[13] == true) lb_2x5.BackgroundColor = Color.Red;
            if (ResultArray[14] == true) lb_2x6.BackgroundColor = Color.Red;
            if (ResultArray[15] == true) lb_2x7.BackgroundColor = Color.Red;
            if (ResultArray[16] == true) lb_2x8.BackgroundColor = Color.Red;
            if (ResultArray[17] == true) lb_2x9.BackgroundColor = Color.Red;

            if (ResultArray[18] == true) lb_3x1.BackgroundColor = Color.Red;
            if (ResultArray[19] == true) lb_3x2.BackgroundColor = Color.Red;
            if (ResultArray[20] == true) lb_3x3.BackgroundColor = Color.Red;
            if (ResultArray[21] == true) lb_3x4.BackgroundColor = Color.Red;
            if (ResultArray[22] == true) lb_3x5.BackgroundColor = Color.Red;
            if (ResultArray[23] == true) lb_3x6.BackgroundColor = Color.Red;
            if (ResultArray[24] == true) lb_3x7.BackgroundColor = Color.Red;
            if (ResultArray[25] == true) lb_3x8.BackgroundColor = Color.Red;
            if (ResultArray[26] == true) lb_3x9.BackgroundColor = Color.Red;

            if (ResultArray[27] == true) lb_4x1.BackgroundColor = Color.Red;
            if (ResultArray[28] == true) lb_4x2.BackgroundColor = Color.Red;
            if (ResultArray[29] == true) lb_4x3.BackgroundColor = Color.Red;
            if (ResultArray[30] == true) lb_4x4.BackgroundColor = Color.Red;
            if (ResultArray[31] == true) lb_4x5.BackgroundColor = Color.Red;
            if (ResultArray[32] == true) lb_4x6.BackgroundColor = Color.Red;
            if (ResultArray[33] == true) lb_4x7.BackgroundColor = Color.Red;
            if (ResultArray[34] == true) lb_4x8.BackgroundColor = Color.Red;
            if (ResultArray[35] == true) lb_4x9.BackgroundColor = Color.Red;

            if (ResultArray[36] == true) lb_5x1.BackgroundColor = Color.Red;
            if (ResultArray[37] == true) lb_5x2.BackgroundColor = Color.Red;
            if (ResultArray[38] == true) lb_5x3.BackgroundColor = Color.Red;
            if (ResultArray[39] == true) lb_5x4.BackgroundColor = Color.Red;
            if (ResultArray[40] == true) lb_5x5.BackgroundColor = Color.Red;
            if (ResultArray[41] == true) lb_5x6.BackgroundColor = Color.Red;
            if (ResultArray[42] == true) lb_5x7.BackgroundColor = Color.Red;
            if (ResultArray[43] == true) lb_5x8.BackgroundColor = Color.Red;
            if (ResultArray[44] == true) lb_5x9.BackgroundColor = Color.Red;

            if (ResultArray[45] == true) lb_6x1.BackgroundColor = Color.Red;
            if (ResultArray[46] == true) lb_6x2.BackgroundColor = Color.Red;
            if (ResultArray[47] == true) lb_6x3.BackgroundColor = Color.Red;
            if (ResultArray[48] == true) lb_6x4.BackgroundColor = Color.Red;
            if (ResultArray[49] == true) lb_6x5.BackgroundColor = Color.Red;
            if (ResultArray[50] == true) lb_6x6.BackgroundColor = Color.Red;
            if (ResultArray[51] == true) lb_6x7.BackgroundColor = Color.Red;
            if (ResultArray[52] == true) lb_6x8.BackgroundColor = Color.Red;
            if (ResultArray[53] == true) lb_6x9.BackgroundColor = Color.Red;

            if (ResultArray[54] == true) lb_7x1.BackgroundColor = Color.Red;
            if (ResultArray[55] == true) lb_7x2.BackgroundColor = Color.Red;
            if (ResultArray[56] == true) lb_7x3.BackgroundColor = Color.Red;
            if (ResultArray[57] == true) lb_7x4.BackgroundColor = Color.Red;
            if (ResultArray[58] == true) lb_7x5.BackgroundColor = Color.Red;
            if (ResultArray[59] == true) lb_7x6.BackgroundColor = Color.Red;
            if (ResultArray[60] == true) lb_7x7.BackgroundColor = Color.Red;
            if (ResultArray[61] == true) lb_7x8.BackgroundColor = Color.Red;
            if (ResultArray[62] == true) lb_7x9.BackgroundColor = Color.Red;

            if (ResultArray[63] == true) lb_8x1.BackgroundColor = Color.Red;
            if (ResultArray[64] == true) lb_8x2.BackgroundColor = Color.Red;
            if (ResultArray[65] == true) lb_8x3.BackgroundColor = Color.Red;
            if (ResultArray[66] == true) lb_8x4.BackgroundColor = Color.Red;
            if (ResultArray[67] == true) lb_8x5.BackgroundColor = Color.Red;
            if (ResultArray[68] == true) lb_8x6.BackgroundColor = Color.Red;
            if (ResultArray[69] == true) lb_8x7.BackgroundColor = Color.Red;
            if (ResultArray[70] == true) lb_8x8.BackgroundColor = Color.Red;
            if (ResultArray[71] == true) lb_8x9.BackgroundColor = Color.Red;

            if (ResultArray[72] == true) lb_9x1.BackgroundColor = Color.Red;
            if (ResultArray[73] == true) lb_9x2.BackgroundColor = Color.Red;
            if (ResultArray[74] == true) lb_9x3.BackgroundColor = Color.Red;
            if (ResultArray[75] == true) lb_9x4.BackgroundColor = Color.Red;
            if (ResultArray[76] == true) lb_9x5.BackgroundColor = Color.Red;
            if (ResultArray[77] == true) lb_9x6.BackgroundColor = Color.Red;
            if (ResultArray[78] == true) lb_9x7.BackgroundColor = Color.Red;
            if (ResultArray[79] == true) lb_9x8.BackgroundColor = Color.Red;
            if (ResultArray[80] == true) lb_9x9.BackgroundColor = Color.Red;
        }

        void GoVictoryPage()
        {
            Application.Current.MainPage = new VictoryPage();
        }

        void IsNumHaveRepeat(string num1, string num2, string num3, string num4, string num5,
    string num6, string num7, string num8, string num9, ref bool[] array)
        {
            array = new bool[9];
            //前處理
            if (string.IsNullOrEmpty(num1)) num1 = "0";
            if (string.IsNullOrEmpty(num2)) num2 = "0";
            if (string.IsNullOrEmpty(num3)) num3 = "0";
            if (string.IsNullOrEmpty(num4)) num4 = "0";
            if (string.IsNullOrEmpty(num5)) num5 = "0";
            if (string.IsNullOrEmpty(num6)) num6 = "0";
            if (string.IsNullOrEmpty(num7)) num7 = "0";
            if (string.IsNullOrEmpty(num8)) num8 = "0";
            if (string.IsNullOrEmpty(num9)) num9 = "0";

            int[] array1 = {
                               int.Parse(num1),
                               int.Parse(num2),
                               int.Parse(num3),
                               int.Parse(num4),
                               int.Parse(num5),
                               int.Parse(num6),
                               int.Parse(num7),
                               int.Parse(num8),
                               int.Parse(num9)
                           };
            var dict1 = new Dictionary<int, int>();

            foreach (var value in array1)
            {
                if (dict1.ContainsKey(value))
                    dict1[value]++;
                else
                    dict1[value] = 1;
            }

            foreach (var pair in dict1)
            {
                if (pair.Value > 1)
                {
                    if (pair.Key == 0) continue; //---排除0的結果
                    for (int i = 0; i < 9; i++)
                    {
                        if (array[i] == true) continue; //---這邊的目的是為了保留true的結果

                        if (array1[i] == pair.Key) array[i] = true;
                        else array[i] = false;
                    }
                }
            }
        }
        void SetIndexError(int index1,int index2,int index3,int index4,int index5,
            int index6,int index7,int index8,int index9, bool[] array)
        {
            //----有true的情況，就不填入false了.....
            if (ResultArray[index1] != true) ResultArray[index1] = array[0];
            if (ResultArray[index2] != true) ResultArray[index2] = array[1];
            if (ResultArray[index3] != true) ResultArray[index3] = array[2];
            if (ResultArray[index4] != true) ResultArray[index4] = array[3];
            if (ResultArray[index5] != true) ResultArray[index5] = array[4];
            if (ResultArray[index6] != true) ResultArray[index6] = array[5];
            if (ResultArray[index7] != true) ResultArray[index7] = array[6];
            if (ResultArray[index8] != true) ResultArray[index8] = array[7];
            if (ResultArray[index9] != true) ResultArray[index9] = array[8];
        }
        
        void GetNowArray()
        {
            NowArray[0] = lb_1x1.Text;
            NowArray[1] = lb_1x2.Text;
            NowArray[2] = lb_1x3.Text;
            NowArray[3] = lb_1x4.Text;
            NowArray[4] = lb_1x5.Text;
            NowArray[5] = lb_1x6.Text;
            NowArray[6] = lb_1x7.Text;
            NowArray[7] = lb_1x8.Text;
            NowArray[8] = lb_1x9.Text;

            NowArray[9] = lb_2x1.Text;
            NowArray[10] = lb_2x2.Text;
            NowArray[11] = lb_2x3.Text;
            NowArray[12] = lb_2x4.Text;
            NowArray[13] = lb_2x5.Text;
            NowArray[14] = lb_2x6.Text;
            NowArray[15] = lb_2x7.Text;
            NowArray[16] = lb_2x8.Text;
            NowArray[17] = lb_2x9.Text;
            
            NowArray[18] = lb_3x1.Text;
            NowArray[19] = lb_3x2.Text;
            NowArray[20] = lb_3x3.Text;
            NowArray[21] = lb_3x4.Text;
            NowArray[22] = lb_3x5.Text;
            NowArray[23] = lb_3x6.Text;
            NowArray[24] = lb_3x7.Text;
            NowArray[25] = lb_3x8.Text;
            NowArray[26] = lb_3x9.Text;

            NowArray[27] = lb_4x1.Text;
            NowArray[28] = lb_4x2.Text;
            NowArray[29] = lb_4x3.Text;
            NowArray[30] = lb_4x4.Text;
            NowArray[31] = lb_4x5.Text;
            NowArray[32] = lb_4x6.Text;
            NowArray[33] = lb_4x7.Text;
            NowArray[34] = lb_4x8.Text;
            NowArray[35] = lb_4x9.Text;

            NowArray[36] = lb_5x1.Text;
            NowArray[37] = lb_5x2.Text;
            NowArray[38] = lb_5x3.Text;
            NowArray[39] = lb_5x4.Text;
            NowArray[40] = lb_5x5.Text;
            NowArray[41] = lb_5x6.Text;
            NowArray[42] = lb_5x7.Text;
            NowArray[43] = lb_5x8.Text;
            NowArray[44] = lb_5x9.Text;

            NowArray[45] = lb_6x1.Text;
            NowArray[46] = lb_6x2.Text;
            NowArray[47] = lb_6x3.Text;
            NowArray[48] = lb_6x4.Text;
            NowArray[49] = lb_6x5.Text;
            NowArray[50] = lb_6x6.Text;
            NowArray[51] = lb_6x7.Text;
            NowArray[52] = lb_6x8.Text;
            NowArray[53] = lb_6x9.Text;

            NowArray[54] = lb_7x1.Text;
            NowArray[55] = lb_7x2.Text;
            NowArray[56] = lb_7x3.Text;
            NowArray[57] = lb_7x4.Text;
            NowArray[58] = lb_7x5.Text;
            NowArray[59] = lb_7x6.Text;
            NowArray[60] = lb_7x7.Text;
            NowArray[61] = lb_7x8.Text;
            NowArray[62] = lb_7x9.Text;

            NowArray[63] = lb_8x1.Text;
            NowArray[64] = lb_8x2.Text;
            NowArray[65] = lb_8x3.Text;
            NowArray[66] = lb_8x4.Text;
            NowArray[67] = lb_8x5.Text;
            NowArray[68] = lb_8x6.Text;
            NowArray[69] = lb_8x7.Text;
            NowArray[70] = lb_8x8.Text;
            NowArray[71] = lb_8x9.Text;

            NowArray[72] = lb_9x1.Text;
            NowArray[73] = lb_9x2.Text;
            NowArray[74] = lb_9x3.Text;
            NowArray[75] = lb_9x4.Text;
            NowArray[76] = lb_9x5.Text;
            NowArray[77] = lb_9x6.Text;
            NowArray[78] = lb_9x7.Text;
            NowArray[79] = lb_9x8.Text;
            NowArray[80] = lb_9x9.Text;
        }


        string[] NowArray = new string[81];
        bool[] ResultArray = new bool[81];

        bool IsGameEnd()
        {
            //---判斷ResultArray是否裡面都沒有0
            for(int i = 0;i<81;i++)
            {
                if (string.IsNullOrEmpty(NowArray[i])) return false;
            }
            //---判斷沒有錯誤
            for( int j = 0; j < 81; j++)
            {
                if(ResultArray[j] == true) return false;
            }

            return true;
        }
        
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