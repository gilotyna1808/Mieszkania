﻿#pragma checksum "..\..\..\Wyswietlanie\WyswietlMieszkania.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C281FE233CF643291233BE681BA75D6CE1387BC405DB74AD59E91A6476D25CA1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Mieszkania.Wyswietlanie;
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


namespace Mieszkania.Wyswietlanie {
    
    
    /// <summary>
    /// WyswietlMieszkania
    /// </summary>
    public partial class WyswietlMieszkania : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Wyswietlanie\WyswietlMieszkania.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataG;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Wyswietlanie\WyswietlMieszkania.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_W;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Wyswietlanie\WyswietlMieszkania.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_M;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Wyswietlanie\WyswietlMieszkania.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_kod;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Wyswietlanie\WyswietlMieszkania.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_ul;
        
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
            System.Uri resourceLocater = new System.Uri("/Mieszkania;component/wyswietlanie/wyswietlmieszkania.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Wyswietlanie\WyswietlMieszkania.xaml"
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
            this.dataG = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btn_W = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\Wyswietlanie\WyswietlMieszkania.xaml"
            this.btn_W.Click += new System.Windows.RoutedEventHandler(this.btn_W_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_M = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\..\Wyswietlanie\WyswietlMieszkania.xaml"
            this.txt_M.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_M_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txt_kod = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\Wyswietlanie\WyswietlMieszkania.xaml"
            this.txt_kod.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_kod_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txt_ul = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\Wyswietlanie\WyswietlMieszkania.xaml"
            this.txt_ul.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_ul_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

