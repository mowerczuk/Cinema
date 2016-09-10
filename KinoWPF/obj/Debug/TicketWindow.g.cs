﻿#pragma checksum "..\..\TicketWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2DB795385A182DFF57ADA04A4E899637"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KinoWPF;
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


namespace KinoWPF {
    
    
    /// <summary>
    /// TicketWindow
    /// </summary>
    public partial class TicketWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Ticket;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle TicketBackground;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TicketData;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTicketTitle;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTicketDate;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTicketTime;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTicketHall;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTicketSeats;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTicketName;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTicketSurname;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelTicketType;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\TicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas ButtonBackground;
        
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
            System.Uri resourceLocater = new System.Uri("/KinoWPF;component/ticketwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TicketWindow.xaml"
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
            
            #line 8 "..\..\TicketWindow.xaml"
            ((KinoWPF.TicketWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Ticket = ((System.Windows.Controls.Canvas)(target));
            
            #line 32 "..\..\TicketWindow.xaml"
            this.Ticket.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TicketMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TicketBackground = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 4:
            this.TicketData = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.LabelTicketTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.LabelTicketDate = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.LabelTicketTime = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.LabelTicketHall = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.LabelTicketSeats = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.LabelTicketName = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.LabelTicketSurname = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.LabelTicketType = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.ButtonBackground = ((System.Windows.Controls.Canvas)(target));
            return;
            case 14:
            
            #line 125 "..\..\TicketWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseButtonClick);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 126 "..\..\TicketWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PrintButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

