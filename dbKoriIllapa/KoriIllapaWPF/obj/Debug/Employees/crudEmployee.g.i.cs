﻿#pragma checksum "..\..\..\Employees\crudEmployee.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4F34BE15DD14B758A6ECB20CB0598CD2478EA929305387089BD140947F695BF5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using KoriIllapaWPF.Employee;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace KoriIllapaWPF.Employee {
    
    
    /// <summary>
    /// crudEmployee
    /// </summary>
    public partial class crudEmployee : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\Employees\crudEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stpClose;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Employees\crudEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAgregar;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Employees\crudEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificar;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Employees\crudEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridOptionEmployee;
        
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
            System.Uri resourceLocater = new System.Uri("/KoriIllapaWPF;component/employees/crudemployee.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Employees\crudEmployee.xaml"
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
            this.stpClose = ((System.Windows.Controls.StackPanel)(target));
            
            #line 32 "..\..\..\Employees\crudEmployee.xaml"
            this.stpClose.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.stpClose_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnAgregar = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\Employees\crudEmployee.xaml"
            this.btnAgregar.Click += new System.Windows.RoutedEventHandler(this.btnAgregar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnModificar = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\Employees\crudEmployee.xaml"
            this.btnModificar.Click += new System.Windows.RoutedEventHandler(this.btnModificar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.gridOptionEmployee = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

