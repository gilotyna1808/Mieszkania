﻿#pragma checksum "..\..\..\Dodawanie\DodajLokatora.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1576ABB51B625055DF6461A1C7ADE0881667EE6E6014C88ACF88D4150AAE7391"
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
    /// DodajLokatora
    /// </summary>
    public partial class DodajLokatora : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\Dodawanie\DodajLokatora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_imie;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Dodawanie\DodajLokatora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_naz;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Dodawanie\DodajLokatora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_tel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Dodawanie\DodajLokatora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_dodaj;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Dodawanie\DodajLokatora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_pesel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Dodawanie\DodajLokatora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_adresk;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Dodawanie\DodajLokatora.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_mail;
        
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
            System.Uri resourceLocater = new System.Uri("/Mieszkania;component/dodawanie/dodajlokatora.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Dodawanie\DodajLokatora.xaml"
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
            this.txt_imie = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txt_naz = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_tel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btn_dodaj = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Dodawanie\DodajLokatora.xaml"
            this.btn_dodaj.Click += new System.Windows.RoutedEventHandler(this.btn_dodaj_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txt_pesel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txt_adresk = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txt_mail = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

