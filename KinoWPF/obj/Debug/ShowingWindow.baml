   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   #    WpfApplication1.ShowingWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$  ShowingWindow��5   	   $	��350��6   $	��310��6,   .��5	      � $��10q�6   .+�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   .+�5      �� -   5         ��Name$ label��5   %   $��0��6   $��Imię:��64   �� 5      -   5         ��Name$ TBShowingName��5   '   $��1��6   $��21��6>    �� TextWrapping$
 Wrap=�6J   $��Maciej��6^   �� 5      -   5        $ label1��5   %   $��2��6   $��	Nazwisko:��65   �� 5      -   5        $ TBShowingSurname��5   '   $��3��6   $��21��6A   $
 Wrap=�6M   $��Owerczuk��6a   �� 5       -   5        $ label4��5    %   $��4��6   $��Rodzaj operacji:��65   �� 5!      $��5q�6   $��5��6$    �� Orientation$ 
Horizontal=�61   .+�5"      	� -   5         	�Name$ EnabledRadioButton��5"   3   $��0, 0, 20, 0q�6   $��	Sprzedaż��6O    	� 	GroupName$ Enabler��6b    d� 	IsChecked$
 TrueY�6v   	� 5#      -   5        $ DisabledRadioButton��5#      $��
Rezerwacja��6;   $ Enabler��6P   5$      �� 5&      -   5        $ label2��5&   %   $��6��6   $��Rodzaj biletu:��65   �� 5'      $��5q�6   $��7��6$   $ 
Horizontal=�61   {�6J   �� 	 �� ElementName$	 EnabledRadioButton��
 �� Path$
 	IsChecked�.+�5(      	� -	   5        $��RBTicketZwykly��5(   3   $��0, 0, 20, 0q�6   $��Zwykły��6I   	� 5)      -
   5        $��RBTicketUlgowy��5)      $��Ulgowy��64   5*      �� 5,      -   5        $ label3��5,   !   $��8��6   $��Miejsce:��61   �� 5-      -   5        $ textBox��5-   #   $��9��6   $��23��64   $
��auto��6@   $
 Wrap=�6M   $��5F��6a   �� 5.      $��10��6   $ 
Horizontal=�6'   $
��auto��6@   $��0, 10, 0, 0q�6N   .+�5/      �� -   5        $��Cancel��5/   %   $��3q�6   $��Anuluj��63    �� IsCancel . 6V   �� 50      -   5        $��button2��50   9   $��3q�6   $��
3, 0, 0, 0q�6%   $��Lista rezerwacji��6H   6|   �� 51      -   5         ��Name$ button��51   9   $��3q�6   $��
3, 0, 0, 0q�6%   $��Podgląd sali��6I   6`   �� 52      -   5        $ button1��52   9   $��3q�6   $��
3, 0, 0, 0q�6%   $��
Zatwierdź��6J   54      55      56      57      