using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Threading;
using Word = Microsoft.Office.Interop.Word;


namespace Quran_Addon
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : Window
    {
        public List<Verset> Result;
        

        

        public UserControl1()
        {

            InitializeComponent();
            Result = new List<Verset>();
            Result.Add(new Verset() { Soura = 1, Aya = 1, Texte = "allah" });
            Result.Add(new Verset() { Soura = 1, Aya = 2, Texte = "rassoul" });
            Result.Add(new Verset() { Soura = 1, Aya = 3, Texte = "mohamed" });
            lvDataBinding.ItemsSource = Result;
        }
        
        private void Tb1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lvDataBinding_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int a = lvDataBinding.SelectedIndex;
            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;
            currentRange.Text = "[" + Result[a].Texte + "] ( " + Result[a].Aya + " : " + Result[a].Soura + " )";
            currentRange.Font.NameBi = "KFGQPC Uthmanic Script HAFS";
            currentRange.Font.SizeBi = 14;


        }
    }
}
