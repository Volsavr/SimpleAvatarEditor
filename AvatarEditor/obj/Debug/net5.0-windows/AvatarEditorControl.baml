   M S B A M L   `   `   `  ����G  CAvatarEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AvatarEditorAvatarEditor  5      =#clr-namespace:AvatarEditor.TriggersAvatarEditor.Triggers  5      &     AvatarEditor.AvatarEditorControl   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:AvatarEditor     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      2triggers#clr-namespace:AvatarEditor.Triggers  5      .��5      � $	��500��6   $	��450��6   
�������  � RowDefinitions  5   
   �� 5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   $��15q�6   .+�5      �� -   5         ��Name$ scrollViewer��5      $��Hidden=�5      $��Hidden=�6B   .��5      �� -   5         ��Name$ image��5      $���|https://upload.wikimedia.org/wikipedia/commons/thumb/a/a1/Johnrogershousemay2020.webp/1200px-Johnrogershousemay2020.webp.png��6'   $
��None=�6�    J� IsManipulationEnabled$
 True��5       � LayoutTransform 5      V� 5      .~�5      u� -   5        matrixTransform��5   .   5      5      5      (� 5       $��Stretch=�6   $��Stretch=�65    (� Stretch$
 Fill=�6Q   .��5!      F� ���#E4E4E4 J� Opacity$	 .67Q�6&   ����� 3�    � 3� 3��     3��        � 3�    ��
 z Ӱ-" z  z �-" z ���
� z �G��-"@cG���
@cGӐG�@cG@cG�G�@cG���
S@cG��Mb�U@�G� z ���
 z 	64   5"      5#      � 5%   
   $��1��6    � ColumnDefinitions 5&      �� 5'      �� 5(      $
��auto �6#   �� 5)      $
��auto �6#   �� 5*      $
��auto �6#   �� 5+      .+�5.      �� $��1��6   $��
15,0,15,15q�6%   
�������*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5/      ,  &AvatarEditor.Triggers.TapActionTrigger  50      *  $Microsoft.Xaml.Behaviors.TriggerBase	   Actions	 51      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  52      
   Command
 64   �� *ScaleDownCommand+54      /   )AvatarEditor.Triggers.InputBindingTrigger  55         InputBinding 56      �� 57      
 �� Key$ Enter��6)    �� Command 65   �� *ScaleDownCommand+59      ._�5<      F� ���#ffffff$��16��6&   $��16��61   �����@T� ��j ���� ��j � N� ��j  $� ��q  $�  z � $� @~�  N� @T� ��� @T� �@B @T� �x�&1��?@T� @~�  z �    ��q  � ��j ��j ���j ��j �@T� ��j 	6=   5=      �� 5?      -   5         ��Name$ slider��5?      $��2��6%    � Maximum$ 20Q�65    � Minimum$ 1Q�6B    �� TickFrequency$ 1Q�6N    � Value$ 1Q�6`   $��Center=�5@   4   $	��200��6Q   $��
10,0,10,15q�6]   �� 5B      $��3��6   $��
15,0,15,15q�6%   
������ 5C        5D      	 5E        5F      
 64   �� *ScaleUpCommand+5H        5I       5J      �� 5K      $ Enter��6)    65   �� *ScaleUpCommand+5M      ._�5P      F� ���#ffffff$��16��6'   $��16��62   ����� z     �@~�     @T�  � @T� �@T� ��j ���� ��j � N� ��j  $� ��q  $�  z � $� @~�  N� @T� ��� @T� �@T� @T� �@T� ��� �@T�  N� @~�  $�  z  $� ���q  $� ��j  N� ��j ��� ���j @T� �@B @T� �x�&1��?@T� @~�  z �    ��q  � ��j ��j ���j ��j ���j @B S��j x�&1��?��q  z 	6>   5Q      5R      �� 5T   
   $��2��6   
�������$��1��6-   � 5V   
   $��3��6   $��Bottom=�6   $��Stretch=�67   $��10,10,10,10q�5W       5X      �� 5Y      �� 5Z      .+�5]      �� $��1��6   $��Right=�5_      $
��Save��5`      ��5^      �� *SaveCommand+5`      5a      5b      5c      