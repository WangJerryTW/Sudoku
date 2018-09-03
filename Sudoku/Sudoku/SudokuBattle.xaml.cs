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
		}
        private void SaveReturn_Clicked(object sender, EventArgs e)
        {
            //---儲存進度切回主頁面
            Application.Current.MainPage = new MainPage();
        }
    }
}