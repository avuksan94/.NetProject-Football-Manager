   M S B A M L   `   `   `  ����  FootballManagerWPFApp(    "FootballManagerWPFApp.View.RepInfo   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  RepInfo��5   	   $	��500��5   	   $
��1000��5	   	   $	��428��5
   	   $	��200��5   	    � WindowStyle$
 none=�5   	    � AllowsTransparency$
 True��5   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#2C3E50���#34495E � Triggers 5      :� 5   
    :� RoutedEvent$ Loaded��6   .[�5      �� .��5      ��  g� Duration$ 0:0:2D�6    �� TargetProperty$ Opacity�6.   .��5      W�  W� From 06&   		 W� To	 16/   5      5      5      .��5      � -   5        
 �Name$
 RepInfoWindow��5      .+�5   
   �� -   5        $��	lbCountry��5      $��0��5      $��0��5      $��REP INFO��5      $��Center=�5       $��0,0,0,0q�5!      $	��Top=�5"      $��24(�5#      
�������5$      �� 5%   
   -   5        $��RepresentationGrid��5%      $��40,40,40,380q�5&      $��Center=�5'      $��Center=�67   ��5(      �� 5)       �� 
TargetType" ��6   .�5*      ��  �� Property � �� �� Value$ Center=�6C   �� 5+       � ��$ Center=�6A   5,       �� View 5.      �� 50      -   5        gridViewDisplayRepInfo��.P�51      �� $��Country��6%    �� Width$	 100��6_    �� DisplayMemberBinding 66   �� *	Country+6_   �� 52      $��FifaCode��6%   $	 100��6a    67   �� *
FifaCode+6a   �� 53      $��Games Played��6%   $	 100��6h    6;   �� *GamesPlayed+6h   �� 54      $
��Wins��6%   $	 100��6Y    63   �� *Wins+6Y   �� 55      $��Losses��6%   $	 100��6]    65   �� *Losses+6]   �� 56      $��Draws��6%   $	 100��6[    64   �� *Draws+6[   �� 57      $��	Goals For��6%   $	 100��6b    68   �� *
GoalsFor+6b   �� 58      $��Goals Against��6%   $	 100��6j    6<   �� *GoalsAgainst+6j   �� 59      $��Goal Differential��6%   $	 100��6r    6@   �� *GoalDifferential+6r   5:      5<      �� 5>   
   -   5         ��Name$ btnExit��5>      $
��Exit��5?      $��Stretch=�5@      $��0,0,0,0q�5A      $��Stretch=�5B      $��50��5C      $	��120��5D      $��24(�5E      6   5F      5G      