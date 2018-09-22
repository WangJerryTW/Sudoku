using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sudoku
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }

        private void ChallangeMode_Clicked(object sender, EventArgs e)
        {
            //--頁面切換到數獨頁面
            Application.Current.MainPage = new SudokuBattle();
        }

    }
}
