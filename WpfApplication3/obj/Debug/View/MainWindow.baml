   M S B A M L   `   `   `  ����J  FWpfApplication3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication3WpfApplication3  5   	        WpfApplication3.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication3     5   	   -   5          �Name$  mW��5   P    � Title$ 
MainWindow��6	   $	��550��6   $
��1025��6)    � 
ResizeMode$ CanMinimize=�66   
����� �$��2q�6o   .��5	      � -   5         �Name$ gridMain��5	      $��0,0,0,0q�6   
���  ��.+�5
   
   � -   5        $ grdwhole��5
      $��0,0,0,0q�6!   $
��Left=�63   ��5      �� 5       �� ImageSource$3 -/WpfApplication3;component/Sankes_Ladders.jpg��6   6[   5      �� 5   
   -   5         ��Name$ btnRollDice��5   '   $y�Hidden=�6   $��Rolldice��6<   $
��Left=�6O   $��877,479,0,0q�6j   $	��Top=�5      $��75��6)   $��30��6O   �� 5   
   -   5        $ btnDisplayLog��5      $��Display Log��6+   $
��Left=�6A   $��810,479,0,0q�6\   $	��Top=�5      $��67��6)   $��30��6R   �� 5   
   $��Number of Players��6   $��822,98,49,386q�6,   �� 5   
   -   5         ��Name$ txtnop��5   )   $��973,98,15,391q�6   69   �� 5   
   -   5        $ btnSetPlayer��5   '   $��Set Players��6   $��896,133,14,356q�6X   $y�Hidden=�6p   6�   �� 5   
   -   5        $ btnResetGame��5   &   $��
Reset Game��6   $��896,133,14,356q�6X   $y�Hidden=�6p   �� 5   
   -	   5         ��Name$ lblPlayerText��5      $��20(�6(   $
��Bold"�66   $��Label��6I   $
��Left=�6Y   $��42��6t   $��
803,10,0,0q�6�   $	��Top=�6�   $	��204��6�   �� 5   
   $
��Dice��6   $��896,57,65,419q�6    �� 5   
   -
   5        $ lblDice��5      $��20(�6#   $��Black"�62   $��Center=�6E   $��Center=�6b   $��32��6}   $��36��6�   $��0��6�   $��964,52,21,431q�6�   � 5   
   $
��Left=�6   $��822,168,0,0q�6*   $	��Top=�6?   $	��185��6W   
����� �.+�5      �� -   5         ��Name$ stkPnlPlayerList��5      $
��Left=�63   $	��Top=�6O   	 �� Orientation$	 Vertical=�6h   5      &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 dataGridScopre��5      $
��Left=�6,   $��540,168,0,0q�6G   $	��Top=�6\   $	��308��6t   $	��184��6�      AutoGenerateColumns .     Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Player��6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ PlayerNumber�   ClipboardContentBinding 6K   Z� 6n     5"      $ Start��6s    6%   �� $ PlayerStartNumber� 6P   Z� 6s     5#      $
 Dice��6k    6%   �� $ 	DiceNumer� 6H   Z� 6k     5$      $ Target��6o    6%   �� $ TargetNumber� 6K   Z� 6o   5'      5)      5*      