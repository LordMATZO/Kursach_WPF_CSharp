   M S B A M L   `   `   `  ����E  AKURSACH_22, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KURSACH_22
KURSACH_22  5   	       KURSACH_22.DriverChill   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   $localclr-namespace:KURSACH_22  5   	     � Title$  Взятие заказа��5	   	   $	��450��6   $	��800��6,    � Icon$. (pack://application:,,,/Resources/All.ico��69    � 	Resources 5
       �� 
TargetType   
btTemplate �� CornerRadius  btTemplate1 �� 
TargetType �� Property �� Value��%O  &	        &	 �     '�� �    '��     '�� �    �� 5   
   " ��6   .R�5      �� $ 10��6   
���   �$��2q�6;   
�������._�5      �� $��5q�6!   $��Center=�6,   $��Center=�6I   $��Обновить��6e   5      5      �� 5   
   " ��6   .R�5      �� $ 10��6   
���   �$��2q�6;   
�������._�5      �� $��5q�6!   $��Center=�6,   $��Center=�6I   $��Взять заказ��6e   5      5      �� 5   
   " ��6   .�5      ��  � ��$ FRANKLIN GOTHIC MEDIUM)�6+   �� 5       � ��
 �   �6+   5      �� 5   
   " ��6   .�5      ��  � ��$ FRANKLIN GOTHIC MEDIUM)�6+   �� 5       � ��
 �����6+   5      �� 5   
   " ��6   .�5       ��  � ��$ FRANKLIN GOTHIC MEDIUM)�6+   �� 5!       � ��$ 14(�6)   5"      5#      ��5$      �� 5%   
    �� ImageSource$O IC:\\Users\\Alex\\source\\repos\\KURSACH_22\\Resources\\BackgroundAuth.jpg��6   .��5'      � 	 � RowDefinitions	 5(   
   �� 5)      $
��Auto �6   6,   �� 5*      6   �� 5+      6   �� 5,      $��70 �6   6*   
 � ColumnDefinitions
 5.   
   �� 5/      6!   �� 50      6!   .+�52   
   �� $��0��6   $��FRANKLIN GOTHIC MEDIUM)�6"   
�������$��1��6Z    �� TextAlignment$ Center=�6j   $��Center=�6�   $��Center=�6�   $��30(�6�   $4��.Список доступных заказов��6�    J� Effect 53      3  -System.Windows.Media.Effects.DropShadowEffect  54         
BlurRadius$ 10Q�6#      Color$ Black��63   56      �� 57   
   -   5         ��Name$ taskers��57   �    J� Opacity$	 0.4Q�62   $	��350��6@   $��4��6M   
�������
���   �$��1��6�   $��10.2,34,9.6,36q�6�   $��Visible=�6�   $��Visible=�6�   ��58      �� 59      .R�5:      ��  �� Orientation$ 
Horizontal=�6"   .+�5;      ��  ��Name$ goodID��6I   $��0 0 10 0q�6$   
���������6Y   �� *tskID+6r   �� 5<      $ goodNAME��67   
���������6I   �� *	wareHID+6d   5=      5>      5@      �� 5A   
   $��0��6   $��FRANKLIN GOTHIC MEDIUM)�6"   
�������$��0��6Z   $ Center=�6j   $��Center=�6�   $��Center=�6�   $��30(�6�   $,��&Должность: первозчик��6�    5B        5C      $ 10Q�6#   $ Black��63   5E      � 5F   
   $��0��6   $��1��6   	 5G      �� 5H      $��20 �6    6.   �� 5I      $
��Auto �6    60   �� 5J      6"   
 5L      �� 5M      $
��Auto �6#   62   �� 5N      6%   .+�5P      �� $��1��6   $��FRANKLIN GOTHIC MEDIUM)�6&   
�������$��0��6^   $ Center=�6n   $��Center=�6�   $��Center=�6�   $��22(�6�   $H��BВыберите заказ который хотите взять��6�   $��2��6�   $��17,5,9.8,107.6q�6
  $��2��6"   5Q        5R      $ 10Q�6'   $ Black��67   5T      �� 5U      -   5        $��2��5U      #��[ 6"   $��20(�6J   $��2��6X   $	��200��6l   $��40��6x   6�   5V      5W      5X      