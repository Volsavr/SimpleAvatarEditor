#pragma checksum "..\..\..\AvatarEditorControl2.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6146E1F5A118E743B9FD3D44C2BD21F1AF3C434A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AvatarEditor;
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


namespace AvatarEditor {
    
    
    /// <summary>
    /// AvatarEditorControl2
    /// </summary>
    public partial class AvatarEditorControl2 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\AvatarEditorControl2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrollViewer;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\AvatarEditorControl2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\AvatarEditorControl2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.MatrixTransform matrixTransform;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\AvatarEditorControl2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/AvatarEditor;component/avatareditorcontrol2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AvatarEditorControl2.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.scrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 14 "..\..\..\AvatarEditorControl2.xaml"
            this.scrollViewer.ScrollChanged += new System.Windows.Controls.ScrollChangedEventHandler(this.scrollViewer_ScrollChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.image = ((System.Windows.Controls.Image)(target));
            
            #line 16 "..\..\..\AvatarEditorControl2.xaml"
            this.image.ManipulationStarting += new System.EventHandler<System.Windows.Input.ManipulationStartingEventArgs>(this.Image_ManipulationStarting);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\AvatarEditorControl2.xaml"
            this.image.ManipulationDelta += new System.EventHandler<System.Windows.Input.ManipulationDeltaEventArgs>(this.Image_ManipulationDelta);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\AvatarEditorControl2.xaml"
            this.image.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseDown);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\AvatarEditorControl2.xaml"
            this.image.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseUp);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\AvatarEditorControl2.xaml"
            this.image.MouseMove += new System.Windows.Input.MouseEventHandler(this.Image_MouseMove);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\AvatarEditorControl2.xaml"
            this.image.MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.Image_MouseWheel);
            
            #line default
            #line hidden
            return;
            case 3:
            this.matrixTransform = ((System.Windows.Media.MatrixTransform)(target));
            return;
            case 4:
            this.slider = ((System.Windows.Controls.Slider)(target));
            
            #line 42 "..\..\..\AvatarEditorControl2.xaml"
            this.slider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Slider_ValueChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

