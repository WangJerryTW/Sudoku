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
	public partial class VictoryPage : ContentPage
	{
		public VictoryPage ()
		{
			InitializeComponent ();
            GoGO.Source = ImageSource.FromResource("Sudoku.Images.Goodjob.gif");
        }
        private void BackToMenu_Clicked(object sender, EventArgs e)
        {
            //--頁面切換到數獨頁面
            Application.Current.MainPage = new MainPage();
        }
        private void FightOtherStage_Clicked(object sender, EventArgs e)
        {
            //--頁面切換到數獨頁面
            Application.Current.MainPage = new SudokuBattle();
        }
    }
}