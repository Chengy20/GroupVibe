﻿#pragma checksum "..\..\Group_Details.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B8ECFE68BE58CD038E0BE6996AB476E1FEED8792"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GroupGrindr;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace GroupGrindr {
    
    
    /// <summary>
    /// Group_Details
    /// </summary>
    public partial class Group_Details : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\Group_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle MenuBar;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Group_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Details;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Group_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Tasks;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Group_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Members;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Group_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Files;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Group_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Menu;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Group_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ProfileIcon;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Group_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Profile;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Group_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Logo;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Group_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Group_Name_Text;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Group_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Group_ID_Text;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\Group_Details.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Group_Description_Text;
        
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
            System.Uri resourceLocater = new System.Uri("/GroupGrindr;component/group_details.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Group_Details.xaml"
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
            this.MenuBar = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 2:
            this.Details = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\Group_Details.xaml"
            this.Details.Click += new System.Windows.RoutedEventHandler(this.Details_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Tasks = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\Group_Details.xaml"
            this.Tasks.Click += new System.Windows.RoutedEventHandler(this.Tasks_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Members = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\Group_Details.xaml"
            this.Members.Click += new System.Windows.RoutedEventHandler(this.Members_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Files = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Group_Details.xaml"
            this.Files.Click += new System.Windows.RoutedEventHandler(this.Files_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Menu = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\Group_Details.xaml"
            this.Menu.Click += new System.Windows.RoutedEventHandler(this.Menu_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ProfileIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.Profile = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Group_Details.xaml"
            this.Profile.Click += new System.Windows.RoutedEventHandler(this.Profile_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Logo = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.Group_Name_Text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.Group_ID_Text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.Group_Description_Text = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
