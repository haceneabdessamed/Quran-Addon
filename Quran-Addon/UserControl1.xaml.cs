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
       
        
        public string[] sourates = new string[] { "الفاتحة", "البقرة", "آل عمران", "النساء", "المائدة", "الأنعام", "الأعراف", "الأنفال", "التوبة", "يونس", "هود", "يوسف", "الرعد", "إبراهيم", "الحجر", "النحل", "الإسراء", "الكهف", "مريم", "طه", "الأنبياء", "الحج", "المؤمنون", "النور", "الفرقان", "الشعراء", "النمل", "القصص", "العنكبوت", "الروم", "لقمان", "السجدة", "الأحزاب", "سبأ", "فاطر", "يس", "الصافات", "ص", "الزمر", "غافر", "فصلت", "الشورى", "الزخرف", "الدخان", "الجاثية", "الأحقاف", "محمد", "الفتح", "الحجرات", "ق", "الذاريات", "الطور", "النجم", "القمر", "الرحمن", "الواقعة", "الحديد", "المجادلة", "الحشر", "الممتحنة", "الصف", "الجمعة", "المنافقون", "التغابن", "الطلاق", "التحريم", "الملك", "القلم", "الحاقة", "المعارج", "نوح", "الجن", "المزمل", "المدثر", "القيامة", "الإنسان", "المرسلات", "النبأ", "النازعات", "عبس", "التكوير", "الإنفطار", "المطففين", "الإنشقاق", "البروج", "الطارق", "الأعلى", "الغاشية", "الفجر", "البلد", "الشمس", "الليل", "الضحى", "الشرح", "التين", "العلق", "القدر", "البينة", "الزلزلة", "العاديات", "القارعة", "التكاثر", "العصر", "الهمزة", "الفيل", "قريش", "الماعون", "الكوثر", "الكافرون", "النصر", "المسد", "الإخلاص", "الفلق", "الناس" };
          

        

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
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;
            Word.Paragraphs currentParagraph = Globals.ThisAddIn.Application.Selection.Paragraphs;
            ///currentParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            currentRange.Text = "[ " + Result[a].Texte + "] ( " + Result[a].Aya + " : " + sourates[Result[a].Soura - 1] + " )";
            currentRange.Font.NameBi = "KFGQPC Uthmanic Script HAFS";
            currentRange.Font.SizeBi = 14;
            currentParagraph.Add(currentRange);
            currentRange.Font.SizeBi = 14;


        }
    }
}
