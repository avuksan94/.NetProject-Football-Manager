   M S B A M L   `   `   `  ����P  LFootballManagerWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FootballManagerWPFApp.ViewFootballManagerWPFApp.View  5   	   c6clr-namespace:FootballManagerWPFApp.CustomUserControls(FootballManagerWPFApp.CustomUserControls  6@   .    (FootballManagerWPFApp.View.WPF_Favorites   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:FootballManagerWPFApp.View     5   	   Ucustomusercontrols6clr-namespace:FootballManagerWPFApp.CustomUserControls     6@   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  WPF_Favorites��5	   	   $
��1600��5
   	   $	��800��5   	   $	��428��5   	   $	��200��5   	    � WindowStyle$
 none=�5   	    � AllowsTransparency$
 True��5   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#2C3E50���#34495E.��5      � -   5         �Name$ 
WindowFavs��5       � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $	��29* �6   6+   �� 5      $
��171* �6   6,   .+�5   
   � -   5        $��gridSoccerField��5   ,   $��1��6   $��1��6    5       �� 5!      $��* �6    �� 5"      $��* �6    �� 5#      $��* �6    �� 5$      $��* �6    �� 5%      $��* �6    �� 5&      $��* �6    �� 5'      $��* �6    �� 5(      $��* �6     5+      �� 5,      $��* �6#   �� 5-      $��* �6#   �� 5.      $��* �6#   �� 5/      $��* �6#   �� 50      $��* �6#   �� 51      $��* �6#   �� 52      $��* �6#   56      �� 58   
   -   5        $��cbChooseRep��5;       �� MaxDropDownHeight$	 200��58      $��0��59      $
��Left=�5:       �� Text$ Choose representation��5<      $��	40,40,0,0q�5=      $��0��5>      $��Stretch=�5?      $	��170��5@      $��30��5A      $��15(�5B      	 �� DisplayMemberPath$	 Country��5C      5E      �� 5G   
   -   5        $��lbDisplayScore��5I      $��0��5G      $��0��5H      $��Selected Match Score:��5J      $��Center=�5K      $��0,0,0,0q�5L      $��Center=�5M      $��24(�5N      
�������5O      �� 5Q   
   -   5        $��lbScore��5S      $��0��5R      $�� ��5T      $��Center=�5U      $��0,74,0,0q�5V      $	��Top=�5W      $��24(�5X      
�������5Y      �� 5[   
   -   5        
 ��Name$
 btnClose��5[      $��1��5\      $��0��5]      $��Close��5^      $��Right=�5_      $��0,0,20,0q�5`      $��Stretch=�5a      $��50��5b      $	��120��5c      $��24(�5d      6   �� 5f   
   -   5        $
 btnSettings��5f      $��1��5g      $��0��5h      $��Settings��5i      $
��Left=�5j      $��0,0,20,0q�5k      $��Stretch=�5l      $��50��5m      $	��120��5n      $��24(�5o      6   �� 5q   
   -	   5        $��RepresentationGrid��5q      $��1��5r      $��40,40,140,40q�5s      $��Center=�5u      $��Center=�67    �� View 5v      �� 5w      -
   5        gridViewAllPlayers��.P�5x      �� $��	Code Home��6%    �� Width$
 auto��6g    �� DisplayMemberBinding 68   �� *HomeTeam.Code+6g   �� 5y      $��	Code Away��6%   $
 auto��6g    68   �� *AwayTeam.Code+6g   �� 5z      $��	Home Team��6%   $
 auto��6i    68   �� *HomeTeamCountry+6i   �� 5{      $��	Away team��6%   $
 auto��6i    68   �� *AwayTeamCountry+6i   �� 5|      $��Display��6%   $
 auto��66    �� CellTemplate 5}      �� 5~      .R�5   "   �� $��Display Info��6)   ��5�   )   �� *(&DataContext.VMMatch.OpenRepInfoCommand+ �� RelativeSource ��  �� AncestorType" ���5�   )   ��  �� " � �� Path$ CustomResults�5�   #   5�      5�      5�      5�      %  Xceed.Wpf.Toolkit.BusyIndicator  5�   
   -   5        $��biLoadingFavs��5�         BusyContent$ Updating content...��5�      5�      5�      5�      