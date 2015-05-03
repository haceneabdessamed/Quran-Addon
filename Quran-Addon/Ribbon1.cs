﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;
using System.Xaml;
using System.Web.Http;
using System.Net.Http;
using System.IO;
using System.Web.Helpers;
namespace Quran_Addon
{
    public partial class Ribbon1
    {
        public SearchForm FormRecherche;
        public UserControl1 C;
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {

        }
        protected void button_Click(object sender, EventArgs e)
        {
            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;
            currentRange.Text = this.FormRecherche.textBox1.Text;            
        }


        protected void ajouterClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;
            currentRange.Text = this.C.Tb1.Text;
            this.C.Hide();

        }
        private void group1_DialogLauncherClick(object sender, RibbonControlEventArgs e)
        {
            
            FormRecherche = new SearchForm();
            ///FormRecherche.Show();
            C = new UserControl1();
            C.Btn1.Click += new System.Windows.RoutedEventHandler(ajouterClick);
            C.ShowDialog();
            System.Net.WebRequest request = System.Net.WebRequest.Create("http://127.0.0.1/Quran_Text_Editor/controllers/SearchController.php");
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "query=محمد&function=service&page=1";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            System.Net.WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((System.Net.HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
            dynamic dynamicObject = Json.Decode(responseFromServer);
            MessageBox.Show(dynamicObject[3][0].texte);

        }

        private void dropDown1_SelectionChanged(object sender, RibbonControlEventArgs e)
        {

        }
    }
}