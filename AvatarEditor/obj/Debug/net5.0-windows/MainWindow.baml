   M S B A M L   `   `   `  ����G  CAvatarEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AvatarEditorAvatarEditor  5   	       AvatarEditor.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:AvatarEditor     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��550��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5        $��
Load Image��5      6*   �� 5      -   5        $��
Save Image��5      6*   5      � 5   
   $��1��6   .+�5      &    AvatarEditor.AvatarEditorControl  -   5          Name$ avatarEditor1��5   (   $��0��6?   5      5      5      