   M S B A M L   `   `   `  ����  WpfApplication6     WpfApplication6.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  MyNotifiactions��5   	   $	��120��6!   $	��300��6.    � ShowActivated .   � AllowsTransparency .  � WindowStyle$
 None=�6l    � ShowInTaskbar .  
������  � Topmost .  � UseLayoutRounding .  � 	Resources 5       �� MergedDictionaries	 �� Source�� 5	   
    5
      �� 5      $ 	 Resources/ButtonStyle.xaml?�6%   %    5      .��5   
   � -   5        
 �Name$
 NotificationWindow��5      .+�5   
   �� -   5        $��border��5      ���#2a3345$��2q�64    �� CornerRadius$ 10��6H   $��10q�6Z   
���   � J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 0Q�6#      Opacity$	 0.8Q�63      
BlurRadius$ 10Q�6A   ._�5      � $��50��6   $	��230��6    � RowDefinitions 5      �� 5      $
��Auto �6$   64   �� 5      $��* �6$   61    � ColumnDefinitions 5      �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   .+�5      �� $��0��6   $��1��6)   $��bla bla��69   
�������6I   �� 5!      $��1��6   $��1��6)   $$��This is the URL to the one bug��69   &   System.Windows.Media.TextOptions   TextRenderingMode$ 	ClearType=�6`      TextFormattingMode$ Display=�6�   $��Arial)�5"   $   $��Center=�67   $��2,2,4,4q�6S   $
��Wrap=�6d   $��CharacterEllipsis=�6x   
�������6�   �� 5#      -   5         ��Name$ CloseButton��5#      $��1��6.   $��16��6>   $��16��6I   $��0q�6V   $��Right=�6j   $��0,0,6,0q�6�      CloseButton#��[  6�   5%      5&      5'       � Triggers 5(   
   :� 5)       :� RoutedEvent$ Window.Loaded��6    :� 
SourceName$ NotificationWindow��69   .[�5*      �� -   5         ��Name$ FadeInStoryBoard��5*   "   .��5+      �� .��5,      W�  �� 
TargetName$ NotificationWindow��6*    W� From$
 0.01X�6U   	 W� To$ 1X�6a    �� TargetProperty$ Opacity�6h    g� Duration$ 0:0:2D�6�   W� 5-      $ NotificationWindow��6*   $ 1X�6U   $ 0X�6^   $ Opacity�6e   $ 0:0:2D�6�    g� 	BeginTime$ 0:0:6X�6�   5.      5/      50      :� 51      $ Grid.MouseEnter��6   $ NotificationWindow��69   [�52      �� 53       �� Offset$ 0:0:3h�6%     �� BeginStoryboardName$  FadeInStoryBoard��64   ?� 54      $  FadeInStoryBoard��6&   58      :� 59      $ Grid.MouseLeave��6   $ NotificationWindow��69   [�5:      �� 5;      $ 0:0:3h�6%   $  FadeInStoryBoard��64   �� 5<      $  FadeInStoryBoard��6'   6P   5>      :� 5?      $ Button.Click��6   $ CloseButton��66   .[�5@      �� .��5A      �� .��5B      W� $ NotificationWindow��6*   $ 1X�6U   $ 0X�6^   $ (Grid.Opacity)�6e   $ 0:0:0D�6�   5C      5D      5E      5H      5K      