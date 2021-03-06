﻿/*
 * Copyright (c) 2015 Mehrzad Chehraz (mehrzady@gmail.com)
 * Released under the MIT License
 * http://chehraz.ir/mit_license
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:

 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.

 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
namespace Atf.ScreenRecorder.UI.View {
   using System;
   using System.Collections.Generic;
   using System.ComponentModel;
   using System.Drawing;
   using System.Reflection;
   using System.Windows.Forms;
   using System.Diagnostics;
   partial class frmAboutBox : Form {
      #region Constructors
      public frmAboutBox() {
         InitializeComponent();
         this.Text = String.Format("About {0}", Application.ProductName);
         //this.labelCompanyName.Text = AssemblyCompany;
         lblProduct.Text = string.Format("{0} v{1} (Build {2})", Application.ProductName, Application.ProductVersion,
                                         this.AssemblyVersion);
         lblCopyright.Text = string.Format("{0}", this.AssemblyCopyright);
         txtDescription.Text = AssemblyDescription;
      }
      #endregion

      #region Methods
      private void btnOK_Click(object sender, EventArgs e) {
         this.Close();
      }
      private void frmAboutBox_Load(object sender, EventArgs e) {
         if (this.Owner != null && !this.Owner.Visible) {
            // In case of opening from notify icon
            // this.StartPosition = FormStartPosition.CenterScreen;
            Rectangle screenBounds = Screen.PrimaryScreen.WorkingArea;
            this.Location = new Point((screenBounds.Width - this.Width) / 2,
                                       (screenBounds.Height - this.Height) / 2);
         }
      }
      #endregion
      #region Assembly Attribute Accessors
      public string AssemblyDescription {
         get {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if (attributes.Length == 0) {
               return "";
            }
            return ((AssemblyDescriptionAttribute)attributes[0]).Description;
         }
      }
       public string AssemblyCopyright {
         get {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute) 
                                                                                      , false);
            if (attributes.Length == 0) {
               return "";
            }
            return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
         }
      }
      public string AssemblyCompany {
         get {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute),
                                                                                      false);
            if (attributes.Length == 0) {
               return "";
            }
            return ((AssemblyCompanyAttribute)attributes[0]).Company;
         }
      }
      public string AssemblyVersion {
         get {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
         }
      }
      #endregion


   }
}
