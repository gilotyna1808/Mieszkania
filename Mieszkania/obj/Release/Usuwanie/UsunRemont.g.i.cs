﻿#pragma checksum "..\..\..\Usuwanie\UsunRemont.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AD7236D82F75EB66E504DC921D31273014697E027BE4F413615FE6680A1FF272"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Mieszkania;
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


namespace Mieszkania {
    
    
    /// <summary>
    /// UsunRemont
    /// </summary>
    public partial class UsunRemont : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\Usuwanie\UsunRemont.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_id;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Usuwanie\UsunRemont.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_idM;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Usuwanie\UsunRemont.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_stan;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Usuwanie\UsunRemont.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_koszt;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Usuwanie\UsunRemont.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txt_data_p;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Usuwanie\UsunRemont.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txt_data_k;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Usuwanie\UsunRemont.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Wybierz;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Usuwanie\UsunRemont.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Mieszkania;component/usuwanie/usunremont.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Usuwanie\UsunRemont.xaml"
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
            this.txt_idM = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txt_stan = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txt_koszt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txt_data_p = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.txt_data_k = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.btn_Wybierz = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Usuwanie\UsunRemont.xaml"
            this.btn_Wybierz.Click += new System.Windows.RoutedEventHandler(this.btn_Wybierz_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_Usun = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Usuwanie\UsunRemont.xaml"
            this.btn_Usun.Click += new System.Windows.RoutedEventHandler(this.btn_Usun_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

