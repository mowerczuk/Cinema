   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   $    WpfApplication1.ReservedWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$  ReservedWindow��5   	   $	��330��6    $	��450��6-   .��5	      � .+�5      �� .@�5   
   �� $��Reserved��6   .��5      �  � ColumnDefinitions 5      �� 5      $
��auto �6+   6:   �� 5      $
��auto �6+   6:   .+�5      �� -   5         ��Name$ LBXReservedList��5   I   $	��200��6   $��10q�6-   $��0��69   6I   � 5      $��1��6   $
��auto��6+    � RowDefinitions 5      �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5      $
��auto �6,   6<   �� 5       $
��auto �6,   6<   �� 5!      $
��auto �6,   6<   �� 5"      $
��auto �6,   6<   .+�5%      �� -   5         ��Name$ label��5%   -   $��0��6    $��Imię:��6<   �� 5&      -   5         ��Name$ TBShowingName��5&   <   $
��auto��6"   $��1��6/   $��21��6S    �� TextWrapping$
 Wrap=�6_   $��Maciej��6s   �� 5'      -   5        $ label1��5'   -   $��2��6    $��	Nazwisko:��6=   �� 5(      -   5        $ TBShowingSurname��5(   <   $
��auto��6"   $��3��6/   $��21��6V   $
 Wrap=�6b   $��Owerczuk��6v   �� 5*      -   5        $ label2��5*   -   $��6��6    $��Rodzaj biletu:��6=   �� 5+      $��5q�6%   $��7��60    �� Orientation$ 
Horizontal=�6=   {�6V   ��  �� ElementName$ EnabledRadioButton��	 �� Path$	 	IsChecked�.+�5,      	� -   5        $��RBTicketZwykly��5,   ?   $��0, 0, 32, 0q�6*   $��Zwykły��6U   	� 5-      -   5        $��RBTicketUlgowy��5-   *   $��Ulgowy��6@   5.      �� 5/      -	   5        
 ��Name$
 CBPaid��5/   ;   $��5q�6#   $��8��6.   $��
Zapłacono��6K   $
��Left=�6_   $	��Top=�6z   �� 50      -
   5        $ label3��50   -   $��9��6    $��Miejsce:��6=   �� 51      -   5        $ textBox��51   =   $
��auto��6"   $��10��6/   $��23��6N   $
 Wrap=�6Z   $��5F��6n   �� 52      $��11��6%   $ 
Horizontal=�63   $
��auto��6L   $��0, 10, 0, 0q�6Z   $
��auto��6o   .+�53      �� -   5        $��Cancel��53   1   $��3q�6%   $��Anuluj��6?    �� IsCancel . 6b   �� 54      -   5        $��button2��54   E   $��3q�6%   $��
3, 0, 0, 0q�61   $��Usuń��6T   6e   �� 55      -   5         ��Name$ button��55   E   $��3q�6%   $��
3, 0, 0, 0q�61   $��Podgląd sali��6U   6l   �� 56      -   5        $ button1��56   E   $��3q�6%   $��
3, 0, 0, 0q�61   $��
Zatwierdź��6V   58      5:      5;      5<      �� 5=   
   $��Nothing��6   5?      5@      5A      5B      