﻿#pragma checksum "..\..\..\Modyfikacje\ModyfikujRachunek.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0F101908377DB4DF36DBFAB019CB54B3A3560E90B2B0EB0BAF39455A91D561CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Mieszkania.Modyfikacje;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Mieszkania.Modyfikacje {
    
    
    /// <summary>
    /// ModyfikujRachunek
    /// </summary>
    public partial class ModyfikujRachunek : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_id;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_wybierz;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Kwota;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txt_termin;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_modyfikuj;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbox_oplacone;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_idrach;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_wybierzrach;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Mieszkania;component/modyfikacje/modyfikujrachunek.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txt_id = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.btn_wybierz = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
            this.btn_wybierz.Click += new System.Windows.RoutedEventHandler(this.btn_wybierz_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_Kwota = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
            this.txt_Kwota.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_Kwota_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_termin = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.btn_modyfikuj = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
            this.btn_modyfikuj.Click += new System.Windows.RoutedEventHandler(this.btn_modyfikuj_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cbox_oplacone = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.txt_idrach = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btn_wybierzrach = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Modyfikacje\ModyfikujRachunek.xaml"
            this.btn_wybierzrach.Click += new System.Windows.RoutedEventHandler(this.btn_wybierzrach_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

