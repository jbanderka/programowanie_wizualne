﻿#pragma checksum "..\..\..\EngineWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76635EA02E49F37504EA81D0EEE0370AAF1F5383"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
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
using lab2;


namespace lab2 {
    
    
    /// <summary>
    /// EngineWindow
    /// </summary>
    public partial class EngineWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\EngineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton petrol;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\EngineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton diesel;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\EngineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton gas;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\EngineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton hybrid;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\EngineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\EngineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox power;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\EngineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem power1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\EngineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem power2;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\EngineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem power3;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\EngineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem power4;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\EngineWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label price;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/lab2;component/enginewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EngineWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.petrol = ((System.Windows.Controls.RadioButton)(target));
            
            #line 11 "..\..\..\EngineWindow.xaml"
            this.petrol.Checked += new System.Windows.RoutedEventHandler(this.petrol_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.diesel = ((System.Windows.Controls.RadioButton)(target));
            
            #line 12 "..\..\..\EngineWindow.xaml"
            this.diesel.Checked += new System.Windows.RoutedEventHandler(this.diesel_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.gas = ((System.Windows.Controls.RadioButton)(target));
            
            #line 13 "..\..\..\EngineWindow.xaml"
            this.gas.Checked += new System.Windows.RoutedEventHandler(this.gas_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.hybrid = ((System.Windows.Controls.RadioButton)(target));
            
            #line 14 "..\..\..\EngineWindow.xaml"
            this.hybrid.Checked += new System.Windows.RoutedEventHandler(this.hybrid_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.back = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\EngineWindow.xaml"
            this.back.Click += new System.Windows.RoutedEventHandler(this.back_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.power = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\..\EngineWindow.xaml"
            this.power.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.power_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.power1 = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 8:
            this.power2 = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 9:
            this.power3 = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 10:
            this.power4 = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 11:
            this.price = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
