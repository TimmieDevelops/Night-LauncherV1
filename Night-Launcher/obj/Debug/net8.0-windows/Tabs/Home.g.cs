﻿#pragma checksum "..\..\..\..\Tabs\Home.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3161C653E9A95CC29F6DAFC615FD265BB6B3EFA4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Night_Launcher.Tabs;
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
using Wpf.Ui;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Navigation;
using Wpf.Ui.Converters;
using Wpf.Ui.Markup;
using Wpf.Ui.ValidationRules;


namespace Night_Launcher.Tabs {
    
    
    /// <summary>
    /// Home
    /// </summary>
    public partial class Home : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Tabs\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image BackgroundImage;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\Tabs\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TimerLabel;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\Tabs\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBuildButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Tabs\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.Card BuildFrame;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Tabs\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.TextBox VersionName;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Tabs\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf.Ui.Controls.TextBox FortnitePath;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Tabs\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer ScrollerViewer;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Tabs\Home.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel BuildPanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Night-Launcher;component/tabs/home.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Tabs\Home.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BackgroundImage = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.TimerLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.AddBuildButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\Tabs\Home.xaml"
            this.AddBuildButton.Click += new System.Windows.RoutedEventHandler(this.AddBuild1_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BuildFrame = ((Wpf.Ui.Controls.Card)(target));
            return;
            case 5:
            
            #line 17 "..\..\..\..\Tabs\Home.xaml"
            ((Wpf.Ui.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddBuild_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.VersionName = ((Wpf.Ui.Controls.TextBox)(target));
            return;
            case 7:
            this.FortnitePath = ((Wpf.Ui.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 20 "..\..\..\..\Tabs\Home.xaml"
            ((Wpf.Ui.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddPath_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 21 "..\..\..\..\Tabs\Home.xaml"
            ((Wpf.Ui.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitBuild_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ScrollerViewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 11:
            this.BuildPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
