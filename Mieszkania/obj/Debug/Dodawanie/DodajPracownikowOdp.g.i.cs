﻿#pragma checksum "..\..\..\Dodawanie\DodajPracownikowOdp.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F52AFDAA639A6D637077A2901F4F28A8A237B72C04E69C65D31B03E36A58E42A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Mieszkania.Dodawanie;
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


namespace Mieszkania.Dodawanie {
    
    
    /// <summary>
    /// DodajPracownikowOdp
    /// </summary>
    public partial class DodajPracownikowOdp : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Dodawanie\DodajPracownikowOdp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_imie;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Dodawanie\DodajPracownikowOdp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_nazw;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Dodawanie\DodajPracownikowOdp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_id;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Dodawanie\DodajPracownikowOdp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_wybierz;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Dodawanie\DodajPracownikowOdp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataG_Odp;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Dodawanie\DodajPracownikowOdp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Dodaj;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Dodawanie\DodajPracownikowOdp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataG_dost;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Dodawanie\DodajPracownikowOdp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Usun;
        
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
            System.Uri resourceLocater = new System.Uri("/Mieszkania;component/dodawanie/dodajpracownikowodp.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Dodawanie\DodajPracownikowOdp.xaml"
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
            this.lbl_imie = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lbl_nazw = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lbl_id = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btn_wybierz = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Dodawanie\DodajPracownikowOdp.xaml"
            this.btn_wybierz.Click += new System.Windows.RoutedEventHandler(this.btn_wybierz_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dataG_Odp = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btn_Dodaj = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Dodawanie\DodajPracownikowOdp.xaml"
            this.btn_Dodaj.Click += new System.Windows.RoutedEventHandler(this.btn_Dodaj_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dataG_dost = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.btn_Usun = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Dodawanie\DodajPracownikowOdp.xaml"
            this.btn_Usun.Click += new System.Windows.RoutedEventHandler(this.btn_Usun_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

