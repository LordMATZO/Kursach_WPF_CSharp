   M S B A M L   `   `   `  ����E  AKURSACH_22, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:KURSACH_22
KURSACH_22  5   	       KURSACH_22.DriverWork   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   $localclr-namespace:KURSACH_22  5   	     � Title$  Доставка��5	   	   $	��450��6   $	��800��6'    � Icon$. (pack://application:,,,/Resources/All.ico��64    � 	Resources 5
       �� 
TargetType   
btTemplate �� CornerRadius  btTemplate2  btTemplate1 �� 
TargetType �� Property �� Value��%�  &	        &	 �     &	 �    '�� b    '�� �    �� 5   
   " ��6   .R�5      �� $ 10��6   
���   �$��2q�6;   
�������._�5      �� $��5q�6!   $��Center=�6,   $��Center=�6I   $��
Отвёз��6e   5      5      �� 5   
   " ��6   .R�5      �� $ 10��6   
���   �$��2q�6;   
�������._�5      �� $��5q�6!   $��Center=�6,   $��Center=�6I   $��Создать отчёт��6e   5      5      �� 5   
   " ��6   .R�5      �� $ 10��6   
���   �$��2q�6;   
�������._�5      �� $��5q�6!   $��Center=�6,   $��Center=�6I   $��Взял груз��6e   5      5      �� 5   
   " ��6   .�5      ��  � ��$ FRANKLIN GOTHIC MEDIUM)�6+   �� 5       � ��
 �����6+   5!      �� 5"   
   " ��6   .�5#      ��  � ��$ FRANKLIN GOTHIC MEDIUM)�6+   �� 5$       � ��$ 14(�6)   �� 5%       � ��
 �   �6+   5&      5'      ��5(      �� 5)   
    �� ImageSource$O IC:\\Users\\Alex\\source\\repos\\KURSACH_22\\Resources\\BackgroundAuth.jpg��6   .��5+      � 	 � RowDefinitions	 5,   
   �� 5-      $��60 �6   6*   �� 5.      $
��Auto �6   6,   �� 5/      6   �� 50      $
��Auto �6   6,   �� 51      $
��Auto �6   6,   �� 52      $��70 �6   6*   
 � ColumnDefinitions
 54   
   �� 55      6!   �� 56      6!   .+�58   
   �� $��0��6   $��FRANKLIN GOTHIC MEDIUM)�6"   
�������$��0��6Z    �� TextAlignment$ Center=�6j   $��Center=�6�   $��Center=�6�   $��25(�6�   $��Заметки��6�    J� Effect 59      3  -System.Windows.Media.Effects.DropShadowEffect  5:         
BlurRadius$ 10Q�6#      Color$ Black��63   5<      �� 5=   
   $
��Auto��6   $
��Auto��6"   $��0��60   $��FRANKLIN GOTHIC MEDIUM)�6=   
�������$��1��6u   $��Center=�6�   $��Center=�6�   $��25(�6�   $'��!Пункты назначения��6�    5>        5?      $ 10Q�6#   $ Black��63   5A      �� 5B   
   -   5         ��Name$ completeBut��5B      $��5��6   $��2��63   #��[ 6G   $	��600��6o   $��60��6{   $��30(�6�   6�   �� 5C   
   -   5        $ takeBut��5C      $��3��6   $��1��6/   #��[ 6C   $��40��6k   $��20(�6w   $	��120��6�   6�   �� 5D   
   -   5         ��Name$ destinations��5D   �    J� Opacity$	 0.4Q�6   $��3��6    
�������
���   �$��1��6W   $��1��6d   $��10q�6u   $��Visible=�6�   $��Visible=�6�   ��5E      �� 5F      .R�5G      ��  �� Orientation$ 
Horizontal=�6"   .+�5H      ��  ��Name$ tb��67   
�������
���   ���6V   �� *shpID+5I      5J      5L      �� 5M   
   -   5         ��Name$ hints��5M      
������� �� TextWrapping$
 Wrap=�64   $��1��6H   $��2��6U   
���   �$	 0.4Q�6y   $��10q�6�   6�   "  Xceed.Wpf.Toolkit.TimePicker  5N   
   -   5          Name$ st��5N   :   $	 0.4Q�6   $��10 0 0 0q�6(   
���   �$��0��6Y   $��4��6i   
�������,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$ Время начала��6�   6�     5O   
   -   5        $ et��5O   :   $	 0.4Q�6   $��10 0 0 0q�6(   
���   �$��1��6Y   $��4��6i   
�������$ Время конца��6�   6�   5P      5Q      