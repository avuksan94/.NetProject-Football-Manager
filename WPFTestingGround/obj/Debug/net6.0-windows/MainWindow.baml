   M S B A M L   `   `   `  ����P  LFootballManagerWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPFTestingGroundWPFTestingGround  5   	   !    WPFTestingGround.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WPFTestingGround     5   	   -   5          � Title$,  &Welcome to the FootballManager WPF App��5   	   $
��1600��5
   	   $	��800��5   	   $	��428��5   	   $	��200��5   	    � WindowStyle$
 none=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	   ���#2C3E50���#34495E.��5      � -   5         �Name$ MainWindow1��5       � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5       6!   �� 5!      6!   .+�5$   
   �� -   5         ��Name$ btnExit��5$      $��2��5%      $��0��5&      $
��Exit��5'      $��Stretch=�5(      $��0,0,0,0q�5)      $��Stretch=�5*      $��50��5+      $	��120��5,      $��24(�5-      6   �� 5/   
   -   5        $��lbChooseResolution��51      $��1��5/      $��1��50      $��Choose your resolution��52      $��Center=�53      $��0,0,0,0q�54      $��Stretch=�55      $��24(�56      
�������57      �� 59   
   -   5        $��cbChooseResolution��5;      $��1��59      $��1��5:      $��Stretch=�5<      $��0,40,0,0q�5=      $��Stretch=�5>      $	��170��5?      $��50��5@      $��24(�5A      .@�5B      �� $��1366x768��6   �� 5C      $��1600x800��6   �� 5D      $��	1920x1080��6   5E      �� 5G   
   -   5        $��lbChooseLanguage��5K      $��1��5H      $��Choose you language��5I      $��Center=�5J      $��0,0,0,0q�5L      $��2��5M      $��Stretch=�5N      $��24(�5O      
�������5P      �� 5R   
   -   5        $��cbChooseLanguage��5T      $��1��5R      $��Stretch=�5S      $��0,40,0,0q�5U      $��2��5V      $��Stretch=�5W      $	��170��5X      $��50��5Y      $��24(�5Z      .@�5[      �� $	��ENG��6   �� 5\      $	��HRV��6   5]      �� 5_   
   -   5        $��lbChooseRepMF��5b      $��1��5_      $��Choose MF representation��5`      $��Center=�5a      $��0,0,0,0q�5c      $��3��5d      $��Stretch=�5e      $��24(�5f      
�������5g      �� 5i   
   -	   5        $��
cbChooseMF��5k      $��1��5i      $��Stretch=�5j      $��0,40,0,0q�5l      $��3��5m      $��Stretch=�5n      $	��170��5o      $��50��5p      $��24(�5q      .@�5r      �� $
��Male��6   �� 5s      $��Female��6   5t      �� 5v   
   -
   5        $��btnFavorites��5x      $��	Favorites��5w      $��0��5y      $
��Left=�5z      $��10,0,0,0q�5{      $��1��5|      $��Stretch=�5}      $	��300��5~      $��70��5      $��26(�5�      6   5�      5�      